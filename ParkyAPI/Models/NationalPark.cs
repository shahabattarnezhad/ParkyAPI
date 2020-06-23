using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkyAPI.Models
{
    [Table("Tbl_NationalPark")]
    public class NationalPark
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string State { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
    }
}
