using VistoriaApp.Data;
using VistoriaApp.Models;

namespace VistoriaApp.Repository
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly VistoriaContext _context;

        public UsuarioRepositorio(VistoriaContext context)
        {
            _context = context;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _context.Usuario.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper()); 
        }

        public ICollection<UsuarioModel> BuscarTodos()
        {
            return _context.Usuario.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel BuscarPorId(int id)
        {
            return _context.Usuario.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = BuscarPorId(usuario.Id);

            if (usuarioDb == null) throw new System.Exception("Houve um erro na atualização dos dados");
            {
                usuarioDb.Nome = usuario.Nome;
                usuarioDb.Login = usuario.Login;
                usuarioDb.Email = usuario.Email;
                usuarioDb.Senha = usuario.Senha;
                usuarioDb.Perfil = usuario.Perfil;

                _context.Usuario.Update(usuarioDb);
                _context.SaveChanges();

                return usuarioDb;
            }
        }

        public bool Excluir(int id)
        {
            UsuarioModel usuarioDb = BuscarPorId(id);
            _context.Usuario.Remove(usuarioDb);
            _context.SaveChanges();

            return true;
        }

        public bool IdExiste(int id)
        {
            return _context.Usuario.Any(x => x.Id == id);
        }


    }
}
