using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace mission6.Models
{
    public class Task
    {
        [Required]
        [Key]
        public int TaskID { get; set; }

        [Required(ErrorMessage = "Task is a required field")]
        public string TaskName { get; set; }

        public string DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is a required field")]
        public int Quadrant { get; set; }

        public bool Completed { get; set; }

        [Required(ErrorMessage = "Category is a required field")]
        public int Categoryid { get; set; }
        [ForeignKey("Categoryid")]
        public Category Category { get; set; }
    }
}
