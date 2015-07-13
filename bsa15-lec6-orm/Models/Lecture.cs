using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bsa15_lec6_orm.Models
{
    public class Lecture
    {
        //public Lecture()
        //{
        //    this.Instructors = new List<Instructor>();
        //    this.Categories = new List<Category>();
        //}
        
        public int Id { get; set; }
        
        //[Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
 
        public virtual ICollection<Category> Categories { get; set; }
    }
}