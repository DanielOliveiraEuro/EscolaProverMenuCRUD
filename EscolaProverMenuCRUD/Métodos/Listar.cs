using EscolaProverMenuCRUD.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaProverMenuCRUD
{
    partial class Program
    {
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
                    Console.WriteLine("|\tTelefone       {0}         ", Convert.ToUInt64(aluno1.telefone).ToString(@"(00)00000-0000"));
                    Console.WriteLine("|\tCódigo         {0}         ", aluno1.codigo);
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
