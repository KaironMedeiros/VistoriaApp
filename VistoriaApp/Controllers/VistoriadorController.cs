using Microsoft.AspNetCore.Mvc;
using VistoriaApp.Models;
using VistoriaApp.Repository;

namespace VistoriaApp.Controllers
{
    public class VistoriadorController : Controller
    {
        private readonly IVistoriadorRepositorio _repositorio;

        public VistoriadorController(IVistoriadorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            ICollection<VistoriadorModel> vistoriador = _repositorio.BuscarTodos();
            return View(vistoriador);
        }

        public IActionResult CriarEditar(int? id)
        {
            if (id > 0)
            {
                VistoriadorModel vistoriadorDb = _repositorio.BuscarPorId(id.Value);
                return View(vistoriadorDb);
            }
            return View();
        }

        [HttpPost]
        public IActionResult CriarEditar(VistoriadorModel vistoriador)
        {
            if (ModelState.IsValid)
            {
                if (vistoriador.Id > 0)
                {
                    if (_repositorio.IdExiste(vistoriador.Id))
                    {
                        _repositorio.Atualizar(vistoriador);
                        TempData["mensagem"] = MensagemModel.Serializar("Vistoriador atualizado com sucesso!");
                        return RedirectToAction("Index", "Vistoriador");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Não foi possivel atualizar os dados!", Enums.TipoMensagem.Erro);
                        return RedirectToAction("Index", "Vistoriador");
                    }
                }
                else
                {
                    _repositorio.Adicionar(vistoriador);
                    TempData["mensagem"] = MensagemModel.Serializar("Vistoriador cadastrado com sucesso!");
                    return RedirectToAction("Index", "Vistoriador");
                }


            }
            return View(vistoriador);
        }

        public IActionResult ExcluirConfirmacao(int id)
        {
            if (_repositorio.IdExiste(id))
            {
                VistoriadorModel vistoriadorDb = _repositorio.BuscarPorId(id);
                return View(vistoriadorDb);
            }
            TempData["mensagem"] = MensagemModel.Serializar("Vistoriador não encontrado", Enums.TipoMensagem.Erro);
            return RedirectToAction("Index", "Vistoriador");
        }

        public IActionResult Excluir(int id)
        {
            if (_repositorio.IdExiste(id))
            {
                _repositorio.Excluir(id);
                TempData["mensagem"] = MensagemModel.Serializar("Vistoriador excluido com sucesso!");
                return RedirectToAction("Index", "Vistoriador");
            }
            TempData["mensagem"] = MensagemModel.Serializar("Não foi possivel excluir o vistoriador!", Enums.TipoMensagem.Erro);
            return RedirectToAction("Index", "Vistoriador");
        }









    }
}
