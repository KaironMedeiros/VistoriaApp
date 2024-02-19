using System.ComponentModel.DataAnnotations;
using VistoriaApp.Enums;

namespace VistoriaApp.Models
{
    public class VistoriaModel
    {
        public int Id { get; set; } 
        public DateTime DataVistoria { get; set; }
        public int MedidorAgua { get; set; }
        public int MedidorEnergia { get; set; }
        public TipoVistoria TipoVistoria { get; set; }
        public int VistoriadorId { get; set; }
        public VistoriadorModel? Vistoriador { get; set;}
        public int ImovelId { get; set; }
        public ImovelModel? Imovel { get; set; }
        public ICollection<AmbienteModel>? Ambiente { get; set; }       
    }
}
