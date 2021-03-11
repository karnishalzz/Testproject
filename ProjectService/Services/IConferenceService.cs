using ProjectModel;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectService.Services
{
    public interface IConferenceService
    {
        List<object> GetProjectListByHostId(string id);
        Task<object> GetBatchListByProjectId(Guid id);
        List<object> GetParticipantsListByBatchId(Guid id);
        //Task<object> GetHostListByParticipateId(string id);
        Task<object> CreateConferene(Conference conference);
    }
}
