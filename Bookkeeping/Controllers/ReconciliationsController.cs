using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookkeeping.DataStore;
using Bookkeeping.Model;
using Bookkeeping.Service;

namespace Bookkeeping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReconciliationsController : ControllerBase
    {
        private readonly IReconciliationService reconciliationService;        
        public ReconciliationsController(IReconciliationService reconciliationService)
        {
            this.reconciliationService = reconciliationService;            
        }
        
        //[HttpGet]
        //public async Task<IEnumerable<Reconciliation>> GetReconciliations()
        //{            
        //    return await repoReconciliation.GetAll();
        //}
        
        //[HttpGet("{id}")]
        //public async Task<Reconciliation> GetReconciliation(int id)
        //{
        //    var reconciliation = await repoReconciliation.Get(id);
        //    return reconciliation;
        //}
        
        //[HttpPut("{id}")]
        //public async Task PutReconciliation(int id, Reconciliation reconciliation)
        //{           
        //    try
        //    {
        //        await repoReconciliation.Update(reconciliation);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }
        //}
        
        [HttpPost]
        public async Task PostReconciliation(Reconciliation reconciliation)
        {
            await reconciliationService.SaveReconciliation(reconciliation);
        }

        //// DELETE: api/Reconciliations/5
        //[HttpDelete("{id}")]
        //public async Task DeleteReconciliation(int id)
        //{
        //    var reconciliation = await repoReconciliation.Get(id);
        //    await repoReconciliation.Delete(reconciliation);
        //}


    }
}
