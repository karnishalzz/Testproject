using Microsoft.AspNetCore.Mvc;
using ProjectModel;
using ProjectModels;
using ProjectService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ConferenceController : ControllerBase
    {
        
        private readonly IConferenceService _conferenceService;
        public ConferenceController(IConferenceService conferenceService)
        {
            _conferenceService = conferenceService;
        }
        //// GET: api/<ConferenceController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ConferenceController>/5
        [HttpGet, Route("GetProjectListByHostId/{hostId}")]
        public List<object> GetProjectListByHostId(string hostId)
        {
           var list= _conferenceService.GetProjectListByHostId(hostId);
            return list;
        }
        [HttpGet, Route("GetBatchListByProjectId/{projectId}")]
        public Task<object> GetBatchListByProjectId(Guid projectId)
        {
            var list =_conferenceService.GetBatchListByProjectId(projectId);
            return list;
        }
        [HttpGet, Route("GetParticipantsListByBatchId/{batchId}")]
        public List<object> GetParticipantsListByBatchId(Guid batchId)
        {
            var list = _conferenceService.GetParticipantsListByBatchId(batchId);

            return list;
        }
        // POST api/<ConferenceController>
        [HttpPost]
        public void CreateConferene([FromBody] Conference conference)
        {
            _conferenceService.CreateConferene(conference);
        }

        //// PUT api/<ConferenceController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ConferenceController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
