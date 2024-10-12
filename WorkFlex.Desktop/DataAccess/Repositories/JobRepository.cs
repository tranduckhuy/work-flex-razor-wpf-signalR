﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlex.Desktop.DataAccess.DAO;
using WorkFlex.Domain.Entities;
using WorkFlex.Infrastructure.Data;

namespace WorkFlex.Desktop.DataAccess.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(JobPost jobpost)
        {
            _context.JobPosts.Add(jobpost);
            _context.SaveChanges();
        }

        public JobPost? GetJobPostById(string id)
        {
            var jobPost = _context.JobPosts.FirstOrDefault(j => j.Id.Equals(id));
            if (jobPost == null)
                return null;
            return jobPost;
        }

        public IEnumerable<JobPost> List()
        {
            return _context.JobPosts.ToList(); 
        }

        public IEnumerable<JobType> GetAllJobTypes()
        {
            return _context.JobTypes.ToList();
        }

        public IEnumerable<Industry> GetAllIndustries()
        {
            return _context.Industries.ToList();
        }
    }
}