using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaProverMenuCRUD.Classes
{
    public class Aluno
    {
        public string nome { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
        public string codigo { get; set; }
        public string materia { get; set; }
        public string turma { get; set; }
        public ArrayList estudantes { get; set; }
        public Aluno()
        {
            estudantes = new ArrayList();
        }
    }
}
