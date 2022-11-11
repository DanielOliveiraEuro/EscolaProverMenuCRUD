using Caelum.Stella.CSharp.Validation;
using EscolaProverMenuCRUD.Classes;
using EscolaProverMenuCRUD.Validacao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaProverMenuCRUD
{
    partial class Program
    {
        static void AlterarRemover()
        {
            Console.Clear();

            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|\t    ESCOLHER\t\tEscolaProver\t     |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| Escolha qual opção deseja:                         |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| 1- Alterar\t\t\t\t\t     |\n| 2- Remover\t\t\t\t\t     |\n| 3- Excluir Todos\t\t\t\t     |\n| 4- Ir ao Menu inicial\t\t\t\t     |");
            Console.WriteLine("|                                                    |");
            Console.Write("| Insira a Opção:");

            string opcao = Console.ReadLine();
            if (opcao == "1")
            {
                Console.Clear();

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t     |");
                Console.WriteLine("|        Digite 0 para voltar ao menu inicial        |");
                Console.WriteLine("|----------------------------------------------------|");

                foreach (Aluno aluno in alunos)
                {
                    foreach (Aluno aluno2 in aluno.estudantes)
                    {
                        Console.WriteLine("|\tAluno          {0}         ", aluno2.nome);
                        Console.WriteLine("|\tCódigo         {0}         ", aluno2.codigo);
                    }
                    Console.WriteLine("                                                      ");
                    Console.WriteLine("|----------------------------------------------------|");
                }

                Console.Write("| Insira o código do aluno que quer alterar: ");

                string nome = Console.ReadLine();
                if (nome == "0")
                {
                    Escolher();
                }

                bool encontrado = false;
                int count = 0;
                int countAlterar = 0;
                string linha;
                Aluno aluno1 = new Aluno();
                foreach (Aluno aluno in alunos)
                {
                    if (aluno.codigo == int.Parse(nome))
                    {
                        countAlterar = count;
                        encontrado = true;

                        Console.Clear();

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t     |");
                        Console.WriteLine("|        Digite 0 para voltar ao menu inicial        |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|\n| O aluno {0} foi encontrado.", aluno.nome);
                        Console.WriteLine("|\n| Deseja alterá-lo? s p/ sim");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            Console.Clear();

                            Console.WriteLine("|----------------------------------------------------|");
                            Console.WriteLine("|                                                    |");
                            Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t     |");
                            Console.WriteLine("|        Digite 0 para voltar ao menu inicial        |");
                            Console.WriteLine("|----------------------------------------------------|");
                            Console.WriteLine("| Escreva o nome do aluno: \t");
                            try
                            {
                                aluno1.nome = Console.ReadLine();
                                if (aluno1.nome == "0")
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
                                int valor = int.Parse(aluno1.nome);
                                if (aluno1.nome == "0")
                                {
                                    Escolher();
                                }
                                if (valor is int)
                                {
                                    Console.WriteLine("O valor deve ser textual, digite enter para continuar.");
                                    Console.ReadLine();
                                    AlterarRemover();
                                }
                            }
                            catch (FormatException ex)
                            {
                                if (aluno1.nome.Equals(aluno1.nome.ToLower()))
                                {
                                    Console.WriteLine("Não permitido caracteres especiais.Aperte enter para tentar novamente.");
                                    Console.ReadLine();
                                    AlterarRemover();
                                    throw new Exception(ex.Message);

                                }

                            }
                            if (aluno1.nome == "" || aluno1.cpf == "" || aluno1.telefone == "")
                            {
                                Console.WriteLine("O nome não pode ser nulo, digite enter para continuar.");
                                Console.ReadLine();
                                AlterarRemover();
                            }
                            Console.Write("|\n| CPF do aluno(apenas números): \t");

                            aluno1.cpf = Console.ReadLine();
                            while (aluno1.cpf == aluno.cpf)
                            {
                                Console.WriteLine("|\n| Alterar para o mesmo CPF não é permitido, digite um CPF diferente.");
                                Console.ReadLine();
                                Console.Clear();
                                Console.Write("|\n| CPF do aluno(apenas números): \t");
                                aluno1.cpf = Console.ReadLine();
                                if (aluno1.cpf == "0")
                                {
                                    Escolher();
                                }
                            }
                            long n;
                            var isNumeric = long.TryParse(aluno1.cpf, out n);
                            if (aluno1.cpf == "0")
                            {
                                Escolher();
                            }
                            foreach (Aluno aluno2 in alunos)
                            {
                                while (aluno2.cpf == aluno1.cpf)
                                {
                                    Console.WriteLine("|\n| Este CPF já está cadastrado. Digite novamente.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    Console.Write("|\n| CPF do aluno(apenas números): \t");
                                    aluno1.cpf = Console.ReadLine();
                                    while (isNumeric == false || aluno1.cpf.Length != 11 || ValidaCPF.IsCpf(aluno1.cpf) == false)
                                    {
                                        Console.WriteLine("|\n| O CPF deve conter 11 numeros.E deve ser um CPF válido. \t");
                                        Console.Write("|\n| CPF do aluno(apenas números): \t");
                                        aluno1.cpf = Console.ReadLine();
                                        isNumeric = long.TryParse(aluno1.cpf, out n);
                                        if (aluno1.cpf == "0")
                                        {
                                            Escolher();
                                        }
                                    }
                                }
                            }
                            if (aluno1.cpf == aluno.cpf)
                            {
                                Console.WriteLine("|\n| Este CPF já está cadastrado. Digite novamente.");
                                Console.ReadLine();
                                Console.Clear();
                                Console.Write("|\n| CPF do aluno(apenas números): \t");
                                aluno1.cpf = Console.ReadLine();
                                while (isNumeric == false || aluno1.cpf.Length != 11 || ValidaCPF.IsCpf(aluno1.cpf) == false)
                                {
                                    Console.WriteLine("|\n| O CPF deve conter 11 numeros.E deve ser um CPF válido. \t");
                                    Console.Write("|\n| CPF do aluno(apenas números): \t");
                                    aluno1.cpf = Console.ReadLine();
                                    isNumeric = long.TryParse(aluno1.cpf, out n);
                                    if (aluno1.cpf == "0")
                                    {
                                        Escolher();
                                    }
                                }
                            }

                            while (isNumeric == false || aluno1.cpf.Length != 11 || ValidaCPF.IsCpf(aluno1.cpf) == false)
                            {
                                try
                                {
                                    new CPFValidator().AssertValid(aluno1.cpf);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("CPF inválido, por favor verifique-o. Aperte enter para continuar.");
                                    Console.WriteLine(ex.Message);
                                    Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("|\n| Digite o CPF novamente");
                                    aluno1.cpf = Console.ReadLine();
                                }
                                isNumeric = long.TryParse(aluno1.cpf, out n);
                                if (aluno1.cpf == "0")
                                {
                                    Escolher();
                                }
                                while (isNumeric == false || aluno1.cpf.Length != 11 || ValidaCPF.IsCpf(aluno1.cpf) == false)
                                {
                                    Console.WriteLine("|\n| O CPF deve conter 11 numeros.E deve ser um CPF válido. \t");
                                    Console.ReadLine();
                                    Console.Clear();
                                    Console.Write("|\n| CPF do aluno(apenas números): \t");
                                    aluno1.cpf = Console.ReadLine();
                                    isNumeric = long.TryParse(aluno1.cpf, out n);
                                    if (aluno1.cpf == "0")
                                    {
                                        Escolher();
                                    }
                                }
                            }
                            Console.Write("|\n| Celular do aluno(apenas números): \t");
                            aluno1.telefone = Console.ReadLine();
                            var isNumerico = long.TryParse(aluno1.telefone, out n);
                            if (aluno1.telefone == "0")
                            {
                                Escolher();
                            }
                            while (isNumerico == false || aluno1.telefone.Length != 11)
                            {
                                Console.WriteLine("|\n| Celular deve conter 11 digitos.Tecle enter para recomeçar. \t");
                                Console.Write("|\n| Celular(apenas números): \t");
                                aluno1.telefone = Console.ReadLine();
                                isNumerico = long.TryParse(aluno1.telefone, out n);
                                if (aluno1.telefone == "0")
                                {
                                    Escolher();
                                }
                            }
                            try
                            {
                                SqlConnection sqlConnection;
                                string connectionString = @"Data Source=DESKTOP-4N1BV2V\SQLSERVER;Initial Catalog=EscolaProverDados;Integrated Security=True";

                                sqlConnection = new SqlConnection(connectionString);
                                sqlConnection.Open();
                                string updateQuery = $"update dbo.Alunos set Nome = '{aluno1.nome}', CPF = '{aluno1.cpf}', Celular = '{aluno1.telefone}' WHERE Nome = '{aluno.nome}'";
                                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                                updateCommand.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Operação Falhou.");
                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                            }

                            linha = aluno1.nome + "|";
                            Random random = new Random();
                            aluno1.codigo = random.Next(1, 500);
                            linha += aluno1.nome + "|" + aluno1.cpf + "|" + aluno1.telefone + "|" + aluno1.codigo + "|";
                            aluno1.estudantes.Add(aluno1);

                        }
                        else
                        {
                            AlterarRemover();
                        }
                    }
                    count++;
                }
                if (!encontrado)
                {
                    Console.Clear();

                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t     |");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|----------------------------------------------------|");

                    Console.WriteLine("|\n|\n| Item {0} não existe!", nome);
                    Console.WriteLine("|\n|\n| Escolha a opção:");
                    Console.WriteLine("|\n| 1-Voltar a Alterar ou Remover \n| 2-Ir ao Menu incial");
                    Console.Write("|\n| Insira a Opção:");
                    opcao = Console.ReadLine();
                    if (opcao == "1")
                    {
                        AlterarRemover();
                    }
                    else if (opcao == "2")
                    {
                        Escolher();
                    }
                }
                else
                {
                    alunos[countAlterar] = aluno1;
                }
                if (File.Exists(Ficheiro))
                {
                    file = new StreamWriter(Ficheiro);
                    foreach (Aluno aluno in alunos)
                    {
                        linha = aluno.nome + "|";
                        foreach (Aluno aluno2 in aluno.estudantes)
                        {
                            linha += aluno2.nome + "|" + aluno2.cpf + "|" + aluno2.telefone + "|" + aluno2.codigo + "|";
                        }
                        file.WriteLine(linha);
                    }
                    file.Close();
                }
                else
                {
                    file = File.CreateText(Ficheiro);
                }
                Console.Clear();

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|\n| Aluno alterado com sucesso!");
                Console.WriteLine("|\n|\n| Escolha a opção:");
                Console.WriteLine("|\n| 1-Voltar a Alterar ou Remover \n| 2-Ir ao Menu incial");
                Console.Write("|\n| Insira a Opção:");
                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    AlterarRemover();
                }
                else if (opcao == "2")
                {
                    Escolher();
                }
            }
            else if (opcao == "2")
            {
                Console.Clear();

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    REMOVER ALUNO\tESCOLAPROVER\t     |");
                Console.WriteLine("|        Digite 0 para voltar ao menu inicial        |");
                Console.WriteLine("|----------------------------------------------------|");
                foreach (Aluno aluno in alunos)
                {
                    foreach (Aluno aluno2 in aluno.estudantes)
                    {
                        Console.WriteLine("|\tAluno          {0}         ", aluno2.nome);
                        Console.WriteLine("|\tCódigo         {0}         ", aluno2.codigo);
                    }
                    Console.WriteLine("                                                      ");
                    Console.WriteLine("|----------------------------------------------------|");
                }
                Console.WriteLine("| Insira código do aluno que quer deletar:");
                string nome = Console.ReadLine();
                if (nome == "0")
                {
                    Escolher();
                }
                bool encontrado = false;
                string linha;
                foreach (Aluno aluno in alunos)
                {
                    if (aluno.codigo == int.Parse(nome))
                    {
                        encontrado = true;

                        Console.Clear();

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|\t    REMOVER ALUNO\tESCOLAPROVER\t     |");
                        Console.WriteLine("|        Digite 0 para voltar ao menu inicial        |");
                        Console.WriteLine("|----------------------------------------------------|");

                        Console.WriteLine("| Aluno {0} existe e pode ser removido.", aluno.nome);
                        Console.WriteLine("|\n| Deseja remover o aluno {0}? s p/ sim e n p/ não", aluno.nome);
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            
                            try
                            {
                                SqlConnection sqlConnection;
                                string connectionString = @"Data Source=DESKTOP-4N1BV2V\SQLSERVER;Initial Catalog=EscolaProverDados;Integrated Security=True";

                                sqlConnection = new SqlConnection(connectionString);
                                sqlConnection.Open();
                                string deleteQuery = $"delete from dbo.Alunos where Nome = '{aluno.nome}'";
                                SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                                deleteCommand.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Operação Falhou.");
                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                            }
                            alunos.Remove(aluno);
                            break;
                        }
                        else if (Console.ReadLine() == "n")
                        {
                            Escolher();
                        }
                    }
                }
                if (!encontrado)
                {
                    Console.Clear();

                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|\t    REMOVER ALUNO\tESCOLAPROVER\t     |");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|----------------------------------------------------|");

                    Console.WriteLine("|\n|\n| Item {0} não existe!", nome);
                    Console.WriteLine("|\n|\n| Escolha a opção:");
                    Console.WriteLine("|\n| 1-Voltar a Alterar ou Remover \n| 2-Ir ao Menu incial");
                    Console.Write("|\n| Insira a Opção:");
                    opcao = Console.ReadLine();
                    if (opcao == "1")
                    {
                        AlterarRemover();
                    }
                    else if (opcao == "2")
                    {
                        Escolher();
                    }
                }
                if (File.Exists(Ficheiro))
                {
                    file = new StreamWriter(Ficheiro);
                    foreach (Aluno aluno in alunos)
                    {
                        linha = aluno.nome + "|";
                        foreach (Aluno aluno1 in aluno.estudantes)
                        {
                            linha += aluno1.nome + "|" + aluno1.cpf + "|" + aluno1.telefone + "|" + aluno1.codigo + "|";
                        }
                        file.WriteLine(linha);
                    }
                    file.Close();
                }
                else
                {
                    file = File.CreateText(Ficheiro);
                }
                Console.Clear();

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    REMOVER ALUNO\tESCOLAPROVER\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.WriteLine("|\n|\n| Operação bem-sucedida!");
                Console.WriteLine("|\n|\n| Escolha a opção:");
                Console.WriteLine("|\n| 1-Voltar a Alterar ou Remover \n| 2-Ir ao Menu incial");
                Console.Write("|\n| Insira a Opção:");
                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    AlterarRemover();
                }
                else if (opcao == "2")
                {
                    Escolher();
                }
            }
            else if (opcao == "3")
            {
                Console.Clear();

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.WriteLine("Deseja excluir todos os alunos? s p/ sim n p/ não");
                string excluir = Console.ReadLine();
                if (excluir == "s")
                {
                    alunos.Clear();
                    File.Delete(Ficheiro);
                    Console.WriteLine("Todos os dados foram excluídos. Aperte enter para continuar.");
                    Console.ReadLine();

                }
                else if (excluir == "n")
                {
                    Escolher();
                }
            }
        }
    }
}
