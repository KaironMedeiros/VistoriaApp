using Microsoft.AspNetCore.Mvc;
using VistoriaApp.Models;
using VistoriaApp.Repository;

namespace VistoriaApp.Controllers
{
    public class ImovelController : Controller
    {
        private readonly IImovelRepositorio _repositorio;
        public ImovelController(IImovelRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            ICollection<ImovelModel> imovel = _repositorio.BuscarTodos();
            return View(imovel);
        }

        public IActionResult CriarEditar(int? id)
        {
            if (id != null && id != 0)
            {
                ImovelModel imovel = _repositorio.BuscarPorId(id.Value);
                return View(imovel);
            }
            return View();
        }

        [HttpPost]
        public IActionResult CriarEditar(ImovelModel imovel)

        {
            if (ModelState.IsValid)
            {
                if (imovel.Id > 0)
                {
                    if (_repositorio.IdExiste(imovel.Id))
                    {
                        _repositorio.Atualizar(imovel);
                        TempData["mensagem"] = MensagemModel.Serializar("Dados atualizados com sucesso!");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Não foi possivel atualizar os dados!", Enums.TipoMensagem.Erro);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    _repositorio.Adicionar(imovel);
                    TempData["mensagem"] = MensagemModel.Serializar("Dados cadastrados com sucesso!");
                    return RedirectToAction("Index");
                }
            }
            return View(imovel);
        }

        public IActionResult ExcluirConfirmacao(int id)
        {
            if (_repositorio.IdExiste(id))
            {
                ImovelModel ImovelDb = _repositorio.BuscarPorId(id);
                return View(ImovelDb);
            }
            TempData["mensagem"] = MensagemModel.Serializar("Imovel não encontrado.", Enums.TipoMensagem.Erro);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            if (_repositorio.IdExiste(id))
            {
                _repositorio.Excluir(id);
                TempData["mensagem"] = MensagemModel.Serializar("Imóvel excluido com sucesso!");
                return RedirectToAction("Index");
            }
            TempData["mensagem"] = MensagemModel.Serializar("Houve um erro na exclusão do imóvel!", Enums.TipoMensagem.Erro);
            return RedirectToAction("Index");
        }
    }
}
