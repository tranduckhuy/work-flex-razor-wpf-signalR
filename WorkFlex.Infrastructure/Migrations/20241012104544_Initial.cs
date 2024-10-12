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
                    Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsLock = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241012104544_Initial.cs
                    { 1, new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2230), "Software Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2232), "Artificial Intelligence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2232), "Healthcare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2233), "Finance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2234), "Transportation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2234), "Agriculture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
========
                    { 1, new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1775), "Software Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1778), "Artificial Intelligence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1779), "Healthcare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1779), "Finance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1780), "Transportation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1781), "Agriculture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
>>>>>>>> 252893c40bb6d32524e3c84cb2d97364e003deb9:WorkFlex.Infrastructure/Migrations/20241011030449_Initial.cs
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "TypeName" },
                values: new object[,]
                {
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241012104544_Initial.cs
                    { 1, new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2209), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Time" },
                    { 2, new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2211), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Part Time" },
                    { 3, new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2212), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internship" }
========
                    { 1, new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1752), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Time" },
                    { 2, new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1755), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Part Time" },
                    { 3, new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1756), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internship" }
>>>>>>>> 252893c40bb6d32524e3c84cb2d97364e003deb9:WorkFlex.Infrastructure/Migrations/20241011030449_Initial.cs
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
                columns: new[] { "Id", "Avatar", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsActive", "IsLock", "LastName", "Location", "ModifiedAt", "Password", "Phone", "RoleId", "Username" },
                values: new object[,]
                {
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241012104544_Initial.cs
                    { new Guid("cc04dca7-51c8-4ad7-92f5-fe34d16bcd30"), "", new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2152), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@@", "", 3, "jobseeker" },
                    { new Guid("cd995775-997e-4077-b980-076556d81a6b"), "", new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2136), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@@", "", 1, "admin" },
                    { new Guid("fcfb701b-ba0d-41e6-943d-126aea87ba4b"), "", new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2141), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@", "", 2, "recruiter" }
========
                    { new Guid("1f62f10c-2653-488d-8d52-21b3a86d23fc"), "", new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1702), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" },
                    { new Guid("3cbc5bb3-6339-4caa-9289-627dd9e6dd15"), "", new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1698), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("982ef243-9fcf-4da4-8139-cfc54d16527c"), "", new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1705), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" }
>>>>>>>> 252893c40bb6d32524e3c84cb2d97364e003deb9:WorkFlex.Infrastructure/Migrations/20241011030449_Initial.cs
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241012104544_Initial.cs
                    { new Guid("2fb27653-151f-4a61-a36b-d64db5c08365"), new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2280), new DateTime(2024, 11, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2280), 3, "We are looking for a nurse to join our team. Must have a nursing degree and at least 2 years of experience.", "Số 1, Đại Cồ Việt, Hai Bà Trưng, Hà Nội", 1, new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2280), "", 0, "Nurse", new Guid("fcfb701b-ba0d-41e6-943d-126aea87ba4b") },
                    { new Guid("74de2430-18d0-4abc-85ca-89ba8900861d"), new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2260), new DateTime(2024, 11, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2262), 1, "Looking for a skilled software engineer. Must have experience with C# and .NET Core. Angular experience is a plus.", "Số 13, Tân Thuận Đông, Quận 7, Hồ Chí Minh", 1, new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2261), "", 0, "Software Engineer", new Guid("fcfb701b-ba0d-41e6-943d-126aea87ba4b") },
                    { new Guid("a0daa583-8e0e-40d6-b92a-9ea7ec67f281"), new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2276), new DateTime(2024, 11, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2277), 2, "Looking for a data scientist to join our AI team. Must have experience with Python, TensorFlow, and Keras.", " 239 Đ. Xuân Thủy, Dịch Vọng Hậu, Cầu Giấy, Hà Nội", 1, new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2276), "", 0, "AI Engineer", new Guid("fcfb701b-ba0d-41e6-943d-126aea87ba4b") }
