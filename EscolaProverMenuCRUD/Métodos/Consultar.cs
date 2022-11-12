using EscolaProverMenuCRUD.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaProverMenuCRUD
{
    partial class Program
    {
        static void Consultar()
        {
            Console.Clear();

            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|\t   CONSULTA\t\tESCOLAPROVER\t     |");
            Console.WriteLine("|        Digite 0 para voltar ao menu inicial        |");
            Console.WriteLine("|----------------------------------------------------|");
            foreach (Aluno aluno in alunos)
            {
                foreach (Aluno aluno1 in aluno.estudantes)
                {
                    Console.WriteLine("|\tAluno          {0}         ", aluno1.nome);
                    Console.WriteLine("|\tCódigo         {0}         ", aluno1.codigo);
                }
                Console.WriteLine("                                                      ");
                Console.WriteLine("|----------------------------------------------------|");
            }

            Console.WriteLine("| Insira o código do aluno que deseja consultar:               |");
            string nome = Console.ReadLine();
            bool encontrado = false;
            if (nome == "0")
            {
                Escolher();
            }
            foreach (Aluno aluno in alunos)
            {
                if (aluno.codigo == int.Parse(nome))
                {
                    
                    encontrado = true;

                    Console.Clear();

                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|\t   CONSULTA\t\tESCOLAPROVER\t     |");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|----------------------------------------------------|\n");
                    Console.WriteLine("  {0} foi encontrado no banco de dados.\n", aluno.nome);
                    Console.WriteLine("|----------------------------------------------------|");

                    foreach (Aluno aluno1 in aluno.estudantes)
                    {

                        Console.WriteLine("|\tAluno          {0}         ", aluno1.nome);
                        Console.WriteLine("|\tCPF            {0}          ", Convert.ToUInt64(aluno1.cpf).ToString(@"000\.000\.000\-00"));
                        Console.WriteLine("|\tTelefone       {0}         ", Convert.ToUInt64(aluno1.telefone).ToString(@"(00)00000-0000"));
                        Console.WriteLine("|\tCódigo         {0}         ", aluno1.codigo);
                    }
                    Console.WriteLine(" ---------------------------------------------------- ");
                    Console.WriteLine(" \n \n  Escolha a opção:");
                    Console.WriteLine(" \n  1-Voltar p/Consultar \n  2-Ir ao Menu incial");
                    Console.Write(" \n  Insira a Opção:");
                    string opcao = Console.ReadLine();
                    if (opcao == "1")
                    {
                        try
                        {
                            Consultar();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Erro encontrado.");
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (opcao == "2")
                    {
                        try
                        {
                            Escolher();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Erro encontrado.");
                            Console.WriteLine(ex.Message);
                        }
                    }
                    Console.ReadKey();
                }
                foreach (Aluno aluno2 in aluno.estudantes)
                {
                    if (aluno2.nome.ToLower().Contains(nome.ToLower()))
                    {
                        encontrado = true;
                        Console.Clear();

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|\t   CONSULTA\t\tESCOLAPROVER\t     |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("| Aluno Encontrado.");
                        Console.WriteLine("|\n| Aluno: {0}\n| CPF do aluno: {1}", aluno2.nome, aluno2.cpf);
                        Console.WriteLine("|\n|\n| Escolha a opção:");
                        Console.WriteLine("|\n| 1-Voltar p/Consultar \n| 2-Ir ao Menu incial");
                        Console.Write("|\n| Insira a Opção:");
                        string opcao = Console.ReadLine();
                        if (opcao == "1")
                        {
                            try
                            {
                                Consultar();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Erro encontrado.");
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (opcao == "2")
                        {
                            try
                            {
                                Escolher();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Erro encontrado.");
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
            }
            if (!encontrado)
            {
                Console.Clear();

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t   CONSULTA\t\tESCOLAPROVER\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.WriteLine("|\n| {0} não existe no banco de dados.", nome);
                Console.WriteLine("|\n|\n|\n| Escolha a opção:");
                Console.WriteLine("|\n| 1   -Voltar p/Consultar \n| 2-Ir ao Menu incial");
                Console.WriteLine("|");
                Console.Write("| Insira a Opção:");
                string opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    try
                    {
                        Consultar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro encontrado.");
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (opcao == "2")
                {
                    try
                    {
                        Escolher();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro encontrado.");
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
