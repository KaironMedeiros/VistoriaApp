using VistoriaApp.Models;

namespace VistoriaApp.Repository
{
    public interface IImovelRepositorio
    {
        ImovelModel BuscarPorId(int id);
        ICollection<ImovelModel> BuscarTodos();
        ImovelModel Atualizar(ImovelModel imovel);
        ImovelModel Adicionar(ImovelModel imovel);
        bool IdExiste(int id);
        bool Excluir(int id);
    }
}
