public class Advogado
{
    public string Nome { get; private set; }
    public DateTime DataNasc { get; private set; }
    public string Cpf { get; private set; }
    public string Cna { get; private set; }

    public Advogado(string nome, DateTime dataNasc, string cpf, string cna)
    {
        Nome = nome;
        DataNasc = dataNasc;
        Cpf = cpf;
        Cna = cna;
    }
}
public class Cliente
{
    public string Nome { get; private set; }
    public DateTime DataNasc { get; private set; }
    public string Cpf { get; private set; }
    public string EstadoCivil { get; private set; }
    public string Profissao { get; private set; }

    public Cliente(string nome, DateTime dataNasc, string cpf, string estadoCivil, string profissao)
    {
        Nome = nome;
        DataNasc = dataNasc;
        Cpf = cpf;
        EstadoCivil = estadoCivil;
        Profissao = profissao;
    }
}
    ExibirInformacoes(advogado, cliente);
    

    public static void ExibirInformacoes(Advogado advogado, Cliente cliente)
    {
        Console.WriteLine("Advogado:");
        Console.WriteLine($"Nome: {advogado.Nome}");
        Console.WriteLine($"Data de Nascimento: {advogado.DataNasc.ToShortDateString()}");
        Console.WriteLine($"CPF: {advogado.Cpf}");
        Console.WriteLine($"CNA: {advogado.Cna}");

        Console.WriteLine("\nCliente:");
        Console.WriteLine($"Nome: {cliente.Nome}");
        Console.WriteLine($"Data de Nascimento: {cliente.DataNasc.ToShortDateString()}");
        Console.WriteLine($"CPF: {cliente.Cpf}");
        Console.WriteLine($"Estado Civil: {cliente.EstadoCivil}");
        Console.WriteLine($"Profissão: {cliente.Profissao}");
    }

Teste
