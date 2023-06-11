using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Helpers;

    

namespace TermProject_2018136107.Models
{
    public class Board
    {
        public int Id { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Writer { get; set; }
        public int View { get; set; }
        
        public string Genre { get; set; }
        public int Like { get; set; }
        public string Content { get; set; }
    }
}
