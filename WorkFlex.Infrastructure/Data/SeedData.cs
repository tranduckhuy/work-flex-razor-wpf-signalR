﻿using Microsoft.EntityFrameworkCore;
using WorkFlex.Domain.Entities;
using WorkFlex.Domain;

namespace WorkFlex.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "Recruiter" },
                new Role { Id = 3, RoleName = "JobSeeker" }
            );

            // Seed Users
            var adminId = Guid.NewGuid();
            var recruiterId = Guid.NewGuid();
            var jobSeekerId = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    Username = "admin",
                    Password = "admin@@",
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@example.com",
                    RoleId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = recruiterId,
                    Username = "recruiter",
                    Password = "recruiter@",
                    FirstName = "Recruiter",
                    LastName = "User",
                    Email = "recruiter@example.com",
                    RoleId = 2,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = jobSeekerId,
                    Username = "jobseeker",
                    Password = "jobseeker@@",
                    FirstName = "Job",
                    LastName = "Seeker",
                    Email = "jobseeker@example.com",
                    RoleId = 3,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );

            // Seed Profiles
            modelBuilder.Entity<Profile>().HasData(
                new Profile { Id = Guid.NewGuid(), Headline = "Admin Profile", UserId = adminId },
                new Profile { Id = Guid.NewGuid(), Headline = "Recruiter Profile", UserId = recruiterId },
                new Profile { Id = Guid.NewGuid(), Headline = "Job Seeker Profile", UserId = jobSeekerId }
            );

            // Seed JobTypes
            modelBuilder.Entity<JobType>().HasData(
                new JobType { Id = 1, TypeName = "Full Time" },
                new JobType { Id = 2, TypeName = "Part Time" },
                new JobType { Id = 3, TypeName = "Internship" }
            );

            // Seed Industries
            modelBuilder.Entity<Industry>().HasData(
                new Industry { Id = 1, IndustryName = "Software Development" },
                new Industry { Id = 2, IndustryName = "Artificial Intelligence" },
                new Industry { Id = 3, IndustryName = "Healthcare" },
                new Industry { Id = 4, IndustryName = "Finance" },
                new Industry { Id = 5, IndustryName = "Transportation" },
                new Industry { Id = 6, IndustryName = "Agriculture" }
            );

            // Seed JobPosts
            var jobPostId = Guid.NewGuid();
            modelBuilder.Entity<JobPost>().HasData(
                new JobPost
                {
                    Id = jobPostId,
                    Title = "Software Engineer",
                    JobDescription = "Looking for a skilled software engineer. Must have experience with C# and .NET Core. Angular experience is a plus.",
                    JobLocation = "Số 13, Tân Thuận Đông, Quận 7, Hồ Chí Minh",
                    UserId = recruiterId,
                    IndustryId = 1,
                    JobTypeId = 1,
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "AI Engineer",
                    JobDescription = "Looking for a data scientist to join our AI team. Must have experience with Python, TensorFlow, and Keras.",
                    JobLocation = " 239 Đ. Xuân Thủy, Dịch Vọng Hậu, Cầu Giấy, Hà Nội",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 1,
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Nurse",
                    JobDescription = "We are looking for a nurse to join our team. Must have a nursing degree and at least 2 years of experience.",
                    JobLocation = "Số 1, Đại Cồ Việt, Hai Bà Trưng, Hà Nội",
                    UserId = recruiterId,
                    IndustryId = 3,
                    JobTypeId = 1,
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                }
            );

            // Seed Applications
            modelBuilder.Entity<JobApplication>().HasData(
                new JobApplication
                {
                    Id = Guid.NewGuid(),
                    UserId = jobSeekerId,
                    JobPostId = jobPostId,
                    ApplicationDate = DateTime.UtcNow,
                    CvFile = "path/to/cv.pdf",
                    Status = Status.Pending
                }
            );
        }
    }
}
