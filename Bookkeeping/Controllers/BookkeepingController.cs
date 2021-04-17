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
        public async Task<ActionResult<BookkeepingInfo>> GetBookkeepingInfo(int id)
        {
            var BookkeepingInfo = await repoBookkeepingInfo.Get(id);

            if (BookkeepingInfo == null)
            {
                return NotFound();
            }
            return BookkeepingInfo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookkeepingInfo(int id, BookkeepingInfo BookkeepingInfo)
        {
            if (id != BookkeepingInfo.Id)
            {
                return BadRequest();
            }

            try
            {
                await repoBookkeepingInfo.Update(BookkeepingInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BookkeepingInfo>> PostBookkeepingInfo(BookkeepingInfo BookkeepingInfo)
        {
            await repoBookkeepingInfo.Add(BookkeepingInfo);

            return CreatedAtAction("GetBookkeepingInfo", new { id = BookkeepingInfo.Id }, BookkeepingInfo);
        }

        // DELETE: api/BookkeepingInfos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookkeepingInfo(int id)
        {
            var BookkeepingInfo = await repoBookkeepingInfo.Get(id);
            if (BookkeepingInfo == null)
            {
                return NotFound();
            }

            await repoBookkeepingInfo.Delete(BookkeepingInfo);

            return NoContent();
        }
    }
}
