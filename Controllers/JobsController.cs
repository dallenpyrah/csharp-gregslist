using System.Collections.Generic;
using gregslist.db;
using gregslist.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregslist.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job newJob)
        {
            try
            {
                Fakedb.Jobs.Add(newJob);
                return Ok(newJob);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Job>> GetAllJobs()
        {
            try
            {
                return Ok(Fakedb.Jobs);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Job> GetJobById(string id)
        {
            try
            {
                Job foundJob = Fakedb.Jobs.Find(j => j.Id == id);
                return Ok(foundJob);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Job> DeleteJob(string id)
        {
            try
            {
                Job currentJob = Fakedb.Jobs.Find(j => j.Id == id);
                if (currentJob == null)
                {
                    throw new System.Exception("Job not found");
                }
                else
                {
                    Fakedb.Jobs.Remove(currentJob);
                    return Ok("Job was deleted");
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Job> EditJob(string id, Job editedJob)
        {
            try
            {
                Job currentJob = Fakedb.Jobs.Find(j => j.Id == id);
                if (currentJob == null)
                {
                    throw new System.Exception("Job not found");
                }
                else
                {
                    currentJob.Company = editedJob.Company;
                    currentJob.Hours = editedJob.Hours;
                    currentJob.Location = editedJob.Location;
                    currentJob.Salary = editedJob.Salary;
                    currentJob.Title = editedJob.Title;
                    return Ok(currentJob);
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}