========
                    { new Guid("2c6f50f0-ffe5-4e4c-b32b-02394029cad0"), new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1806), new DateTime(2024, 11, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1807), 1, "Looking for a skilled software engineer. Must have experience with C# and .NET Core. Angular experience is a plus.", "Số 13, Tân Thuận Đông, Quận 7, Hồ Chí Minh", 1, new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1806), "1000 - 6000", 0, "Software Engineer", new Guid("1f62f10c-2653-488d-8d52-21b3a86d23fc") },
                    { new Guid("ab2b0bea-e2be-4916-acd0-5b67ed8ae4b1"), new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1820), new DateTime(2024, 11, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1820), 2, "Looking for a data scientist to join our AI team. Must have experience with Python, TensorFlow, and Keras.", " 239 Đ. Xuân Thủy, Dịch Vọng Hậu, Cầu Giấy, Hà Nội", 1, new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1820), "100 - 1000", 0, "AI Engineer", new Guid("1f62f10c-2653-488d-8d52-21b3a86d23fc") },
                    { new Guid("d2462388-f4cc-40c6-8bf1-d68f5a85a01b"), new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1823), new DateTime(2024, 11, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1824), 3, "We are looking for a nurse to join our team. Must have a nursing degree and at least 2 years of experience.", "Số 1, Đại Cồ Việt, Hai Bà Trưng, Hà Nội", 1, new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1823), "100 - 500", 0, "Nurse", new Guid("1f62f10c-2653-488d-8d52-21b3a86d23fc") }
>>>>>>>> 252893c40bb6d32524e3c84cb2d97364e003deb9:WorkFlex.Infrastructure/Migrations/20241011030449_Initial.cs
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241012104544_Initial.cs
                    { new Guid("03af2bff-10ca-43a0-b3fa-bf652cb263c8"), new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2184), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("cd995775-997e-4077-b980-076556d81a6b") },
                    { new Guid("bd754ed0-4304-40f2-95a7-a2fbf7b961cd"), new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2188), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("fcfb701b-ba0d-41e6-943d-126aea87ba4b") },
                    { new Guid("d47eced3-02df-490e-9a1b-10d61e2f7af8"), new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2189), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("cc04dca7-51c8-4ad7-92f5-fe34d16bcd30") }
========
                    { new Guid("0c921627-f798-4e73-aa23-3cf4b682f581"), new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1734), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("982ef243-9fcf-4da4-8139-cfc54d16527c") },
                    { new Guid("16bccc30-2fcb-4fff-84ff-cd280c08a3ca"), new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1733), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("1f62f10c-2653-488d-8d52-21b3a86d23fc") },
                    { new Guid("ca550dc7-3cc2-42c8-9da5-0c9711dc34f3"), new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1727), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("3cbc5bb3-6339-4caa-9289-627dd9e6dd15") }
>>>>>>>> 252893c40bb6d32524e3c84cb2d97364e003deb9:WorkFlex.Infrastructure/Migrations/20241011030449_Initial.cs
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241012104544_Initial.cs
                columns: new[] { "Id", "ApplicationDate", "CvFile", "JobPostId", "Status", "UserId" },
                values: new object[] { new Guid("cdf9b195-8de0-4346-8cd1-aca52036c508"), new DateTime(2024, 10, 12, 10, 45, 43, 620, DateTimeKind.Utc).AddTicks(2299), "path/to/cv.pdf", new Guid("74de2430-18d0-4abc-85ca-89ba8900861d"), 2, new Guid("cc04dca7-51c8-4ad7-92f5-fe34d16bcd30") });
========
                columns: new[] { "Id", "ApplicationDate", "CvFile", "Description", "JobPostId", "Status", "UserId" },
                values: new object[] { new Guid("6ec2aa71-a419-4b94-acb7-c8bf30f566c8"), new DateTime(2024, 10, 11, 3, 4, 49, 98, DateTimeKind.Utc).AddTicks(1843), "path/to/cv.pdf", "", new Guid("2c6f50f0-ffe5-4e4c-b32b-02394029cad0"), 2, new Guid("982ef243-9fcf-4da4-8139-cfc54d16527c") });
>>>>>>>> 252893c40bb6d32524e3c84cb2d97364e003deb9:WorkFlex.Infrastructure/Migrations/20241011030449_Initial.cs

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
