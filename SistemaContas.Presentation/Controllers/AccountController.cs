using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using SistemaContas.Data.Entities;
using SistemaContas.Data.Helpers;
using SistemaContas.Data.Repositories;
using SistemaContas.Presentation.Models.Account;
using SistemaContas.Presentation.Models.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SistemaContas.Presentation.Controllers
{
    public class AccountController : Controller
    {
        //atributo para automapper
        private readonly IMapper? _mapper;

        //construtor para inicializar os atributos da classe
        public AccountController(IMapper? mapper)
        {
            _mapper = mapper;
        }

        //GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        //POST: //Account/Login
        [HttpPost] //metodo para receber o submit(POST) do form
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    //buscar usuário no BD através do email e senha
                    var usuarioRepository = new UsuarioRepository();
                    var usuario = usuarioRepository.Obter
                        (u => u.Email.Equals(model.Email) && u.Senha.Equals(MD5Cryptography.Hash(model.Senha)));


                    //valida se o usuário foi encontrado
                    if(usuario != null)
                    {
                        //validar se usuário está ativo

                        if (usuario.Ativo == 1)
                        {
                            //capturando os dados do usuario q será autenticado
                            var authenticatonModel = _mapper.Map<AuthenticationModel>(usuario);
                            var json = JsonConvert.SerializeObject(authenticatonModel);

                            //preparar os dados para serem gravados no Cookie de autenticação
                            var claimsIdentity = new ClaimsIdentity(
                                new[] { new Claim(ClaimTypes.Name, json) }, CookieAuthenticationDefaults.AuthenticationScheme);

                            //gravando o cookie de autenticacao
                            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                            //redirecionamento para /Home/Index
                            return RedirectToAction("Index", "Home");

                        }
                        else
                        {
                            TempData["MensagemErro"] = "Sua conta foi blqueada. Favor entrar em contato com o Administrador do sistema";
                        }

                    }
                    else 
                    {
                        TempData["MensagemErro"] = "Acesso negado. Usuário não encontrado.";
                    }


                }
                catch (Exception e)
                {

                    TempData["MensagemErro"] = $"Falha ao autenticar o usuário: {e.Message}";
                }
            }

            return View();
        }

        //GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        //POST: /Account/Register
        [HttpPost] //recebe o submmit do form
        public IActionResult Register( RegisterViewModel model)
        {
            //sempre que tiver um post é preciso ter  o ModelState.Isvalid
            if (ModelState.IsValid)
            {
                try
                {
                    #region Verificar se o e-mail já está cadastrado
                    var usuarioRepository = new UsuarioRepository();

                    if (usuarioRepository.Obter(x => x.Email.Equals(model.Email)) != null)
                        ModelState.AddModelError("Email", "O e-mail informado já possui cadastro no sistema!");
                    else
                    {
                        //por automaper
                        var usuario = _mapper.Map<Usuario>(model);

                        //var usuario = new Usuario
                        //{
                        //    IdUsuario = Guid.NewGuid(),
                        //    Nome = model.Nome,
                        //    Email = model.Email,
                        //    Senha = MD5Cryptography.Hash(model.Senha),
                        //    DataCriacao = DateTime.Now,
                        //    Ativo = 1
                        //};
                        usuarioRepository.Adicionar(usuario);

                        ModelState.Clear(); //limpa o formulário

                        TempData["MensagemSucesso"] = $"Conta {usuario.Nome} criada com sucesso!";
                        
                    }

                    
                    #endregion
                }
                catch (Exception ex)
                {

                    TempData["MensagemErro"] = $"Falha ao cadastrar conta: {ex.Message}";
                }
            }
            return View();
        }

        //GET: /Account/PasswordRecover
        public IActionResult PassWordRecover()
        {
            return View();
        }


        //GET: /Account/Logout
        [Authorize]
        public IActionResult Logout()
        {
            //destruir cookie de autenticação
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //redirecionando o usuário para página de login
            return RedirectToAction("Login", "Account");
        }

    }
}
