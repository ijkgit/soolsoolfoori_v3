using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TermProject_2018136107.Models
{
    public class BoardGenreViewModel
    {
        public List<Board> Drinks { get; set; }
        public SelectList Genres { get; set; }
        public string DrinkGenre { get; set; }
        public string SearchString { get; set; }
    }
}
