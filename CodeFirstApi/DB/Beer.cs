using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Beer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto increment
        public int BeerID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int BrandID { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }
    }
}
