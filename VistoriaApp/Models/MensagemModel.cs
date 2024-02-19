using Newtonsoft.Json;
using VistoriaApp.Enums;

namespace VistoriaApp.Models
{
    public class MensagemModel
    {
        public TipoMensagem Tipo { get; set; }
        public string Texto { get; set; }

        public MensagemModel(string mensagem, TipoMensagem tipo = TipoMensagem.Informacao)
        {
            Tipo = tipo;
            Texto = mensagem;
        }

        public static string Serializar(string mensagem, TipoMensagem tipo = TipoMensagem.Informacao)
        {
            var mensagemModel = new MensagemModel(mensagem, tipo);
            return JsonConvert.SerializeObject(mensagemModel);
        }

        public static MensagemModel Desserializar(string mensagemString)
        {
            return JsonConvert.DeserializeObject<MensagemModel>(mensagemString);
        }
    }
}
