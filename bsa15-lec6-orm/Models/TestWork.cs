using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsa15_lec6_orm.Models
{
    public class TestWork
    {
        public int Id { get; set; }

        [Required]
        public int Result { get; set; }

        [Required]
        public TimeSpan ExecutionTime { get; set; }

        //[ForeignKey("User")]
        //public int UserRefId { get; set; }

        //[ForeignKey("Test")]
        //public int TestRefId { get; set; }

        //[Required]
        public virtual User User { get; set; }

        [Required]
        public virtual Test Test { get; set; }
    }
}

