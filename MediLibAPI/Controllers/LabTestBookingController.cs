using MediLibAPI.Data;
using MediLibAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;

namespace MediLibAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTestBookingController : ControllerBase
    {
        public readonly ApplicationDBContext dBContext;

        public LabTestBookingController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LabTestBooking>>> Get()
        {
            var LabTest = await dBContext.labTests.ToListAsync();
            return Ok(LabTest);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LabTestBooking>> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var LabTest = await dBContext.labTests.FirstOrDefaultAsync(x => x.Id == id);
            if (LabTest != null)
            {
                return Ok(LabTest);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(LabTestBooking? labTest)
        {
            if (labTest == null)
            {
                return BadRequest();
            }
            try
            {
                await dBContext.labTests.AddAsync(labTest);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, LabTestBooking labTest)
        {
            if (id != labTest.Id)
            { 
                return BadRequest();
            }
            try {
                dBContext.labTests.Update(labTest);
                await dBContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            var labtest = await dBContext.labTests.FirstOrDefaultAsync(x => x.Id == id);
            if (labtest!=null)
            {
                dBContext.labTests.Remove(labtest);
                await dBContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }

    }
}
