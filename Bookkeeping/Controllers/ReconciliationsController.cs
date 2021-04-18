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

        [HttpPost]
        public async Task PostReconciliation(Reconciliation reconciliation)
        {
            await reconciliationService.SaveReconciliation(reconciliation);
        }  
    }
}
