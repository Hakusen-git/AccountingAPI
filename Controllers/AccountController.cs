using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AccountingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDatabase _context;
        private IConfiguration _config;

        public AccountController(ApplicationDatabase context, IConfiguration config)
        {
            _context = context;
            _config = config;
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
        public async Task<ActionResult<Account>> AddAccount(string id, Account account)
        {
            account.CustomerID = id;
            _context.Account.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddAccount", new { id = account.AccountID}, account);
        }

        [HttpPut]
        [Route("UpdateAccount")]
        public async Task<ActionResult> UpdateAccount(int id, Account account)
        {
            if(id != account.AccountID)
            {
                return BadRequest();
            }

            if(! _context.Account.Any(e => e.AccountID == id)){
                return BadRequest();
            }

            var updateAccount = await _context.Account.FirstOrDefaultAsync(s => (s.AccountID == account.AccountID));
            _context.Entry(updateAccount).State = EntityState.Modified;

            updateAccount.AccountType = account.AccountType;
            updateAccount.AccountLabel = account.AccountLabel;
            updateAccount.AccountDate = account.AccountDate;
            updateAccount.AccountAmount = account.AccountAmount;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Account.Any(e => e.AccountID == id))
                {
                    return BadRequest();
                }
                else
                {
                    throw;
                }

            }
            return NoContent();
        }
    }
}
