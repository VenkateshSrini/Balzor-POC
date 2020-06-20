using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlazorCRUD.Shared.Model
{
    public class Receipe
    {
        public string ReceipeID { get; set; }
        [Required]
        public string ReceipeName { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
