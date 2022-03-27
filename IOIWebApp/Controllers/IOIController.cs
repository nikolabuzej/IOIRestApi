using IOIDataAccess.UnitOfWork;
using IOIModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IOIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IOIController : ControllerBase
    {
        private readonly IUnitOfWork work;

        public IOIController(IUnitOfWork work)
        {
            this.work = work;
        }
        // GET: api/<IOIController>
        [HttpGet]
        public IEnumerable<IOI> Get()
        {

            return work.IOI.GetAll();
        }
        [HttpGet("warranty")]
        public IEnumerable<Warranty> GetWarrantyIds()
        {
            return work.Warranty.GetAll();
        }
        // GET api/<IOIController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            IOI ioi = work.IOI.FindById(id);
            if (ioi != null)
            {
                return Ok(ioi);
            }
            else
            {
                return NotFound($"The IOI with the id: {id} was not found ");
            }
        }

        // POST api/<IOIController>
        [HttpPost]
        public IOI Post([FromBody] IOI value)
        {
            try
            {
                value.Warranty = work.Warranty.FindById(value.WarrantyId);
                work.IOI.Add(value);
                work.Commit();
                Response.StatusCode = StatusCodes.Status201Created;

            }
            catch (Exception)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;

            }
            return value;
        }

        // PUT api/<IOIController>/5
        [HttpPut("{id}")]
        public ActionResult<IOI> Put(int id, [FromBody] IOI value)
        {
            IOI ioi = work.IOI.FindById(id);
            if (ioi != null)
            {
                ioi.DeliveryDeadline = value.DeliveryDeadline;
                ioi.PaymentDeadline = value.PaymentDeadline;
                ioi.WarrantyId = value.WarrantyId;

                work.Commit();

                return Ok(ioi);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<IOIController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            IOI forRemoval = work.IOI.FindById(id);

            try
            {
                if (forRemoval != null)
                {
                    work.IOI.Delete(forRemoval);
                    work.Commit();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
    }
}
