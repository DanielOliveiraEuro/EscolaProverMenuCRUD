using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaProverMenuCRUD.Classes
{
    public class Turma : Materia
    {
        public string TurmaNome { get; set; }
        public string TurmaNumero { get; set; }
        public ArrayList turmas { get; set; }
        public Turma()
        {
            turmas = new ArrayList();
        }
    }
}
