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
        public async Task<ActionResult<Customer>> GetAccounts(string id)
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

        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);

            if(customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);

            await _context.SaveChangesAsync();

            return customer;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();
        }


        [HttpPost]
        [Route("AddCustomer")]
        public async Task<ActionResult<Customer>> AddCustomer(string id, Customer customer)
        {
            customer.CustomerID = id;
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccounts", new { id = customer.Accounts }, customer);
        }

        

    }

}
