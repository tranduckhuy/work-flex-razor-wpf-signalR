using Microsoft.EntityFrameworkCore;
using WorkFlex.Domain;
using WorkFlex.Domain.Entities;

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
            var johnWeekId = Guid.NewGuid();
            var huyId = Guid.NewGuid();
            var sangId = Guid.NewGuid();
            var quyId = Guid.NewGuid();
            var haoId = Guid.NewGuid();
            var thuanId = Guid.NewGuid();
            var hoangId = Guid.NewGuid();
            var thinhId = Guid.NewGuid();
            var nghiaId = Guid.NewGuid();

            var defaultAvatar = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287";
            var defaultBgrImg = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10";

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    Username = "admin",
                    Password = "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm",
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@example.com",
                    RoleId = 1,
                    Avatar = defaultAvatar,
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = recruiterId,
                    Username = "recruiter",
                    Password = "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm",
                    FirstName = "Recruiter",
                    LastName = "User",
                    Email = "recruiter@example.com",
                    RoleId = 2,
                    Avatar = defaultAvatar,
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 10, 15)
                },
                new User
                {
                    Id = jobSeekerId,
                    Username = "jobseeker",
                    Password = "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i",
                    FirstName = "Job",
                    LastName = "Seeker",
                    Email = "jobseeker@example.com",
                    RoleId = 3,
                    Avatar = defaultAvatar,
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 12, 25)
                },
                new User
                {
                    Id = johnWeekId,
                    Username = "johnweek",
                    Password = "$2a$12$zWTkYvKaD2nrl/FIEzZvAus4fK1zT5kIk9U.IrzNxHZOzLxYzIYNe",
                    FirstName = "John",
                    LastName = "Week",
                    Email = "johnweek@example.com",
                    RoleId = 3,
                    Avatar = defaultAvatar,
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 15)
                },
                new User
                {
                    Id = huyId,
                    Username = "tranduckhuy",
                    Password = "$2a$12$MNV7kUVAks5PkB4cMD8cNuLvONZlKt/ej7.hCdRTGyj4F/csD8oKK",
                    FirstName = "Tran Duck",
                    LastName = "Huy",
                    Email = "huy@example.com",
                    RoleId = 3,
                    Avatar = defaultAvatar,
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 2, 20)
                },
                new User
                {
                    Id = sangId,
                    Username = "sang",
                    Password = "$2a$12$CwxlScy8xNpcrGL/2sg7V.vDUC1zh.QOjZD1qefQgxmq3vn0Q7R9.",
                    FirstName = "Tran Ngoc",
                    LastName = "Sang",
                    Email = "sang@example.com",
                    RoleId = 3,
                    Avatar = defaultAvatar,
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 3, 26)
                },
                new User
                {
                    Id = quyId,
                    Username = "quy",
                    Password = "$2a$12$O/urkLFsFi/GN9s0asTeZ.3YnvDozIBPXS5vpDbl6Kvz4RsxZYRIS",
                    FirstName = "Nguyen Xuan",
                    LastName = "Quy",
                    Email = "quy@example.com",
                    RoleId = 3,
                    Avatar = defaultAvatar,
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 4, 3)
                },
                new User
                {
                    Id = haoId,
                    Username = "hao",
                    Password = "$2a$12$KcwDWaYdePFeLgKTwoJd7OQl6YCi9ZvCzdPDdt7lROYp2paxwpyGC",
                    FirstName = "Nguyen Nhat",
                    LastName = "Hao",
                    Email = "hao@example.com",
                    RoleId = 3,
                    Avatar = defaultAvatar,
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 5, 25)
                },
                new User
                {
                    Id = thuanId,
                    Username = "thuan",
                    Password = "$2a$12$3hGHatEPOSTNLlvBEUMw.uxZMLNxLz74/Ls47cvbccwwlJlhFELqS",
                    FirstName = "Nguyen Dao",
                    LastName = "Minh Thuan",
                    Email = "thuan@example.com",
                    RoleId = 3,
                    Avatar = defaultAvatar,
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 6, 24)
                },
                new User
                {
                    Id = hoangId,
                    Username = "hoang",
                    Password = "$2a$12$aYH6ji8QMczfCJxRGoBUqeTA7Ttk1JnanbTXBiafDDrrOQcy6hK7O",
                    FirstName = "Ngo Gia",
                    LastName = "Hoang",
                    Email = "hoang@example.com",
                    RoleId = 3,
                    Avatar = defaultAvatar,
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 7, 15)
                },
                new User
                {
                    Id = thinhId,
                    Username = "thinh",
                    Password = "$2a$12$kzs6W6lPdNmhq9mAxWfov.FJAHD2YDQJgQ/oiDeeMo78LKzDExz2O",
                    FirstName = "Gia",
                    LastName = "Thinh",
                    Email = "thinh@example.com",
                    RoleId = 3,
                    Avatar = defaultAvatar,
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 8, 15)
                },
                new User
                {
                    Id = nghiaId,
                    Username = "nghia",
                    Password = "$2a$12$zD2J2lknJ27rADmUbwJM9eSS0sX16W/FUw/xVx7XauSjOuxauzeZa",
                    FirstName = "Trong",
                    LastName = "Nghia",
                    Email = "nghia@example.com",
                    RoleId = 3,
                    Avatar = defaultAvatar,
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 9, 11)
                }
            );

            // Seed Profiles
            modelBuilder.Entity<Profile>().HasData(
                new Profile { Id = Guid.NewGuid(), Headline = "Admin Profile", UserId = adminId },
                new Profile { Id = Guid.NewGuid(), Headline = "Recruiter Profile", UserId = recruiterId },
                new Profile { Id = Guid.NewGuid(), Headline = "Job Seeker Profile", UserId = jobSeekerId },
                new Profile { Id = Guid.NewGuid(), Headline = "Job Seeker Profile", UserId = johnWeekId },
                new Profile { Id = Guid.NewGuid(), Headline = "Job Seeker Profile", UserId = huyId },
                new Profile { Id = Guid.NewGuid(), Headline = "Job Seeker Profile", UserId = sangId },
                new Profile { Id = Guid.NewGuid(), Headline = "Job Seeker Profile", UserId = quyId },
                new Profile { Id = Guid.NewGuid(), Headline = "Job Seeker Profile", UserId = haoId },
                new Profile { Id = Guid.NewGuid(), Headline = "Job Seeker Profile", UserId = thuanId },
                new Profile { Id = Guid.NewGuid(), Headline = "Job Seeker Profile", UserId = hoangId },
                new Profile { Id = Guid.NewGuid(), Headline = "Job Seeker Profile", UserId = thinhId },
                new Profile { Id = Guid.NewGuid(), Headline = "Job Seeker Profile", UserId = nghiaId }
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
                new Industry { Id = 6, IndustryName = "Agriculture" },
                new Industry { Id = 7, IndustryName = "Customer Service" },
                new Industry { Id = 8, IndustryName = "Marketing" },
                new Industry { Id = 9, IndustryName = "Education" },
                new Industry { Id = 10, IndustryName = "Logistics" }
            );

            // Seed JobPosts
            var jobPostId = Guid.NewGuid();
            modelBuilder.Entity<JobPost>().HasData(
                new JobPost
                {
                    Id = jobPostId,
                    Title = "Web Developer",
                    SalaryRange = "1500 - 2000",
                    JobDescription = "Position Overview:\n" +
                        "- Develop and maintain web applications.\n" +
                        "- Participate in the design and product development process.\n" +
                        "- Optimize performance and security of web applications.\n\n" +
                        "Candidate Requirements:\n" +
                        "- Experience with HTML, CSS, JavaScript, and PHP.\n" +
                        "- Problem-solving skills and logical thinking.\n" +
                        "- Graduate in IT or equivalent.",
                    JobLocation = "Tòa nhà A, Số 12, Phố Nguyễn Trãi, Quận Thanh Xuân, Hải Phòng",
                    UserId = recruiterId,
                    IndustryId = 1,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 1, 15),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Data Analyst",
                    SalaryRange = "2000 - 2500",
                    JobDescription = "Position Overview:\n" +
                                     "- Analyze data and create reports for management.\n" +
                                     "- Use analytical tools to detect data trends.\n" +
                                     "- Collaborate with other departments to improve processes based on data.\n\n" +
                                     "Candidate Requirements:\n" +
                                     "- Experience with Excel, SQL, and data analysis tools.\n" +
                                     "- Communication and data presentation skills.\n" +
                                     "- Graduate in statistics, mathematics, or equivalent.",
                    JobLocation = "Văn phòng 5, Số 23, Phố Lê Duẩn, Quận Hải Châu, Đà Nẵng",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 2, 10),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "UX/UI Designer",
                    SalaryRange = "1800 - 2200",
                    JobDescription = "Position Overview:\n" +
                                     "- Design user interfaces for applications and websites.\n" +
                                     "- Research and analyze user needs to improve experiences.\n" +
                                     "- Create design prototypes and collaborate with development teams.\n\n" +
                                     "Candidate Requirements:\n" +
                                     "- Experience with Figma, Sketch, or Adobe XD.\n" +
                                     "- Good communication and teamwork skills.\n" +
                                     "- Graduate in design or equivalent.",
                    JobLocation = "Tầng 2, Số 45, Phố Lê Lai, Quận 1, Hồ Chí Minh",
                    UserId = recruiterId,
                    IndustryId = 1,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 3, 5),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "HR Manager",
                    SalaryRange = "2500 - 3000",
                    JobDescription = "Position Overview:\n" +
                                     "- Manage the recruitment and training processes for new employees.\n" +
                                     "- Develop HR policies and manage performance.\n" +
                                     "- Advise management on HR-related issues.\n\n" +
                                     "Candidate Requirements:\n" +
                                     "- At least 3 years of experience in a similar position.\n" +
                                     "- Strong communication and leadership skills.\n" +
                                     "- Graduate in human resource management or equivalent.",
                    JobLocation = "Văn phòng 3, Số 78, Phố Nguyễn Trãi, Quận Thanh Xuân, Hà Nội",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 1,
                    CreatedAt = new DateTime(2024, 4, 12),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Graphic Designer",
                    SalaryRange = "1200 - 1500",
                    JobDescription = "Position Overview:\n" +
                                     "- Design graphic products for marketing campaigns.\n" +
                                     "- Collaborate with other departments to create creative content.\n" +
                                     "- Maintain the company’s brand and design style.\n\n" +
                                     "Candidate Requirements:\n" +
                                     "- Experience with Adobe Illustrator, Photoshop.\n" +
                                     "- Creative thinking and ability to work under pressure.\n" +
                                     "- Graduate in graphic design or equivalent.",
                    JobLocation = "Tầng trệt, Số 92, Phố Võ Văn Kiệt, Quận 1, Hồ Chí Minh",
                    UserId = recruiterId,
                    IndustryId = 8,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 5, 8),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Content Writer",
                    SalaryRange = "1000 - 1500",
                    JobDescription = "Position Overview:\n" +
                                     "- Write content for blogs, websites, and social media.\n" +
                                     "- Research and develop new content topics.\n" +
                                     "- Optimize content for SEO.\n\n" +
                                     "Candidate Requirements:\n" +
                                     "- Good writing and editing skills.\n" +
                                     "- Experience in content writing is a plus.\n" +
                                     "- Graduate in journalism, communication, or equivalent.",
                    JobLocation = "Văn phòng 10, Số 56, Phố Nguyễn Thị Minh Khai, Quận Hải Châu, Đà Nẵng",
                    UserId = recruiterId,
                    IndustryId = 8,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 6, 25),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Sales Executive",
                    SalaryRange = "2000 - 2500",
                    JobDescription = "Position Overview:\n" +
                                     "- Seek and develop new customers.\n" +
                                     "- Conduct calls and meet clients to introduce products.\n" +
                                     "- Achieve monthly sales targets.\n\n" +
                                     "Candidate Requirements:\n" +
                                     "- Experience in sales.\n" +
                                     "- Good communication and persuasion skills.\n" +
                                     "- University graduate in business or equivalent.",
                    JobLocation = "Văn phòng 4, Số 150, Phố Trần Hưng Đạo, Quận 5, Hồ Chí Minh",
                    UserId = recruiterId,
                    IndustryId = 4,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 7, 20),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Network Engineer",
                    SalaryRange = "2500 - 3000",
                    JobDescription = "Position Overview:\n" +
                                     "- Design and implement computer networks.\n" +
                                     "- Monitor and maintain network systems.\n" +
                                     "- Troubleshoot network-related issues.\n\n" +
                                     "Candidate Requirements:\n" +
                                     "- Experience with networking equipment.\n" +
                                     "- CCNA certification is a plus.\n" +
                                     "- Graduate in IT or equivalent.",
                    JobLocation = "Tòa nhà B, Số 34, Phố Lê Văn Sỹ, Quận 3, Hà Nội",
                    UserId = recruiterId,
                    IndustryId = 1,
                    JobTypeId = 1,
                    CreatedAt = new DateTime(2024, 8, 11),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Product Manager",
                    SalaryRange = "3000 - 3500",
                    JobDescription = "Position Overview:\n" +
                                     "- Responsible for product development and management.\n" +
                                     "- Coordinate with departments to ensure product timelines.\n" +
                                     "- Research market trends and analyze customer needs.\n\n" +
                                     "Candidate Requirements:\n" +
                                     "- At least 3 years of experience in product management.\n" +
                                     "- Strong leadership and communication skills.\n" +
                                     "- Graduate in business or marketing.",
                    JobLocation = "Tòa nhà D, Số 80, Phố Trần Phú, Quận Hà Đông, Hải Phòng",
                    UserId = recruiterId,
                    IndustryId = 3,
                    JobTypeId = 1,
                    CreatedAt = new DateTime(2024, 9, 14),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Full-stack Developer",
                    SalaryRange = "3000 - 5000",
                    JobDescription = "Position Overview:\n" +
                                     "- Develop both frontend and backend web applications.\n" +
                                     "- Collaborate with design and product teams.\n" +
                                     "- Optimize code and application performance.\n\n" +
                                     "Candidate Requirements:\n" +
                                     "- Experience with React, Node.js, and databases.\n" +
                                     "- Ability to manage both frontend and backend tasks.\n" +
                                     "- Graduate in IT or equivalent.",
                    JobLocation = "Tòa nhà C, Số 65, Phố Trần Duy Hưng, Quận Cầu Giấy, Hà Nội",
                    UserId = recruiterId,
                    IndustryId = 1,
                    JobTypeId = 1,
                    CreatedAt = new DateTime(2024, 11, 5),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Financial Analyst",
                    SalaryRange = "2500 - 3000",
                    JobDescription = "Position Overview:\n" +
                                    "- Analyze financial situations and prepare financial reports.\n" +
                                    "- Provide investment and risk management recommendations.\n" +
                                    "- Monitor and analyze market trends.\n\n" +
                                    "Candidate Requirements:\n" +
                                    "- Experience in financial analysis.\n" +
                                    "- Strong analytical and reporting skills.\n" +
                                    "- Graduate in finance or equivalent.",
                    JobLocation = "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh",
                    UserId = recruiterId,
                    IndustryId = 4,
                    JobTypeId = 2,
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Digital Marketing Specialist",
                    SalaryRange = "1500 - 2000",
                    JobDescription = "Position Overview:\n" +
                                    "- Build and implement digital marketing campaigns.\n" +
                                    "- Manage social media channels and optimize advertisements.\n" +
                                    "- Analyze campaign effectiveness and report results.\n\n" +
                                    "Candidate Requirements:\n" +
                                    "- Experience in digital marketing.\n" +
                                    "- Analytical skills and proficiency in online marketing tools.\n" +
                                    "- Graduate in marketing or equivalent.",
                    JobLocation = "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh",
                    UserId = recruiterId,
                    IndustryId = 8,
                    JobTypeId = 2,
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Business Analyst",
                    SalaryRange = "2000 - 2500",
                    JobDescription = "Position Overview:\n" +
                                    "- Analyze business requirements and processes.\n" +
                                    "- Collaborate with departments to improve operational efficiency.\n" +
                                    "- Prepare analytical documents and reports for management.\n\n" +
                                    "Candidate Requirements:\n" +
                                    "- Experience in business analysis.\n" +
                                    "- Good communication and teamwork skills.\n" +
                                    "- Graduate in business administration or equivalent.",
                    JobLocation = "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Đà Nẵng",
                    UserId = recruiterId,
                    IndustryId = 4,
                    JobTypeId = 1,
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Customer Support Specialist",
                    SalaryRange = "1000 - 1500",
                    JobDescription = "Position Overview:\n" +
                                    "- Provide customer support via phone, email, and chat.\n" +
                                    "- Resolve customer issues quickly and effectively.\n" +
                                    "- Collect customer feedback to improve services.\n\n" +
                                    "Candidate Requirements:\n" +
                                    "- Good communication and listening skills.\n" +
                                    "- Experience in customer service is an advantage.\n" +
                                    "- Graduate from vocational school or higher.",
                    JobLocation = "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội",
                    UserId = recruiterId,
                    IndustryId = 7,
                    JobTypeId = 2,
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Mobile App Developer",
                    SalaryRange = "2000 - 2500",
                    JobDescription = "Position Overview:\n" +
                                    "- Develop and maintain mobile applications on iOS and Android.\n" +
                                    "- Participate in product design and development processes.\n" +
                                    "- Optimize application performance.\n\n" +
                                    "Candidate Requirements:\n" +
                                    "- Experience with Swift, Kotlin, or React Native.\n" +
                                    "- Creative problem-solving skills.\n" +
                                    "- Graduate in IT or equivalent.",
                    JobLocation = "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội",
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
                    Title = "Cloud Engineer",
                    SalaryRange = "2500 - 3000",
                    JobDescription = "Position Overview:\n" +
                                    "- Design and implement cloud computing solutions.\n" +
                                    "- Manage infrastructure and data security in the cloud.\n" +
                                    "- Optimize costs and system performance.\n\n" +
                                    "Candidate Requirements:\n" +
                                    "- Experience with AWS, Azure, or Google Cloud.\n" +
                                    "- Programming skills and understanding of computer networks.\n" +
                                    "- Graduate in IT or equivalent.",
                    JobLocation = "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Đà Nẵng",
                    UserId = recruiterId,
                    IndustryId = 1,
                    JobTypeId = 2,
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Cybersecurity Analyst",
                    SalaryRange = "3000 - 3500",
                    JobDescription = "Position Overview:\n" +
                                    "- Analyze and assess security risks.\n" +
                                    "- Implement measures to protect information systems.\n" +
                                    "- Monitor and respond to security incidents.\n\n" +
                                    "Candidate Requirements:\n" +
                                    "- Experience in cybersecurity.\n" +
                                    "- Certifications such as CISSP or CEH are a plus.\n" +
                                    "- Graduate in IT or equivalent.",
                    JobLocation = "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh",
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
                    Title = "Database Administrator",
                    SalaryRange = "2000 - 2500",
                    JobDescription = "Position Overview:\n" +
                                    "- Manage and maintain the company's databases.\n" +
                                    "- Optimize query performance and data security.\n" +
                                    "- Support users in accessing and using databases.\n\n" +
                                    "Candidate Requirements:\n" +
                                    "- Experience with SQL Server, MySQL, or Oracle.\n" +
                                    "- Strong analytical and problem-solving skills.\n" +
                                    "- Graduate in IT or equivalent.",
                    JobLocation = "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội",
                    UserId = recruiterId,
                    IndustryId = 1,
                    JobTypeId = 3,
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Marketing Manager",
                    SalaryRange = "2500 - 3000",
                    JobDescription = "Position Overview:\n" +
                                    "- Plan and implement marketing campaigns.\n" +
                                    "- Manage marketing budgets and report results.\n" +
                                    "- Analyze market trends and customer needs.\n\n" +
                                    "Candidate Requirements:\n" +
                                    "- At least 3 years of experience in marketing.\n" +
                                    "- Strong leadership and communication skills.\n" +
                                    "- Graduate in marketing or equivalent.",
                    JobLocation = "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 3,
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },
                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Content Strategist",
                    SalaryRange = "1500 - 2200",
                    JobDescription = "Position Overview:\n" +
                         "- Plan and oversee content strategies for branding.\n" +
                         "- Coordinate with writers and designers for content creation.\n" +
                         "- Analyze audience insights to improve content.\n\n" +
                         "Candidate Requirements:\n" +
                         "- Strong writing and editorial skills.\n" +
                         "- Experience in content strategy or journalism.\n" +
                         "- Graduate in communication or marketing.",
                    JobLocation = "Văn phòng 7, Số 11, Phố Lê Lợi, Quận 1, Đà Nẵng",
                    UserId = recruiterId,
                    IndustryId = 8,
                    JobTypeId = 3,
                    CreatedAt = new DateTime(2024, 9, 28),
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
