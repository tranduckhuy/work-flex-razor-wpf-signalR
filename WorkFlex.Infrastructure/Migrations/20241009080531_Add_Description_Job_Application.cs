using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkFlex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Description_Job_Application : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: new Guid("20097e66-9210-4b04-8365-3b1cb9006866"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("0412e9a9-06e5-408e-9813-e28578c64017"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("3ef7cabf-9d07-45c0-b094-3277308c44b9"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("09d7d5d9-135f-4f0b-b871-f935772e1dba"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("0cfaadcb-1eec-4284-a16d-c1a4dd40052e"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("946724f7-b12f-4391-ac2d-f9bcbfac8dc6"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("ea258eb5-e60a-4b85-ae2b-3d7824d9bcf2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e36ecb98-c8d0-43db-ba6d-71efed6a5de2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("eccac318-06b0-4bf2-b3a7-17d7b53e39b1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a09be84a-eca4-4f44-89f0-5e37677a2171"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1043));

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1044));

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1044));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1021));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1021));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsActive", "IsLock", "LastName", "Location", "ModifiedAt", "Password", "Phone", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("5b86f1ab-349a-4f85-9ca0-6e4a0d0a5321"), "", new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(902), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("5e00316f-34b1-422d-aced-7df47cd486c4"), "", new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(905), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" },
                    { new Guid("b9901f8d-a093-4668-9425-e678450ab197"), "", new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(908), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" }
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("517306b6-9100-4b6a-8d14-989929f2d3b7"), new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1141), new DateTime(2024, 11, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1142), 1, "Looking for a skilled software engineer. Must have experience with C# and .NET Core. Angular experience is a plus.", "Số 13, Tân Thuận Đông, Quận 7, Hồ Chí Minh", 1, new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1142), "", 0, "Software Engineer", new Guid("5e00316f-34b1-422d-aced-7df47cd486c4") },
                    { new Guid("90ab47e4-e674-4d75-8e09-dd668234ceb3"), new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1161), new DateTime(2024, 11, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1161), 3, "We are looking for a nurse to join our team. Must have a nursing degree and at least 2 years of experience.", "Số 1, Đại Cồ Việt, Hai Bà Trưng, Hà Nội", 1, new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1161), "", 0, "Nurse", new Guid("5e00316f-34b1-422d-aced-7df47cd486c4") },
                    { new Guid("ada5f8c2-65c2-4c18-b1c8-d3f3a0238607"), new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1157), new DateTime(2024, 11, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1158), 2, "Looking for a data scientist to join our AI team. Must have experience with Python, TensorFlow, and Keras.", " 239 Đ. Xuân Thủy, Dịch Vọng Hậu, Cầu Giấy, Hà Nội", 1, new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1158), "", 0, "AI Engineer", new Guid("5e00316f-34b1-422d-aced-7df47cd486c4") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId" },
                values: new object[,]
                {
                    { new Guid("bc12cdfb-a888-49e4-9771-c6cb934b4668"), new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(997), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("b9901f8d-a093-4668-9425-e678450ab197") },
                    { new Guid("c0bcc639-ff4d-4e1b-8f30-0a7c026e0247"), new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(995), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("5e00316f-34b1-422d-aced-7df47cd486c4") },
                    { new Guid("e62ef57d-51c2-45a2-a166-3e311f10f4dc"), new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(992), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("5b86f1ab-349a-4f85-9ca0-6e4a0d0a5321") }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ApplicationDate", "CvFile", "Description", "JobPostId", "Status", "UserId" },
                values: new object[] { new Guid("dc15e04c-f427-46dd-89d3-d7c9f2be3d14"), new DateTime(2024, 10, 9, 8, 5, 31, 443, DateTimeKind.Utc).AddTicks(1180), "path/to/cv.pdf", "", new Guid("517306b6-9100-4b6a-8d14-989929f2d3b7"), 2, new Guid("b9901f8d-a093-4668-9425-e678450ab197") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: new Guid("dc15e04c-f427-46dd-89d3-d7c9f2be3d14"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("90ab47e4-e674-4d75-8e09-dd668234ceb3"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("ada5f8c2-65c2-4c18-b1c8-d3f3a0238607"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("bc12cdfb-a888-49e4-9771-c6cb934b4668"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("c0bcc639-ff4d-4e1b-8f30-0a7c026e0247"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("e62ef57d-51c2-45a2-a166-3e311f10f4dc"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("517306b6-9100-4b6a-8d14-989929f2d3b7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b86f1ab-349a-4f85-9ca0-6e4a0d0a5321"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9901f8d-a093-4668-9425-e678450ab197"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5e00316f-34b1-422d-aced-7df47cd486c4"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "JobApplications");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4031));

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4010));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4013));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4014));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsActive", "IsLock", "LastName", "Location", "ModifiedAt", "Password", "Phone", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("a09be84a-eca4-4f44-89f0-5e37677a2171"), "", new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(3959), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" },
                    { new Guid("e36ecb98-c8d0-43db-ba6d-71efed6a5de2"), "", new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(3946), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("eccac318-06b0-4bf2-b3a7-17d7b53e39b1"), "", new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(3961), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" }
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("0412e9a9-06e5-408e-9813-e28578c64017"), new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4074), new DateTime(2024, 11, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4075), 2, "Looking for a data scientist to join our AI team. Must have experience with Python, TensorFlow, and Keras.", " 239 Đ. Xuân Thủy, Dịch Vọng Hậu, Cầu Giấy, Hà Nội", 1, new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4074), "", 0, "AI Engineer", new Guid("a09be84a-eca4-4f44-89f0-5e37677a2171") },
                    { new Guid("3ef7cabf-9d07-45c0-b094-3277308c44b9"), new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4077), new DateTime(2024, 11, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4078), 3, "We are looking for a nurse to join our team. Must have a nursing degree and at least 2 years of experience.", "Số 1, Đại Cồ Việt, Hai Bà Trưng, Hà Nội", 1, new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4078), "", 0, "Nurse", new Guid("a09be84a-eca4-4f44-89f0-5e37677a2171") },
                    { new Guid("ea258eb5-e60a-4b85-ae2b-3d7824d9bcf2"), new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4061), new DateTime(2024, 11, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4063), 1, "Looking for a skilled software engineer. Must have experience with C# and .NET Core. Angular experience is a plus.", "Số 13, Tân Thuận Đông, Quận 7, Hồ Chí Minh", 1, new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4062), "", 0, "Software Engineer", new Guid("a09be84a-eca4-4f44-89f0-5e37677a2171") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId" },
                values: new object[,]
                {
                    { new Guid("09d7d5d9-135f-4f0b-b871-f935772e1dba"), new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(3991), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("eccac318-06b0-4bf2-b3a7-17d7b53e39b1") },
                    { new Guid("0cfaadcb-1eec-4284-a16d-c1a4dd40052e"), new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(3985), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("e36ecb98-c8d0-43db-ba6d-71efed6a5de2") },
                    { new Guid("946724f7-b12f-4391-ac2d-f9bcbfac8dc6"), new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(3990), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("a09be84a-eca4-4f44-89f0-5e37677a2171") }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ApplicationDate", "CvFile", "JobPostId", "Status", "UserId" },
                values: new object[] { new Guid("20097e66-9210-4b04-8365-3b1cb9006866"), new DateTime(2024, 10, 9, 1, 36, 43, 666, DateTimeKind.Utc).AddTicks(4099), "path/to/cv.pdf", new Guid("ea258eb5-e60a-4b85-ae2b-3d7824d9bcf2"), 2, new Guid("eccac318-06b0-4bf2-b3a7-17d7b53e39b1") });
        }
    }
}
