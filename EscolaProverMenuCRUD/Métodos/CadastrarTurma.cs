using EscolaProverMenuCRUD.Classes;
using EscolaProverMenuCRUD.Validacao;
using Caelum.Stella.CSharp.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaProverMenuCRUD
{
    partial class Program
    {
        static void InserirTurma()
        {
            do
            {
                Console.Clear();
                bool encontrado = false;


                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    CADASTRO\t\tEscolaProver\t     |");
                Console.WriteLine("|        Digite 0 para voltar ao menu inicial        |");
                Console.WriteLine("|----------------------------------------------------|");

                Turma turma1 = new Turma();
                Console.WriteLine("|                                                    |");
                Console.Write("| Escreva o nome da turma: \t\t");
                try
                {
                    turma1.TurmaNome = Console.ReadLine();
                    if (turma1.TurmaNome == "0")
                    {
                        Escolher();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Não permitido caracteres especiais. Aperte enter para tentar novamente.");
                }
                try
                {
                    int valor = int.Parse(turma1.TurmaNome);
                    if (turma1.TurmaNome == "0")
                    {
                        Escolher();
                    }
                    if (valor is int)
                    {
                        Console.WriteLine("O valor deve ser textual, digite enter para continuar.");
                        Console.ReadLine();
                        InserirTurma();
                    }
                }
                catch (FormatException ex)
                {
                    if (turma1.TurmaNome.Equals(turma1.TurmaNome.ToLower()))
                    {
                        Console.WriteLine("Não permitido caracteres especiais.Aperte enter para tentar novamente.");
                        Console.ReadLine();
                        InserirTurma();
                        throw new Exception(ex.Message);
                    }

                }
                if (turma1.TurmaNome == "" || turma1.TurmaNumero == "")
                {
                    Console.WriteLine("O nome não pode ser nulo, digite enter para continuar.");
                    Console.ReadLine();
                    InserirTurma();
                }
                Console.Write("|\n| Número da turma(apenas números): \t");
                turma1.TurmaNumero = Console.ReadLine();
                long n;
                var isNumerico = long.TryParse(turma1.TurmaNumero, out n);
                if (turma1.TurmaNumero == "0")
                {
                    Escolher();
                }
                while (isNumerico == false || turma1.TurmaNumero.Length <= 3)
                {
                    Console.WriteLine("|\n| Turma deve ter 3 números. Aperte enter para continuar. \t");
                    Console.Write("|\n| Número da turma(apenas números): \t");
                    turma1.TurmaNumero = Console.ReadLine();
                    isNumerico = long.TryParse(turma1.TurmaNumero, out n);
                    if (turma1.TurmaNumero == "0")
                    {
                        Escolher();
                    }
                }
                foreach (Turma turma in turmas)
                {
                    if (turma.TurmaNome.ToLower().Contains(turma1.TurmaNome.ToLower()))
                    {
                        encontrado = true;
                        Console.Clear();

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|\t    CADASTRO\t\tEscolaProver\t     |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|\n| A turma {0} já foi adicionada.", turma1.TurmaNome);

                        Console.WriteLine("|\n|\n| Escolha a opção:");
                        Console.WriteLine("|\n| 1- Adicionar outra turma\n| 2- Menu incial");
                        Console.Write("|\n|Insira a Opção:");
                        string opcao = Console.ReadLine();
                        if (opcao == "1")
                        {
                            InserirTurma();
                        }
                        else if (opcao == "2")
                        {
                            Escolher();
                        }
                        else
                        {
                            Console.WriteLine("Opção Inválida!!");
                        }
                    }
                }
                if (!encontrado)
                {
                    string linha = turma1.TurmaNome + "|";
                    for (int i = 0; i < 1; i++)
                    {
                        linha += turma1.TurmaNome + "|" + turma1.TurmaNumero + "|";
                        turma1.turmas.Add(turma1);
                    }
                    turmas.Add(turma1);
                    if (File.Exists(Ficheiro))
                    {
                        file = File.AppendText(Ficheiro);
                    }
                    else
                    {
                        file = File.CreateText(Ficheiro);
                    }
                    file.WriteLine(linha);
                    file.Close();
                    Console.WriteLine("|\n| Deseja continuar inserindo turmas? s p/ sim e n p/ não: \t");
                }
            }
            while (Console.ReadLine().ToLower() == "s");
            Console.Clear();
            Escolher();
        }
    }
}
