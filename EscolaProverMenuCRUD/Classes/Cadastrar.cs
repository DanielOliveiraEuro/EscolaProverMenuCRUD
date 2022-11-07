using Caelum.Stella.CSharp.Validation;
using EscolaProverMenuCRUD.Classes;
using EscolaProverMenuCRUD.Validacao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaProverMenuCRUD
{
    partial class Program
    {
        static void Inserir()
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

                Aluno aluno1 = new Aluno();
                Console.WriteLine("|                                                    |");
                Console.Write("| Escreva o nome do aluno: \t\t");
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
                        Inserir();
                    }
                }
                catch (FormatException ex)
                {
                    if (aluno1.nome.Equals(aluno1.nome.ToLower()) /*|| aluno1.cpf.Equals(aluno1.cpf.ToLower()) || aluno1.telefone.Equals(aluno1.telefone.ToLower())*/)
                    {
                        Console.WriteLine("Não permitido caracteres especiais.Aperte enter para tentar novamente.");
                        Console.ReadLine();
                        Inserir();
                        throw new Exception(ex.Message);

                    }

                }
                if (aluno1.nome == "" || aluno1.cpf == "" || aluno1.telefone == "")
                {
                    Console.WriteLine("O nome não pode ser nulo, digite enter para continuar.");
                    Console.ReadLine();
                    Inserir();
                }
                Console.Write("|\n| CPF do aluno(apenas números): \t");
                aluno1.cpf = Console.ReadLine();
                long n;
                var isNumeric = long.TryParse(aluno1.cpf, out n);
                if (aluno1.cpf == "0")
                {
                    Escolher();
                }
                foreach (Aluno aluno in alunos)
                {
                    while (aluno1.cpf == aluno.cpf || isNumeric == false || aluno1.cpf.Length != 11 || ValidaCPF.IsCpf(aluno1.cpf) == false)
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
                    }
                    //Console.WriteLine("|\n| O CPF deve conter 11 numeros.E deve ser um CPF válido. \t");
                    //Console.ReadLine();
                    Console.Clear();
                        if (aluno1.cpf == aluno.cpf)
                        {
                            Console.WriteLine("Já existe um aluno com esse CPF cadastrado, tente novamente.");
                        }
                    Console.Write("|\n| CPF do aluno(apenas números): \t");
                    aluno1.cpf = Console.ReadLine();
                    isNumeric = long.TryParse(aluno1.cpf, out n);
                    if (aluno1.cpf == "0")
                    {
                        Escolher();
                    }
                }
                }

                //foreach (Aluno aluno in alunos)
                //{
                //    while ( aluno1.cpf == aluno.cpf || isNumeric == false || aluno1.cpf.Length != 11 || ValidaCPF.IsCpf(aluno1.cpf) == false)
                //    {
                //        Console.WriteLine("|\n| Este CPF já está cadastrado. Digite novamente.");
                //        Console.ReadLine();
                //        Console.Clear();
                //        Console.Write("|\n| CPF do aluno(apenas números): \t");
                //        aluno1.cpf = Console.ReadLine();
                //        //while (isNumeric == false || aluno1.cpf.Length != 11 || ValidaCPF.IsCpf(aluno1.cpf) == false)
                //        //{
                //            //Console.WriteLine("|\n| O CPF deve conter 11 numeros.E deve ser um CPF válido. \t");
                //            //Console.Write("|\n| CPF do aluno(apenas números): \t");
                //            //aluno1.cpf = Console.ReadLine();
                //            isNumeric = long.TryParse(aluno1.cpf, out n);
                //            if (aluno1.cpf == "0")
                //            {
                //                Escolher();
                //            }
                //        //}
                //    }
                //}
                //if (Validacao.ValidaCPF.IsCpf(aluno1.cpf) == false)
                //{
                //    Console.WriteLine("|\n| CPF não é valido. Insira um CPF válido.");
                //    Console.Write("|\n| CPF do aluno(apenas números): \t");
                //    aluno1.cpf = Console.ReadLine();
                //}

                //while (aluno1.cpf.Length != 11)
                //{
                //    Console.WriteLine("CPF deve conter 11 digitos.Tecle enter para continuar.");
                //    Console.ReadLine();
                //    Console.Write("|\n| CPF do aluno(apenas números): \t");
                //    aluno1.cpf = Console.ReadLine();
                //}
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


                foreach (Aluno aluno in alunos)
                {
                    if (aluno.nome.ToLower().Contains(aluno1.nome.ToLower()))
                    {
                        encontrado = true;
                        Console.Clear();

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|\t    CADASTRO\t\tEscolaProver\t     |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|\n| O aluno {0} já foi adicionada.", aluno.nome);

                        Console.WriteLine("|\n|\n| Escolha a opção:");
                        Console.WriteLine("|\n| 1- Adicionar outro aluno\n| 2- Menu incial");
                        Console.Write("|\n|Insira a Opção:");
                        string opcao = Console.ReadLine();
                        if (opcao == "1")
                        {
                            Inserir();
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
                    string linha = aluno1.nome + "|";
                    for (int i = 0; i < 1; i++)
                    {
                        //Turma turma = new Turma();
                        //Console.Write("|\n| Nome inteiro do aluno: \t");
                        //aluno1.nome = Console.ReadLine();
                        Random random = new Random();
                        //Console.Write("|\n| CPF do aluno(apenas números): \t");
                        //aluno1.cpf = Console.ReadLine();
                        //Console.Write("|\n| Telefone do aluno(apenas números): \t");
                        //aluno1.telefone = Console.ReadLine();
                        //Console.Write("|\n| Código do aluno: \t");
                        aluno1.codigo = random.Next(1, 500);
                        //Console.Write("|\n| Matéria do aluno: \t");
                        //aluno1.materia = Console.ReadLine();
                        //Console.WriteLine("|\n| Turma do aluno: \t");
                        //aluno1.turma = Console.ReadLine();
                        linha += aluno1.nome + "|" + aluno1.cpf + "|" + aluno1.telefone + "|" + aluno1.codigo + "|"/* + aluno1.materia + "|" + aluno1.turma + "|"*/;
                        aluno1.estudantes.Add(aluno1);
                    }
                    alunos.Add(aluno1);
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
                    Console.WriteLine("|\n| Deseja continuar inserindo alunos? s p/ sim e n p/ não: \t");
                }
            } while (Console.ReadLine().ToLower() == "s");
            Console.Clear();
            Escolher();
        }
    }
}
