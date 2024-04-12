using DentiSys.Models.Enums;

namespace DentiSys.Models
{
    public class Plano
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public TipoDePlano TipoDePlano { get; set; }
        public string Descricao { get; set; }
        public string Coberturas { get; set; }
        public DateTime DataInicial { get; set; } = DateTime.Now;
        public DateTime DataFinal { get; set; }
    }
}
