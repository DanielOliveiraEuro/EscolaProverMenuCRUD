using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaProverMenuCRUD.Classes
{
    public class Materia
    {
        public string MateriaNome { get; set; }
        public ArrayList materias { get; set; }
        public Materia()
        {
            materias = new ArrayList();
        }
    }
}
