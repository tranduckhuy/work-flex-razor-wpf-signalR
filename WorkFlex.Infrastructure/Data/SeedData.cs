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
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Ftjw6hg_1730428353803_table-img1.png?alt=media&token=fa6ddab5-418a-4cfb-ab75-2aa0d578c164",
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    SubscriptionType = SubscriptionType.Premium
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
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2F2q2joa_1730428345764_vendor-14.png?alt=media&token=75952a9b-a099-4ec3-acc5-3240f0839dd2",
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 10, 15),
                    SubscriptionType = SubscriptionType.Premium
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
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2F17mshd_1730428341488_vendor-13.png?alt=media&token=33092b37-f077-4863-9329-63fa6e5964f7",
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 12, 25),
                    SubscriptionType = SubscriptionType.Premium
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
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fwobtrg_1730428336088_vendor-11.png?alt=media&token=306e81e3-dee1-4e09-bd09-0ea22d9bcd66",
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 15),
                    SubscriptionType = SubscriptionType.Standard
                },
                new User
                {
                    Id = huyId,
                    Username = "tranduckhuy",
                    Password = "$2a$12$MNV7kUVAks5PkB4cMD8cNuLvONZlKt/ej7.hCdRTGyj4F/csD8oKK",
                    FirstName = "Tran Duck",
                    LastName = "Huy",
                    Email = "huytdqe170235@fpt.edu.vn",
                    RoleId = 3,
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Frijtlx_1730428289939_vendor-1.png?alt=media&token=529439ae-4bc1-4c9a-ad2a-6d97f0c5ae25",
                    BackgroundImg = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fmau-cua-hang-tap-hoa-12-aeros.webp?alt=media&token=55cb771a-c564-4d29-b0fa-f6cccea186e2",
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
                    Email = "sangtnqe170193@fpt.edu.vn",
                    RoleId = 3,
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2F9xi15_1730428296376_vendor-2.png?alt=media&token=e850aa0f-9798-45da-851a-1b4a7bc6726d",
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 3, 26),
                    SubscriptionType = SubscriptionType.Premium
                },
                new User
                {
                    Id = quyId,
                    Username = "quy",
                    Password = "$2a$12$O/urkLFsFi/GN9s0asTeZ.3YnvDozIBPXS5vpDbl6Kvz4RsxZYRIS",
                    FirstName = "Nguyen Xuan",
                    LastName = "Quy",
                    Email = "quynxqe170239@fpt.edu.vn",
                    RoleId = 2,
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fvn1m3b_1730428306808_vendor-4.png?alt=media&token=f1e61339-1c7f-4065-acbf-d49a012dc604",
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 4, 3),
                    SubscriptionType = SubscriptionType.Premium
                },
                new User
                {
                    Id = haoId,
                    Username = "hao",
                    Password = "$2a$12$KcwDWaYdePFeLgKTwoJd7OQl6YCi9ZvCzdPDdt7lROYp2paxwpyGC",
                    FirstName = "Nguyen Nhat",
                    LastName = "Hao",
                    Email = "haonnqe170204@fpt.edu.vn",
                    RoleId = 3,
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Faq8ir_1730428301407_vendor-3.png?alt=media&token=295216c1-4ea0-4a0c-8a61-3c66200f41bb",
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 5, 25),
                    SubscriptionType = SubscriptionType.Premium
                },
                new User
                {
                    Id = thuanId,
                    Username = "thuan",
                    Password = "$2a$12$3hGHatEPOSTNLlvBEUMw.uxZMLNxLz74/Ls47cvbccwwlJlhFELqS",
                    FirstName = "Nguyen Dao",
                    LastName = "Minh Thuan",
                    Email = "thuanndmqe170240@fpt.edu.vn",
                    RoleId = 3,
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Ftvujfq_1730428311602_vendor-5.png?alt=media&token=65db1056-55f6-4620-990b-c3641807507f",
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 6, 24),
                    SubscriptionType = SubscriptionType.Premium
                },
                new User
                {
                    Id = hoangId,
                    Username = "hoang",
                    Password = "$2a$12$aYH6ji8QMczfCJxRGoBUqeTA7Ttk1JnanbTXBiafDDrrOQcy6hK7O",
                    FirstName = "Ngo Gia",
                    LastName = "Hoang",
                    Email = "hoangngqe170225@fpt.edu.vn",
                    RoleId = 3,
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fkxakd5_1730428320184_vendor-7.png?alt=media&token=9a4cabc8-8372-45d8-9d3e-364766154550",
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 7, 15),
                    SubscriptionType = SubscriptionType.Premium
                },
                new User
                {
                    Id = thinhId,
                    Username = "thinh",
                    Password = "$2a$12$kzs6W6lPdNmhq9mAxWfov.FJAHD2YDQJgQ/oiDeeMo78LKzDExz2O",
                    FirstName = "Gia",
                    LastName = "Thinh",
                    Email = "thinhhqgqs170196@fpt.edu.vn",
                    RoleId = 3,
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Ffc2hi5_1730428324559_vendor-9.png?alt=media&token=fa4632f1-2584-4496-9927-d0a645413638",
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 8, 15),
                    SubscriptionType = SubscriptionType.Premium
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
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fmrcf7_1730428331026_vendor-10.png?alt=media&token=9e787b31-eea6-4f38-a2c2-fa3c8a2140e1",
                    BackgroundImg = defaultBgrImg,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 9, 11),
                    SubscriptionType = SubscriptionType.Basic
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
                    Title = "Nhân Viên Bán Hàng Tạp Hóa Anh Ba",
                    SalaryRange = "100 - 150",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Tìm kiếm và phát triển khách hàng mới cho tạp hóa.\n" +
                    "- Đạt được mục tiêu doanh số hàng tháng của cửa hàng.\n" +
                    "- Hỗ trợ khách hàng trong quá trình mua sắm tại tạp hóa.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Có kinh nghiệm trong lĩnh vực bán hàng hoặc tạp hóa.\n" +
                    "- Kỹ năng giao tiếp tốt và thân thiện với khách hàng.\n" +
                    "- Có khả năng làm việc theo nhóm và độc lập.",
                    JobLocation = "Tạp Hóa Anh Ba, Đường Lê Lợi, Phường Trần Phú, Quy Nhơn, Bình Định",
                    UserId = huyId,
                    IndustryId = 4,
                    JobTypeId = 2,   
                    CreatedAt = new DateTime(2024, 1, 10),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Nhân Viên Kỹ Thuật Part-time",
                    SalaryRange = "700 - 1000",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Hỗ trợ kỹ thuật cho các sản phẩm công nghệ.\n" +
                    "- Giải quyết các sự cố kỹ thuật của khách hàng.\n" +
                    "- Tham gia vào các dự án nhỏ theo yêu cầu.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Có kiến thức về công nghệ thông tin.\n" +
                    "- Kỹ năng giải quyết vấn đề tốt.\n" +
                    "- Có khả năng làm việc độc lập.",
                    JobLocation = "Tòa nhà B, Đường Trần Hưng Đạo, Phường Hải Cảng, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 1,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 2, 5),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Thực Tập Sinh Marketing",
                    SalaryRange = "400 - 600",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing.\n" +
                    "- Nghiên cứu thị trường và phân tích dữ liệu khách hàng.\n" +
                    "- Theo dõi và báo cáo kết quả chiến dịch.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành marketing.\n" +
                    "- Kỹ năng giao tiếp tốt.\n" +
                    "- Có khả năng làm việc nhóm.",
                    JobLocation = "Tòa nhà C, Đường Nguyễn Huệ, Phường Lê Lợi, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 3,
                    CreatedAt = new DateTime(2024, 3, 15),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Nhân Viên Hỗ Trợ Khách Hàng Part-time",
                    SalaryRange = "500 - 800",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Hỗ trợ khách hàng qua điện thoại và email.\n" +
                    "- Giải quyết các vấn đề của khách hàng.\n" +
                    "- Cung cấp thông tin về sản phẩm và dịch vụ.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Kỹ năng giao tiếp và lắng nghe tốt.\n" +
                    "- Có khả năng làm việc dưới áp lực.\n" +
                    "- Chịu khó và cầu tiến.",
                    JobLocation = "Tòa nhà D, Đường Phạm Ngũ Lão, Phường Trần Phú, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 4, 20),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Nhân Viên Kinh Doanh Part-time",
                    SalaryRange = "600 - 900",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Tìm kiếm khách hàng và giới thiệu sản phẩm.\n" +
                    "- Đạt được chỉ tiêu doanh số tháng.\n" +
                    "- Duy trì mối quan hệ với khách hàng hiện tại.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Có kinh nghiệm trong lĩnh vực kinh doanh.\n" +
                    "- Kỹ năng giao tiếp tốt.\n" +
                    "- Có khả năng làm việc độc lập và theo nhóm.",
                    JobLocation = "Tòa nhà E, Đường Nguyễn Công Trứ, Phường Lê Lợi, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 5, 25),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Nhân Viên Marketing Part-time",
                    SalaryRange = "500 - 800",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing.\n" +
                    "- Phân tích dữ liệu và báo cáo kết quả.\n" +
                    "- Tham gia các hoạt động quảng bá sản phẩm.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Có kiến thức về marketing.\n" +
                    "- Kỹ năng phân tích và giao tiếp tốt.\n" +
                    "- Chịu khó và ham học hỏi.",
                    JobLocation = "Tòa nhà F, Đường Lý Thường Kiệt, Phường Xuân Diệu, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 6, 30),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Nhân Viên Tư Vấn Khách Hàng Part-time",
                    SalaryRange = "600 - 900",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Tư vấn sản phẩm cho khách hàng.\n" +
                    "- Hỗ trợ giải quyết thắc mắc của khách hàng.\n" +
                    "- Cập nhật thông tin về sản phẩm mới.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Kỹ năng giao tiếp tốt.\n" +
                    "- Có khả năng làm việc nhóm.\n" +
                    "- Chịu khó và nhiệt tình.",
                    JobLocation = "Tòa nhà G, Đường Đống Đa, Phường Bình Định, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 7, 15),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Nhân Viên Kỹ Thuật Part-time",
                    SalaryRange = "700 - 1000",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Hỗ trợ kỹ thuật cho các sản phẩm công nghệ.\n" +
                    "- Giải quyết các sự cố kỹ thuật.\n" +
                    "- Tham gia vào các dự án nhỏ theo yêu cầu.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Có kiến thức về kỹ thuật.\n" +
                    "- Kỹ năng giải quyết vấn đề tốt.\n" +
                    "- Có khả năng làm việc độc lập.",
                    JobLocation = "Tòa nhà H, Đường Phạm Văn Đồng, Phường Trần Phú, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 1,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 8, 5),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Nhân Viên Hỗ Trợ Marketing Part-time",
                    SalaryRange = "600 - 900",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing.\n" +
                    "- Phân tích và báo cáo kết quả chiến dịch.\n" +
                    "- Tham gia vào các hoạt động quảng bá sản phẩm.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Có kiến thức về marketing.\n" +
                    "- Kỹ năng phân tích và giao tiếp tốt.\n" +
                    "- Chịu khó và ham học hỏi.",
                    JobLocation = "Tòa nhà I, Đường Nguyễn Thái Học, Phường Lê Lợi, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 9, 10),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Thực Tập Sinh Kinh Doanh",
                    SalaryRange = "400 - 600",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Hỗ trợ thực hiện các kế hoạch kinh doanh.\n" +
                    "- Nghiên cứu thị trường và phân tích dữ liệu khách hàng.\n" +
                    "- Theo dõi và báo cáo kết quả.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành kinh doanh.\n" +
                    "- Kỹ năng giao tiếp tốt.\n" +
                    "- Có khả năng làm việc nhóm.",
                    JobLocation = "Tòa nhà J, Đường Nguyễn Công Trứ, Phường Lê Lợi, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 3,
                    CreatedAt = new DateTime(2024, 10, 5),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Thực Tập Sinh Digital Marketing",
                    SalaryRange = "400 - 600",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing số.\n" +
                    "- Theo dõi và phân tích dữ liệu trên các kênh truyền thông.\n" +
                    "- Cập nhật thông tin về sản phẩm và dịch vụ.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành marketing.\n" +
                    "- Kỹ năng phân tích và giao tiếp tốt.\n" +
                    "- Chịu khó và nhiệt tình.",
                    JobLocation = "Tòa nhà K, Đường Trần Phú, Phường Trần Phú, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 3,
                    CreatedAt = new DateTime(2024, 10, 15),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Thực Tập Sinh Kỹ Thuật IT",
                    SalaryRange = "400 - 600",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Hỗ trợ kỹ thuật trong các dự án IT.\n" +
                    "- Học hỏi và phát triển kỹ năng chuyên môn.\n" +
                    "- Tham gia vào các công việc hàng ngày của nhóm kỹ thuật.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành IT.\n" +
                    "- Có kiến thức cơ bản về lập trình.\n" +
                    "- Nhiệt tình và ham học hỏi.",
                    JobLocation = "Tòa nhà L, Đường Lý Thường Kiệt, Phường Xuân Diệu, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 1,
                    JobTypeId = 3,
                    CreatedAt = new DateTime(2024, 10, 25),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                }, 

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Quản Lý Marketing",
                    SalaryRange = "2500 - 3500",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Lập kế hoạch và thực hiện các chiến dịch marketing.\n" +
                    "- Quản lý ngân sách marketing và báo cáo kết quả.\n" +
                    "- Phân tích xu hướng thị trường và nhu cầu khách hàng.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Tối thiểu 3 năm kinh nghiệm trong lĩnh vực marketing.\n" +
                    "- Kỹ năng lãnh đạo và giao tiếp tốt.\n" +
                    "- Tốt nghiệp chuyên ngành marketing hoặc tương đương.",
                    JobLocation = "Tòa nhà M, Đường Phạm Ngũ Lão, Phường Trần Phú, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 1,
                    CreatedAt = new DateTime(2024, 11, 5),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Chuyên Viên Phân Tích Dữ Liệu",
                    SalaryRange = "2000 - 3000",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Phân tích dữ liệu để đưa ra quyết định chiến lược.\n" +
                    "- Tạo báo cáo và trình bày kết quả phân tích.\n" +
                    "- Hỗ trợ các bộ phận khác trong việc sử dụng dữ liệu.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Kinh nghiệm trong phân tích dữ liệu.\n" +
                    "- Kỹ năng sử dụng các công cụ phân tích và báo cáo.\n" +
                    "- Tốt nghiệp chuyên ngành thống kê, kinh tế hoặc tương đương.",
                    JobLocation = "Tòa nhà N, Đường Trần Hưng Đạo, Phường Hải Cảng, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 1,
                    JobTypeId = 1,
                    CreatedAt = new DateTime(2024, 11, 10),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Chuyên Viên Kinh Doanh",
                    SalaryRange = "2500 - 3500",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Phát triển và duy trì mối quan hệ với khách hàng.\n" +
                    "- Đạt được mục tiêu doanh số hàng tháng.\n" +
                    "- Phân tích nhu cầu của khách hàng để đề xuất các giải pháp phù hợp.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Kinh nghiệm trong lĩnh vực kinh doanh.\n" +
                    "- Kỹ năng giao tiếp và thuyết phục tốt.\n" +
                    "- Tốt nghiệp chuyên ngành kinh tế hoặc tương đương.",
                    JobLocation = "Tòa nhà O, Đường Đống Đa, Phường Bình Định, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 1,
                    CreatedAt = new DateTime(2024, 11, 15),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Kỹ Sư Phần Mềm",
                    SalaryRange = "3000 - 4000",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Phát triển và duy trì các ứng dụng phần mềm.\n" +
                    "- Làm việc với các nhóm để phát triển sản phẩm.\n" +
                    "- Thực hiện kiểm thử và sửa lỗi phần mềm.\n\n" + "Yêu cầu ứng viên:\n" +
                    "- Có ít nhất 2 năm kinh nghiệm lập trình.\n" +
                    "- Thành thạo một hoặc nhiều ngôn ngữ lập trình.\n" +
                    "- Kỹ năng làm việc nhóm và giải quyết vấn đề tốt.",
                    JobLocation = "Tòa nhà P, Đường Nguyễn Thái Học, Phường Lê Lợi, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 1,
                    JobTypeId = 1,
                    CreatedAt = new DateTime(2024, 11, 20),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Giám Đốc Dự Án",
                    SalaryRange = "4000 - 5000",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Lập kế hoạch và giám sát tiến độ dự án.\n" +
                    "- Quản lý nguồn lực và ngân sách dự án.\n" +
                    "- Đảm bảo các mục tiêu dự án được thực hiện đúng hạn.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Tối thiểu 5 năm kinh nghiệm trong quản lý dự án.\n" +
                    "- Kỹ năng lãnh đạo và quản lý tốt.\n" +
                    "- Tốt nghiệp chuyên ngành quản trị kinh doanh hoặc tương đương.",
                    JobLocation = "Tòa nhà Q, Đường Nguyễn Công Trứ, Phường Lê Lợi, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 1,
                    CreatedAt = new DateTime(2024, 11, 25),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Chuyên Viên Tư Vấn Tài Chính",
                    SalaryRange = "3500 - 4500",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Tư vấn và quản lý các dịch vụ tài chính cho khách hàng.\n" +
                    "- Phân tích và đánh giá tình hình tài chính của khách hàng.\n" +
                    "- Xây dựng các kế hoạch tài chính phù hợp.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Kinh nghiệm trong lĩnh vực tài chính hoặc ngân hàng.\n" +
                    "- Kỹ năng giao tiếp và thuyết phục tốt.\n" +
                    "- Tốt nghiệp chuyên ngành tài chính hoặc tương đương.",
                    JobLocation = "Tòa nhà R, Đường Trần Nhân Tông, Phường Trần Phú, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 1,
                    CreatedAt = new DateTime(2024, 11, 30),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Nhân Viên Tổ Chức Sự Kiện Part-time",
                    SalaryRange = "500 - 800",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Hỗ trợ tổ chức và quản lý các sự kiện.\n" +
                    "- Liên lạc với các nhà cung cấp và khách hàng.\n" +
                    "- Đảm bảo mọi thứ diễn ra suôn sẻ trong sự kiện.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Kỹ năng tổ chức và giao tiếp tốt.\n" +
                    "- Có khả năng làm việc dưới áp lực cao.\n" +
                    "- Nhiệt tình và sáng tạo.",
                    JobLocation = "Tòa nhà S, Đường Nguyễn Thái Học, Phường Lê Lợi, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 2,
                    CreatedAt = new DateTime(2024, 12, 1),
                    ModifiedAt = DateTime.UtcNow,
                    ExpiredAt = DateTime.UtcNow.AddMonths(1),
                    Status = Status.Active
                },

                new JobPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Chuyên Viên Phát Triển Thị Trường",
                    SalaryRange = "3.000 - 7.000",
                    JobDescription = "Tổng quan vị trí:\n" +
                    "- Nghiên cứu và phân tích thị trường để phát triển chiến lược.\n" +
                    "- Phát triển mối quan hệ với khách hàng và đối tác.\n" +
                    "- Tạo báo cáo và đề xuất các giải pháp kinh doanh.\n\n" +
                    "Yêu cầu ứng viên:\n" +
                    "- Tối thiểu 2 năm kinh nghiệm trong phát triển thị trường.\n" +
                    "- Kỹ năng phân tích và giao tiếp tốt.\n" +
                    "- Tốt nghiệp chuyên ngành kinh tế, marketing hoặc tương đương.",
                    JobLocation = "Tòa nhà T, Đường Trần Hưng Đạo, Phường Hải Cảng, Quy Nhơn, Bình Định",
                    UserId = recruiterId,
                    IndustryId = 2,
                    JobTypeId = 1,
                    CreatedAt = new DateTime(2024, 12, 5),
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
