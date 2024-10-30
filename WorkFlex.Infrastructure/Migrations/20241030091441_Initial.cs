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
                    { 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7355), "Software Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7357), "Artificial Intelligence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7358), "Healthcare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7359), "Finance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7360), "Transportation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7361), "Agriculture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7362), "Customer Service", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7363), "Marketing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7364), "Education", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7365), "Logistics", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "TypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7306), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Time" },
                    { 2, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7309), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Part Time" },
                    { 3, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7310), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internship" }
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
                    { new Guid("2a05cb86-de0a-456e-aa0f-feb165433029"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7223), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" },
                    { new Guid("7c9d1ddc-51e9-400e-9acb-e9e3ea0d1115"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7213), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("e16702dc-edc3-4311-950a-5c78a273f377"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7227), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" }
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("052892fd-40e9-47e9-ad18-a7079e8d774e"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7511), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7512), 1, "Position Overview:\n- Manage and maintain the company's databases.\n- Optimize query performance and data security.\n- Support users in accessing and using databases.\n\nCandidate Requirements:\n- Experience with SQL Server, MySQL, or Oracle.\n- Strong analytical and problem-solving skills.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7512), "2000 - 2500", 0, "Database Administrator", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("0f73a3ec-2fc0-4e9f-922f-2493a25d168c"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7407), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7408), 1, "Position Overview:\n- Develop and maintain web applications.\n- Participate in the design and product development process.\n- Optimize performance and security of web applications.\n\nCandidate Requirements:\n- Experience with HTML, CSS, JavaScript, and PHP.\n- Problem-solving skills and logical thinking.\n- Graduate in IT or equivalent.", "Tòa nhà A, Số 12, Phố Nguyễn Trãi, Quận Thanh Xuân, Hải Phòng", 2, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7408), "1500 - 2000", 0, "Web Developer", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("19caef04-429a-4b2f-bfc2-753dc6b47567"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7483), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7484), 4, "Position Overview:\n- Analyze business requirements and processes.\n- Collaborate with departments to improve operational efficiency.\n- Prepare analytical documents and reports for management.\n\nCandidate Requirements:\n- Experience in business analysis.\n- Good communication and teamwork skills.\n- Graduate in business administration or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Đà Nẵng", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7484), "2000 - 2500", 0, "Business Analyst", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("1f8581e8-b369-437e-83de-64b1c045d552"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7464), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7465), 2, "Position Overview:\n- Responsible for product development and management.\n- Coordinate with departments to ensure product timelines.\n- Research market trends and analyze customer needs.\n\nCandidate Requirements:\n- At least 3 years of experience in product management.\n- Strong leadership and communication skills.\n- Graduate in business management or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7465), "3000 - 3500", 0, "Product Manager", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("25970497-903e-40f4-a2aa-f2f8bb3ef14d"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7516), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7517), 2, "Position Overview:\n- Plan and implement marketing campaigns.\n- Manage marketing budgets and report results.\n- Analyze market trends and customer needs.\n\nCandidate Requirements:\n- At least 3 years of experience in marketing.\n- Strong leadership and communication skills.\n- Graduate in marketing or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7516), "2500 - 3000", 0, "Marketing Manager", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("2c23c650-386c-48a1-830e-4b6f7512b2da"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7479), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7480), 8, "Position Overview:\n- Build and implement digital marketing campaigns.\n- Manage social media channels and optimize advertisements.\n- Analyze campaign effectiveness and report results.\n\nCandidate Requirements:\n- Experience in digital marketing.\n- Analytical skills and proficiency in online marketing tools.\n- Graduate in marketing or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7480), "1500 - 2000", 0, "Digital Marketing Specialist", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("33ece889-02a7-477b-ab4f-fbd8abadcaed"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7455), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7456), 1, "Position Overview:\n- Design and implement computer networks.\n- Monitor and maintain network systems.\n- Troubleshoot network-related issues.\n\nCandidate Requirements:\n- Experience with networking equipment.\n- CCNA certification is a plus.\n- Graduate in IT or equivalent.", "Tòa nhà B, Số 34, Phố Lê Văn Sỹ, Quận 3, Hà Nội", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7456), "2500 - 3000", 0, "Network Engineer", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("36fddd95-2455-46dc-b1c4-a315e4187767"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7447), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7448), 4, "Position Overview:\n- Seek and develop new customers.\n- Conduct calls and meet clients to introduce products.\n- Achieve monthly sales targets.\n\nCandidate Requirements:\n- Experience in sales.\n- Good communication and persuasion skills.\n- University graduate in business or equivalent.", "Văn phòng 4, Số 150, Phố Trần Hưng Đạo, Quận 5, Hồ Chí Minh", 2, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7448), "2000 - 2500", 0, "Sales Executive", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("3f5fd29c-62c9-4927-83d4-52dfd10b8613"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7432), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7433), 2, "Position Overview:\n- Manage the recruitment and training processes for new employees.\n- Develop HR policies and manage performance.\n- Advise management on HR-related issues.\n\nCandidate Requirements:\n- At least 3 years of experience in a similar position.\n- Strong communication and leadership skills.\n- Graduate in human resource management or equivalent.", "Văn phòng 3, Số 78, Phố Nguyễn Trãi, Quận Thanh Xuân, Hà Nội", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7432), "2500 - 3000", 0, "HR Manager", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("3fec9393-5be4-4d9a-9e3f-08db3594aeb3"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7501), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7502), 1, "Position Overview:\n- Design and implement cloud computing solutions.\n- Manage infrastructure and data security in the cloud.\n- Optimize costs and system performance.\n\nCandidate Requirements:\n- Experience with AWS, Azure, or Google Cloud.\n- Programming skills and understanding of computer networks.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Đà Nẵng", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7502), "2500 - 3000", 0, "Cloud Engineer", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("4417e32d-ad60-4302-aa82-da453e568ecc"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7437), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7438), 8, "Position Overview:\n- Design graphic products for marketing campaigns.\n- Collaborate with other departments to create creative content.\n- Maintain the company’s brand and design style.\n\nCandidate Requirements:\n- Experience with Adobe Illustrator, Photoshop.\n- Creative thinking and ability to work under pressure.\n- Graduate in graphic design or equivalent.", "Tầng trệt, Số 92, Phố Võ Văn Kiệt, Quận 1, Hồ Chí Minh", 2, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7437), "1200 - 1500", 0, "Graphic Designer", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("4b932f05-563b-4088-b3a1-95ab5961ff85"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7496), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7497), 1, "Position Overview:\n- Develop and maintain mobile applications on iOS and Android.\n- Participate in product design and development processes.\n- Optimize application performance.\n\nCandidate Requirements:\n- Experience with Swift, Kotlin, or React Native.\n- Creative problem-solving skills.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7497), "2000 - 2500", 0, "Mobile App Developer", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("57fe3f04-09f8-4ade-b881-71f975ff0cce"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7506), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7507), 1, "Position Overview:\n- Analyze and assess security risks.\n- Implement measures to protect information systems.\n- Monitor and respond to security incidents.\n\nCandidate Requirements:\n- Experience in cybersecurity.\n- Certifications such as CISSP or CEH are a plus.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7506), "3000 - 3500", 0, "Cybersecurity Analyst", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("6c16179c-379f-4bc6-aa3a-2061ed177c3a"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7488), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7489), 7, "Position Overview:\n- Provide customer support via phone, email, and chat.\n- Resolve customer issues quickly and effectively.\n- Collect customer feedback to improve services.\n\nCandidate Requirements:\n- Good communication and listening skills.\n- Experience in customer service is an advantage.\n- Graduate from vocational school or higher.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội", 2, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7489), "1000 - 1500", 0, "Customer Support Specialist", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("7b44c719-2c45-429f-9a7c-170f8169953b"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7460), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7461), 8, "Position Overview:\n- Optimize websites to improve search engine rankings.\n- Research and analyze keywords.\n- Monitor and report on SEO performance.\n\nCandidate Requirements:\n- Experience in SEO.\n- Good analytical and problem-solving skills.\n- Graduate in marketing or equivalent.", "Văn phòng 7, Số 88, Phố Nguyễn Đình Chiểu, Quận 1, Đà Nẵng", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7460), "1500 - 2000", 0, "SEO Specialist", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("93bbf39f-2347-413e-861d-5d4e44fe106a"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7427), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7428), 1, "Position Overview:\n- Design user interfaces for applications and websites.\n- Research and analyze user needs to improve experiences.\n- Create design prototypes and collaborate with development teams.\n\nCandidate Requirements:\n- Experience with Figma, Sketch, or Adobe XD.\n- Good communication and teamwork skills.\n- Graduate in design or equivalent.", "Tầng 2, Số 45, Phố Lê Lai, Quận 1, Hồ Chí Minh", 2, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7427), "1800 - 2200", 0, "UX/UI Designer", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("9fa99d22-d367-4174-8791-5a8be05499bc"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7469), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7470), 1, "Position Overview:\n- Perform software testing to ensure product quality.\n- Analyze and report bugs.\n- Collaborate with development engineers to improve testing processes.\n\nCandidate Requirements:\n- Experience in software testing.\n- Understanding of software development processes.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7470), "1500 - 1800", 0, "Software Tester", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("a691d792-63e2-49f0-8cfa-16eedd315b23"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7441), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7442), 8, "Position Overview:\n- Write content for blogs, websites, and social media.\n- Research and develop new content topics.\n- Optimize content for SEO.\n\nCandidate Requirements:\n- Good writing and editing skills.\n- Experience in content writing is a plus.\n- Graduate in journalism, communication, or equivalent.", "Văn phòng 10, Số 56, Phố Nguyễn Thị Minh Khai, Quận Hải Châu, Đà Nẵng", 2, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7442), "1000 - 1500", 0, "Content Writer", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("d6aceb1a-882a-4568-8700-866a5d8159a6"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7473), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7474), 4, "Position Overview:\n- Analyze financial situations and prepare financial reports.\n- Provide investment and risk management recommendations.\n- Monitor and analyze market trends.\n\nCandidate Requirements:\n- Experience in financial analysis.\n- Strong analytical and reporting skills.\n- Graduate in finance or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7474), "2500 - 3000", 0, "Financial Analyst", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") },
                    { new Guid("d932ccfc-1bf3-471b-9b04-e6da182b2c1e"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7421), new DateTime(2024, 11, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7422), 2, "Position Overview:\n- Analyze data and create reports for management.\n- Use analytical tools to detect data trends.\n- Collaborate with other departments to improve processes based on data.\n\nCandidate Requirements:\n- Experience with Excel, SQL, and data analysis tools.\n- Communication and data presentation skills.\n- Graduate in statistics, mathematics, or equivalent.", "Văn phòng 5, Số 23, Phố Lê Duẩn, Quận Hải Châu, Đà Nẵng", 1, new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7422), "2000 - 2500", 0, "Data Analyst", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId", "Website" },
                values: new object[,]
                {
                    { new Guid("695cfb22-68ba-47fc-aaec-7715a146c7f2"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7272), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("e16702dc-edc3-4311-950a-5c78a273f377"), null },
                    { new Guid("6fb1bcf4-a939-4781-a7e6-24cde1044757"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7270), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2a05cb86-de0a-456e-aa0f-feb165433029"), null },
                    { new Guid("be695160-5698-4dda-8e0d-63f7fc7036f7"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7264), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("7c9d1ddc-51e9-400e-9acb-e9e3ea0d1115"), null }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ApplicationDate", "CvFile", "Description", "JobPostId", "Status", "UserId" },
                values: new object[] { new Guid("4a778eb2-c33d-4fd4-a7ca-ebc198588cea"), new DateTime(2024, 10, 30, 9, 14, 40, 911, DateTimeKind.Utc).AddTicks(7567), "path/to/cv.pdf", "", new Guid("0f73a3ec-2fc0-4e9f-922f-2493a25d168c"), 2, new Guid("e16702dc-edc3-4311-950a-5c78a273f377") });

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
