using Microsoft.EntityFrameworkCore;
using VistoriaApp.Data;
using VistoriaApp.Models;

namespace VistoriaApp.Repository
{

    public class AmbienteRepositorio : IAmbienteRepositorio
    {
        private readonly VistoriaContext _context;

        public AmbienteRepositorio(VistoriaContext context) 
        {
            _context = context;
        }

        public AmbienteModel Adicionar(AmbienteModel ambiente)
        {
            _context.Ambiente.Add(ambiente);
            _context.SaveChanges();
            return ambiente;
        }

        public AmbienteModel BuscarPorId(int id)
        {
            return _context.Ambiente.FirstOrDefault(x => x.Id == id);
        }

       /* public ICollection<AmbienteModel> BuscarTodos()
        {
            return _context.Ambiente.ToList();
        }*/

        public bool Excluir(int id)
        {
            AmbienteModel ambienteDb = BuscarPorId(id);

            _context.Ambiente.Remove(ambienteDb);
            _context.SaveChanges();

            return true;
        }

        public bool IdExiste(int id)
        {
            return _context.Ambiente.Any(x => x.Id == id);
        }
    }
}
