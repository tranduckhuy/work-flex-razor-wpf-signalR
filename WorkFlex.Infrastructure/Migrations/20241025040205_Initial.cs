using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkFlex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BackgroundImg = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsLock = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsRecruiterRequestPending = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserOne = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserTwo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_Users_UserOne",
                        column: x => x.UserOne,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversations_Users_UserTwo",
                        column: x => x.UserTwo,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SalaryRange = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    JobTypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPosts_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPosts_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConversationReplies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversationReplies_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversationReplies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CvFile = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_JobPosts_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobApplications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CreatedAt", "IndustryName", "ModifiedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2029), "Software Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2032), "Artificial Intelligence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2032), "Healthcare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2033), "Finance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2034), "Transportation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2034), "Agriculture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2035), "Customer Service", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2036), "Marketing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2036), "Education", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2037), "Logistics", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "TypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2007), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Time" },
                    { 2, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2009), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Part Time" },
                    { 3, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2010), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internship" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Recruiter" },
                    { 3, "JobSeeker" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "BackgroundImg", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsActive", "IsLock", "IsRecruiterRequestPending", "LastName", "Location", "ModifiedAt", "Password", "Phone", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("69350bda-5910-4a19-98a9-90f4695b2975"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(1954), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" },
                    { new Guid("cf1c3d4e-6e07-43cd-b237-6f94366d466f"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(1951), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("f7755a76-5c34-472c-a3c7-6e7b88c2ad4f"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(1957), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" }
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("02e34f01-3c96-487f-acb5-d99d0e2606df"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2144), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2144), 1, "Job Description:\n- Manage and maintain the company's databases.\n- Optimize query performance and data security.\n- Support users in accessing and using databases.\n\nCandidate Requirements:\n- Experience with SQL Server, MySQL, or Oracle.\n- Strong analytical and problem-solving skills.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2144), "2000 - 2500", 0, "Database Administrator", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("1042b213-a576-40a4-b90e-55ec7858259d"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2067), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2068), 1, "Job Description:\n- Develop and maintain web applications.\n- Participate in the design and product development process.\n- Optimize performance and security of web applications.\n\nCandidate Requirements:\n- Experience with HTML, CSS, JavaScript, and PHP.\n- Problem-solving skills and logical thinking.\n- Graduate in IT or equivalent.", "Tòa nhà A, Số 12, Phố Nguyễn Trãi, Quận Thanh Xuân, Hà Nội", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2068), "1500 - 2000", 0, "Web Developer", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("120361d1-1fed-4103-a2d5-5c198d06728e"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2081), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2082), 2, "Job Description:\n- Analyze data and create reports for management.\n- Use analytical tools to detect data trends.\n- Collaborate with other departments to improve processes based on data.\n\nCandidate Requirements:\n- Experience with Excel, SQL, and data analysis tools.\n- Communication and data presentation skills.\n- Graduate in statistics, mathematics, or equivalent.", "Văn phòng 5, Số 23, Phố Lê Duẩn, Quận Hải Châu, Đà Nẵng", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2082), "2000 - 2500", 0, "Data Analyst", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("143300d3-9561-4b91-8961-8eaeb9e75a51"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2124), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2124), 8, "Job Description:\n- Build and implement digital marketing campaigns.\n- Manage social media channels and optimize advertisements.\n- Analyze campaign effectiveness and report results.\n\nCandidate Requirements:\n- Experience in digital marketing.\n- Analytical skills and proficiency in online marketing tools.\n- Graduate in marketing or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2124), "1500 - 2000", 0, "Digital Marketing Specialist", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("1d90bfb7-d319-482f-a86c-1c9b44180acf"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2104), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2104), 4, "Job Description:\n- Seek and develop new customers.\n- Conduct calls and meet clients to introduce products.\n- Achieve monthly sales targets.\n\nCandidate Requirements:\n- Experience in sales.\n- Good communication and persuasion skills.\n- University graduate in business or equivalent.", "Văn phòng 4, Số 150, Phố Trần Hưng Đạo, Quận 5, Hồ Chí Minh", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2104), "2000 - 2500", 0, "Sales Executive", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("2641b128-0308-43ae-ab5d-2a469b97fc48"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2141), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2142), 1, "Job Description:\n- Analyze and assess security risks.\n- Implement measures to protect information systems.\n- Monitor and respond to security incidents.\n\nCandidate Requirements:\n- Experience in cybersecurity.\n- Certifications such as CISSP or CEH are a plus.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2141), "3000 - 3500", 0, "Cybersecurity Analyst", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("4729b89a-4019-4883-8ef4-e3d201b40747"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2138), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2139), 1, "Job Description:\n- Design and implement cloud computing solutions.\n- Manage infrastructure and data security in the cloud.\n- Optimize costs and system performance.\n\nCandidate Requirements:\n- Experience with AWS, Azure, or Google Cloud.\n- Programming skills and understanding of computer networks.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Đà Nẵng", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2138), "2500 - 3000", 0, "Cloud Engineer", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("70453267-2341-4a47-9d7e-99a4e4e10578"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2091), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2091), 8, "Job Description:\n- Design graphic products for marketing campaigns.\n- Collaborate with other departments to create creative content.\n- Maintain the company’s brand and design style.\n\nCandidate Requirements:\n- Experience with Adobe Illustrator, Photoshop.\n- Creative thinking and ability to work under pressure.\n- Graduate in graphic design or equivalent.", "Tầng trệt, Số 92, Phố Võ Văn Kiệt, Quận 1, Hồ Chí Minh", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2091), "1200 - 1500", 0, "Graphic Designer", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("71d5e743-2b30-4a9f-8534-ec3ba5f9798a"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2126), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2127), 4, "Job Description:\n- Analyze business requirements and processes.\n- Collaborate with departments to improve operational efficiency.\n- Prepare analytical documents and reports for management.\n\nCandidate Requirements:\n- Experience in business analysis.\n- Good communication and teamwork skills.\n- Graduate in business administration or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Đà Nẵng", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2127), "2000 - 2500", 0, "Business Analyst", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("7368b384-bb7b-4326-b084-caf8087f8c70"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2121), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2121), 4, "Job Description:\n- Analyze financial situations and prepare financial reports.\n- Provide investment and risk management recommendations.\n- Monitor and analyze market trends.\n\nCandidate Requirements:\n- Experience in financial analysis.\n- Strong analytical and reporting skills.\n- Graduate in finance or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2121), "2500 - 3000", 0, "Financial Analyst", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("7fbe173d-1d48-4682-8c65-9dbd2f169090"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2112), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2112), 8, "Job Description:\n- Optimize websites to improve search engine rankings.\n- Research and analyze keywords.\n- Monitor and report on SEO performance.\n\nCandidate Requirements:\n- Experience in SEO.\n- Good analytical and problem-solving skills.\n- Graduate in marketing or equivalent.", "Văn phòng 7, Số 88, Phố Nguyễn Đình Chiểu, Quận 1, Đà Nẵng", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2112), "1500 - 2000", 0, "SEO Specialist", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("7fde71d8-3261-4e41-9d3b-0d66306e11c7"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2118), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2118), 1, "Job Description:\n- Perform software testing to ensure product quality.\n- Analyze and report bugs.\n- Collaborate with development engineers to improve testing processes.\n\nCandidate Requirements:\n- Experience in software testing.\n- Understanding of software development processes.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2118), "1500 - 1800", 0, "Software Tester", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("828ccd46-20ab-4249-931f-cbf7441d81d8"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2088), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2088), 2, "Job Description:\n- Manage the recruitment and training processes for new employees.\n- Develop HR policies and manage performance.\n- Advise management on HR-related issues.\n\nCandidate Requirements:\n- At least 3 years of experience in a similar position.\n- Strong communication and leadership skills.\n- Graduate in human resource management or equivalent.", "Văn phòng 3, Số 78, Phố Nguyễn Trãi, Quận Thanh Xuân, Hà Nội", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2088), "2500 - 3000", 0, "HR Manager", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("93d23b45-2217-45e8-9acb-a907287caf62"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2132), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2134), 1, "Job Description:\n- Develop and maintain mobile applications on iOS and Android.\n- Participate in product design and development processes.\n- Optimize application performance.\n\nCandidate Requirements:\n- Experience with Swift, Kotlin, or React Native.\n- Creative problem-solving skills.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2134), "2000 - 2500", 0, "Mobile App Developer", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("a79fc53c-08df-4a2b-ba7d-772210541a0d"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2101), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2101), 8, "Job Description:\n- Write content for blogs, websites, and social media.\n- Research and develop new content topics.\n- Optimize content for SEO.\n\nCandidate Requirements:\n- Good writing and editing skills.\n- Experience in content writing is a plus.\n- Graduate in journalism, communication, or equivalent.", "Văn phòng 10, Số 56, Phố Nguyễn Thị Minh Khai, Quận Hải Châu, Đà Nẵng", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2101), "1000 - 1500", 0, "Content Writer", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("aedb36cf-42d5-47e0-bcfd-a6139b4dba26"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2085), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2085), 1, "Job Description:\n- Design user interfaces for applications and websites.\n- Research and analyze user needs to improve experiences.\n- Create design prototypes and collaborate with development teams.\n\nCandidate Requirements:\n- Experience with Figma, Sketch, or Adobe XD.\n- Good communication and teamwork skills.\n- Graduate in design or equivalent.", "Tầng 2, Số 45, Phố Lê Lai, Quận 1, Hồ Chí Minh", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2085), "1800 - 2200", 0, "UX/UI Designer", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("caeebf14-d12e-4d02-84a8-bd40e9587a02"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2129), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2130), 7, "Job Description:\n- Provide customer support via phone, email, and chat.\n- Resolve customer issues quickly and effectively.\n- Collect customer feedback to improve services.\n\nCandidate Requirements:\n- Good communication and listening skills.\n- Experience in customer service is an advantage.\n- Graduate from vocational school or higher.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2130), "1000 - 1500", 0, "Customer Support Specialist", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("e3c7429d-d38a-4a07-a264-70f31de5b503"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2107), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2108), 1, "Job Description:\n- Design and implement computer networks.\n- Monitor and maintain network systems.\n- Troubleshoot network-related issues.\n\nCandidate Requirements:\n- Experience with networking equipment.\n- CCNA certification is a plus.\n- Graduate in IT or equivalent.", "Tòa nhà B, Số 34, Phố Lê Văn Sỹ, Quận 3, Hà Nội", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2107), "2500 - 3000", 0, "Network Engineer", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("e942dcef-ce41-438d-9b48-18167b98cd92"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2115), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2115), 2, "Job Description:\n- Responsible for product development and management.\n- Coordinate with departments to ensure product timelines.\n- Research market trends and analyze customer needs.\n\nCandidate Requirements:\n- At least 3 years of experience in product management.\n- Strong leadership and communication skills.\n- Graduate in business management or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2115), "3000 - 3500", 0, "Product Manager", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") },
                    { new Guid("f4d6969d-a090-4dbb-a4aa-8b25c56480e2"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2147), new DateTime(2024, 11, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2147), 2, "Job Description:\n- Plan and implement marketing campaigns.\n- Manage marketing budgets and report results.\n- Analyze market trends and customer needs.\n\nCandidate Requirements:\n- At least 3 years of experience in marketing.\n- Strong leadership and communication skills.\n- Graduate in marketing or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 1, new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2147), "2500 - 3000", 0, "Marketing Manager", new Guid("69350bda-5910-4a19-98a9-90f4695b2975") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId", "Website" },
                values: new object[,]
                {
                    { new Guid("687a0532-cdc8-49f4-ab4a-25ae6eab6438"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(1980), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("cf1c3d4e-6e07-43cd-b237-6f94366d466f"), null },
                    { new Guid("75a58bdb-3c38-4817-bde4-6979c0034739"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(1987), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("69350bda-5910-4a19-98a9-90f4695b2975"), null },
                    { new Guid("7851a8ec-b85c-47a5-a780-f9a5e85d97a2"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(1989), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("f7755a76-5c34-472c-a3c7-6e7b88c2ad4f"), null }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ApplicationDate", "CvFile", "Description", "JobPostId", "Status", "UserId" },
                values: new object[] { new Guid("11a72a3d-1a93-43db-8bd1-7a2dc3d40037"), new DateTime(2024, 10, 25, 4, 2, 5, 375, DateTimeKind.Utc).AddTicks(2180), "path/to/cv.pdf", "", new Guid("1042b213-a576-40a4-b90e-55ec7858259d"), 2, new Guid("f7755a76-5c34-472c-a3c7-6e7b88c2ad4f") });

            migrationBuilder.CreateIndex(
                name: "IX_ConversationReplies_ConversationId",
                table: "ConversationReplies",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationReplies_UserId",
                table: "ConversationReplies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_UserOne",
                table: "Conversations",
                column: "UserOne");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_UserTwo",
                table: "Conversations",
                column: "UserTwo");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobPostId",
                table: "JobApplications",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_UserId",
                table: "JobApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_IndustryId",
                table: "JobPosts",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_JobTypeId",
                table: "JobPosts",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_UserId",
                table: "JobPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversationReplies");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "JobPosts");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
