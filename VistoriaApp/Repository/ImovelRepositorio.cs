using Microsoft.EntityFrameworkCore;
using VistoriaApp.Data;
using VistoriaApp.Models;

namespace VistoriaApp.Repository
{

    public class ImovelRepositorio : IImovelRepositorio
    {
        private readonly VistoriaContext _context;

        public ImovelRepositorio(VistoriaContext context) 
        {
            _context = context;
        }

        public ImovelModel Adicionar(ImovelModel imovel)
        {
            _context.Imovel.Add(imovel);
            _context.SaveChanges();
            return imovel;
        }

        public ImovelModel BuscarPorId(int id)
        {
            return _context.Imovel.Include(x => x.Endereco).Include(x => x.Locatario).FirstOrDefault(x => x.Id == id);
        }

        public ICollection<ImovelModel> BuscarTodos()
        {
            return _context.Imovel.Include(x => x.Endereco).Include(x => x.Vistoria).Include(x => x.Locatario).ToList();
        }

        public ImovelModel Atualizar(ImovelModel imovel)
        {
            ImovelModel imovelDb = BuscarPorId(imovel.Id);

            if (imovelDb == null) throw new System.Exception("Houve um erro na atualização dos dados");

            imovelDb.TipoImovel = imovel.TipoImovel;
            imovelDb.Situacao = imovel.Situacao;
            imovelDb.Endereco.UF = imovel.Endereco.UF;
            imovelDb.Endereco.Cidade = imovel.Endereco.Cidade;
            imovelDb.Endereco.Bairro = imovel.Endereco.Bairro;
            imovelDb.Endereco.Rua = imovel.Endereco.Rua;
            imovelDb.Endereco.Numero = imovel.Endereco.Numero;
            imovelDb.Endereco.CEP = imovel.Endereco.CEP;
            imovelDb.Endereco.Complemento = imovel.Endereco.Complemento;

            _context.Imovel.Update(imovelDb);
            _context.SaveChanges();

            return imovelDb;
        }

        public bool Excluir(int id)
        {
            ImovelModel imovelDb = BuscarPorId(id);

            _context.Imovel.Remove(imovelDb);
            _context.SaveChanges();

            return true;
        }

        public bool IdExiste(int id)
        {
            return _context.Imovel.Any(x => x.Id == id);
        }
    }
}
