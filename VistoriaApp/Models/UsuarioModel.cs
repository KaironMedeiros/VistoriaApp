using System.ComponentModel.DataAnnotations;
using VistoriaApp.Enums;

namespace VistoriaApp.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo nome abrigatório")]
        public string Nome { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        [EmailAddress(ErrorMessage = "Digite um E-mail válido")]
        public string Email { get; set;} = string.Empty;
        public string Senha { get; set; }
        public PerfilUsuario Perfil { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

    }
}
