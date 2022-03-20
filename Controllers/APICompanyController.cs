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
using Microsoft.AspNetCore.Cors;

namespace DT191G_Projekt
{
    [Route("api/[controller]")]
    [ApiController]
    public class APICompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public APICompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/APICompany
        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompany()
        {
            return await _context.Company.ToListAsync();
        }

        // GET: api/APICompany/5
        [EnableCors]
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _context.Company.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }
    }
}
