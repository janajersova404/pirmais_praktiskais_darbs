using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pirmais_praktiskais_darbs.Models
{
    public class Darbinieks
    {
        //public int Id { get; set; }
        //public string Vards { get; set; }
        //public string Uzvards { get; set; }
        //public int AmatsId { get; set; }
        //public Amats Amats { get; set; }
        //public int DepartamentsId { get; set; }
        //public Departaments Departaments { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Vards { get; set; }

        [Required]
        [MaxLength(50)]
        public string Uzvards { get; set; }

        [ForeignKey("Amats")]
        public int AmatsId { get; set; }
        public Amats Amats { get; set; }

        [ForeignKey("Departaments")]
        public int DepartamentsId { get; set; }
        public Departaments Departaments { get; set; }
    }
}
