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
    public class APIProductCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public APIProductCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/APIProductCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        // GET: api/APIProductCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);

            if (productCategory == null)
            {
                return NotFound();
            }

            return productCategory;
        }
    }
}
