namespace DentiSys.Models
{
    public class PacientePlano
    {
        public int IdPlano { get; set; }
        public Plano Plano { get; set; }
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public bool PlanoAtivo { get; set; }

    }
}
