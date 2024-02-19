using Microsoft.EntityFrameworkCore;
using VistoriaApp.Data;
using VistoriaApp.Models;

namespace VistoriaApp.Repository
{
    public class VistoriaRepositorio : IVistoriaRepositorio
    {
        private readonly VistoriaContext _context;

        public VistoriaRepositorio(VistoriaContext context)
        {
            _context = context;
        }

        public VistoriaModel Adicionar(VistoriaModel vistoria)
        {
            _context.Vistoria.Add(vistoria);
            _context.SaveChanges();
            return(vistoria);
        }

        public VistoriaModel Atualizar(VistoriaModel vistoria)
        {
            VistoriaModel vistoriaDb = BuscarPorId(vistoria.Id);

            if(vistoriaDb == null) throw new System.Exception("Houve um erro na atualização dos dados");
            {
                vistoriaDb.TipoVistoria = vistoria.TipoVistoria;
                vistoriaDb.MedidorAgua = vistoria.MedidorAgua;
                vistoriaDb.MedidorEnergia = vistoria.MedidorEnergia;
                vistoriaDb.DataVistoria = vistoria.DataVistoria;

                _context.Vistoria.Update(vistoriaDb);
                _context.SaveChanges();

                return vistoriaDb;
            }
        }

        public VistoriaModel BuscarPorId(int id)
        {
            return _context.Vistoria.Include(x => x.Imovel.Endereco).Include(x => x.Imovel.Locatario).Include(x => x.Vistoriador).Include(x => x.Ambiente).FirstOrDefault(x => x.Id == id);
        }

        public VistoriaModel BuscarPorIdImovel(int ImovelId)
        {
            return _context.Vistoria.FirstOrDefault(x => x.ImovelId == ImovelId);
        }

        public VistoriadorModel BuscarPorIdVistoriador(int id) ///***
        {
            return _context.Vistoriador.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<VistoriaModel> BuscarTodos()
        {
            return _context.Vistoria.Include(x => x.Imovel.Endereco).Include(x => x.Imovel.Locatario).Include(x => x.Vistoriador).ToList();
        }

        public ICollection<AmbienteModel> BuscarAmbientes(int vistoriaId)
        {
            return _context.Ambiente.Where(x => x.VistoriaId == vistoriaId).ToList();
        }

        public bool Excluir(int id)
        {
            VistoriaModel vistoria = BuscarPorId(id);
            _context.Remove(vistoria);
            _context.SaveChanges();

            return true;

        }

        public bool IdExiste(int id)
        {
            return _context.Vistoria.Any(x => x.Id == id);
        }
    }
}
