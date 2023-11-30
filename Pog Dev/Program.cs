using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Escritorio escritorio = new Escritorio("Escritório de Advocacia XYZ");

        Advogado advogado1 = new Advogado("Tales", new DateTime(1976, 2, 1), "12345678901", "CNA-123");
        Advogado advogado2 = new Advogado("Danilo", new DateTime(1976, 3, 16), "98765432109", "CNA-456");

        escritorio.AdicionarAdvogado(advogado1);
        escritorio.AdicionarAdvogado(advogado2);

        Cliente cliente1 = new Cliente("Cliente 1", new DateTime(1985, 3, 10), "98765432101", "Casado", "Médico");
        Cliente cliente2 = new Cliente("Cliente 2", new DateTime(1992, 7, 20), "12345678902", "Solteiro", "Fisioteraupeta");

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

        // Gerando relatórios
        Console.WriteLine("Relatórios:");
        Console.WriteLine($"Número de Advogados: {escritorio.ObterNumeroAdvogados()}");
        Console.WriteLine($"Número de Clientes: {escritorio.ObterNumeroClientes()}");
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
        Advogados.Add(advogado);
    }

   