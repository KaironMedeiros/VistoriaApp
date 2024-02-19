using Microsoft.AspNetCore.Mvc;
using VistoriaApp.Data;
using VistoriaApp.Models;
using VistoriaApp.Repository;

namespace VistoriaApp.Controllers
{
    public class VistoriaController : Controller
    {
        private readonly IVistoriaRepositorio _repositorio;
        public VistoriaController(IVistoriaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public IActionResult Index()
        {
            ICollection<VistoriaModel> vistoria = _repositorio.BuscarTodos();
            return View(vistoria);
        }

        public IActionResult CriarEditar(int? imovelId)
        {
            if (imovelId != null)
            {
                VistoriaModel vistoriaDb = _repositorio.BuscarPorIdImovel(imovelId.Value);

                if (vistoriaDb != null)
                {
                    return View(vistoriaDb);
                }
                return View();
            }
            TempData["mensagem"] = MensagemModel.Serializar("Não foi possivel criar uma nova vistoria!", Enums.TipoMensagem.Erro);
            return RedirectToAction("Index", "Imovel");
        }

        [HttpPost]
        public IActionResult CriarEditar(VistoriaModel vistoria)
        {
            if (ModelState.IsValid)
            {
                VistoriadorModel vistoriadorDb = _repositorio.BuscarPorIdVistoriador(vistoria.VistoriadorId);

                if (vistoriadorDb != null)
                {
                    if (vistoria.Id > 0)
                    {
                        _repositorio.Atualizar(vistoria);

                        return RedirectToAction("Visualizar", new { vistoriaId = vistoria.Id });
                    }

                    _repositorio.Adicionar(vistoria);
                    return RedirectToAction("Visualizar", new { vistoriaId = vistoria.Id });
                }
                ModelState.AddModelError("VistoriadorId", "Código de vistoriador inválido");
                return View(vistoria);
            }
            return View(vistoria);
        }

        public IActionResult Visualizar(int vistoriaId)
        {
            if (_repositorio.IdExiste(vistoriaId))
            {
                ICollection<AmbienteModel> ambiente = _repositorio.BuscarAmbientes(vistoriaId);
                ViewBag.Ambiente = ambiente;

                VistoriaModel vistoriaDb = _repositorio.BuscarPorId(vistoriaId);
                return View(vistoriaDb);
            }
            TempData["mensagem"] = MensagemModel.Serializar("Vistoria não encontrada", Enums.TipoMensagem.Erro);
            return RedirectToAction("Index", "Vistoria");
        }

        public IActionResult ExcluirConfirmacao(int id)
        {
            if (_repositorio.IdExiste(id))
            {
                VistoriaModel vistoriaDb = _repositorio.BuscarPorId(id);
                return View(vistoriaDb);
            }
            TempData["mensagem"] = MensagemModel.Serializar("Vistoria não encontrado", Enums.TipoMensagem.Erro);
            return RedirectToAction("Index", "Vistoria");
        }

        public IActionResult Excluir(int id)
        {
            if (_repositorio.IdExiste(id))
            {
                _repositorio.Excluir(id);
                TempData["mensagem"] = MensagemModel.Serializar("Vistoria excluida com sucesso!");
                return RedirectToAction("Index", "Vistoria");
            }
            TempData["mensagem"] = MensagemModel.Serializar("Não foi possivel excluir a vistoria!", Enums.TipoMensagem.Erro);
            return RedirectToAction("Index", "Vistoriador");
        }
    }
}
