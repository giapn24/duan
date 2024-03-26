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
    public class HoSoesController : Controller
    {
        private readonly QLDBContext _context;

        public HoSoesController(QLDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> HienThi()
        {
            return View(await _context.HoSos.ToListAsync());
        }
        // GET: HoSoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.HoSos.ToListAsync());
        }
        // GET: HoSoes/ViewImage/5
        public async Task<IActionResult> ViewImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoSo = await _context.HoSos.FindAsync(id);
            if (hoSo == null)
            {
                return NotFound();
            }

            return View(hoSo);
        }
    
    // GET: HoSoes/Details/5
    public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoSo = await _context.HoSos
                .Include(h => h.Nganh)
                .FirstOrDefaultAsync(m => m.MaHS == id);
            if (hoSo == null)
            {
                return NotFound();
            }

            return View(hoSo);
        }

        // GET: HoSoes/Create
        public IActionResult Create()
        {
            ViewData["Nganh"] = new SelectList(_context.Nganhs, "MaNganh", "TenNganh");
            return View();
        }


        // POST: HoSoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHS,HoTen,NgaySinh,DiaChi,MaCanCuocCongDan,MaNganh,NgayNop,TrangThai")] HoSo hoSo, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                // Lưu ảnh vào thư mục wwwroot/images
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Lưu đường dẫn ảnh vào cơ sở dữ liệu
                hoSo.AnhHoSo = "/images/" + fileName;

                _context.Add(hoSo);
                await _context.SaveChangesAsync();

                // Hiển thị thông báo thành công
                TempData["SuccessMessage"] = "DANG KY THANH CONG";

                // Chuyển hướng người dùng đến trang chủ
                return RedirectToAction("Index", "Home");
            }
            ViewData["MaNganh"] = new SelectList(_context.Nganhs, "MaNganh", "MaNganh", hoSo.MaNganh);
            return View(hoSo);
        }


        // GET: HoSoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoSo = await _context.HoSos.FindAsync(id);
            if (hoSo == null)
            {
                return NotFound();
            }
            ViewData["MaNganh"] = new SelectList(_context.Nganhs, "MaNganh", "MaNganh", hoSo.MaNganh);
            return View(hoSo);
        }
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHS,HoTen,NgaySinh,DiaChi,AnhHoSo,MaCanCuocCongDan,MaNganh,NgayNop,TrangThai")] HoSo hoSo)
        {
            if (id != hoSo.MaHS)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoSo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoSoExists(hoSo.MaHS))
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
            ViewData["MaNganh"] = new SelectList(_context.Nganhs, "MaNganh", "MaNganh", hoSo.MaNganh);
            return View(hoSo);
        }

        // GET: HoSoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoSo = await _context.HoSos
                .Include(h => h.Nganh)
                .FirstOrDefaultAsync(m => m.MaHS == id);
            if (hoSo == null)
            {
                return NotFound();
            }

            return View(hoSo);
        }

        // POST: HoSoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoSo = await _context.HoSos.FindAsync(id);
            if (hoSo != null)
            {
                _context.HoSos.Remove(hoSo);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool HoSoExists(int id)
        {
            return _context.HoSos.Any(e => e.MaHS == id);
        }
    }
}
