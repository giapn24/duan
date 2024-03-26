using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vesion15.Models;

namespace vesion15.Controllers
{
    public class KetQuasController : Controller
    {
        private readonly QLDBContext _context;

        public KetQuasController(QLDBContext context)
        {
            _context = context;
        }

        // GET: KetQuas
        public async Task<IActionResult> Index()
        {
            var qLDBContext = _context.KetQuas.Include(k => k.HoSo);
            return View(await qLDBContext.ToListAsync());
        }

        // GET: KetQuas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketQua = await _context.KetQuas
                .Include(k => k.HoSo)
                .FirstOrDefaultAsync(m => m.MaKQ == id);
            if (ketQua == null)
            {
                return NotFound();
            }

            return View(ketQua);
        }

        // GET: KetQuas/Create
        public IActionResult Create()
        {
            ViewData["MaHS"] = new SelectList(_context.HoSos, "MaHS", "MaHS");
            return View();
        }

        // POST: KetQuas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKQ,MaHS,Diem,HienThi")] KetQua ketQua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ketQua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHS"] = new SelectList(_context.HoSos, "MaHS", "MaHS", ketQua.MaHS);
            return View(ketQua);
        }

        // GET: KetQuas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketQua = await _context.KetQuas.FindAsync(id);
            if (ketQua == null)
            {
                return NotFound();
            }
            ViewData["MaHS"] = new SelectList(_context.HoSos, "MaHS", "MaHS", ketQua.MaHS);
            return View(ketQua);
        }

        // POST: KetQuas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaKQ,MaHS,Diem,HienThi")] KetQua ketQua)
        {
            if (id != ketQua.MaKQ)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ketQua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KetQuaExists(ketQua.MaKQ))
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
            ViewData["MaHS"] = new SelectList(_context.HoSos, "MaHS", "MaHS", ketQua.MaHS);
            return View(ketQua);
        }

        // GET: KetQuas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketQua = await _context.KetQuas
                .Include(k => k.HoSo)
                .FirstOrDefaultAsync(m => m.MaKQ == id);
            if (ketQua == null)
            {
                return NotFound();
            }

            return View(ketQua);
        }

        // POST: KetQuas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ketQua = await _context.KetQuas.FindAsync(id);
            if (ketQua != null)
            {
                _context.KetQuas.Remove(ketQua);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KetQuaExists(int id)
        {
            return _context.KetQuas.Any(e => e.MaKQ == id);
        }
    }
}
