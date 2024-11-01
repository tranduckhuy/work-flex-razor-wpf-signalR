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
                    { 1, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7106), "Software Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7108), "Artificial Intelligence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7109), "Healthcare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7109), "Finance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7110), "Transportation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7111), "Agriculture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7111), "Customer Service", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7112), "Marketing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7113), "Education", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7113), "Logistics", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "TypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7072), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Time" },
                    { 2, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7074), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Part Time" },
                    { 3, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7075), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internship" }
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
                    { new Guid("0ce3dbac-c471-4b84-9df7-688a0b133fad"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fvn1m3b_1730428306808_vendor-4.png?alt=media&token=f1e61339-1c7f-4065-acbf-d49a012dc604", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "quy@example.com", "Nguyen Xuan", true, false, false, "Quy", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$O/urkLFsFi/GN9s0asTeZ.3YnvDozIBPXS5vpDbl6Kvz4RsxZYRIS", "", 2, "quy" },
                    { new Guid("21729287-19ce-4e9c-93ec-ea6ffb3abd8d"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2F9xi15_1730428296376_vendor-2.png?alt=media&token=e850aa0f-9798-45da-851a-1b4a7bc6726d", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sang@example.com", "Tran Ngoc", true, false, false, "Sang", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$CwxlScy8xNpcrGL/2sg7V.vDUC1zh.QOjZD1qefQgxmq3vn0Q7R9.", "", 2, "sang" },
                    { new Guid("537b3391-99bb-4a12-99cd-7e0ccd73e75d"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fwobtrg_1730428336088_vendor-11.png?alt=media&token=306e81e3-dee1-4e09-bd09-0ea22d9bcd66", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnweek@example.com", "John", true, false, false, "Week", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$zWTkYvKaD2nrl/FIEzZvAus4fK1zT5kIk9U.IrzNxHZOzLxYzIYNe", "", 3, "johnweek" },
                    { new Guid("7b6fa5ab-4a91-4149-b533-3a1db30e802b"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Ffc2hi5_1730428324559_vendor-9.png?alt=media&token=fa4632f1-2584-4496-9927-d0a645413638", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "thinh@example.com", "Gia", true, false, false, "Thinh", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$kzs6W6lPdNmhq9mAxWfov.FJAHD2YDQJgQ/oiDeeMo78LKzDExz2O", "", 3, "thinh" },
                    { new Guid("81b8c843-361c-4be3-8a06-d4b561d9c21d"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Frijtlx_1730428289939_vendor-1.png?alt=media&token=529439ae-4bc1-4c9a-ad2a-6d97f0c5ae25", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fmau-cua-hang-tap-hoa-12-aeros.webp?alt=media&token=55cb771a-c564-4d29-b0fa-f6cccea186e2", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "huy@example.com", "Tran Duck", true, false, false, "Huy", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$MNV7kUVAks5PkB4cMD8cNuLvONZlKt/ej7.hCdRTGyj4F/csD8oKK", "", 2, "tranduckhuy" },
                    { new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2F2q2joa_1730428345764_vendor-14.png?alt=media&token=75952a9b-a099-4ec3-acc5-3240f0839dd2", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" },
                    { new Guid("9b200022-54df-47f5-9da8-8cab3e4bf399"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fkxakd5_1730428320184_vendor-7.png?alt=media&token=9a4cabc8-8372-45d8-9d3e-364766154550", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoang@example.com", "Ngo Gia", true, false, false, "Hoang", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$aYH6ji8QMczfCJxRGoBUqeTA7Ttk1JnanbTXBiafDDrrOQcy6hK7O", "", 3, "hoang" },
                    { new Guid("9c7a4b40-df0d-483e-b860-2168153c6abd"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fmrcf7_1730428331026_vendor-10.png?alt=media&token=9e787b31-eea6-4f38-a2c2-fa3c8a2140e1", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nghia@example.com", "Trong", true, false, false, "Nghia", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$zD2J2lknJ27rADmUbwJM9eSS0sX16W/FUw/xVx7XauSjOuxauzeZa", "", 3, "nghia" },
                    { new Guid("9d3dc5ad-c601-4624-9582-8c2058565730"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Ftjw6hg_1730428353803_table-img1.png?alt=media&token=fa6ddab5-418a-4cfb-ab75-2aa0d578c164", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(6956), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("c5b3686c-b4fc-4d03-bbb9-9506546fb05e"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2F17mshd_1730428341488_vendor-13.png?alt=media&token=33092b37-f077-4863-9329-63fa6e5964f7", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" },
                    { new Guid("f01a631e-156c-449e-8588-062199cbe42e"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Ftvujfq_1730428311602_vendor-5.png?alt=media&token=65db1056-55f6-4620-990b-c3641807507f", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "thuan@example.com", "Nguyen Dao", true, false, false, "Minh Thuan", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$3hGHatEPOSTNLlvBEUMw.uxZMLNxLz74/Ls47cvbccwwlJlhFELqS", "", 3, "thuan" },
                    { new Guid("f4a16290-9899-4bef-869f-1b84c1ccdacb"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Faq8ir_1730428301407_vendor-3.png?alt=media&token=295216c1-4ea0-4a0c-8a61-3c66200f41bb", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hao@example.com", "Nguyen Nhat", true, false, false, "Hao", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$KcwDWaYdePFeLgKTwoJd7OQl6YCi9ZvCzdPDdt7lROYp2paxwpyGC", "", 3, "hao" }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ApplicationDate", "CvFile", "Description", "JobPostId", "Status", "UserId" },
                values: new object[] { new Guid("612e143c-1a95-47fb-af97-a69a2623802b"), new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7245), "path/to/cv.pdf", "", new Guid("00c62130-f022-4b1e-a39b-8d9dccf5849b"), 2, new Guid("c5b3686c-b4fc-4d03-bbb9-9506546fb05e") });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("00f68e78-29a2-461d-903c-b8846724fc96"), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7211), 2, "Tổng quan vị trí:\n- Hỗ trợ tổ chức và quản lý các sự kiện.\n- Liên lạc với các nhà cung cấp và khách hàng.\n- Đảm bảo mọi thứ diễn ra suôn sẻ trong sự kiện.\n\nYêu cầu ứng viên:\n- Kỹ năng tổ chức và giao tiếp tốt.\n- Có khả năng làm việc dưới áp lực cao.\n- Nhiệt tình và sáng tạo.", "Tòa nhà S, Đường Nguyễn Thái Học, Phường Lê Lợi, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7210), "500 - 800", 0, "Nhân Viên Tổ Chức Sự Kiện Part-time", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("0675be32-2b2b-4825-83aa-db9bbb92ba41"), new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7189), 1, "Tổng quan vị trí:\n- Hỗ trợ kỹ thuật trong các dự án IT.\n- Học hỏi và phát triển kỹ năng chuyên môn.\n- Tham gia vào các công việc hàng ngày của nhóm kỹ thuật.\n\nYêu cầu ứng viên:\n- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành IT.\n- Có kiến thức cơ bản về lập trình.\n- Nhiệt tình và ham học hỏi.", "Tòa nhà L, Đường Lý Thường Kiệt, Phường Xuân Diệu, Quy Nhơn, Bình Định", 3, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7189), "400 - 600", 0, "Thực Tập Sinh Kỹ Thuật IT", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("07296988-143c-4f7b-ace5-858de51b4b56"), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7180), 2, "Tổng quan vị trí:\n- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing.\n- Phân tích và báo cáo kết quả chiến dịch.\n- Tham gia vào các hoạt động quảng bá sản phẩm.\n\nYêu cầu ứng viên:\n- Có kiến thức về marketing.\n- Kỹ năng phân tích và giao tiếp tốt.\n- Chịu khó và ham học hỏi.", "Tòa nhà I, Đường Nguyễn Thái Học, Phường Lê Lợi, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7180), "600 - 900", 0, "Nhân Viên Hỗ Trợ Marketing Part-time", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("0e6cbb04-eaf4-4591-9590-434050771225"), new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7214), 2, "Tổng quan vị trí:\n- Nghiên cứu và phân tích thị trường để phát triển chiến lược.\n- Phát triển mối quan hệ với khách hàng và đối tác.\n- Tạo báo cáo và đề xuất các giải pháp kinh doanh.\n\nYêu cầu ứng viên:\n- Tối thiểu 2 năm kinh nghiệm trong phát triển thị trường.\n- Kỹ năng phân tích và giao tiếp tốt.\n- Tốt nghiệp chuyên ngành kinh tế, marketing hoặc tương đương.", "Tòa nhà T, Đường Trần Hưng Đạo, Phường Hải Cảng, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7213), "3.000 - 7.000", 0, "Chuyên Viên Phát Triển Thị Trường", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("21f4b00a-dd45-448b-b6b6-256def944bec"), new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7200), 2, "Tổng quan vị trí:\n- Phát triển và duy trì mối quan hệ với khách hàng.\n- Đạt được mục tiêu doanh số hàng tháng.\n- Phân tích nhu cầu của khách hàng để đề xuất các giải pháp phù hợp.\n\nYêu cầu ứng viên:\n- Kinh nghiệm trong lĩnh vực kinh doanh.\n- Kỹ năng giao tiếp và thuyết phục tốt.\n- Tốt nghiệp chuyên ngành kinh tế hoặc tương đương.", "Tòa nhà O, Đường Đống Đa, Phường Bình Định, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7199), "2500 - 3500", 0, "Chuyên Viên Kinh Doanh", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("28ad300e-6f01-48b3-a61a-83b383160047"), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7160), 2, "Tổng quan vị trí:\n- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing.\n- Nghiên cứu thị trường và phân tích dữ liệu khách hàng.\n- Theo dõi và báo cáo kết quả chiến dịch.\n\nYêu cầu ứng viên:\n- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành marketing.\n- Kỹ năng giao tiếp tốt.\n- Có khả năng làm việc nhóm.", "Tòa nhà C, Đường Nguyễn Huệ, Phường Lê Lợi, Quy Nhơn, Bình Định", 3, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7160), "400 - 600", 0, "Thực Tập Sinh Marketing", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("2a1ce1b7-38fb-4ba4-b0e1-99627a20208c"), new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7183), 2, "Tổng quan vị trí:\n- Hỗ trợ thực hiện các kế hoạch kinh doanh.\n- Nghiên cứu thị trường và phân tích dữ liệu khách hàng.\n- Theo dõi và báo cáo kết quả.\n\nYêu cầu ứng viên:\n- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành kinh doanh.\n- Kỹ năng giao tiếp tốt.\n- Có khả năng làm việc nhóm.", "Tòa nhà J, Đường Nguyễn Công Trứ, Phường Lê Lợi, Quy Nhơn, Bình Định", 3, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7182), "400 - 600", 0, "Thực Tập Sinh Kinh Doanh", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("3efa7f8f-be06-4d75-85cd-ce2bed0ec302"), new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7205), 2, "Tổng quan vị trí:\n- Lập kế hoạch và giám sát tiến độ dự án.\n- Quản lý nguồn lực và ngân sách dự án.\n- Đảm bảo các mục tiêu dự án được thực hiện đúng hạn.\n\nYêu cầu ứng viên:\n- Tối thiểu 5 năm kinh nghiệm trong quản lý dự án.\n- Kỹ năng lãnh đạo và quản lý tốt.\n- Tốt nghiệp chuyên ngành quản trị kinh doanh hoặc tương đương.", "Tòa nhà Q, Đường Nguyễn Công Trứ, Phường Lê Lợi, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7205), "4000 - 5000", 0, "Giám Đốc Dự Án", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("63ac18f0-b475-4ec0-b2a2-48052f3693a0"), new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7186), 2, "Tổng quan vị trí:\n- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing số.\n- Theo dõi và phân tích dữ liệu trên các kênh truyền thông.\n- Cập nhật thông tin về sản phẩm và dịch vụ.\n\nYêu cầu ứng viên:\n- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành marketing.\n- Kỹ năng phân tích và giao tiếp tốt.\n- Chịu khó và nhiệt tình.", "Tòa nhà K, Đường Trần Phú, Phường Trần Phú, Quy Nhơn, Bình Định", 3, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7185), "400 - 600", 0, "Thực Tập Sinh Digital Marketing", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("6df0caf8-28f9-4966-bae9-86a882ceeb09"), new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7167), 2, "Tổng quan vị trí:\n- Tìm kiếm khách hàng và giới thiệu sản phẩm.\n- Đạt được chỉ tiêu doanh số tháng.\n- Duy trì mối quan hệ với khách hàng hiện tại.\n\nYêu cầu ứng viên:\n- Có kinh nghiệm trong lĩnh vực kinh doanh.\n- Kỹ năng giao tiếp tốt.\n- Có khả năng làm việc độc lập và theo nhóm.", "Tòa nhà E, Đường Nguyễn Công Trứ, Phường Lê Lợi, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7167), "600 - 900", 0, "Nhân Viên Kinh Doanh Part-time", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("77341460-3ff5-4e6f-a219-fb38a153b384"), new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7202), 1, "Tổng quan vị trí:\n- Phát triển và duy trì các ứng dụng phần mềm.\n- Làm việc với các nhóm để phát triển sản phẩm.\n- Thực hiện kiểm thử và sửa lỗi phần mềm.\n\nYêu cầu ứng viên:\n- Có ít nhất 2 năm kinh nghiệm lập trình.\n- Thành thạo một hoặc nhiều ngôn ngữ lập trình.\n- Kỹ năng làm việc nhóm và giải quyết vấn đề tốt.", "Tòa nhà P, Đường Nguyễn Thái Học, Phường Lê Lợi, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7202), "3000 - 4000", 0, "Kỹ Sư Phần Mềm", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("7b88f2fe-bb07-4a7f-bd31-9257037f15d4"), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7157), 1, "Tổng quan vị trí:\n- Hỗ trợ kỹ thuật cho các sản phẩm công nghệ.\n- Giải quyết các sự cố kỹ thuật của khách hàng.\n- Tham gia vào các dự án nhỏ theo yêu cầu.\n\nYêu cầu ứng viên:\n- Có kiến thức về công nghệ thông tin.\n- Kỹ năng giải quyết vấn đề tốt.\n- Có khả năng làm việc độc lập.", "Tòa nhà B, Đường Trần Hưng Đạo, Phường Hải Cảng, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7156), "700 - 1000", 0, "Nhân Viên Kỹ Thuật Part-time", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("962b8ca7-e945-4522-bce9-68ceed71e345"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7147), 4, "Tổng quan vị trí:\n- Tìm kiếm và phát triển khách hàng mới cho tạp hóa.\n- Đạt được mục tiêu doanh số hàng tháng của cửa hàng.\n- Hỗ trợ khách hàng trong quá trình mua sắm tại tạp hóa.\n\nYêu cầu ứng viên:\n- Có kinh nghiệm trong lĩnh vực bán hàng hoặc tạp hóa.\n- Kỹ năng giao tiếp tốt và thân thiện với khách hàng.\n- Có khả năng làm việc theo nhóm và độc lập.", "Tạp Hóa Anh Ba, Đường Lê Lợi, Phường Trần Phú, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7146), "100 - 150", 0, "Nhân Viên Bán Hàng Tạp Hóa Anh Ba", new Guid("81b8c843-361c-4be3-8a06-d4b561d9c21d") },
                    { new Guid("98c45392-a68a-4bd8-bee2-1cd23a861f34"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7171), 2, "Tổng quan vị trí:\n- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing.\n- Phân tích dữ liệu và báo cáo kết quả.\n- Tham gia các hoạt động quảng bá sản phẩm.\n\nYêu cầu ứng viên:\n- Có kiến thức về marketing.\n- Kỹ năng phân tích và giao tiếp tốt.\n- Chịu khó và ham học hỏi.", "Tòa nhà F, Đường Lý Thường Kiệt, Phường Xuân Diệu, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7171), "500 - 800", 0, "Nhân Viên Marketing Part-time", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("b7ef8af8-8633-4d05-9e0c-8fdaea537fb8"), new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7208), 2, "Tổng quan vị trí:\n- Tư vấn và quản lý các dịch vụ tài chính cho khách hàng.\n- Phân tích và đánh giá tình hình tài chính của khách hàng.\n- Xây dựng các kế hoạch tài chính phù hợp.\n\nYêu cầu ứng viên:\n- Kinh nghiệm trong lĩnh vực tài chính hoặc ngân hàng.\n- Kỹ năng giao tiếp và thuyết phục tốt.\n- Tốt nghiệp chuyên ngành tài chính hoặc tương đương.", "Tòa nhà R, Đường Trần Nhân Tông, Phường Trần Phú, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7208), "3500 - 4500", 0, "Chuyên Viên Tư Vấn Tài Chính", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("da513892-9883-4675-bdc0-bdbd0a025262"), new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7192), 2, "Tổng quan vị trí:\n- Lập kế hoạch và thực hiện các chiến dịch marketing.\n- Quản lý ngân sách marketing và báo cáo kết quả.\n- Phân tích xu hướng thị trường và nhu cầu khách hàng.\n\nYêu cầu ứng viên:\n- Tối thiểu 3 năm kinh nghiệm trong lĩnh vực marketing.\n- Kỹ năng lãnh đạo và giao tiếp tốt.\n- Tốt nghiệp chuyên ngành marketing hoặc tương đương.", "Tòa nhà M, Đường Phạm Ngũ Lão, Phường Trần Phú, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7192), "2500 - 3500", 0, "Quản Lý Marketing", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("dccd0b74-8e07-45c3-8b6d-0f841bbb283f"), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7177), 1, "Tổng quan vị trí:\n- Hỗ trợ kỹ thuật cho các sản phẩm công nghệ.\n- Giải quyết các sự cố kỹ thuật.\n- Tham gia vào các dự án nhỏ theo yêu cầu.\n\nYêu cầu ứng viên:\n- Có kiến thức về kỹ thuật.\n- Kỹ năng giải quyết vấn đề tốt.\n- Có khả năng làm việc độc lập.", "Tòa nhà H, Đường Phạm Văn Đồng, Phường Trần Phú, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7177), "700 - 1000", 0, "Nhân Viên Kỹ Thuật Part-time", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("dcf4f6e4-1083-44a7-a292-d4187b2c50f7"), new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7164), 2, "Tổng quan vị trí:\n- Hỗ trợ khách hàng qua điện thoại và email.\n- Giải quyết các vấn đề của khách hàng.\n- Cung cấp thông tin về sản phẩm và dịch vụ.\n\nYêu cầu ứng viên:\n- Kỹ năng giao tiếp và lắng nghe tốt.\n- Có khả năng làm việc dưới áp lực.\n- Chịu khó và cầu tiến.", "Tòa nhà D, Đường Phạm Ngũ Lão, Phường Trần Phú, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7164), "500 - 800", 0, "Nhân Viên Hỗ Trợ Khách Hàng Part-time", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("e25371cc-46b2-4d0b-9311-b1c515b88792"), new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7197), 1, "Tổng quan vị trí:\n- Phân tích dữ liệu để đưa ra quyết định chiến lược.\n- Tạo báo cáo và trình bày kết quả phân tích.\n- Hỗ trợ các bộ phận khác trong việc sử dụng dữ liệu.\n\nYêu cầu ứng viên:\n- Kinh nghiệm trong phân tích dữ liệu.\n- Kỹ năng sử dụng các công cụ phân tích và báo cáo.\n- Tốt nghiệp chuyên ngành thống kê, kinh tế hoặc tương đương.", "Tòa nhà N, Đường Trần Hưng Đạo, Phường Hải Cảng, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7196), "2000 - 3000", 0, "Chuyên Viên Phân Tích Dữ Liệu", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") },
                    { new Guid("e37691b6-152c-434e-a70e-bdd108a975be"), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7174), 2, "Tổng quan vị trí:\n- Tư vấn sản phẩm cho khách hàng.\n- Hỗ trợ giải quyết thắc mắc của khách hàng.\n- Cập nhật thông tin về sản phẩm mới.\n\nYêu cầu ứng viên:\n- Kỹ năng giao tiếp tốt.\n- Có khả năng làm việc nhóm.\n- Chịu khó và nhiệt tình.", "Tòa nhà G, Đường Đống Đa, Phường Bình Định, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7174), "600 - 900", 0, "Nhân Viên Tư Vấn Khách Hàng Part-time", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId", "Website" },
                values: new object[,]
                {
                    { new Guid("0c318820-66b2-4b9f-9eed-e17eb7244957"), new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7044), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("7b6fa5ab-4a91-4149-b533-3a1db30e802b"), null },
                    { new Guid("1dbcee83-84c2-4036-a740-d766b48a7519"), new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7043), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("9b200022-54df-47f5-9da8-8cab3e4bf399"), null },
                    { new Guid("37078825-d9e8-4930-b043-e36a3f5d90ce"), new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7036), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("537b3391-99bb-4a12-99cd-7e0ccd73e75d"), null },
                    { new Guid("40275dbf-e189-4aa2-b2a8-e9d2dfb41799"), new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7034), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("c5b3686c-b4fc-4d03-bbb9-9506546fb05e"), null },
                    { new Guid("5269dbb9-a6c8-4d5b-b36d-0c1dbb0c1a73"), new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7040), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("0ce3dbac-c471-4b84-9df7-688a0b133fad"), null },
                    { new Guid("5a2dc2e6-bacd-4fd5-8a1a-f0dfef630a73"), new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7038), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("81b8c843-361c-4be3-8a06-d4b561d9c21d"), null },
                    { new Guid("602c122c-d6b5-46aa-81b1-c52292ba3a10"), new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7032), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("9780b3c8-8bbe-4765-a52a-5f1c9b4277cb"), null },
                    { new Guid("89bdfffe-9a47-4ecf-93ec-5aa141633b90"), new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7039), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("21729287-19ce-4e9c-93ec-ea6ffb3abd8d"), null },
                    { new Guid("a8ec3fae-9d47-4deb-9f1a-abc222ba7183"), new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7041), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("f4a16290-9899-4bef-869f-1b84c1ccdacb"), null },
                    { new Guid("c1d0fee0-290d-451a-bbcb-f799500c6af4"), new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7028), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("9d3dc5ad-c601-4624-9582-8c2058565730"), null },
                    { new Guid("c1e08076-9021-4151-acb5-fdb3f861ee7d"), new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7042), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("f01a631e-156c-449e-8588-062199cbe42e"), null },
                    { new Guid("db045101-cd16-4032-8329-2485ae238903"), new DateTime(2024, 11, 1, 2, 45, 35, 638, DateTimeKind.Utc).AddTicks(7047), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("9c7a4b40-df0d-483e-b860-2168153c6abd"), null }
                });

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
