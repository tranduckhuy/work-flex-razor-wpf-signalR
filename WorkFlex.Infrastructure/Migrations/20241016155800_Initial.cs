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
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241016155800_Initial.cs
                    { 1, new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4165), "Software Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4167), "Artificial Intelligence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4168), "Healthcare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4169), "Finance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4169), "Transportation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4170), "Agriculture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
========
                    { 1, new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7525), "Software Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7528), "Artificial Intelligence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7530), "Healthcare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7532), "Finance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7534), "Transportation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7535), "Agriculture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
>>>>>>>> d864071abc59997970d490fd7eaefcc1803ee823:WorkFlex.Infrastructure/Migrations/20241013134258_Initial.cs
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "TypeName" },
                values: new object[,]
                {
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241016155800_Initial.cs
                    { 1, new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4145), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Time" },
                    { 2, new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4147), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Part Time" },
                    { 3, new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4148), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internship" }
========
                    { 1, new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7485), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Time" },
                    { 2, new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7490), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Part Time" },
                    { 3, new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7491), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internship" }
>>>>>>>> d864071abc59997970d490fd7eaefcc1803ee823:WorkFlex.Infrastructure/Migrations/20241013134258_Initial.cs
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
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241016155800_Initial.cs
                    { new Guid("82389d3a-4bed-424f-8bbc-b0bcaaf0a857"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4092), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("8f03f01e-9204-43a0-8585-e5ec473fbace"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4099), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" },
                    { new Guid("f2e1a566-3fcf-4332-832d-53101049aeea"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4096), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" }
========
                    { new Guid("0c67acbb-5233-4080-b97f-e283063facec"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7379), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("5dd615db-40c3-458f-abb5-6ee59ca4b747"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7387), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" },
                    { new Guid("94a2641c-b813-48b7-8541-0b8d416ddc7c"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7392), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" }
>>>>>>>> d864071abc59997970d490fd7eaefcc1803ee823:WorkFlex.Infrastructure/Migrations/20241013134258_Initial.cs
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241016155800_Initial.cs
                    { new Guid("9ebc919d-54ed-4cf2-92e0-ff8e5b5c0600"), new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4212), new DateTime(2024, 11, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4213), 3, "We are looking for a nurse to join our team. Must have a nursing degree and at least 2 years of experience.", "Số 1, Đại Cồ Việt, Hai Bà Trưng, Hà Nội", 1, new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4212), "100 - 500", 0, "Nurse", new Guid("f2e1a566-3fcf-4332-832d-53101049aeea") },
                    { new Guid("d0389ba0-d71f-4fe1-84dc-32c885b7e57d"), new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4209), new DateTime(2024, 11, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4209), 2, "Looking for a data scientist to join our AI team. Must have experience with Python, TensorFlow, and Keras.", " 239 Đ. Xuân Thủy, Dịch Vọng Hậu, Cầu Giấy, Hà Nội", 1, new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4209), "100 - 1000", 0, "AI Engineer", new Guid("f2e1a566-3fcf-4332-832d-53101049aeea") },
                    { new Guid("e39516f1-2811-4af4-90f0-99badf104cdd"), new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4196), new DateTime(2024, 11, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4197), 1, "Looking for a skilled software engineer. Must have experience with C# and .NET Core. Angular experience is a plus.", "Số 13, Tân Thuận Đông, Quận 7, Hồ Chí Minh", 1, new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4197), "1000 - 6000", 0, "Software Engineer", new Guid("f2e1a566-3fcf-4332-832d-53101049aeea") }
========
                    { new Guid("853bd750-071d-487c-ae52-6bc6f81640d9"), new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7581), new DateTime(2024, 11, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7584), 1, "Looking for a skilled software engineer. Must have experience with C# and .NET Core. Angular experience is a plus.", "Số 13, Tân Thuận Đông, Quận 7, Hồ Chí Minh", 1, new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7583), "1000 - 6000", 0, "Software Engineer", new Guid("5dd615db-40c3-458f-abb5-6ee59ca4b747") },
                    { new Guid("8a719506-1e41-43b1-9e4c-07775de6ce56"), new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7597), new DateTime(2024, 11, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7599), 2, "Looking for a data scientist to join our AI team. Must have experience with Python, TensorFlow, and Keras.", " 239 Đ. Xuân Thủy, Dịch Vọng Hậu, Cầu Giấy, Hà Nội", 1, new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7598), "100 - 1000", 0, "AI Engineer", new Guid("5dd615db-40c3-458f-abb5-6ee59ca4b747") },
                    { new Guid("d0a96728-5ab4-4e84-b282-27c0e3819957"), new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7609), new DateTime(2024, 11, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7610), 3, "We are looking for a nurse to join our team. Must have a nursing degree and at least 2 years of experience.", "Số 1, Đại Cồ Việt, Hai Bà Trưng, Hà Nội", 1, new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7610), "100 - 500", 0, "Nurse", new Guid("5dd615db-40c3-458f-abb5-6ee59ca4b747") }
>>>>>>>> d864071abc59997970d490fd7eaefcc1803ee823:WorkFlex.Infrastructure/Migrations/20241013134258_Initial.cs
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241016155800_Initial.cs
                    { new Guid("4c6e08c4-ce9f-420e-bafc-ba5efe229a05"), new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4121), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("82389d3a-4bed-424f-8bbc-b0bcaaf0a857") },
                    { new Guid("c89a945f-8e25-402d-a9cb-e08e646cda47"), new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4125), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("f2e1a566-3fcf-4332-832d-53101049aeea") },
                    { new Guid("ef2aa372-18d1-4bea-a2c9-01dd6f3284d6"), new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4126), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("8f03f01e-9204-43a0-8585-e5ec473fbace") }
========
                    { new Guid("138a841c-13ac-4781-ac95-83034a233c1a"), new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7452), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("94a2641c-b813-48b7-8541-0b8d416ddc7c") },
                    { new Guid("55fb6a4e-00b4-48b1-8c70-bd074c904e2e"), new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7443), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("0c67acbb-5233-4080-b97f-e283063facec") },
                    { new Guid("ba2f030b-ab07-4ba1-b336-8f23aae8f2cb"), new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7449), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("5dd615db-40c3-458f-abb5-6ee59ca4b747") }
>>>>>>>> d864071abc59997970d490fd7eaefcc1803ee823:WorkFlex.Infrastructure/Migrations/20241013134258_Initial.cs
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ApplicationDate", "CvFile", "Description", "JobPostId", "Status", "UserId" },
<<<<<<<< HEAD:WorkFlex.Infrastructure/Migrations/20241016155800_Initial.cs
                values: new object[] { new Guid("b5c03dc3-8266-4e21-9bd5-f2335d5c7154"), new DateTime(2024, 10, 16, 15, 58, 0, 351, DateTimeKind.Utc).AddTicks(4230), "path/to/cv.pdf", "", new Guid("e39516f1-2811-4af4-90f0-99badf104cdd"), 2, new Guid("8f03f01e-9204-43a0-8585-e5ec473fbace") });
========
                values: new object[] { new Guid("a8ae3213-3cad-4258-ac6c-a8920c4ffd01"), new DateTime(2024, 10, 13, 13, 42, 58, 190, DateTimeKind.Utc).AddTicks(7648), "path/to/cv.pdf", "", new Guid("853bd750-071d-487c-ae52-6bc6f81640d9"), 2, new Guid("94a2641c-b813-48b7-8541-0b8d416ddc7c") });
>>>>>>>> d864071abc59997970d490fd7eaefcc1803ee823:WorkFlex.Infrastructure/Migrations/20241013134258_Initial.cs

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
