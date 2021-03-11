using Microsoft.EntityFrameworkCore;
using ProjectModel;
using ProjectModels;
using ProjectService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectService.ServiceImplementation
{
    public class ConferenceService : IConferenceService
    {
        private readonly ApplicationDbContext _context;
        public ConferenceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetBatchListByProjectId(Guid id)
        {
            try
            {
                var batches =await _context.Batches
                    .Where(x => x.ProjectId == id)
                    .Include(x=>x.Project)
                    .ToListAsync();
              
                return batches;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<object> GetProjectListByHostId(string hostId)
        {
            try
            {
               
                var batches = _context.BatchHosts.Where(x => x.HostId == hostId).GroupBy(x=>x.BatchId).Select(t=>t.Key);
                List<object> result=new List<object>();
                foreach(var i in batches)
                {
                    result.Add(_context.Batches.Where(x => x.Id == i)
                          .Select(t => new { t.Project.Id, t.Project.Name }));

                }
                

                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<object> GetParticipantsListByBatchId(Guid id)
        {
            try
            {
                var batchHostParticipates = _context.BatchHostParticipates.Where(x => x.BatchId == id).Select(x=>x.ParticipateId);
                List<object> result = new List<object>();
                foreach (var i in batchHostParticipates)
                {
                    result.Add(_context.Users.Where(x => x.Id == i)
                          .Select(t => new { t.Id, t.Email}));

                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<object> CreateConferene(Conference conference)
        {
            try
            {
                
                conference.RoomId = CreateUniqueRoomId();
                _context.Add(conference);
                await _context.SaveChangesAsync();
                
                return new
                {
                    Success = true,
                    Records = "Added",

                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private string CreateUniqueRoomId()
        {

            //var roomId = _context.Conferences
            //    .OrderBy(x=>x.Id)
            //    .Select(x => x.RoomId)
            //    .LastOrDefault()

            var roomId = _context.Conferences
                .OrderByDescending(x => x.Id)
                .Select(x => x.RoomId)
                .FirstOrDefault();

            if (roomId == null)
            {
                return "Room-101";
            }
            var roomNum = int.Parse(roomId.Remove(0, 5));
            roomNum++;
            return "Room-" + roomNum;
           
        
        }

        public List<object> GetHostListByParticipateId(string id)
        {
            try
            {

                //var data = _context.Users.Select(u => u.)
                var hostids = _context.BatchHostParticipates.Where(x => x.ParticipateId == id)
                    .GroupBy(x => x.HostId)
                    .Select(y => new
                    {
                        y.Key
                    });
                List<object> result = new List<object>();
                foreach (var i in hostids)
                {
                    result.Add(_context.Users.Where(x => x.Id == id)
                          .Select(t => new { t.FirstName, t.Email,t.UserType }));

                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

       
    }
}
