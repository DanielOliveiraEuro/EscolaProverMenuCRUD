using EscolaProverMenuCRUD.Classes;
using EscolaProverMenuCRUD.Conexao;
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.IO;

namespace EscolaProverMenuCRUD;

partial class Program
{
    static string Ficheiro = "EscolaProver.txt";
    static StreamWriter file;
    static ArrayList alunos = new ArrayList();
    static ArrayList turmas = new ArrayList();
    static void Main(string[] args)
    {
        //try
        //{
        //    SqlConnection sqlConnection;
        //    string connectionString = @"Data Source=DESKTOP-4N1BV2V\SQLSERVER;Initial Catalog=EscolaProverDados;Integrated Security=True";

        //    sqlConnection = new SqlConnection(connectionString);
        //    sqlConnection.Open();
        //    Console.WriteLine("Conexão Criada.");
        //    Console.ReadKey();
        //    string insertQuery = "insert into dbo.Alunos (Nome, CPF, Celular) VALUES ('Teste', '32165498701', '21918372748';";
        //    SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
        //    insertCommand.ExecuteNonQuery();
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Conexão Falhou.");
        //    Console.WriteLine(ex.Message);
        //    Console.ReadKey();
        //}
        CarregarArquivosAlunos();
        Escolher();
    }
    static void CarregarArquivosAlunos()
    {

        try
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=DESKTOP-BRDOPT0;Initial Catalog=EscolaProver;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            //Console.WriteLine("Conexão Criada.");
            //Console.ReadKey();
            string selectQuery = $"select AlunoId, Nome, CPF, Celular from dbo.Alunos";
            SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);
            SqlDataReader reader = selectCommand.ExecuteReader();
            List<string> str = new List<string>();
            int i = 0;
            while (reader.Read())
            {
                str.Add(reader.GetValue(i).ToString());
                i++;
            }
            reader.Close();
            
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conexão Falhou.");
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
        
        //if (File.Exists(Ficheiro))
        //{
        //    string[] linhas = File.ReadAllLines(Ficheiro);
        //    foreach (string linha in linhas)
        //    {
        //        string[] partes = linha.Split('|');
        //        Aluno aluno = new Aluno();
        //        aluno.nome = partes[0];
        //        int c = 0;
        //        for (int i = 0; i < 1; i++)
        //        {
        //            aluno.nome = partes[i + 1 + c];
        //            aluno.cpf = partes[i + 2 + c];
        //            aluno.telefone = partes[i + 3 + c];
        //            aluno.codigo = int.Parse(partes[i + 4 + c]);
        //            aluno.estudantes.Add(aluno);
        //            c++;
        //        }
        //        alunos.Add(aluno);
        //    }
        //}
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
            Console.WriteLine("|5- Cadastrar Turma \t\t                     |");
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|6- Cadastrar Matéria \t\t                     |");
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
                    CarregarArquivosAlunos();
                    
                    break;
                case "5":
                    InserirTurma();
                    break;
                case "6":
                    InserirMateria();
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