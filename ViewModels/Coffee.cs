using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class Coffee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Type is required")]
        [MaxLength(250,ErrorMessage ="Type cannot be greater than 250")]
        public string Type { get; set; } // this should be enum type safe
        [Required(ErrorMessage = "isTasty is required")]
        public bool Tasty { get; set; }

    }
}
