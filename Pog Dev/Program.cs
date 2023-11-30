using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Escritorio escritorio = new Escritorio("Escritório de Advocacia XYZ");

        Advogado advogado1 = new Advogado("Tales Araujo", new DateTime(1996, 2, 4), "12345678901", "CNA-123");
        Advogado advogado2 = new Advogado("Danilo Pereira", new DateTime(1983, 5, 16), "98765432109", "CNA-456");

        escritorio.AdicionarAdvogado(advogado1);
        escritorio.AdicionarAdvogado(advogado2);

        Cliente cliente1 = new Cliente("Luciano Nascimento", new DateTime(1972, 3, 15), "98765432101", "Casado", "Engenheiro");
        Cliente cliente2 = new Cliente("Gustavo Pereira", new DateTime(1989, 4, 13), "12345678902", "Solteiro", "Advogado");

        escritorio.AdicionarCliente(cliente1);
        escritorio.AdicionarCliente(cliente2);

        Console.WriteLine($"Nome do Escritório: {escritorio.Nome}");
        Console.WriteLine("\nAdvogados:");
        foreach (Advogado advogado in escritorio.Advogados)
        {
            Console.WriteLine($"Nome: {advogado.Nome}");
            Console.WriteLine($"Data de Nascimento: {advogado.DataNascimento.ToShortDateString()}");
            Console.WriteLine($"CPF: {advogado.CPF}");
            Console.WriteLine($"CNA: {advogado.CNA}");
            Console.WriteLine("\n");
        }

        Console.WriteLine("\nClientes:");
        foreach (Cliente cliente in escritorio.Clientes)
        {
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"Data de Nascimento: {cliente.DataNascimento.ToShortDateString()}");
            Console.WriteLine($"CPF: {cliente.CPF}");
            Console.WriteLine($"Estado Civil: {cliente.EstadoCivil}");
            Console.WriteLine($"Profissão: {cliente.Profissao}");
            Console.WriteLine("\n");
        }

        Console.WriteLine("Relatórios:");
        Console.WriteLine("Advogados com idade entre 30 e 40 anos:");
        List<Advogado> advogadosIdade30a40 = escritorio.ObterAdvogadosComIdadeEntre(30, 40);
        ExibirAdvogados(advogadosIdade30a40);

        Console.WriteLine("Clientes com idade entre 25 e 35 anos:");
        List<Cliente> clientesIdade25a35 = escritorio.ObterClientesComIdadeEntre(25, 35);
        ExibirClientes(clientesIdade25a35);

        Console.WriteLine("Clientes com estado civil informado pelo usuário:");
        Console.Write("Informe o estado civil desejado (Casado/Solteiro): ");
        string estadoCivilUsuario = Console.ReadLine();
        List<Cliente> clientesComEstadoCivil = escritorio.ObterClientesPorEstadoCivil(estadoCivilUsuario);
        ExibirClientes(clientesComEstadoCivil);

        Console.WriteLine("Clientes em ordem alfabética:");
        List<Cliente> clientesEmOrdemAlfabetica = escritorio.ObterClientesEmOrdemAlfabetica();
        ExibirClientes(clientesEmOrdemAlfabetica);

        Console.WriteLine("Clientes cuja profissão contenha texto informado pelo usuário:");
        Console.Write("Informe o texto desejado na profissão: ");
        string textoProfissaoUsuario = Console.ReadLine();
        List<Cliente> clientesComProfissaoContendoTexto = escritorio.ObterClientesComProfissaoContendoTexto(textoProfissaoUsuario);
        ExibirClientes(clientesComProfissaoContendoTexto);

        Console.WriteLine("Advogados e Clientes aniversariantes do mês informado:");
        Console.Write("Informe o mês desejado (1 a 12): ");
        int mesAniversario = int.Parse(Console.ReadLine());
        List<Pessoa> aniversariantesDoMes = escritorio.ObterAniversariantesDoMes(mesAniversario);
        ExibirAniversariantes(aniversariantesDoMes);
    }

    static void ExibirAdvogados(List<Advogado> advogados)
    {
        foreach (Advogado advogado in advogados)
        {
            Console.WriteLine($"Nome: {advogado.Nome}");
            Console.WriteLine($"Data de Nascimento: {advogado.DataNascimento.ToShortDateString()}");
            Console.WriteLine($"CPF: {advogado.CPF}");
            Console.WriteLine($"CNA: {advogado.CNA}");
            Console.WriteLine("\n");
        }
    }

    static void ExibirClientes(List<Cliente> clientes)
    {
        foreach (Cliente cliente in clientes)
        {
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"Data de Nascimento: {cliente.DataNascimento.ToShortDateString()}");
            Console.WriteLine($"CPF: {cliente.CPF}");
            Console.WriteLine($"Estado Civil: {cliente.EstadoCivil}");
            Console.WriteLine($"Profissão: {cliente.Profissao}");
            Console.WriteLine("\n");
        }
    }

    static void ExibirAniversariantes(List<Pessoa> aniversariantes)
    {
        foreach (Pessoa pessoa in aniversariantes)
        {
            Console.WriteLine($"Nome: {pessoa.Nome}");
            Console.WriteLine($"Data de Nascimento: {pessoa.DataNascimento.ToShortDateString()}");
            Console.WriteLine("\n");
        }
    }
}

