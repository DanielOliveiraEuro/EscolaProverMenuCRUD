using EscolaProverMenuCRUD.Classes;
using System;
using System.Collections;
using System.IO;

namespace EscolaProverMenuCRUD
{
    class Program
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
                        Turma turma = new Turma();
                        turma.nome = partes[i + 1 + c];
                        turma.cpf = partes[i + 2 + c];
                        turma.telefone = partes[i + 3 + c];
                        turma.codigo = partes[i + 4 + c];
                        turma.materia = partes[i + 5 + c];
                        turma.estudantes.Add(aluno);
                        c++;
                    }
                    alunos.Add(aluno);
                }
            }
        }
        static void Escolher()
        {
            char opcao = ' ';
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
                opcao = char.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case '1':
                        Inserir();
                        break;
                    case '2':
                        AlterarRemover();
                        break;
                    case '3':
                        Consultar();
                        break;
                    case '4':
                        Listar();
                        break;
                    default:
                        if (opcao != '0')
                        {
                            Console.WriteLine("Opção Inválida!!");
                        }
                        break;
                }
            } while (opcao != '0');
        }
        static void Inserir()
        {
            do
            {
                Console.Clear();
                bool encontrado = false;

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    CADASTRO\t\tEscolaProver\t\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Aluno aluno1 = new Aluno();
                Console.WriteLine("|                                                    |");
                Console.Write("| Escreva o nome do aluno de forma abreviada: \t\t");
                aluno1.nome = Console.ReadLine();

                foreach (Aluno aluno in alunos)
                {
                    if (aluno.nome.ToLower().Contains(aluno1.nome.ToLower()))
                    {
                        encontrado = true;
                        Console.Clear();

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|\t    CADASTRO\t\tEscolaProver\t\t     |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|\n| O aluno {0} já foi adicionada.", aluno.nome);

                        Console.WriteLine("|\n|\n| Escolha a opção:");
                        Console.WriteLine("|\n| 1- Adicionar outra turma\n| 2- Menu incial");
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
                        Turma turma = new Turma();
                        Console.Write("|\n| Nome inteiro do aluno: \t");
                        turma.nome = Console.ReadLine();
                        Console.Write("|\n| CPF do aluno: \t");
                        turma.cpf = Console.ReadLine();
                        Console.Write("|\n| Telefone do aluno: \t");
                        turma.telefone = Console.ReadLine();
                        Console.Write("|\n| Código do aluno: \t");
                        turma.codigo = Console.ReadLine();
                        Console.Write("|\n| Matéria do aluno: \t");
                        turma.materia = Console.ReadLine();
                        Console.WriteLine("|\n| Turma do aluno: \t");
                        turma.turma = Console.ReadLine();
                        linha += turma.nome + "|" + turma.cpf + "|" + turma.telefone + "|" + turma.codigo + "|" + turma.materia + "|" + turma.turma + "|";
                        aluno1.estudantes.Add(turma);
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
                    Console.WriteLine("|\n| Deseja continuar inserindo alunos? s p/ sim: \t");
                }
            } while (Console.ReadLine().ToLower() == "s");
            Console.Clear();
            Escolher();
        }
        static void AlterarRemover()
        {
            Console.Clear();

            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|\t    ESCOLHER\t\tEscolaProver\t\t     |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| Escolha qual opção deseja:                         |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| 1- Alterar\t\t\t\t\t     |\n| 2- Remover\t\t\t\t\t     |\n| 3- Ir ao Menu inicial\t\t\t\t     |");
            Console.WriteLine("|                                                    |");
            Console.Write("| Insira a Opção:");

            string opcao = Console.ReadLine();
            if (opcao == "1")
            {
                Console.Clear();

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.Write("| Insira o nome do aluno que quer alterar: ");
                string nome = Console.ReadLine();
                bool encontrado = false;
                int count = 0;
                int countAlterar = 0;
                string linha;
                Aluno aluno1 = new Aluno();
                foreach (Aluno aluno in alunos)
                {
                    if (aluno.nome.ToLower().Contains(nome.ToLower()))
                    {
                        countAlterar = count;
                        encontrado = true;

                        Console.Clear();

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t\t     |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|\n| O aluno {0} foi encontrado.", aluno1.nome);
                        Console.WriteLine("|\n| Deseja alterá-lo? s p/ sim");
                        if (Console.ReadLine().ToLower() == "s") //caso a resposta seja "S" 
                        {
                            Console.Clear();

                            Console.WriteLine("|----------------------------------------------------|");
                            Console.WriteLine("|                                                    |");
                            Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t\t     |");
                            Console.WriteLine("|                                                    |");
                            Console.WriteLine("|----------------------------------------------------|");
                            Console.WriteLine("| Escreva o nome de forma abreviada: \t\t");
                            aluno1.nome = Console.ReadLine();
                            linha = aluno1.nome + "|";
                            for (int i = 0; i < 1; i++)
                            {
                                Turma turma = new Turma();
                                Console.Write("|\n| Nome do aluno: \t");
                                turma.nome = Console.ReadLine();
                                Console.Write("|\n| CPF do aluno: \t");
                                turma.cpf = Console.ReadLine();
                                Console.Write("|\n| Telefone do aluno: \t");
                                turma.telefone = Console.ReadLine();
                                Console.Write("|\n| Código do aluno: \t");
                                turma.codigo = Console.ReadLine();
                                Console.Write("|\n| Matéria do aluno: \t");
                                turma.materia = Console.ReadLine();
                                linha += turma.nome + "|" + turma.cpf + "|" + turma.telefone + "|" + turma.codigo + "|" + turma.materia + "|";

                                aluno1.estudantes.Add(turma);
                            }
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
                    Console.WriteLine("|\t    ALTERAR ALUNO\tTURMA\t\t     |");
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
                        foreach (Turma turma in aluno.estudantes)
                        {
                            linha += turma.nome + "|" + turma.cpf + "|" + turma.telefone + "|" + turma.codigo + "|" + turma.materia + "|";
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
                Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t\t     |");
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
                Console.WriteLine("|\t    REMOVER ALUNO\tCBLOL\t\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.WriteLine("| Insira o nome do aluno que quer deletar:");
                string nome = Console.ReadLine();
                bool encontrado = false;
                string linha;
                foreach (Aluno aluno in alunos)
                {
                    if (aluno.nome.ToLower().Contains(nome.ToLower()))
                    {
                        encontrado = true;

                        Console.Clear();

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|\t    REMOVER ALUNO\tESCOLAPROVER\t\t     |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");

                        Console.WriteLine("| Aluno {0} existe e pode ser removido.", aluno.nome);
                        Console.WriteLine("|\n| Deseja remover a turma {0}? s p/ sim", aluno.nome);
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            alunos.Remove(aluno);
                            break;
                        }
                    }
                }
                if (!encontrado)
                {
                    Console.Clear();

                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|\t    REMOVER ALUNO\tESCOLAPROVER\t\t     |");
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
                        foreach (Turma turma in aluno.estudantes)
                        {
                            linha += turma.nome + "|" + turma.cpf + "|" + turma.telefone + "|" + turma.codigo + "|" + turma.materia + "|";
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
                Console.WriteLine("|\t    REMOVER ALUNO\tESCOLAPROVER\t\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.WriteLine("|\n|\n| Aluno removido com sucesso!");
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
                Escolher();
            }
        }
        static void Consultar()
        {
            Console.Clear();

            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|\t   CONSULTA\t\tESCOLAPROVER\t\t     |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|----------------------------------------------------|");

            Console.WriteLine("| Insira o aluno que deseja consultar:     |");
            string nome = Console.ReadLine();
            bool encontrado = false;
            foreach (Aluno aluno in alunos)
            {
                if (aluno.nome.ToLower().Contains(nome.ToLower()))
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
                    Console.WriteLine("|\tAlunos      Matéria\t      CPF\t|");
                    Console.WriteLine("|----------------------------------------------------|");

                    foreach (Turma turma in aluno.estudantes)
                    {
                        Console.WriteLine("     {0}   {1}\t{2}", aluno.nome, turma.materia, turma.cpf);
                    }
                    Console.WriteLine(" ---------------------------------------------------- ");
                    Console.WriteLine(" \n \n  Escolha a opção:");
                    Console.WriteLine(" \n  1-Voltar p/Consultar \n  2-Ir ao Menu incial");
                    Console.Write(" \n  Insira a Opção:");
                    string opcao = Console.ReadLine();
                    if (opcao == "1")
                    {
                        Consultar();
                    }
                    else if (opcao == "2")
                    {
                        Escolher();
                    }
                    Console.ReadKey();
                }
                foreach (Turma turma in aluno.estudantes)
                {
                    if (turma.nome.ToLower().Contains(nome.ToLower()))
                    {
                        encontrado = true;
                        Console.Clear();

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|\t   CONSULTA\t\tESCOLAPROVER\t\t     |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("| Aluno Encontrado.");
                        Console.WriteLine("|\n| Aluno: {0}\n| CPF do aluno: {1}", turma.nome, turma.cpf);
                        Console.WriteLine("|\n|\n| Escolha a opção:");
                        Console.WriteLine("|\n| 1-Voltar p/Consultar \n| 2-Ir ao Menu incial");
                        Console.Write("|\n| Insira a Opção:");
                        string opcao = Console.ReadLine();
                        if (opcao == "1")
                        {
                            Consultar();
                        }
                        else if (opcao == "2")
                        {
                            Escolher();
                        }
                    }
                }
            }
            if (!encontrado)
            {
                Console.Clear();

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t   CONSULTA\t\tESCOLAPROVER\t\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.WriteLine("|\n| {0} não existe no banco de dados.", nome);
                Console.WriteLine("|\n|\n|\n| Escolha a opção:");
                Console.WriteLine("|\n| 1-Voltar p/Consultar \n| 2-Ir ao Menu incial");
                Console.WriteLine("|");
                Console.Write("| Insira a Opção:");
                string opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    Consultar();
                }
                else if (opcao == "2")
                {
                    Escolher();
                }
            }
        }
        static void Listar()
        {
            Console.Clear();

            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|\t\tALUNOS\t\tESCOLAPROVER\t     |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|----------------------------------------------------|");
            
            Console.WriteLine("|----------------------------------------------------|");

            foreach (Aluno aluno in alunos)
            {
                foreach (Turma turma in aluno.estudantes)
                {
                    Console.WriteLine("|\tAluno          {0}         ", aluno.nome);
                    Console.WriteLine("|\tCPF            {0}          ", turma.cpf);
                    Console.WriteLine("|\tMatéria        {0}         ", turma.materia);
                }
                Console.WriteLine("                                                      ");
                Console.WriteLine("|----------------------------------------------------|");
            }
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| Aperte qualquer tecla para voltar ao menu inicial. |");
            Console.WriteLine("|----------------------------------------------------|");
            Console.ReadKey();
        }
    }
}