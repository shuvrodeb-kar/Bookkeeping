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
        public async Task<IEnumerable<ReconciliationItem>> GetReconciliationItems()
        {
            return await repoReconciliationItem.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ReconciliationItem> GetReconciliationItem(int id)
        {
            var ReconciliationItem = await repoReconciliationItem.Get(id);            
            return ReconciliationItem;
        }

        [HttpPut("{id}")]
        public async Task PutReconciliationItem(int id, ReconciliationItem ReconciliationItem)
        {            
            try
            {
                await repoReconciliationItem.Update(ReconciliationItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task PostReconciliationItem(ReconciliationItem ReconciliationItem)
        {
            await repoReconciliationItem.Add(ReconciliationItem);
        }

        // DELETE: api/ReconciliationItems/5
        [HttpDelete("{id}")]
        public async Task DeleteReconciliationItem(int id)
        {
            var ReconciliationItem = await repoReconciliationItem.Get(id);        

            await repoReconciliationItem.Delete(ReconciliationItem);
        }
    }
}
