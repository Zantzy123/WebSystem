using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Longheng.Data;
using Longheng.Models;

namespace Longheng.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CvTemplatesController : ControllerBase
    {
        private readonly CvDbContext _context;

        public CvTemplatesController(CvDbContext context)
        {
            _context = context;
        }

        // GET: api/CvTemplates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CvTemplate>>> GetCvTemplate()
        {
            return await _context.CvTemplates.ToListAsync();
        }

        // GET: api/CvTemplates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CvTemplate>> GetCvTemplate(int id)
        {
            var cvTemplate = await _context.CvTemplates.FindAsync(id);

            if (cvTemplate == null)
            {
                return NotFound();
            }

            return cvTemplate;
        }

        // PUT: api/CvTemplates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCvTemplate(int id, CvTemplate cvTemplate)
        {
            if (id != cvTemplate.Id)
            {
                return BadRequest();
            }

            _context.Entry(cvTemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CvTemplateExists(id))
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

        // POST: api/CvTemplates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CvTemplate>> PostCvTemplate(IFormFile FilePath,[FromForm] CvTemplateDto cvTemplateDto, IWebHostEnvironment environment)
        {
            var cvTemplate = cvTemplateDto.ToCvTemplate(environment);
            string path = Path.Combine(environment.WebRootPath,"uploads",FilePath.FileName);
            using var stream = System.IO.File.Create(path);
            FilePath.CopyTo(stream);
            cvTemplate.FilePath = $"uploads/{FilePath.FileName}";
            _context.CvTemplates.Add(cvTemplate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCvTemplate", new { id = cvTemplate.Id }, cvTemplate);
        }

        // DELETE: api/CvTemplates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCvTemplate(int id)
        {
            var cvTemplate = await _context.CvTemplates.FindAsync(id);
            if (cvTemplate == null)
            {
                return NotFound();
            }

            _context.CvTemplates.Remove(cvTemplate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CvTemplateExists(int id)
        {
            return _context.CvTemplates.Any(e => e.Id == id);
        }
    }
}
