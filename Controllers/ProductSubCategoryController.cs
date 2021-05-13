using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EKARTAPI.Data;
using EKARTAPI.Entities;

namespace EKARTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSubCategoryController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductSubCategoryController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProductSubCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSubCategory>>> GetProductSubCategories()
        {
            return await _context.ProductSubCategories.ToListAsync();
        }

        // GET: api/ProductSubCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSubCategory>> GetProductSubCategory(int id)
        {
            var productSubCategory = await _context.ProductSubCategories.FindAsync(id);

            if (productSubCategory == null)
            {
                return NotFound();
            }

            return productSubCategory;
        }

        // PUT: api/ProductSubCategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSubCategory(int id, ProductSubCategory productSubCategory)
        {
            if (id != productSubCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(productSubCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSubCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductSubCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductSubCategory>> PostProductSubCategory(ProductSubCategory productSubCategory)
        {
            _context.ProductSubCategories.Add(productSubCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductSubCategory", new { id = productSubCategory.Id }, productSubCategory);
        }

        // DELETE: api/ProductSubCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductSubCategory(int id)
        {
            var productSubCategory = await _context.ProductSubCategories.FindAsync(id);
            if (productSubCategory == null)
            {
                return NotFound();
            }

            _context.ProductSubCategories.Remove(productSubCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductSubCategoryExists(int id)
        {
            return _context.ProductSubCategories.Any(e => e.Id == id);
        }
    }
}
