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
    public class QuanTriViensController : Controller
    {
        private readonly QLDBContext _context;

        public QuanTriViensController(QLDBContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách ngành nghề
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nganhs.ToListAsync());
        }

        // Cập nhật thông tin ngành nghề
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CapNhatNganhNghe(int id, [Bind("MaNganh,TenNganh")] Nganh nganh)
        {
            if (id != nganh.MaNganh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nganh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NganhExists(nganh.MaNganh))
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
            return View(nganh);
        }
        // GET: QuanTriViens/ThemNganhNghe
        public IActionResult ThemNganhNghe()
        {
            return View();
        }

        // POST: QuanTriViens/ThemNganhNghe
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemNganhNghe([Bind("MaNganh,TenNganh")] Nganh nganh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nganh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nganh);
        }

        // GET: QuanTriViens/XoaNganhNghe/5
        public async Task<IActionResult> XoaNganhNghe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganh = await _context.Nganhs
                .FirstOrDefaultAsync(m => m.MaNganh == id);
            if (nganh == null)
            {
                return NotFound();
            }

            return View(nganh);
        }

        // POST: QuanTriViens/XoaNganhNghe/5
        [HttpPost, ActionName("XoaNganhNghe")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> XoaNganhNgheConfirmed(int id)
        {
            var nganh = await _context.Nganhs.FindAsync(id);
            _context.Nganhs.Remove(nganh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: QuanTriViens/SuaNganhNghe/5
        public async Task<IActionResult> SuaNganhNghe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganh = await _context.Nganhs.FindAsync(id);
            if (nganh == null)
            {
                return NotFound();
            }
            return View(nganh);
        }

        // POST: QuanTriViens/SuaNganhNghe/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaNganhNghe(int id, [Bind("MaNganh,TenNganh")] Nganh nganh)
        {
            if (id != nganh.MaNganh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nganh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NganhExists(nganh.MaNganh))
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
            return View(nganh);
        }

        // Theo dõi hồ sơ tuyển sinh
        public async Task<IActionResult> TheoDoiHoSoTuyenSinh()
        {
            return View(await _context.HoSos.Include(hs => hs.Nganh).ToListAsync());
        }

        // Cập nhật kết quả tuyển sinh
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CapNhatKetQuaTuyenSinh(int id, [Bind("MaKQ,MaHS,Diem,HienThi")] KetQua ketQua)
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
                return RedirectToAction(nameof(TheoDoiHoSoTuyenSinh));
            }
            return View(ketQua);
        }


        // GET: QuanTriViens/BaoCaoThongKe
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BaoCaoThongKe()
        {
            var nganhs = await _context.Nganhs.ToListAsync();
            var hosos = await _context.HoSos.ToListAsync();

            var thongKe = nganhs.Select(nganh => new
            {
                MaNganh = nganh.MaNganh,
                TenNganh = nganh.TenNganh,
                SoHoSo = hosos.Count(hoso => hoso.MaNganh == nganh.MaNganh),
                PhanTram = (double)hosos.Count(hoso => hoso.MaNganh == nganh.MaNganh) / hosos.Count() * 100
            })
            .OrderBy(thongKe => thongKe.PhanTram)
            .ToList();

            return View(thongKe);
        }


        private bool NganhExists(int id)
        {
            return _context.Nganhs.Any(e => e.MaNganh == id);
        }

        private bool KetQuaExists(int id)
        {
            return _context.KetQuas.Any(e => e.MaKQ == id);
        }
    }

}
