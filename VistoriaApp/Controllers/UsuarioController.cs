using Microsoft.AspNetCore.Mvc;
using VistoriaApp.Data;
using VistoriaApp.Models;
using VistoriaApp.Repository;

namespace VistoriaApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _repositorio;

        public UsuarioController(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            ICollection<UsuarioModel> usuario = _repositorio.BuscarTodos();
            return View(usuario);
        }

        public IActionResult CriarEditar(int? id)
        {
            if (id != null && id != 0)
            {
                UsuarioModel usuario = _repositorio.BuscarPorId(id.Value);
                return View(usuario);
            }
            return View();
        }

        [HttpPost]
        public IActionResult CriarEditar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.Id > 0)
                {
                    if (_repositorio.IdExiste(usuario.Id))
                    {
                        _repositorio.Atualizar(usuario);
                        TempData["mensagem"] = MensagemModel.Serializar("Usuário atualizado com sucesso!");
                        return RedirectToAction("Index");
                    }

                    TempData["mensagem"] = MensagemModel.Serializar("Não foi possivel atualizar os dados!", Enums.TipoMensagem.Erro);
                    return RedirectToAction("Index");
                }
                else
                {
                    _repositorio.Adicionar(usuario);
                    TempData["mensagem"] = MensagemModel.Serializar("Usuário criado com sucesso!");
                    return RedirectToAction("Index", "Login");
                }
            }
            return View(usuario);
        }

        public IActionResult ExcluirConfirmacao(int id)
        {
            if (_repositorio.IdExiste(id))
            {
                UsuarioModel usuarioDb = _repositorio.BuscarPorId(id);
                return View(usuarioDb);
            }
            TempData["mensagem"] = MensagemModel.Serializar("Usuário não encontrado!", Enums.TipoMensagem.Erro);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            if (_repositorio.IdExiste(id))
            {
                _repositorio.Excluir(id);
                return RedirectToAction("Index");
            }
            TempData["mensagem"] = MensagemModel.Serializar("Usuário não encontrado!", Enums.TipoMensagem.Erro);
            return RedirectToAction("Index");
        }
    }
}
