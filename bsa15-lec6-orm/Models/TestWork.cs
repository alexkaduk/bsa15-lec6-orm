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
        public int Result { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public virtual User User { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}

