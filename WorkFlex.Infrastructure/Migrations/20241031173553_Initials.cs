using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkFlex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initials : Migration
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
                    { 1, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4085), "Software Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4087), "Artificial Intelligence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4088), "Healthcare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4088), "Finance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4089), "Transportation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4090), "Agriculture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4090), "Customer Service", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4091), "Marketing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4091), "Education", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4092), "Logistics", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "TypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4060), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Time" },
                    { 2, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4062), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Part Time" },
                    { 3, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4063), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internship" }
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
                    { new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" },
                    { new Guid("19f91f0f-0ab6-47a1-86ad-77e56764d263"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(3923), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("3e3c92cd-78ca-42ec-ad99-4a2563c9fde8"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnweek@example.com", "John", true, false, false, "Week", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$zWTkYvKaD2nrl/FIEzZvAus4fK1zT5kIk9U.IrzNxHZOzLxYzIYNe", "", 3, "johnweek" },
                    { new Guid("4cd08585-3193-4319-bb0e-72996bd621a7"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sang@example.com", "Tran Ngoc", true, false, false, "Sang", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$CwxlScy8xNpcrGL/2sg7V.vDUC1zh.QOjZD1qefQgxmq3vn0Q7R9.", "", 3, "sang" },
                    { new Guid("58de2045-3d9c-4dc1-8838-ee4300521263"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "thuan@example.com", "Nguyen Dao", true, false, false, "Minh Thuan", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$3hGHatEPOSTNLlvBEUMw.uxZMLNxLz74/Ls47cvbccwwlJlhFELqS", "", 3, "thuan" },
                    { new Guid("5d9281b1-caf0-4b1b-8817-80be49486873"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" },
                    { new Guid("b0d831d8-339c-46ba-95a5-4887d96c4b35"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "quy@example.com", "Nguyen Xuan", true, false, false, "Quy", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$O/urkLFsFi/GN9s0asTeZ.3YnvDozIBPXS5vpDbl6Kvz4RsxZYRIS", "", 3, "quy" },
                    { new Guid("cf545087-0166-4cc3-bf36-aefaf1e97f15"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoang@example.com", "Ngo Gia", true, false, false, "Hoang", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$aYH6ji8QMczfCJxRGoBUqeTA7Ttk1JnanbTXBiafDDrrOQcy6hK7O", "", 3, "hoang" },
                    { new Guid("f1c6d632-2a2f-470a-85f3-1f45e2647b65"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "thinh@example.com", "Gia", true, false, false, "Thinh", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$kzs6W6lPdNmhq9mAxWfov.FJAHD2YDQJgQ/oiDeeMo78LKzDExz2O", "", 3, "thinh" },
                    { new Guid("f62f3551-0d44-452c-a8ea-ad886619a43f"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nghia@example.com", "Trong", true, false, false, "Nghia", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$zD2J2lknJ27rADmUbwJM9eSS0sX16W/FUw/xVx7XauSjOuxauzeZa", "", 3, "nghia" },
                    { new Guid("f6989945-9df8-4796-b23a-b64ea9f2a0f7"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hao@example.com", "Nguyen Nhat", true, false, false, "Hao", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$KcwDWaYdePFeLgKTwoJd7OQl6YCi9ZvCzdPDdt7lROYp2paxwpyGC", "", 3, "hao" },
                    { new Guid("fbf649f9-cc95-4ef8-8841-38302fa40f02"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "huy@example.com", "Tran Duck", true, false, false, "Huy", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$MNV7kUVAks5PkB4cMD8cNuLvONZlKt/ej7.hCdRTGyj4F/csD8oKK", "", 3, "tranduckhuy" }
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("010b6b2b-3a39-43f1-b9c0-edf8e670b08a"), new DateTime(2024, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4157), 3, "Position Overview:\n- Responsible for product development and management.\n- Coordinate with departments to ensure product timelines.\n- Research market trends and analyze customer needs.\n\nCandidate Requirements:\n- At least 3 years of experience in product management.\n- Strong leadership and communication skills.\n- Graduate in business or marketing.", "Tòa nhà D, Số 80, Phố Trần Phú, Quận Hà Đông, Hải Phòng", 1, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4157), "3000 - 3500", 0, "Product Manager", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("02b7b11b-174b-402e-b0ec-124fd0c02ef6"), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4139), 1, "Position Overview:\n- Design user interfaces for applications and websites.\n- Research and analyze user needs to improve experiences.\n- Create design prototypes and collaborate with development teams.\n\nCandidate Requirements:\n- Experience with Figma, Sketch, or Adobe XD.\n- Good communication and teamwork skills.\n- Graduate in design or equivalent.", "Tầng 2, Số 45, Phố Lê Lai, Quận 1, Hồ Chí Minh", 2, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4139), "1800 - 2200", 0, "UX/UI Designer", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("0543eb22-957b-47f5-966d-274a13761cd2"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4178), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4178), 1, "Position Overview:\n- Design and implement cloud computing solutions.\n- Manage infrastructure and data security in the cloud.\n- Optimize costs and system performance.\n\nCandidate Requirements:\n- Experience with AWS, Azure, or Google Cloud.\n- Programming skills and understanding of computer networks.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Đà Nẵng", 2, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4178), "2500 - 3000", 0, "Cloud Engineer", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("060b4b64-28b2-4327-a843-f75410db6bee"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4125), 1, "Position Overview:\n- Develop and maintain web applications.\n- Participate in the design and product development process.\n- Optimize performance and security of web applications.\n\nCandidate Requirements:\n- Experience with HTML, CSS, JavaScript, and PHP.\n- Problem-solving skills and logical thinking.\n- Graduate in IT or equivalent.", "Tòa nhà A, Số 12, Phố Nguyễn Trãi, Quận Thanh Xuân, Hải Phòng", 2, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4124), "1500 - 2000", 0, "Web Developer", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("14425695-aaf0-479f-b554-b69f8fb5a1b8"), new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4160), 1, "Position Overview:\n- Develop both frontend and backend web applications.\n- Collaborate with design and product teams.\n- Optimize code and application performance.\n\nCandidate Requirements:\n- Experience with React, Node.js, and databases.\n- Ability to manage both frontend and backend tasks.\n- Graduate in IT or equivalent.", "Tòa nhà C, Số 65, Phố Trần Duy Hưng, Quận Cầu Giấy, Hà Nội", 1, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4159), "3000 - 5000", 0, "Full-stack Developer", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("26da9acc-6f4d-4d08-9ee5-f36cca08b9d3"), new DateTime(2024, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4154), 1, "Position Overview:\n- Design and implement computer networks.\n- Monitor and maintain network systems.\n- Troubleshoot network-related issues.\n\nCandidate Requirements:\n- Experience with networking equipment.\n- CCNA certification is a plus.\n- Graduate in IT or equivalent.", "Tòa nhà B, Số 34, Phố Lê Văn Sỹ, Quận 3, Hà Nội", 1, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4154), "2500 - 3000", 0, "Network Engineer", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("39b35fc4-5615-407a-bbc5-6078728c992c"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4166), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4167), 8, "Position Overview:\n- Build and implement digital marketing campaigns.\n- Manage social media channels and optimize advertisements.\n- Analyze campaign effectiveness and report results.\n\nCandidate Requirements:\n- Experience in digital marketing.\n- Analytical skills and proficiency in online marketing tools.\n- Graduate in marketing or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 2, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4166), "1500 - 2000", 0, "Digital Marketing Specialist", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("45f18753-237d-4881-a106-638e921ac18a"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4163), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4164), 4, "Position Overview:\n- Analyze financial situations and prepare financial reports.\n- Provide investment and risk management recommendations.\n- Monitor and analyze market trends.\n\nCandidate Requirements:\n- Experience in financial analysis.\n- Strong analytical and reporting skills.\n- Graduate in finance or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 2, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4163), "2500 - 3000", 0, "Financial Analyst", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("4907c747-a0dc-43a8-994b-cfe5589e97f2"), new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4135), 2, "Position Overview:\n- Analyze data and create reports for management.\n- Use analytical tools to detect data trends.\n- Collaborate with other departments to improve processes based on data.\n\nCandidate Requirements:\n- Experience with Excel, SQL, and data analysis tools.\n- Communication and data presentation skills.\n- Graduate in statistics, mathematics, or equivalent.", "Văn phòng 5, Số 23, Phố Lê Duẩn, Quận Hải Châu, Đà Nẵng", 2, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4134), "2000 - 2500", 0, "Data Analyst", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("56856547-45b0-4536-a5e0-d2870fb885ac"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4175), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4175), 1, "Position Overview:\n- Develop and maintain mobile applications on iOS and Android.\n- Participate in product design and development processes.\n- Optimize application performance.\n\nCandidate Requirements:\n- Experience with Swift, Kotlin, or React Native.\n- Creative problem-solving skills.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội", 1, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4175), "2000 - 2500", 0, "Mobile App Developer", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("601918e9-414f-489c-ac31-654ed6175be7"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4180), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4181), 1, "Position Overview:\n- Analyze and assess security risks.\n- Implement measures to protect information systems.\n- Monitor and respond to security incidents.\n\nCandidate Requirements:\n- Experience in cybersecurity.\n- Certifications such as CISSP or CEH are a plus.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 1, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4181), "3000 - 3500", 0, "Cybersecurity Analyst", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("6c18b2e3-4c34-434e-8f75-585e990c6031"), new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4191), 8, "Position Overview:\n- Plan and oversee content strategies for branding.\n- Coordinate with writers and designers for content creation.\n- Analyze audience insights to improve content.\n\nCandidate Requirements:\n- Strong writing and editorial skills.\n- Experience in content strategy or journalism.\n- Graduate in communication or marketing.", "Văn phòng 7, Số 11, Phố Lê Lợi, Quận 1, Đà Nẵng", 3, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4191), "1500 - 2200", 0, "Content Strategist", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("9c1140f0-2d9f-456d-8615-4816f4ad3fda"), new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4145), 8, "Position Overview:\n- Design graphic products for marketing campaigns.\n- Collaborate with other departments to create creative content.\n- Maintain the company’s brand and design style.\n\nCandidate Requirements:\n- Experience with Adobe Illustrator, Photoshop.\n- Creative thinking and ability to work under pressure.\n- Graduate in graphic design or equivalent.", "Tầng trệt, Số 92, Phố Võ Văn Kiệt, Quận 1, Hồ Chí Minh", 2, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4145), "1200 - 1500", 0, "Graphic Designer", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("c4352352-54f6-4287-a1d2-c4e5c976011a"), new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4151), 4, "Position Overview:\n- Seek and develop new customers.\n- Conduct calls and meet clients to introduce products.\n- Achieve monthly sales targets.\n\nCandidate Requirements:\n- Experience in sales.\n- Good communication and persuasion skills.\n- University graduate in business or equivalent.", "Văn phòng 4, Số 150, Phố Trần Hưng Đạo, Quận 5, Hồ Chí Minh", 2, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4151), "2000 - 2500", 0, "Sales Executive", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("cba45913-709e-452a-a91b-98842dc7240e"), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4148), 8, "Position Overview:\n- Write content for blogs, websites, and social media.\n- Research and develop new content topics.\n- Optimize content for SEO.\n\nCandidate Requirements:\n- Good writing and editing skills.\n- Experience in content writing is a plus.\n- Graduate in journalism, communication, or equivalent.", "Văn phòng 10, Số 56, Phố Nguyễn Thị Minh Khai, Quận Hải Châu, Đà Nẵng", 2, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4147), "1000 - 1500", 0, "Content Writer", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("cd8857df-f2f6-480d-a7ae-c012b79162bd"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4183), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4184), 1, "Position Overview:\n- Manage and maintain the company's databases.\n- Optimize query performance and data security.\n- Support users in accessing and using databases.\n\nCandidate Requirements:\n- Experience with SQL Server, MySQL, or Oracle.\n- Strong analytical and problem-solving skills.\n- Graduate in IT or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội", 3, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4183), "2000 - 2500", 0, "Database Administrator", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("d8b10a03-4f43-4b48-9eca-182ed9a9ea33"), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4142), 2, "Position Overview:\n- Manage the recruitment and training processes for new employees.\n- Develop HR policies and manage performance.\n- Advise management on HR-related issues.\n\nCandidate Requirements:\n- At least 3 years of experience in a similar position.\n- Strong communication and leadership skills.\n- Graduate in human resource management or equivalent.", "Văn phòng 3, Số 78, Phố Nguyễn Trãi, Quận Thanh Xuân, Hà Nội", 1, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4142), "2500 - 3000", 0, "HR Manager", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("db1fc396-6a06-4bce-9537-6239c8778452"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4172), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4172), 7, "Position Overview:\n- Provide customer support via phone, email, and chat.\n- Resolve customer issues quickly and effectively.\n- Collect customer feedback to improve services.\n\nCandidate Requirements:\n- Good communication and listening skills.\n- Experience in customer service is an advantage.\n- Graduate from vocational school or higher.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hà Nội", 2, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4172), "1000 - 1500", 0, "Customer Support Specialist", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("ebe71d9f-1bf7-41e2-bd71-9040572350a5"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4169), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4170), 4, "Position Overview:\n- Analyze business requirements and processes.\n- Collaborate with departments to improve operational efficiency.\n- Prepare analytical documents and reports for management.\n\nCandidate Requirements:\n- Experience in business analysis.\n- Good communication and teamwork skills.\n- Graduate in business administration or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Đà Nẵng", 1, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4169), "2000 - 2500", 0, "Business Analyst", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") },
                    { new Guid("ece8b096-4b1a-4aca-8cf6-ae1f50868af5"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4188), new DateTime(2024, 11, 30, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4188), 2, "Position Overview:\n- Plan and implement marketing campaigns.\n- Manage marketing budgets and report results.\n- Analyze market trends and customer needs.\n\nCandidate Requirements:\n- At least 3 years of experience in marketing.\n- Strong leadership and communication skills.\n- Graduate in marketing or equivalent.", "Văn phòng 2, Số 100, Phố Trần Nhân Tông, Quận 3, Hồ Chí Minh", 3, new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4188), "2500 - 3000", 0, "Marketing Manager", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId", "Website" },
                values: new object[,]
                {
                    { new Guid("4b078570-0d83-45af-adef-b2b941a5ec56"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4022), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("5d9281b1-caf0-4b1b-8817-80be49486873"), null },
                    { new Guid("4f5cb15c-726d-4623-98b2-e1fa7f732b02"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4032), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("cf545087-0166-4cc3-bf36-aefaf1e97f15"), null },
                    { new Guid("899e6727-42ae-4d5f-a445-18dabd5a05cb"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4021), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("10331126-4b2c-4a4e-98cb-c851253a0e16"), null },
                    { new Guid("8c96393f-39df-4933-bc91-b8d6189b03bf"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4029), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("f6989945-9df8-4796-b23a-b64ea9f2a0f7"), null },
                    { new Guid("926d59d1-0274-4a9c-9472-a95c556d83ea"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4015), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("19f91f0f-0ab6-47a1-86ad-77e56764d263"), null },
                    { new Guid("93fd53a3-6758-4f58-9058-7743305320d4"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4031), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("58de2045-3d9c-4dc1-8838-ee4300521263"), null },
                    { new Guid("9eb68633-56a1-4b4d-915a-351b29a2e6b3"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4034), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("f62f3551-0d44-452c-a8ea-ad886619a43f"), null },
                    { new Guid("a1052d11-de5e-4449-af36-8aebfb736058"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4027), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("b0d831d8-339c-46ba-95a5-4887d96c4b35"), null },
                    { new Guid("bd62dc43-976e-4e14-96c7-eb3d7da422bc"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4033), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("f1c6d632-2a2f-470a-85f3-1f45e2647b65"), null },
                    { new Guid("c5369fbd-a24a-41d1-bfee-827427fe63ab"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4024), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("fbf649f9-cc95-4ef8-8841-38302fa40f02"), null },
                    { new Guid("e700e819-a2ee-410f-ab99-956bfc23af1d"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4023), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("3e3c92cd-78ca-42ec-ad99-4a2563c9fde8"), null },
                    { new Guid("fad555cf-3522-418f-9fb0-7e2c40ecc083"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4025), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("4cd08585-3193-4319-bb0e-72996bd621a7"), null }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ApplicationDate", "CvFile", "Description", "JobPostId", "Status", "UserId" },
                values: new object[] { new Guid("07b6baa3-1e08-4ae4-9e49-4679ebcfe352"), new DateTime(2024, 10, 31, 17, 35, 53, 496, DateTimeKind.Utc).AddTicks(4227), "path/to/cv.pdf", "", new Guid("060b4b64-28b2-4327-a843-f75410db6bee"), 2, new Guid("5d9281b1-caf0-4b1b-8817-80be49486873") });

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
