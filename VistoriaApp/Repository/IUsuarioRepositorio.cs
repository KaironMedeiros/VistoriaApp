using VistoriaApp.Models;

namespace VistoriaApp.Repository
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        ICollection<UsuarioModel> BuscarTodos();
        UsuarioModel BuscarPorId(int id);
        UsuarioModel Atualizar(UsuarioModel locatario);
        UsuarioModel Adicionar(UsuarioModel locatario);
        bool IdExiste(int id);
        bool Excluir(int id);
    }
}
