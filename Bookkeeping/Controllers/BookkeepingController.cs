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
    public class BookkeepingController : ControllerBase
    {
        private readonly IRepository<BookkeepingInfo> repoBookkeepingInfo;
        public BookkeepingController(IRepository<BookkeepingInfo> repoBookkeepingInfo)
        {
            this.repoBookkeepingInfo = repoBookkeepingInfo;
        }

        [HttpGet]
        public async Task<IEnumerable<BookkeepingInfo>> GetBookkeepingInfos()
        {
            return await repoBookkeepingInfo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<BookkeepingInfo> GetBookkeepingInfo(int id)
        {
            var BookkeepingInfo = await repoBookkeepingInfo.Get(id);            
            return BookkeepingInfo;
        }

        [HttpPut("{id}")]
        public async Task PutBookkeepingInfo(int id, BookkeepingInfo BookkeepingInfo)
        {
            try
            {
                await repoBookkeepingInfo.Update(BookkeepingInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task PostBookkeepingInfo(BookkeepingInfo BookkeepingInfo)
        {
            await repoBookkeepingInfo.Add(BookkeepingInfo);
        }

        // DELETE: api/BookkeepingInfos/5
        [HttpDelete("{id}")]
        public async Task DeleteBookkeepingInfo(int id)
        {
            var BookkeepingInfo = await repoBookkeepingInfo.Get(id); 
            await repoBookkeepingInfo.Delete(BookkeepingInfo);
        }
    }
}
