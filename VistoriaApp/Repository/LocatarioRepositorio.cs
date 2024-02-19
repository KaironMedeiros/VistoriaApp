using Microsoft.EntityFrameworkCore;
using VistoriaApp.Data;
using VistoriaApp.Models;

namespace VistoriaApp.Repository
{
    public class LocatarioRepositorio : ILocatarioRepositorio
    {
        private readonly VistoriaContext _context;

        public LocatarioRepositorio(VistoriaContext context)
        {
            _context = context;
        }

        public LocatarioModel Adicionar(LocatarioModel locatario)
        {
            _context.Locatario.Add(locatario);
            _context.SaveChanges();
            return locatario;
        }

        public LocatarioModel BuscarPorFK(int id)
        {
            return _context.Locatario.FirstOrDefault(x => x.ImovelId == id);
        }

        public ImovelModel BuscarPorIdImovel(int id)
        {
            return _context.Imovel.Include(x => x.Locatario).FirstOrDefault(x => x.Id == id);
        }

        public LocatarioModel Atualizar(LocatarioModel locatario)
        {
            LocatarioModel locatarioDb = BuscarPorFK(locatario.ImovelId);

            if (locatarioDb == null) throw new System.Exception("Houve um erro na atualização dos dados");

            locatarioDb.Nome = locatario.Nome;
            locatarioDb.CPF = locatario.CPF;
            locatario.Telefone = locatario.Telefone;
            locatarioDb.DataEntrada = locatario.DataEntrada;
            locatarioDb.DataSaida = locatario.DataSaida;

            _context.Locatario.Update(locatarioDb);
            _context.SaveChanges();

            return locatarioDb;

        }

        public bool Excluir(int id)
        {
            LocatarioModel locatarioDb = BuscarPorFK(id);

            _context.Locatario.Remove(locatarioDb);
            _context.SaveChanges();

            return true;
        }

        public bool IdExiste(int id)
        {
            return _context.Locatario.Any(x => x.ImovelId == id);
        }

        
    }
}
