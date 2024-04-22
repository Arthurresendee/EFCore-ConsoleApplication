using DentiSys.Models.Enums;

namespace DentiSys.Models
{
    public class Procedimento
    {
        public Procedimento(){}

        public int Id { get; set; }
        public string Titulo { get; set; }
        public TipoDeProcedimento TipoDeProcedimento { get; set; }
        public string Descricao { get; set; }
        public ICollection<PacienteProcedimento> PacienteProcedimentos { get; set; }
    }
}
