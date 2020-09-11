using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AccountingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDatabase _context;

        public AccountController(ApplicationDatabase context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAccount")]
        public async Task<ActionResult<Account>> GetAccounts(int id)
        {
            var account = await _context.Account.FindAsync(id);
                

            if (account == null)
            {
                return NotFound();
            }


            return account;
        }

        [HttpDelete]
        [Route("DeleteAccount")]
        public async Task<ActionResult<Account>> DeleteAccount(int id)
        {
            var account = await _context.Account.FindAsync(id);

            if(account == null)
            {
                return NotFound();
            }

            _context.Account.Remove(account);

            await _context.SaveChangesAsync();

            return account;
        }

        [HttpPost]
        [Route("AddAccount")]
        public async Task<ActionResult<Account>> AddAccount(Account account)
        {
            _context.Account.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddAccount", new { id = account.AccountID}, account);
        }
    }
}
