using Microsoft.EntityFrameworkCore;
using VistoriaApp.Data;
using VistoriaApp.Models;

namespace VistoriaApp.Repository
{

    public class VistoriadorRepositorio : IVistoriadorRepositorio
    {
        private readonly VistoriaContext _context;

        public VistoriadorRepositorio(VistoriaContext context) 
        {
            _context = context;
        }

        public VistoriadorModel Adicionar(VistoriadorModel vistoriador)
        {
            _context.Vistoriador.Add(vistoriador);
            _context.SaveChanges();
            return vistoriador;
        }

        public VistoriadorModel BuscarPorId(int id)
        {
            return _context.Vistoriador.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<VistoriadorModel> BuscarTodos()
        {
            return _context.Vistoriador.ToList();
        }

        public VistoriadorModel Atualizar(VistoriadorModel vistoriador)
        {
            VistoriadorModel vistoriadorDb = BuscarPorId(vistoriador.Id);

            if (vistoriadorDb == null) throw new System.Exception("Houve um erro na atualização dos dados");

            vistoriadorDb.Nome = vistoriador.Nome;
            vistoriadorDb.Telefone = vistoriador.Telefone;
            vistoriadorDb.Email = vistoriador.Email;


            _context.Vistoriador.Update(vistoriadorDb);
            _context.SaveChanges();

            return vistoriadorDb;
        }

        public bool Excluir(int id)
        {
            VistoriadorModel vistoriadorlDb = BuscarPorId(id);

            _context.Vistoriador.Remove(vistoriadorlDb);
            _context.SaveChanges();

            return true;
        }

        public bool IdExiste(int id)
        {
            return _context.Vistoriador.Any(x => x.Id == id);
        }
    }
}
