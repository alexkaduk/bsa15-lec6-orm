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
        //public Test()
        //{
        //    this.Questions = new List<Question>();
        //}

        public int TestId { get; set; }
        public string Name { get; set; }
        public TimeSpan MaxTime { get; set; }
        public int PassResult { get; set; }
        
        public virtual ICollection<TestWork> TestWork { get; set; }
        
        public virtual Category Category { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}