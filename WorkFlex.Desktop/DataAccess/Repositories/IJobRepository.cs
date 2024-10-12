using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlex.Domain.Entities;

namespace WorkFlex.Desktop.DataAccess.Repositories
{
    public interface IJobRepository
    {
        void Add(JobPost jobpost);

        JobPost? GetJobPostById(string id);

        IEnumerable<JobPost> List(); 

        IEnumerable<JobType> GetAllJobTypes();

        IEnumerable<Industry> GetAllIndustries();
    }
}
