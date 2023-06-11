using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TermProject_2018136107.Data;
using System;
using System.Linq;

namespace TermProject_2018136107.Models.SeedData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TermProject_2018136107Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TermProject_2018136107Context>>()))
            {
                // Look for any movies.
                if (context.Board.Any())
                {
                    return;   // DB has been seeded
                }

                context.Board.AddRange(
                    new Board
                    {
                        Title = "게시판 시드데이터 1",
                        Date = DateTime.Parse("2022-11-14"),
                        Writer = "관리자",
                        View = 0,
                        Genre = "C#",
                        Like = 0
                    },

                    new Board
                    {
                        Title = "게시판 시드데이터 2",
                        Date = DateTime.Parse("2022-11-14"),
                        Writer = "관리자",
                        View = 0,
                        Genre = "C#",
                        Like = 0
                    }, 
                    
                    new Board
                    {
                        Title = "게시판 시드데이터 3",
                        Date = DateTime.Parse("2022-11-14"),
                        Writer = "관리자",
                        View = 0,
                        Genre = "C#",
                        Like = 0
                    }, 
                    
                    new Board
                    {
                        Title = "게시판 시드데이터 4",
                        Date = DateTime.Parse("2022-11-14"),
                        Writer = "관리자",
                        View = 0,
                        Genre = "C#",
                        Like = 0
                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
