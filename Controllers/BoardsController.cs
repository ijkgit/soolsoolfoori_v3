using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProject_2018136107.Data;
using TermProject_2018136107.Models;

namespace TermProject_2018136107.Controllers
{
    public class BoardsController : Controller
    {
        private readonly TermProject_2018136107Context _context;

        public BoardsController(TermProject_2018136107Context context)
        {
            _context = context;
        }

        // GET: Boards
        // 검색 기능 추가 2022-11-15
        public async Task<IActionResult> Index(string DrinkGenre, string searchString)
        {
            IQueryable<string> genreQuery = from b in _context.Board
                                            orderby b.Genre
                                            select b.Genre;

            var boards = from b in _context.Board
                         select b;

            if(!String.IsNullOrEmpty(searchString))
            {
                boards = boards.Where(a => a.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(DrinkGenre))
            {
                boards = boards.Where(x => x.Genre == DrinkGenre);
            }

            var drinkGenreVM = new BoardGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Drinks = await boards.ToListAsync()
            };

            // return View(await _context.Board.ToListAsync());
            // return View(await boards.ToListAsync());
            return View(drinkGenreVM);
        }

        // 좋아요 순으로 정렬 추가 (2022-12-13)
        public async Task<IActionResult> Like()
        {
            var boards = from b in _context.Board
                         orderby b.Like descending
                         select b;
            // return View(await _context.Board.ToListAsync());
            // return View(await boards.ToListAsync());
            return View(await boards.ToListAsync());
        }

        public async Task<IActionResult> MostView()
        {
            var boards = from b in _context.Board
                         orderby b.View descending
                         select b;
            // return View(await _context.Board.ToListAsync());
            // return View(await boards.ToListAsync());
            return View(await boards.ToListAsync());
        }
        public async Task<IActionResult> Recent()
        {
            var boards = from b in _context.Board
                         orderby b.Date descending
                         select b;
            // return View(await _context.Board.ToListAsync());
            // return View(await boards.ToListAsync());
            return View(await boards.ToListAsync());
        }

        // GET: Boards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Board
                .FirstOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }
            
            // 조회수 기능 추가 (22-12-13)
            board.View++;
            _context.Update(board);
            await _context.SaveChangesAsync();

            return View(board);
        }

        // 좋아요 기능 추가 (22-12-13)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int? id, [Bind("Id,Title,Date,Writer,View,Genre,Like,Content")] Board board)
        {
            if (board == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                board.Like++;
                _context.Update(board);
                await _context.SaveChangesAsync();
            }
            
            return View(board);
        }

        // GET: Boards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Date,Writer,View,Genre,Like,Content")] Board board)
        {
            if (ModelState.IsValid)
            {
                // 현재 시간으로 설정 (2022-12-13)
                DateTime nowDate = DateTime.Now;
                board.Date = nowDate;
                _context.Add(board);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(board);
        }

        // GET: Boards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Board.FindAsync(id);
            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        // POST: Boards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Date,Writer,View,Genre,Like,Content")] Board board)
        {
            if (id != board.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // 현재 시간으로 설정 (2022-12-13)
                    DateTime nowDate = DateTime.Now;
                    board.Date = nowDate;
                    _context.Update(board);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardExists(board.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(board);
        }

        // GET: Boards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Board
                .FirstOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        // POST: Boards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var board = await _context.Board.FindAsync(id);
            _context.Board.Remove(board);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardExists(int id)
        {
            return _context.Board.Any(e => e.Id == id);
        }
    }
}
