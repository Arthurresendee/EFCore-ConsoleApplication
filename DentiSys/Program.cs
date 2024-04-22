using DentiSys.Data;
using DentiSys.Models;

var context = new DentiSysDataContext();

InserirValoresIniciais();

context.SaveChanges();

static void InserirValoresIniciais()
{
    var context = new DentiSysDataContext();

    var enderecos = new List<Endereco>
    {
        new Endereco { CEP = "1232", Pais = "Brasil", Estado = "São Paulo", Cidade = "São Paulo", Rua = "Rua A", Numero = "123" },
        new Endereco { CEP = "223234", Pais = "Brasil", Estado = "Rio de Janeiro", Cidade = "Rio de Janeiro", Rua = "Rua B", Numero = "456" },
        new Endereco { CEP = "333432", Pais = "Brasil", Estado = "Minas Gerais", Cidade = "Belo Horizonte", Rua = "Rua C", Numero = "789" },
        new Endereco { CEP = "444234", Pais = "Brasil", Estado = "Bahia", Cidade = "Salvador", Rua = "Rua D", Numero = "1011" },
        new Endereco { CEP = "555523", Pais = "Brasil", Estado = "Paraná", Cidade = "Curitiba", Rua = "Rua E", Numero = "1213" }
    };

    context.Enderecos.AddRange(enderecos);

    var dentistas = new List<Dentista>
    {
        new Dentista { Nome = "Carlos", SobreNome = "Silva", Endereco = enderecos[0], Especializacao = "Odontopediatria", NumeroDeRegistro = "12345" },
        new Dentista { Nome = "Ana", SobreNome = "Santos", Endereco = enderecos[1], Especializacao = "Ortodontia", NumeroDeRegistro = "54321" },
        new Dentista { Nome = "Pedro", SobreNome = "Oliveira", Endereco = enderecos[2], Especializacao = "Implantodontia", NumeroDeRegistro = "67890" },
        new Dentista { Nome = "Juliana", SobreNome = "Ferreira", Endereco = enderecos[3], Especializacao = "Endodontia", NumeroDeRegistro = "13579" },
        new Dentista { Nome = "Mariana", SobreNome = "Gomes", Endereco = enderecos[4], Especializacao = "Periodontia", NumeroDeRegistro = "24680" }
    };

    context.Dentistas.AddRange(dentistas);

    var pacientes = new List<Paciente>
    {
        new Paciente { Nome = "Gabriel", SobreNome = "Almeida", Endereco = enderecos[0] },
        new Paciente { Nome = "Laura", SobreNome = "Pereira", Endereco = enderecos[1] },
        new Paciente { Nome = "Luiz", SobreNome = "Costa", Endereco = enderecos[2] },
        new Paciente { Nome = "Amanda", SobreNome = "Rodrigues", Endereco = enderecos[3] },
        new Paciente { Nome = "Guilherme", SobreNome = "Martins", Endereco = enderecos[4] }
    };
    context.Pacientes.AddRange(pacientes);

    context.SaveChanges();
}
