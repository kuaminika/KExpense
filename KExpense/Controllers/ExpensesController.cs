using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KExpense.Data;
using KExpense.Model;

namespace KExpense.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly KExpenseContext _context;

        public ExpensesController(KExpenseContext context)
        {
            _context = context;
        }

        // GET: api/ExpenseModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseModel>>> GetExpenseModel()
        {
            return await _context.ExpenseModel.ToListAsync();
        }

        // GET: api/ExpenseModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseModel>> GetExpenseModel(int id)
        {
            var expenseModel = await _context.ExpenseModel.FindAsync(id);

            if (expenseModel == null)
            {
                return NotFound();
            }

            return expenseModel;
        }

        // PUT: api/ExpenseModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenseModel(int id, ExpenseModel expenseModel)
        {
            if (id != expenseModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(expenseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseModelExists(id))
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

        // POST: api/ExpenseModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ExpenseModel>> PostExpenseModel(ExpenseModel expenseModel)
        {
            _context.ExpenseModel.Add(expenseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpenseModel", new { id = expenseModel.Id }, expenseModel);
        }

        // DELETE: api/ExpenseModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExpenseModel>> DeleteExpenseModel(int id)
        {
            var expenseModel = await _context.ExpenseModel.FindAsync(id);
            if (expenseModel == null)
            {
                return NotFound();
            }

            _context.ExpenseModel.Remove(expenseModel);
            await _context.SaveChangesAsync();

            return expenseModel;
        }

        private bool ExpenseModelExists(int id)
        {
            return _context.ExpenseModel.Any(e => e.Id == id);
        }
    }
}
