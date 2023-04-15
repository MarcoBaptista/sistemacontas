using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SistemaContas.Data.Entities;
using SistemaContas.Data.Entities.Enums;
using SistemaContas.Data.Repositories;
using SistemaContas.Presentation.Models.Authentication;
using SistemaContas.Presentation.Models.Categorias;

namespace SistemaContas.Presentation.Controllers
{

    [Authorize]
    public class CategoriasController : Controller
    {
        private readonly IMapper? _mapper;

        public CategoriasController(IMapper? mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Cadastro()
        {
            ViewBag.TiposCategoria = new SelectList(Enum.GetValues(typeof(TipoCategoria)));
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro( CategoriaCadasroViewModel model ) 
        { 

            if (ModelState.IsValid)
            {
                try
                {
                    /* substituido pelo mapper
                    var categoria = new Categoria
                    {
                        IdCategoria = Guid.NewGuid(),
                        Nome = model.Nome,
                        Tipo = model.Tipo,
                        IdUsuario = UsuarioAutenticado.IdUsuario
                    };*/

                    var categoria = _mapper.Map<Categoria>(model);
                    categoria.IdUsuario = UsuarioAutenticado.IdUsuario;

                    var categoriaRepository = new CategoriaRepository();
                    categoriaRepository.Adicionar(categoria);

                    TempData["MensagemSucesso"] = $"Categoria '{categoria.Nome}', cadastrada com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = $"Falha ao cadastrar categoria: {e.Message}";

                }

            }
            ViewBag.TiposCategoria = new SelectList(Enum.GetValues(typeof(TipoCategoria)));
            return View();
        
        }

        public IActionResult Consulta()
        {
            try
            {
                var categoriaRepository = new CategoriaRepository();
                var categorias = categoriaRepository.Obtertodos
                    (c => c.IdUsuario == UsuarioAutenticado.IdUsuario);

                ViewBag.Categorias = categorias;

            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Falha ao consultar categorias:  { e.Message}";
            }

            return View();
        }

        public IActionResult Edicao(Guid id)
        {
            var model = new CategoriaEdicaoViewModel();

            try
            {
                //capturar categoria no banco por id
                var categoriaRepository = new CategoriaRepository();
                var categoria = categoriaRepository.Obter(
                    c => c.IdCategoria == id && c.IdUsuario == UsuarioAutenticado.IdUsuario);

                //verificar se a categ foi encontrada
                if (categoria != null)
                {
                    model.IdCategoria = categoria.IdCategoria;
                    model.Nome = categoria.Nome;
                    model.Tipo = categoria.Tipo;

                }else
                {
                    return RedirectToAction("Consulta");
                };

            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Falha ao obter categoria {e.Message}";
            }
            ViewBag.TiposCategoria = new SelectList(Enum.GetValues(typeof(TipoCategoria)));
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Edicao(CategoriaEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoria = _mapper.Map<Categoria>(model);
                    categoria.IdUsuario = UsuarioAutenticado.IdUsuario;

                    var categoriaRepository = new CategoriaRepository();
                    categoriaRepository.Atualizar(categoria);

                    TempData["MensagemSucesso"] = $"Categoria '{categoria.Nome}', alterada com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = $"Falha ao atualizar categoria: {e.Message}";

                }

            }
            ViewBag.TiposCategoria = new SelectList(Enum.GetValues(typeof(TipoCategoria)));
            return View();
        }

        private AuthenticationModel UsuarioAutenticado
        {
            get
            {
                //capturar o usuario autenticado (Cookie de autenticacao)
                var user = User.Identity.Name;

                //desceralizar o json
                return  JsonConvert.DeserializeObject<AuthenticationModel>(user);
            }
        }

    }
}
