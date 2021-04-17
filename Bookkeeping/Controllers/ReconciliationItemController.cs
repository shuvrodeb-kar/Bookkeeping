using Bookkeeping.DataStore;
using Bookkeeping.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookkeeping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReconciliationItemController : ControllerBase
    {
        private readonly IRepository<ReconciliationItem> repoReconciliationItem;
        public ReconciliationItemController(IRepository<ReconciliationItem> repoReconciliationItem)
        {
            this.repoReconciliationItem = repoReconciliationItem;
        }

        [HttpGet]
        [Route("Controllers/ReconciliationItem/GetReconciliationItems")]
        public async Task<IEnumerable<ReconciliationItem>> GetReconciliationItems()
        {
            return await repoReconciliationItem.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReconciliationItem>> GetReconciliationItem(int id)
        {
            var ReconciliationItem = await repoReconciliationItem.Get(id);

            if (ReconciliationItem == null)
            {
                return NotFound();
            }
            return ReconciliationItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReconciliationItem(int id, ReconciliationItem ReconciliationItem)
        {
            if (id != ReconciliationItem.Id)
            {
                return BadRequest();
            }

            try
            {
                await repoReconciliationItem.Update(ReconciliationItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ReconciliationItem>> PostReconciliationItem(ReconciliationItem ReconciliationItem)
        {
            await repoReconciliationItem.Add(ReconciliationItem);

            return CreatedAtAction("GetReconciliationItem", new { id = ReconciliationItem.Id }, ReconciliationItem);
        }

        // DELETE: api/ReconciliationItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReconciliationItem(int id)
        {
            var ReconciliationItem = await repoReconciliationItem.Get(id);
            if (ReconciliationItem == null)
            {
                return NotFound();
            }

            await repoReconciliationItem.Delete(ReconciliationItem);

            return NoContent();
        }
    }
}
