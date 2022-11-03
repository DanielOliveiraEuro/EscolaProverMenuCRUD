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
        static void Inserir()
        {
            do
            {
                Console.Clear();
                bool encontrado = false;

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    CADASTRO\t\tEscolaProver\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Aluno aluno1 = new Aluno();
                Console.WriteLine("|                                                    |");
                Console.Write("| Escreva o nome do aluno: \t\t");
                aluno1.nome = Console.ReadLine();
                if (aluno1.nome == "")
                {
                    Console.WriteLine("O nome não pode ser nulo, digite enter para continuar.");
                    Console.ReadLine();
                    Inserir();
                }
                try
                {
                    int valor = int.Parse(aluno1.nome);
                    if (valor is int)
                    {
                        Console.WriteLine("O valor deve ser textual, digite enter para continuar.");
                        Console.ReadLine();
                        Inserir();
                    }
                }
                catch (FormatException)
                {
                    if (aluno1.nome.Equals(aluno1.nome.ToLower()))
                    {
                        throw new ExcecaoMenu();
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
                        Console.WriteLine("|\n| 1- Adicionar outra aluno\n| 2- Menu incial");
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
                        Console.Write("|\n| CPF do aluno(Apenas números): \t");
                        aluno1.cpf = Console.ReadLine();
                        Console.Write("|\n| Telefone do aluno(Apenas números): \t");
                        aluno1.telefone = Console.ReadLine();
                        //Console.Write("|\n| Código do aluno: \t");
                        aluno1.codigo = random.Next();
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
            Console.WriteLine("|\t    ESCOLHER\t\tEscolaProver\t     |");
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
                Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t     |");
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
                        Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t     |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|\n| O aluno {0} foi encontrado.", aluno1.nome);
                        Console.WriteLine("|\n| Deseja alterá-lo? s p/ sim");
                        if (Console.ReadLine().ToLower() == "s") 
                        {
                            Console.Clear();

                            Console.WriteLine("|----------------------------------------------------|");
                            Console.WriteLine("|                                                    |");
                            Console.WriteLine("|\t    ALTERAR ALUNO\tESCOLAPROVER\t     |");
                            Console.WriteLine("|                                                    |");
                            Console.WriteLine("|----------------------------------------------------|");
                            Console.WriteLine("| Escreva o nome do aluno: \t\t");
                            aluno1.nome = Console.ReadLine();
                            linha = aluno1.nome + "|";
                            for (int i = 0; i < 1; i++)
                            {
                                //Turma turma = new Turma();
                                //Console.Write("|\n| Nome do aluno: \t");
                                //aluno1.nome = Console.ReadLine();
                                Random random = new Random();
                                Console.Write("|\n| CPF do aluno(apenas números): \t");
                                aluno1.cpf = Console.ReadLine();
                                Console.Write("|\n| Telefone do aluno(apenas números): \t");
                                aluno1.telefone = Console.ReadLine();
                                //Console.Write("|\n| Código do aluno: \t");
                                aluno1.codigo = random.Next();
                                //Console.Write("|\n| Matéria do aluno: \t");
                                //aluno1.materia = Console.ReadLine();
                                //Console.WriteLine("|\n| Turma do aluno: \t");
                                //aluno1.turma = Console.ReadLine();
                                linha += aluno1.nome + "|" + aluno1.cpf + "|" + aluno1.telefone + "|" + aluno1.codigo + "|"/* + aluno1.materia + "|" + aluno1.turma + "|"*/;

                                aluno1.estudantes.Add(aluno1);
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
                            linha += aluno2.nome + "|" + aluno2.cpf + "|" + aluno2.telefone + "|" + aluno2.codigo + "|"/* + aluno2.materia + "|" + aluno2.turma + "|"*/;
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
                        Console.WriteLine("|\t    REMOVER ALUNO\tESCOLAPROVER\t     |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");

                        Console.WriteLine("| Aluno {0} existe e pode ser removido.", aluno.nome);
                        Console.WriteLine("|\n| Deseja remover o aluno {0}? s p/ sim", aluno.nome);
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
                            linha += aluno1.nome + "|" + aluno1.cpf + "|" + aluno1.telefone + "|" + aluno1.codigo + "|"/* + aluno1.materia + "|"*/;
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
                Escolher();
            }
        }
        static void Consultar()
        {
            Console.Clear();

            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|\t   CONSULTA\t\tESCOLAPROVER\t     |");
            Console.WriteLine("|                                                    |");
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

            Console.WriteLine("| Insira o aluno que deseja consultar:               |");
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
                    //Console.WriteLine("|\tAlunos      Matéria\t      CPF\t|");
                    //Console.WriteLine("|----------------------------------------------------|");

                    foreach (Aluno aluno1 in aluno.estudantes)
                    {
                        Console.WriteLine("|\tAluno          {0}         ", aluno1.nome);
                        Console.WriteLine("|\tCPF            {0}          ", Convert.ToUInt64(aluno1.cpf).ToString(@"000\.000\.000\-00"));
                        //Console.WriteLine("|\tMatéria        {0}         ", aluno1.materia);
                        Console.WriteLine("|\tTelefone       {0}         ", Convert.ToUInt64(aluno1.telefone).ToString(@"(00)00000-0000"));
                        Console.WriteLine("|\tCódigo         {0}         ", aluno1.codigo);
                        //Console.WriteLine("|\tTurma          {0}         ", aluno1.turma);
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
                Console.WriteLine("|\n| 1-Voltar p/Consultar \n| 2-Ir ao Menu incial");
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
                foreach (Aluno aluno1 in aluno.estudantes)
                {
                    Console.WriteLine("|\tAluno          {0}         ", aluno1.nome);
                    Console.WriteLine("|\tCPF            {0}          ", Convert.ToUInt64(aluno1.cpf).ToString(@"000\.000\.000\-00"));
                    //Console.WriteLine("|\tMatéria        {0}         ", aluno1.materia);
                    Console.WriteLine("|\tTelefone       {0}         ", Convert.ToUInt64(aluno1.telefone).ToString(@"(00)00000-0000"));
                    Console.WriteLine("|\tCódigo         {0}         ", aluno1.codigo);
                    //Console.WriteLine("|\tTurma          {0}         ", aluno1.turma);
                }
                Console.WriteLine("                                                      ");
                Console.WriteLine("|----------------------------------------------------|");
            }
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| Aperte qualquer tecla para voltar ao menu inicial. |");
            Console.WriteLine("|----------------------------------------------------|");
            Console.ReadKey();
        }
        static void Fechar()
        {
            Console.Clear();
            Console.WriteLine("Até a próxima.");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}