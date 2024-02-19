using VistoriaApp.Models;

namespace VistoriaApp.Repository
{
    public interface IVistoriadorRepositorio
    {
        VistoriadorModel BuscarPorId(int id);
        ICollection<VistoriadorModel> BuscarTodos();
        VistoriadorModel Atualizar(VistoriadorModel imovel);
        VistoriadorModel Adicionar(VistoriadorModel imovel);
        bool IdExiste(int id);
        bool Excluir(int id);
    }
}
