using CRUD_OPERATION_WEBAPI.DataContext;
using CRUD_OPERATION_WEBAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CRUD_OPERATION_WEBAPI.Controllers
{
    [Route("api/[Controller]")]
    public class CustomerController : Controller
    {
       
       

            private  AppDbContext _context;
        public CustomerController(AppDbContext context)
            {
                _context = context;
            }
            
            [HttpGet]
            public List<ChampCustomer> Get()
            {
                return _context.ChampCustomers.ToList();
            }
            [HttpGet("{Id}")]
            public ChampCustomer GetChampCustomer(int Id)
            {
                var data = _context.ChampCustomers.Where(a => a.ID == Id).FirstOrDefault();
                return data;
            }



        //Edit********************************

        //[HttpPatch]
        //[Route("api/[Controller]/{Id}")]
        //public IActionResult Editcustomer(int Id, ChampCustomer customer)
        //{

        //    if (true)
        //    {
        //      customer.ID = Id;

        //        _context.ChampCustomers.Update(customer);
        //        _context.SaveChanges();

        //        return Ok(customer);
        //    }

        //}

        //public IActionResult Update(int Id)
        //{ }
       


        //[HttpPatch("{Id}")]
        //public async Task<ActionResult> Patch(int Id, [FromBody] JsonPatchDocument<Customer> document)
        //{
        //    if (document== null)
        //    {
        //        return BadRequest();
        //    }
             
        //    var cust = _context.ChampCustomers.Update<Customer>(await document.Get(Id));

        //    // Apply changes 

        //    document.ApplyTo(cust);

        //    var custe = _context.Map<Entry>(customer);
        //    var updatedcust = _context.Map<Entry>(await _Customer.Update(Id, custe));

        //    return Ok(custe);
        //}



        [HttpPost]
            public IActionResult PostChampCustomer([FromBody] ChampCustomer champCustomer)
            {
                if (!ModelState.IsValid)
                    return BadRequest("Does not Found");

                _context.ChampCustomers.Add(champCustomer);
                _context.SaveChanges();

                return Ok();
            }

            [HttpDelete("{Id}")]
            public async Task<IActionResult> DeleteChampCustomer(int Id)
            {
                var customer = await _context.ChampCustomers.FindAsync(Id);
                if (customer == null)
                {
                    return NotFound();
                }
                _context.ChampCustomers.Remove(customer);
                await _context.SaveChangesAsync();

                return NoContent();
            }

        }
    }

