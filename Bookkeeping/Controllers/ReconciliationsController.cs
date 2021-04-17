using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookkeeping.DataStore;
using Bookkeeping.Model;

namespace Bookkeeping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReconciliationsController : ControllerBase
    {
        private readonly IRepository<Reconciliation> repoReconciliation;        
        public ReconciliationsController(IRepository<Reconciliation> repoReconciliation)
        {
            this.repoReconciliation = repoReconciliation;            
        }
        
        [HttpGet]
        public async Task<IEnumerable<Reconciliation>> GetReconciliations()
        {            
            return await repoReconciliation.GetAll();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Reconciliation>> GetReconciliation(int id)
        {
            var reconciliation = await repoReconciliation.Get(id);

            if (reconciliation == null)
            {
                return NotFound();
            }
            return reconciliation;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReconciliation(int id, Reconciliation reconciliation)
        {
            if (id != reconciliation.Id)
            {
                return BadRequest();
            }

            try
            {
                await repoReconciliation.Update(reconciliation);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<Reconciliation>> PostReconciliation(Reconciliation reconciliation)
        {
            await repoReconciliation.Add(reconciliation);         

            return CreatedAtAction("GetReconciliation", new { id = reconciliation.Id }, reconciliation);
        }

        // DELETE: api/Reconciliations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReconciliation(int id)
        {
            var reconciliation = await repoReconciliation.Get(id);
            if (reconciliation == null)
            {
                return NotFound();
            }

            await repoReconciliation.Delete(reconciliation);          

            return NoContent();
        }


    }
}
