﻿using System;
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
                name: "Industry",
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
                    table.PrimaryKey("PK_Industry", x => x.Id);
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
                        name: "FK_JobPosts_Industry_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industry",
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
                table: "Industry",
                columns: new[] { "Id", "CreatedAt", "IndustryName", "ModifiedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6807), "Software Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6809), "Artificial Intelligence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6810), "Healthcare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6810), "Finance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6811), "Transportation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6812), "Agriculture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "TypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6787), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Time" },
                    { 2, new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6790), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Part Time" },
                    { 3, new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6790), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internship" }
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
                    { new Guid("162cc3eb-c7a3-470f-8dfb-360dab3f11be"), "", new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6744), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@@", "", 3, "jobseeker" },
                    { new Guid("ea52e77f-37f4-4f73-8c31-6fac03651f5f"), "", new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6738), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@@", "", 1, "admin" },
                    { new Guid("f5b2aae7-ad76-48d7-8052-f32acc072417"), "", new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6742), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@", "", 2, "recruiter" }
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("3fde3bd2-39c3-489a-851c-84052be0ae4b"), new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6851), new DateTime(2024, 11, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6852), 3, "We are looking for a nurse to join our team. Must have a nursing degree and at least 2 years of experience.", "Số 1, Đại Cồ Việt, Hai Bà Trưng, Hà Nội", 1, new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6852), "", 0, "Nurse", new Guid("f5b2aae7-ad76-48d7-8052-f32acc072417") },
                    { new Guid("5ab0dc30-0e17-452c-afff-90a1ba4321d1"), new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6833), new DateTime(2024, 11, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6834), 1, "Looking for a skilled software engineer. Must have experience with C# and .NET Core. Angular experience is a plus.", "Số 13, Tân Thuận Đông, Quận 7, Hồ Chí Minh", 1, new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6833), "", 0, "Software Engineer", new Guid("f5b2aae7-ad76-48d7-8052-f32acc072417") },
                    { new Guid("d062cc86-0308-44ef-8c03-2d1e2c017845"), new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6848), new DateTime(2024, 11, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6849), 2, "Looking for a data scientist to join our AI team. Must have experience with Python, TensorFlow, and Keras.", " 239 Đ. Xuân Thủy, Dịch Vọng Hậu, Cầu Giấy, Hà Nội", 1, new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6849), "", 0, "AI Engineer", new Guid("f5b2aae7-ad76-48d7-8052-f32acc072417") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId" },
                values: new object[,]
                {
                    { new Guid("174a7bc2-26f5-44c2-9726-a6cf6de30852"), new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6767), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("f5b2aae7-ad76-48d7-8052-f32acc072417") },
                    { new Guid("e2b2227c-7812-4ea2-9be2-9af0ca494916"), new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6764), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("ea52e77f-37f4-4f73-8c31-6fac03651f5f") },
                    { new Guid("eb70f1ea-3e83-4a58-98b6-ca3ee030e9cc"), new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6768), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("162cc3eb-c7a3-470f-8dfb-360dab3f11be") }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ApplicationDate", "CvFile", "JobPostId", "Status", "UserId" },
                values: new object[] { new Guid("cf8ccb36-5fac-46fd-bd63-798d83da1929"), new DateTime(2024, 10, 8, 3, 21, 10, 913, DateTimeKind.Utc).AddTicks(6870), "path/to/cv.pdf", new Guid("5ab0dc30-0e17-452c-afff-90a1ba4321d1"), 2, new Guid("162cc3eb-c7a3-470f-8dfb-360dab3f11be") });

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
                name: "Industry");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}