#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DT191G_Projekt.Data;
using DT191G_Projekt.Models;
using Microsoft.AspNetCore.Authorization;

namespace DT191G_Projekt
{
    [Authorize]
    public class StaffsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StaffsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        // GET: Staffs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Staff.ToListAsync());
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,StaffName,StaffRole,StaffMail,StaffImageFile,UpdatedBy,UpdatedDate")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                // Kolla om bild skickats med
                if(staff.StaffImageFile != null)
                {
                    // Ladda upp bilden
                    string wwwRootPath = _webHostEnvironment.WebRootPath;                               // Sökväg till wwwroot
                    string fileName = Path.GetFileNameWithoutExtension(staff.StaffImageFile.FileName);  // Hämta filnamnet
                    string extension = Path.GetExtension(staff.StaffImageFile.FileName);                // Hämta filändelsen
                    fileName = fileName + DateTime.Now.ToString("yyyyMMddssff") + extension;            // Skapa nytt filnamn med datumstämpel

                    // Lagra filnamnet i modellen
                    staff.StaffImageName = fileName;

                    //Uppladdningssökväg
                    string path = Path.Combine(wwwRootPath + "/uploaded/" + fileName);

                    // Flytta filen
                    using(var fs = new FileStream(path, FileMode.Create))
                    {
                        await staff.StaffImageFile.CopyToAsync(fs);
                    }
                }

                // Lägg till inloggad användare
                staff.UpdatedBy = User.Identity.Name;
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,StaffName,StaffRole,StaffMail,StaffImageName,UpdatedBy,UpdatedDate")] Staff staff)
        {
            if (id != staff.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Lägg till inloggad användare
                    staff.UpdatedBy = User.Identity.Name;
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffId))
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
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.StaffId == id);
        }
    }
}