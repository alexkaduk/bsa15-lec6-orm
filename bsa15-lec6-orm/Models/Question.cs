using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace bsa15_lec6_orm.Models
{
    public class Question
    {
        public Question()
        {
            this.Tests = new HashSet<Test>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
