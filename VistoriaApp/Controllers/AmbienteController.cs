using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using VistoriaApp.Data;
using VistoriaApp.Models;
using VistoriaApp.Repository;

namespace VistoriaApp.Controllers
{
    public class AmbienteController : Controller
    {
        private readonly IAmbienteRepositorio _repositorio;
        public AmbienteController(IAmbienteRepositorio repositorio) 
        {
            _repositorio = repositorio;
        }

        public IActionResult Criar(int vistoriaId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(AmbienteModel ambiente)
        {           
            if(ModelState.IsValid)
            {
                _repositorio.Adicionar(ambiente);
                return RedirectToAction("Visualizar", "Vistoria", new {vistoriaId = ambiente.VistoriaId});
            }
            return View(ambiente);
        }

        public IActionResult Excluir(int ambienteId, int vistoId)
        {
            if (_repositorio.IdExiste(ambienteId))
            {
                _repositorio.Excluir(ambienteId);
            }
            return RedirectToAction("Visualizar", "Vistoria", new { vistoriaId = vistoId });
        }
    }
}
