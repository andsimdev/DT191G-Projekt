#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DT191G_Projekt.Data;
using DT191G_Projekt.Models;

namespace DT191G_Projekt
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIStaffsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public APIStaffsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        // GET (image from image-name)
        [HttpGet("{StaffImageName}")]
        public IActionResult Get(string StaffImageName)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;  // Sökväg till wwwroot

            string path = Path.Combine(wwwRootPath + "/uploaded/" + StaffImageName);  //Bildens sökväg

            // Hämta bilden från wwwroot-katalogen
            var image = System.IO.File.OpenRead(path);

            // Kontrollera om bilden finns
            if (image == null)
            {
                return NotFound();
            }
            else
            {
                // Returnera bilden
                return File(image, "image/jpg");
            }
        }

        // GET: api/APIStaffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            return await _context.Staff.ToListAsync();
        }
    }
}
