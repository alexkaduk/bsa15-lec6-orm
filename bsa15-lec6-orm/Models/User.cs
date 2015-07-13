using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsa15_lec6_orm.Models
{
    public class User
    {
        public User()
        {
            this.Categories = new List<Category>();
            this.TestWorks = new List<TestWork>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string University { get; set; }
        [Required]
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<TestWork> TestWorks { get; set; }
    }
}
