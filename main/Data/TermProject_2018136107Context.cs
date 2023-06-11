using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TermProject_2018136107.Models;

namespace TermProject_2018136107.Data
{
    public class TermProject_2018136107Context : DbContext
    {
        public TermProject_2018136107Context (DbContextOptions<TermProject_2018136107Context> options)
            : base(options)
        {
        }

        public DbSet<TermProject_2018136107.Models.Board> Board { get; set; }

        public DbSet<TermProject_2018136107.Models.Comment> Comment { get; set; }

    }
}
