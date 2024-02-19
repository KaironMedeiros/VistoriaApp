using System.ComponentModel.DataAnnotations;

namespace VistoriaApp.Models
{
    public class VistoriadorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo nome abrigatório")]
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Email  abrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;
        public ICollection<VistoriaModel>? Vistoria { get; set; }
    }
}
