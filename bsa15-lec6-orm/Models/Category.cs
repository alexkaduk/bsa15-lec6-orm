using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bsa15_lec6_orm.Models
{
    public class Category
    {
        //public Category()
        //{
        //    this.Lectures = new List<Lecture>();
        //    this.Users = new List<User>();
        //    this.Tests = new List<Test>();
        //    this.Questions = new List<Question>();
        //}

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
