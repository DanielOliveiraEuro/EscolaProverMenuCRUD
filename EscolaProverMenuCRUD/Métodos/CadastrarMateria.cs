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
        static void InserirMateria()
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

                Materia materia1 = new Materia();
                Console.WriteLine("|                                                    |");
                Console.Write("| Escreva o nome da matéria: \t\t");
                try
                {
                    materia1.MateriaNome = Console.ReadLine();
                    if (materia1.MateriaNome == "0")
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
                    int valor = int.Parse(materia1.MateriaNome);
                    if (materia1.MateriaNome == "0")
                    {
                        Escolher();
                    }
                    if (valor is int)
                    {
                        Console.WriteLine("O valor deve ser textual, digite enter para continuar.");
                        Console.ReadLine();
                        InserirMateria();
                    }
                }
                catch (FormatException ex)
                {
                    if (materia1.MateriaNome.Equals(materia1.MateriaNome.ToLower()))
                    {
                        Console.WriteLine("Não permitido caracteres especiais.Aperte enter para tentar novamente.");
                        Console.ReadLine();
                        InserirMateria();
                        throw new Exception(ex.Message);
                    }

                }
                if (materia1.MateriaNome == "")
                {
                    Console.WriteLine("O nome não pode ser nulo, digite enter para continuar.");
                    Console.ReadLine();
                    InserirMateria();
                }
                //foreach (Materia materia in materias)
                //{
                //    if (materia1.MateriaNome.ToLower().Contains(materia1.MateriaNome.ToLower()))
                //    {
                //        encontrado = true;
                //        Console.Clear();

                //        Console.WriteLine("|----------------------------------------------------|");
                //        Console.WriteLine("|                                                    |");
                //        Console.WriteLine("|\t    CADASTRO\t\tEscolaProver\t     |");
                //        Console.WriteLine("|                                                    |");
                //        Console.WriteLine("|----------------------------------------------------|");
                //        Console.WriteLine("|\n| A matéria {0} já foi adicionada.", materia1.MateriaNome);

                //        Console.WriteLine("|\n|\n| Escolha a opção:");
                //        Console.WriteLine("|\n| 1- Adicionar outra materia\n| 2- Menu incial");
                //        Console.Write("|\n|Insira a Opção:");
                //        string opcao = Console.ReadLine();
                //        if (opcao == "1")
                //        {
                //            InserirMateria();
                //        }
                //        else if (opcao == "2")
                //        {
                //            Escolher();
                //        }
                //        else
                //        {
                //            Console.WriteLine("Opção Inválida!!");
                //        }
                //    }
                //}
                //if (!encontrado)
                //{
                //    string linha = materia1.MateriaNome + "|";
                //    for (int i = 0; i < 1; i++)
                //    {
                //        linha += materia1.MateriaNome + "|" + materia1.MateriaNome + "|";
                //        materia1.materias.Add(materia1);
                //    }
                //    materias.Add(materia1);
                //    if (File.Exists(Ficheiro))
                //    {
                //        file = File.AppendText(Ficheiro);
                //    }
                //    else
                //    {
                //        file = File.CreateText(Ficheiro);
                //    }
                //    file.WriteLine(linha);
                //    file.Close();
                //    Console.WriteLine("|\n| Deseja continuar inserindo alunos? s p/ sim e n p/ não: \t");
                //}
            }
            while (Console.ReadLine().ToLower() == "s");
            Console.Clear();
            Escolher();
        }
    }
}
