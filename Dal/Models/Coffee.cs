using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
    [Table("Coffee")]
    public class Coffee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; } // this should be enum type safe
        [Required(ErrorMessage = "isTasty is required")]
        public bool Tasty { get; set; }

    }
}
