using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KExpense.Data;
using KExpense.Model;
using KExpense.Repository.interfaces;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KExpense.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgnanizationsController : ControllerBase
    {

        //todo: remove that context thing
        private readonly KExpenseContext _context;

        public OrgnanizationsController(KExpenseContext context)
        {
            _context = context;
        }

        // GET: api/Orgnanizations
        [HttpGet]

        public ActionResult<IEnumerable<Orgnanization>> GetOrgnanization()
        {

            kContainer.KIgniter ig = new kContainer.KIgniter();
            kContainer.IKServiceConfig configs = ig.IgniteServiceConfig();
            Service.factories.KOrgServiceFactory serviceFactory = new Service.factories.KOrgServiceFactory(configs);
            Service.IKOrganizationService ps = serviceFactory.Create("Mysql"); 
            List<IOrganization> list = ps.GetAll();

            JsonResult result = new JsonResult(list);

            return result;
        }

        // GET: api/Orgnanizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orgnanization>> GetOrgnanization(int id)
        {
            var orgnanization = await _context.Orgnanization.FindAsync(id);

            if (orgnanization == null)
            {
                return NotFound();
            }

            return orgnanization;
        }

        // PUT: api/Orgnanizations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrgnanization(int id, Orgnanization orgnanization)
        {
            if (id != orgnanization.id)
            {
                return BadRequest();
            }

            _context.Entry(orgnanization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrgnanizationExists(id))
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

        // POST: api/Orgnanizations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Orgnanization>> PostOrgnanization(Orgnanization orgnanization)
        {
            _context.Orgnanization.Add(orgnanization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrgnanization", new { id = orgnanization.id }, orgnanization);
        }

        // DELETE: api/Orgnanizations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Orgnanization>> DeleteOrgnanization(int id)
        {
            var orgnanization = await _context.Orgnanization.FindAsync(id);
            if (orgnanization == null)
            {
                return NotFound();
            }

            _context.Orgnanization.Remove(orgnanization);
            await _context.SaveChangesAsync();

            return orgnanization;
        }

        private bool OrgnanizationExists(int id)
        {
            return _context.Orgnanization.Any(e => e.id == id);
        }
    }
}
