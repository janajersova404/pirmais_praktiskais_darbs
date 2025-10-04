using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pirmais_praktiskais_darbs.Models
{
    class Amats
    {
        public int Id { get; set; }
        public string Nosaukums { get; set; }
        public ICollection<Darbinieks> Darbinieki { get; set; }
    }
}
