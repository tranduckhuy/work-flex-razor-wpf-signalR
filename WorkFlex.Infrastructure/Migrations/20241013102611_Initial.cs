using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkFlex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241013102611_Initial.cs
                    { 1, new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8111), "Software Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8116), "Artificial Intelligence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8117), "Healthcare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8118), "Finance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8119), "Transportation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8120), "Agriculture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
========
                    { 1, new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4628), "Software Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4630), "Artificial Intelligence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4631), "Healthcare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4631), "Finance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4632), "Transportation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4633), "Agriculture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
>>>>>>>> a7b269824fa63938eb5072a494da73abdd41967c:WorkFlex.Infrastructure/Migrations/20241013023322_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "TypeName" },
                values: new object[,]
                {
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241013102611_Initial.cs
                    { 1, new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8073), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Time" },
                    { 2, new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8079), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Part Time" },
                    { 3, new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8080), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internship" }
========
                    { 1, new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4610), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Time" },
                    { 2, new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4612), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Part Time" },
                    { 3, new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4613), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internship" }
>>>>>>>> a7b269824fa63938eb5072a494da73abdd41967c:WorkFlex.Infrastructure/Migrations/20241013023322_InitialCreate.cs
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
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241013102611_Initial.cs
                    { new Guid("4a2dc61d-0120-4e2c-a576-21fc57e26a13"), "", new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(7970), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" },
                    { new Guid("ac89369d-b1f6-4ebe-95b3-f5b142f8bcc3"), "", new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(7962), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("ea21eb85-e266-4669-aabb-fa1f3f817d4c"), "", new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(7988), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" }
========
                    { new Guid("0f4fb564-7ff8-4f69-8128-886d3a7aebbf"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4552), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("1e8ef2ba-9856-40d4-a092-c4d7feacc586"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4564), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" },
                    { new Guid("abdb4042-efbf-46a8-b997-aada6afd412b"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4567), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" }
>>>>>>>> a7b269824fa63938eb5072a494da73abdd41967c:WorkFlex.Infrastructure/Migrations/20241013023322_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241013102611_Initial.cs
                    { new Guid("1ded8a85-b424-4471-a60f-1352f27fdbe5"), new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8197), new DateTime(2024, 11, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8197), 3, "We are looking for a nurse to join our team. Must have a nursing degree and at least 2 years of experience.", "Số 1, Đại Cồ Việt, Hai Bà Trưng, Hà Nội", 1, new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8197), "100 - 500", 0, "Nurse", new Guid("4a2dc61d-0120-4e2c-a576-21fc57e26a13") },
                    { new Guid("bdef9b71-e9fc-4bb8-a0f6-5a4adef4fd6a"), new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8174), new DateTime(2024, 11, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8176), 1, "Looking for a skilled software engineer. Must have experience with C# and .NET Core. Angular experience is a plus.", "Số 13, Tân Thuận Đông, Quận 7, Hồ Chí Minh", 1, new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8175), "1000 - 6000", 0, "Software Engineer", new Guid("4a2dc61d-0120-4e2c-a576-21fc57e26a13") },
                    { new Guid("c2bc32cf-33f2-40af-85c7-cc4daa752bfe"), new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8193), new DateTime(2024, 11, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8194), 2, "Looking for a data scientist to join our AI team. Must have experience with Python, TensorFlow, and Keras.", " 239 Đ. Xuân Thủy, Dịch Vọng Hậu, Cầu Giấy, Hà Nội", 1, new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8193), "100 - 1000", 0, "AI Engineer", new Guid("4a2dc61d-0120-4e2c-a576-21fc57e26a13") }
