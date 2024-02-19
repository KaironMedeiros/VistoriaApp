using VistoriaApp.Models;

namespace VistoriaApp.Repository
{
    public interface ILocatarioRepositorio
    {
        LocatarioModel BuscarPorFK(int id);
        ImovelModel BuscarPorIdImovel(int id);
        LocatarioModel Atualizar(LocatarioModel locatario);
        LocatarioModel Adicionar(LocatarioModel locatario);
        bool IdExiste(int id);
        bool Excluir(int id);
    }
}
