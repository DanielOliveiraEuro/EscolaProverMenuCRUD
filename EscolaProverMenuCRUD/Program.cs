using EscolaProverMenuCRUD.Classes;
using System;
using System.Collections;
using System.Diagnostics.Metrics;
using System.IO;

namespace EscolaProverMenuCRUD
{
    partial class Program
    {
        static string Ficheiro = "EscolaProver.txt";
        static StreamWriter file;
        static ArrayList alunos = new ArrayList();
        static void Main(string[] args)
        {
            CarregarArquivosAlunos();
            Escolher();
        }
        static void CarregarArquivosAlunos()
        {
            if (File.Exists(Ficheiro))
            {
                string[] linhas = File.ReadAllLines(Ficheiro);
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split('|');
                    Aluno aluno = new Aluno();
                    aluno.nome = partes[0];
                    int c = 0;
                    for (int i = 0; i < 1; i++)
                    {
                       /* Turma turma = new Turma()*/;
                        aluno.nome = partes[i + 1 + c];
                        aluno.cpf = partes[i + 2 + c];
                        aluno.telefone = partes[i + 3 + c];
                        aluno.codigo = int.Parse(partes[i + 4 + c]);
                        //aluno.materia = partes[i + 5 + c];
                        //aluno.turma = partes[i + 6 + c];
                        aluno.estudantes.Add(aluno);
                        c++;
                    }
                    alunos.Add(aluno);
                }
            }
        }
        static void Escolher()
        {
            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t\tMENU\t\tEscolaProver\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|1- Inserir Aluno\t\t\t\t     |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|2- Alterar ou Remover Alunos\t\t\t     |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|3- Consultar Alunos\t\t                     |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|4- Listar Alunos \t\t                     |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|0- Sair\t\t\t\t\t     |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.WriteLine("Insira a Opção: ");
                opcao = (Console.ReadLine());

                switch (opcao)
                {
                    case "1":
                        Inserir();
                        break;
                    case "2":
                        AlterarRemover();
                        break;
                    case "3":
                        Consultar();
                        break;
                    case "4":
                        Listar();
                        break;
                    case "0":
                        Fechar();
                        break;
                    default:
                        if (opcao != "0")
                        {
                            Console.WriteLine("Opção Inválida!! Aperte enter para voltar ao menu.");
                            Console.ReadLine();
                        }
                        break;
                }
            } while (opcao != "0");
        }
    }
}