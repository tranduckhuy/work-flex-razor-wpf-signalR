using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkFlex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_IsRecruiterRequestPending_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: new Guid("0aa386b4-242e-4f34-b883-211b1c6ffadb"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("51ace9c6-13ff-42e4-9eef-aa29cde09f09"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("ea6c5c85-8539-446e-ba58-db137e4266df"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("6619f79c-467a-40e9-8268-2500611e2692"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("66389ea5-c852-41a7-9b37-fee702721828"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("d3e451b5-2ce3-4620-b60f-25a62b86bb28"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("4ded7c31-c5d6-4630-a226-c267c2d67170"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a1f2f5e4-33e9-4b33-ad85-f2bc27850c83"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dd465659-d91d-4b86-9b8c-b5fd1dba949b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0528a99f-0c7a-4922-b074-1490e4fcccf3"));

            migrationBuilder.AddColumn<bool>(
                name: "IsRecruiterRequestPending",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4870));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "BackgroundImg", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsActive", "IsLock", "IsRecruiterRequestPending", "LastName", "Location", "ModifiedAt", "Password", "Phone", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("449b74df-1dde-4e3b-bb15-b367e396afd4"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", "~img/banner/img.png", new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4758), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" },
                    { new Guid("532b8652-d2ef-4d77-8044-42413d736e7f"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", "~img/banner/img.png", new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4745), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("9e058cef-aac8-4dc0-bcce-b7d05e215379"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", "~img/banner/img.png", new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4753), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" }
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("19137a37-e55e-433b-af19-a9016d624dbb"), new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4989), new DateTime(2024, 11, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4990), 3, "We are looking for a nurse to join our team. Must have a nursing degree and at least 2 years of experience.", "Số 1, Đại Cồ Việt, Hai Bà Trưng, Hà Nội", 1, new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4989), "100 - 500", 0, "Nurse", new Guid("9e058cef-aac8-4dc0-bcce-b7d05e215379") },
                    { new Guid("e627b0c2-aa83-4243-a795-5c47a58274d0"), new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4982), new DateTime(2024, 11, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4984), 2, "Looking for a data scientist to join our AI team. Must have experience with Python, TensorFlow, and Keras.", " 239 Đ. Xuân Thủy, Dịch Vọng Hậu, Cầu Giấy, Hà Nội", 1, new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4983), "100 - 1000", 0, "AI Engineer", new Guid("9e058cef-aac8-4dc0-bcce-b7d05e215379") },
                    { new Guid("f9e96515-b8b4-4ff5-a1d0-592e12a1639b"), new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4960), new DateTime(2024, 11, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4962), 1, "Looking for a skilled software engineer. Must have experience with C# and .NET Core. Angular experience is a plus.", "Số 13, Tân Thuận Đông, Quận 7, Hồ Chí Minh", 1, new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4961), "1000 - 6000", 0, "Software Engineer", new Guid("9e058cef-aac8-4dc0-bcce-b7d05e215379") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId" },
                values: new object[,]
                {
                    { new Guid("5f8a64ea-a26b-460e-8c87-361b180bb450"), new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4829), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("449b74df-1dde-4e3b-bb15-b367e396afd4") },
                    { new Guid("7183e799-08cb-4ab6-93f6-61b5280adbf8"), new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4810), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("9e058cef-aac8-4dc0-bcce-b7d05e215379") },
                    { new Guid("fabdfc5d-5ab0-4f48-8747-1cd58d1d4150"), new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(4801), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("532b8652-d2ef-4d77-8044-42413d736e7f") }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ApplicationDate", "CvFile", "Description", "JobPostId", "Status", "UserId" },
                values: new object[] { new Guid("431c7e86-c71b-488b-88f9-da80de6a9daf"), new DateTime(2024, 10, 21, 16, 37, 34, 537, DateTimeKind.Utc).AddTicks(5029), "path/to/cv.pdf", "", new Guid("f9e96515-b8b4-4ff5-a1d0-592e12a1639b"), 2, new Guid("449b74df-1dde-4e3b-bb15-b367e396afd4") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: new Guid("431c7e86-c71b-488b-88f9-da80de6a9daf"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("19137a37-e55e-433b-af19-a9016d624dbb"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("e627b0c2-aa83-4243-a795-5c47a58274d0"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("5f8a64ea-a26b-460e-8c87-361b180bb450"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("7183e799-08cb-4ab6-93f6-61b5280adbf8"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("fabdfc5d-5ab0-4f48-8747-1cd58d1d4150"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("f9e96515-b8b4-4ff5-a1d0-592e12a1639b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("449b74df-1dde-4e3b-bb15-b367e396afd4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("532b8652-d2ef-4d77-8044-42413d736e7f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e058cef-aac8-4dc0-bcce-b7d05e215379"));

            migrationBuilder.DropColumn(
                name: "IsRecruiterRequestPending",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8419));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8402));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8403));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "BackgroundImg", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsActive", "IsLock", "LastName", "Location", "ModifiedAt", "Password", "Phone", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("0528a99f-0c7a-4922-b074-1490e4fcccf3"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", "~img/banner/img.png", new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8327), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" },
                    { new Guid("a1f2f5e4-33e9-4b33-ad85-f2bc27850c83"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", "~img/banner/img.png", new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8348), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" },
                    { new Guid("dd465659-d91d-4b86-9b8c-b5fd1dba949b"), "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg", "~img/banner/img.png", new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8323), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" }
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("4ded7c31-c5d6-4630-a226-c267c2d67170"), new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8448), new DateTime(2024, 11, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8449), 1, "Looking for a skilled software engineer. Must have experience with C# and .NET Core. Angular experience is a plus.", "Số 13, Tân Thuận Đông, Quận 7, Hồ Chí Minh", 1, new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8448), "1000 - 6000", 0, "Software Engineer", new Guid("0528a99f-0c7a-4922-b074-1490e4fcccf3") },
                    { new Guid("51ace9c6-13ff-42e4-9eef-aa29cde09f09"), new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8463), new DateTime(2024, 11, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8464), 2, "Looking for a data scientist to join our AI team. Must have experience with Python, TensorFlow, and Keras.", " 239 Đ. Xuân Thủy, Dịch Vọng Hậu, Cầu Giấy, Hà Nội", 1, new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8464), "100 - 1000", 0, "AI Engineer", new Guid("0528a99f-0c7a-4922-b074-1490e4fcccf3") },
                    { new Guid("ea6c5c85-8539-446e-ba58-db137e4266df"), new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8467), new DateTime(2024, 11, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8467), 3, "We are looking for a nurse to join our team. Must have a nursing degree and at least 2 years of experience.", "Số 1, Đại Cồ Việt, Hai Bà Trưng, Hà Nội", 1, new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8467), "100 - 500", 0, "Nurse", new Guid("0528a99f-0c7a-4922-b074-1490e4fcccf3") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId" },
                values: new object[,]
                {
                    { new Guid("6619f79c-467a-40e9-8268-2500611e2692"), new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8380), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("0528a99f-0c7a-4922-b074-1490e4fcccf3") },
                    { new Guid("66389ea5-c852-41a7-9b37-fee702721828"), new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8371), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("dd465659-d91d-4b86-9b8c-b5fd1dba949b") },
                    { new Guid("d3e451b5-2ce3-4620-b60f-25a62b86bb28"), new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8381), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("a1f2f5e4-33e9-4b33-ad85-f2bc27850c83") }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ApplicationDate", "CvFile", "Description", "JobPostId", "Status", "UserId" },
                values: new object[] { new Guid("0aa386b4-242e-4f34-b883-211b1c6ffadb"), new DateTime(2024, 10, 19, 1, 34, 55, 493, DateTimeKind.Utc).AddTicks(8484), "path/to/cv.pdf", "", new Guid("4ded7c31-c5d6-4630-a226-c267c2d67170"), 2, new Guid("a1f2f5e4-33e9-4b33-ad85-f2bc27850c83") });
        }
    }
}
