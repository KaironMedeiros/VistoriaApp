using System.ComponentModel.DataAnnotations;
using VistoriaApp.Enums;

namespace VistoriaApp.Models
{
    public class ImovelModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Tipo abrigatório")]
        public TipoImovel TipoImovel { get; set; }
        [Required(ErrorMessage = "Campo situação  abrigatório")]
        public SituacaoImovel Situacao { get; set; }
        public EnderecoModel? Endereco { get; set; }
        public LocatarioModel? Locatario { get; set; }
        public VistoriaModel? Vistoria { get; set;}
    }
}
