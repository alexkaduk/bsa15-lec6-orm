using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsa15_lec6_orm.Models
{
    public class Test
    {
        public Test()
        {
            this.Questions = new List<Question>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public TimeSpan MaxTime { get; set; }

        [Required]
        public int PassResult { get; set; }

        //[ForeignKey("TestWork")]
        //public int TestWorkRefId { get; set; }

        //[ForeignKey("Category")]
        //public int CategoryRefId { get; set; }

        //public virtual TestWork TestWork { get; set; }
        public virtual Category Category { get; set; }

        //[Required]
        public virtual ICollection<Question> Questions { get; set; }
    }
}