using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsa15_lec6_orm.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public bool Correct { get; set; }
        public string Text { get; set; }
        public virtual Question Question { get; set; }
        public virtual TestWork TestWork { get; set; }
    }
}