========
                    { new Guid("45985af4-f263-4b76-b65d-7bf22fc0ba80"), new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4672), new DateTime(2024, 11, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4673), 2, "Looking for a data scientist to join our AI team. Must have experience with Python, TensorFlow, and Keras.", " 239 Đ. Xuân Thủy, Dịch Vọng Hậu, Cầu Giấy, Hà Nội", 1, new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4672), "100 - 1000", 0, "AI Engineer", new Guid("1e8ef2ba-9856-40d4-a092-c4d7feacc586") },
                    { new Guid("8829a141-2924-4133-a6ea-ffc3ad2cc792"), new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4656), new DateTime(2024, 11, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4657), 1, "Looking for a skilled software engineer. Must have experience with C# and .NET Core. Angular experience is a plus.", "Số 13, Tân Thuận Đông, Quận 7, Hồ Chí Minh", 1, new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4656), "1000 - 6000", 0, "Software Engineer", new Guid("1e8ef2ba-9856-40d4-a092-c4d7feacc586") },
                    { new Guid("fdfa0abc-39ac-4532-b97b-d22006db0548"), new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4675), new DateTime(2024, 11, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4676), 3, "We are looking for a nurse to join our team. Must have a nursing degree and at least 2 years of experience.", "Số 1, Đại Cồ Việt, Hai Bà Trưng, Hà Nội", 1, new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4675), "100 - 500", 0, "Nurse", new Guid("1e8ef2ba-9856-40d4-a092-c4d7feacc586") }
>>>>>>>> a7b269824fa63938eb5072a494da73abdd41967c:WorkFlex.Infrastructure/Migrations/20241013023322_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241013102611_Initial.cs
                    { new Guid("34e9e145-685d-4a3b-b23d-bfb0b854d61f"), new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8040), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("ea21eb85-e266-4669-aabb-fa1f3f817d4c") },
                    { new Guid("6ffe69b3-ec74-4f09-8ed3-b399bad85ec7"), new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8038), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("4a2dc61d-0120-4e2c-a576-21fc57e26a13") },
                    { new Guid("92f2b98f-4155-4fc4-b3ae-265dae27caa1"), new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8031), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("ac89369d-b1f6-4ebe-95b3-f5b142f8bcc3") }
========
                    { new Guid("7101617a-7b65-45d3-9ee7-2390bbb1e030"), new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4595), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("abdb4042-efbf-46a8-b997-aada6afd412b") },
                    { new Guid("96d5c03c-e6cb-42fa-a814-0ba5196dd4a7"), new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4593), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("1e8ef2ba-9856-40d4-a092-c4d7feacc586") },
                    { new Guid("e6ef1c6b-9443-43cd-82b5-68c6200e43d5"), new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4589), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("0f4fb564-7ff8-4f69-8128-886d3a7aebbf") }
>>>>>>>> a7b269824fa63938eb5072a494da73abdd41967c:WorkFlex.Infrastructure/Migrations/20241013023322_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ApplicationDate", "CvFile", "Description", "JobPostId", "Status", "UserId" },
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241013102611_Initial.cs
                values: new object[] { new Guid("5d4e1934-e966-49d7-8a47-5f28d6f27cc6"), new DateTime(2024, 10, 13, 10, 26, 11, 490, DateTimeKind.Utc).AddTicks(8224), "path/to/cv.pdf", "", new Guid("bdef9b71-e9fc-4bb8-a0f6-5a4adef4fd6a"), 2, new Guid("ea21eb85-e266-4669-aabb-fa1f3f817d4c") });
========
                values: new object[] { new Guid("cc6ca253-d462-4cfe-bb09-91d7a68ca8a7"), new DateTime(2024, 10, 13, 2, 33, 21, 792, DateTimeKind.Utc).AddTicks(4694), "path/to/cv.pdf", "", new Guid("8829a141-2924-4133-a6ea-ffc3ad2cc792"), 2, new Guid("abdb4042-efbf-46a8-b997-aada6afd412b") });
>>>>>>>> a7b269824fa63938eb5072a494da73abdd41967c:WorkFlex.Infrastructure/Migrations/20241013023322_InitialCreate.cs

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
