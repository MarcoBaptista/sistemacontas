﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaContas.Presentation.Controllers
{

    [Authorize]
    public class CategoriasController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }

        public IActionResult Edicao()
        {
            return View();
        }

    }
}
