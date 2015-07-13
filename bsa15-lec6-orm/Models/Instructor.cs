using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bsa15_lec6_orm.Models
{
    public class Instructor
    {
        //public Instructor()
        //{
        //    this.Lectures = new List<Lecture>();
        //}

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}