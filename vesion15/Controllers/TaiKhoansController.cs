using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vesion15.Models;

namespace vesion15.Controllers
{
    public class TaiKhoansController : BaseController
    {
        private readonly QLDBContext _context;

        public TaiKhoansController(QLDBContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("MaTK,TenDangNhap,MatKhau")] TaiKhoan model)
        {
            if (ModelState.IsValid)
            {
                var loginUser = await _context.TaiKhoans.FirstOrDefaultAsync(m => m.TenDangNhap == model.TenDangNhap);
                if (loginUser == null)
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                    return View(model);
                }
                else
                {
                    using SHA256 hashMethod = SHA256.Create();
                    if (Util.Cryptography.VerifyHash(hashMethod, model.MatKhau, loginUser.MatKhau))
                    {
                        CurrentUser = loginUser.TenDangNhap;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng nhập thất bại");
                        return View(model);
                    }
                }
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("TenDangNhap,MatKhau")] TaiKhoan model)
        {
            if (ModelState.IsValid)
            {
                using SHA256 hashMethod = SHA256.Create();
                model.MatKhau = Util.Cryptography.Gethash(hashMethod, model.MatKhau);
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(model);
        }
    }



}
