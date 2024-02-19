using VistoriaApp.Data;
using VistoriaApp.Models;

namespace VistoriaApp.Repository
{
    public interface IVistoriaRepositorio
    {
        VistoriaModel BuscarPorId(int id);
        VistoriaModel BuscarPorIdImovel(int id);
        VistoriadorModel BuscarPorIdVistoriador(int id);
        ICollection<VistoriaModel> BuscarTodos();
        ICollection<AmbienteModel> BuscarAmbientes(int vistoriaId);
        VistoriaModel Adicionar(VistoriaModel vistoria);
        VistoriaModel Atualizar(VistoriaModel vistoria);
        bool IdExiste(int id);
        bool Excluir(int id); 
    }
}
