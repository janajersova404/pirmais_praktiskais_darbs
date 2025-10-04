using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pirmais_praktiskais_darbs.Models
{
    class Darbinieks
    {
        public int Id { get; set; }
        public string Vards { get; set; }
        public string Uzvards { get; set; }
        public int AmatsId { get; set; }
        public Amats Amats { get; set; }
        public int DepartamentsId { get; set; }
        public Departaments Departaments { get; set; }
    }
}