class Escritorio
{
    public string Nome { get; private set; }
    public List<Advogado> Advogados { get; private set; }
    public List<Cliente> Clientes { get; private set; }

    public Escritorio(string nome)
    {
        Nome = nome;
        Advogados = new List<Advogado>();
        Clientes = new List<Cliente>();
    }

    public void AdicionarAdvogado(Advogado advogado)
    {
        if (Advogados.Any(a => a.CPF == advogado.CPF) || Advogados.Any(a => a.CNA == advogado.CNA))
        {
            Console.WriteLine("Advogado com CPF ou CNA duplicado. Não adicionado.");
        }
        else
        {
            Advogados.Add(advogado);
            Console.WriteLine("Advogado adicionado com sucesso.");
        }
    }

    public void AdicionarCliente(Cliente cliente)
    {
        if (Clientes.Any(c => c.CPF == cliente.CPF))
        {
            Console.WriteLine("Cliente com CPF duplicado. Não adicionado.");
        }
        else
        {
            Clientes.Add(cliente);
            Console.WriteLine("Cliente adicionado com sucesso.");
        }
    }

    public int ObterNumeroAdvogados()
    {
        return Advogados.Count;
    }

    public int ObterNumeroClientes()
    {
        return Clientes.Count;
    }

    public List<Advogado> ObterAdvogadosComIdadeEntre(int idadeMinima, int idadeMaxima)
    {
        DateTime dataAtual = DateTime.Now;
        return Advogados.Where(a => (dataAtual - a.DataNascimento).Days / 365 >= idadeMinima && (dataAtual - a.DataNascimento).Days / 365 <= idadeMaxima).ToList();
    }

    public List<Cliente> ObterClientesComIdadeEntre(int idadeMinima, int idadeMaxima)
    {
        DateTime dataAtual = DateTime.Now;
        return Clientes.Where(c => (dataAtual - c.DataNascimento).Days / 365 >= idadeMinima && (dataAtual - c.DataNascimento).Days / 365 <= idadeMaxima).ToList();
    }

    public List<Cliente> ObterClientesPorEstadoCivil(string estadoCivil)
    {
        return Clientes.Where(c => c.EstadoCivil.ToLower() == estadoCivil.ToLower()).ToList();
    }

    public List<Cliente> ObterClientesEmOrdemAlfabetica()
    {
        return Clientes.OrderBy(c => c.Nome).ToList();
    }

    public List<Cliente> ObterClientesComProfissaoContendoTexto(string textoProfissao)
    {
        return Clientes.Where(c => c.Profissao.ToLower().Contains(textoProfissao.ToLower())).ToList();
    }

    public List<Pessoa> ObterAniversariantesDoMes(int mes)
    {
        DateTime dataAtual = DateTime.Now;
        List<Pessoa> aniversariantes = new List<Pessoa>();

        aniversariantes.AddRange(Advogados.Where(a => a.DataNascimento.Month == mes));
      