using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaProverMenuCRUD.Classes
{
    public class Aluno : Turma
    {
        public string nome { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
        public int codigo { get; set; }
        public ArrayList estudantes { get; set; }
        public Aluno()
        {
            estudantes = new ArrayList();
        }
    }
}
