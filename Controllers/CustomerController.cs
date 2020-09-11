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
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDatabase _context;

        public CustomerController(ApplicationDatabase context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAccounts")]
        public async Task<ActionResult<Customer>> GetAccounts(int id)
        {
            var customer = await _context.Customer
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.CustomerID == id);


            if (customer == null)
            {
                return NotFound();
            }


            return customer;
        }


        [HttpPost]
        [Route("AddCustomer")]
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Accounts }, customer);
        }

        

    }

}
