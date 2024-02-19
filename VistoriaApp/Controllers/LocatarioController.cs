using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using VistoriaApp.Models;
using VistoriaApp.Repository;

namespace VistoriaApp.Controllers
{
    public class LocatarioController : Controller
    {
        private readonly ILocatarioRepositorio _repositorio;

        public LocatarioController(ILocatarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index(int imovelId)
        {
            ImovelModel imovel = _repositorio.BuscarPorIdImovel(imovelId);
            LocatarioModel locatario = _repositorio.BuscarPorFK(imovelId);

            ViewBag.imovel = imovel;
            return View(locatario);
        }

        public IActionResult CriarEditar(int? imovelId)
        {
            LocatarioModel locatarioDb =_repositorio.BuscarPorFK(imovelId.Value);

            if (locatarioDb != null)
            {
                return View(locatarioDb);
            }
            return View();
        }


        [HttpPost]
        public IActionResult CriarEditar(LocatarioModel locatario)
        {
            if (ModelState.IsValid)
            {
                if (locatario.Id > 0)
                {
                    if (_repositorio.IdExiste(locatario.ImovelId))
                    {
                        _repositorio.Atualizar(locatario);
                        TempData["mensagem"] = MensagemModel.Serializar("Locatário atualizado com sucesso!");
                        return RedirectToAction("Index", "Imovel");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Não foi possivel atualizar os dados!", Enums.TipoMensagem.Erro);
                        return RedirectToAction("Index", "Imovel");
                    }
                }
                else
                {
                    _repositorio.Adicionar(locatario);
                    TempData["mensagem"] = MensagemModel.Serializar("Locatário cadastrado com sucesso!");
                    return RedirectToAction("Index", "Imovel");
                }


            }
            return View(locatario);
        }

        public IActionResult ExcluirConfirmacao(int imovelId)
        {
            if (_repositorio.IdExiste(imovelId))
            {
                LocatarioModel locatario = _repositorio.BuscarPorFK(imovelId);
                return View(locatario);
            }
            TempData["mensagem"] = MensagemModel.Serializar("Imovel não encontrado", Enums.TipoMensagem.Erro);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int imovelId)
        {
            if (_repositorio.IdExiste(imovelId))
            {
                _repositorio.Excluir(imovelId);
                TempData["mensagem"] = MensagemModel.Serializar("Locatário excluido com sucesso!");
                return RedirectToAction("Index", "Imovel");
            }
            TempData["mensagem"] = MensagemModel.Serializar("Não foi possivel excluir os dados!", Enums.TipoMensagem.Erro);
            return RedirectToAction("Index", "Imovel");
        }
    }
}







