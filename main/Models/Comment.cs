using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TermProject_2018136107.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Writer { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
    }
}
