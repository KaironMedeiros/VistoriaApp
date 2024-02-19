using VistoriaApp.Models;

namespace VistoriaApp.Repository
{
    public interface IAmbienteRepositorio
    {
        AmbienteModel BuscarPorId(int id);
       // ICollection<AmbienteModel> BuscarTodos();
        AmbienteModel Adicionar(AmbienteModel ambiente);
        bool IdExiste(int id);
        bool Excluir(int id);
    }
}
