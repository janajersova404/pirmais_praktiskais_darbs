using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pirmais_praktiskais_darbs.Models
{
    public class Amats
    {
        //public int Id { get; set; }
        //public string Nosaukums { get; set; }
        //public ICollection<Darbinieks> Darbinieki { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nosaukums { get; set; }
        public ICollection<Darbinieks> Darbinieki { get; set; }
    }
}
