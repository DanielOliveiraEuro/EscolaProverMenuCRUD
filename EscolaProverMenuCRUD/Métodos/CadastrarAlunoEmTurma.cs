//using EscolaProverMenuCRUD.Classes;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EscolaProverMenuCRUD;

//partial class Program
//{
//    static void InserirEmTurma()
//    {
//        Console.Clear();

//        Console.WriteLine("|----------------------------------------------------|");
//        Console.WriteLine("|                                                    |");
//        Console.WriteLine("|\t   CADASTRAR\t\tESCOLAPROVER\t     |");
//        Console.WriteLine("|        Digite 0 para voltar ao menu inicial        |");
//        Console.WriteLine("|----------------------------------------------------|");
//        try
//        {
//            SqlConnection sqlConnection;
//            string connectionString = @"Data Source=DESKTOP-BRDOPT0;Initial Catalog=EscolaProver;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

//            sqlConnection = new SqlConnection(connectionString);
//            sqlConnection.Open();
//            //Console.WriteLine("Conexão Criada.");
//            //Console.ReadKey();
//            //string insertQuery = $"insert into dbo.{turma1.TurmaNome} (TurmaNome) VALUES ('AlunoId')";
//            string selectQuery = $"select AlunoId from dbo.Alunos";
//            SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);
//            selectCommand.ExecuteNonQuery();
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine("Conexão Falhou.");
//            Console.WriteLine(ex.Message);
//            Console.ReadKey();
//        }
//        foreach (Aluno aluno in alunos)
//        {
//            foreach (Aluno aluno1 in aluno.estudantes)
//            {
//                Console.WriteLine("|\tAluno          {0}         ", aluno1.nome);
//                Console.WriteLine("|\tCódigo         {0}         ", aluno1.codigo);
//            }
//            Console.WriteLine("                                                      ");
//            Console.WriteLine("|----------------------------------------------------|");
//        }

//        Console.WriteLine("| Insira o código do aluno que deseja consultar:               |");

//        string nome = Console.ReadLine();
//        if (nome == "0")
//        {
//            Escolher();
//        }

//        bool encontrado = false;
//        int count = 0;
//        int countAlterar = 0;
//        string linha;
//        Aluno aluno1 = new Aluno();
//        foreach (Aluno aluno in alunos)
//        {
//            if (aluno.codigo == int.Parse(nome))
//            {
//                countAlterar = count;
//                encontrado = true;

//                Console.Clear();

//                Console.WriteLine("|----------------------------------------------------|");
//                Console.WriteLine("|                                                    |");
//                Console.WriteLine("|\t    CADASTRAR\tESCOLAPROVER\t     |");
//                Console.WriteLine("|        Digite 0 para voltar ao menu inicial        |");
//                Console.WriteLine("|----------------------------------------------------|");
//                Console.WriteLine("|\n| O aluno {0} foi encontrado.", aluno.nome);
//                Console.WriteLine("|\n| Deseja inserí-lo em alguma turma? s p/ sim");

//                if (Console.ReadLine().ToLower() == "s")
//                {
//                    Console.Clear();

//                    Console.WriteLine("|----------------------------------------------------|");
//                    Console.WriteLine("|                                                    |");
//                    Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t     |");
//                    Console.WriteLine("|        Digite 0 para voltar ao menu inicial        |");
//                    Console.WriteLine("|----------------------------------------------------|");
//                    Console.WriteLine("| Escreva o nome da turma que quer cadastrá-lo: \t");

//                    try
//                    {
//                        nome = Console.ReadLine();
//                        if (nome == "0")
//                        {
//                            Escolher();
//                        }
//                    }
//                    catch (FormatException)
//                    {
//                        Console.WriteLine("Não permitido caracteres especiais. Aperte enter para tentar novamente.");
//                    }
//                    if (nome == turma1.TurmaNome)
//                    {
                        
//                    }
//                }
//}
