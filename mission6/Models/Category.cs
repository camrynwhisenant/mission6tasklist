using System;
using System.ComponentModel.DataAnnotations;
namespace mission6.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }


}
}
