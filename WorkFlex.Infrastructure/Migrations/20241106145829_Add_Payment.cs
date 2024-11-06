using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkFlex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: new Guid("1824422b-ef6e-4fd0-8947-8f1b6f51302a"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("098760d8-6212-46d3-98fe-b6092864d821"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("287457cc-8ea2-4587-87ff-a3ce9ec20521"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("33e43b4b-f098-4742-bdf7-037850073908"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("3c92f177-812c-4fb9-9018-8d57911a5fdf"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("404e50cc-ad5d-4a1b-aed3-c01020568729"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("4cd318c6-794f-4881-bc8a-26da4e0950e9"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("64ca3f34-e832-4365-93f1-119ec61883ce"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("6867ac7d-2070-4d33-8e69-cf2d6d139e82"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("695661ec-8d0f-4ecc-8516-3bafc5fc6f27"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("6db2fe09-99a8-455a-a5ea-8787f75866b8"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("7d443daa-5dc2-4787-bbf7-b14742015e0b"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("99750a50-0b0d-4fd3-9626-d533848e9295"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("aa401aef-c9eb-4e43-9fba-c6c9fecb7ff0"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("c4fa3bf7-1e7e-489c-9f8d-acd2f44329d5"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("ca7c80eb-636c-40be-b39f-710ea2ea1127"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("e3b33627-a210-440e-a3b0-9d55689094a2"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("ea01a830-4be5-4e98-95e8-5dcd8833a173"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("fd170648-2c79-45a1-8062-310d4254b2c9"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("ff151222-a992-4e7b-9c22-ca998380039a"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("1adcadfa-a580-4462-be0d-47e9b4799f5d"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("4ca1adc2-cd2e-4506-a58d-06aca4261f8b"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("56f90d1b-161b-4389-b181-6f189b484184"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("63358ff0-4f6b-4003-924a-fb19054a6b63"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("6d02d55d-f67a-483f-9708-1ee1a396e3f9"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("7a844f32-1575-4b1d-801d-3037ac7a2536"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("a9910264-5041-4dc4-9781-4f0682573207"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("aa4ea6ae-d617-4ae1-a91d-8385d901b704"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("b31ff108-4af6-4e9e-bf30-77ce0e6be1b9"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("b4539aa4-5bb1-4c73-8319-3f64a8c8dde7"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("c5f2ba50-ae50-4e77-b9f5-c2455061c193"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("fd4ea0f7-eac1-4582-9aa9-f5102e164796"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("18edd806-66bc-47a7-bd24-7e4924097930"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("30d0ec3d-6da4-43d4-b9e2-c259fc9a4e11"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3f99986a-953e-43cc-98c5-a842cd0808a1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4272b117-2994-4483-b816-2b8440b71dbb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("543d3c1e-b344-4391-8f97-3c14e9e0f67d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5a917248-65fb-44ea-ac6b-ff0c10b84137"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5c71e821-86d6-4b02-9a7b-98e68a61d3b7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9fa449ba-da72-4e9a-80dd-dfd4c022e58c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a429c4b0-2e25-4cf7-a73b-9d53a3555ee0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c58d1f09-d735-4306-b9f9-1a9b9fddc482"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f995d00b-06f5-44b8-bf63-27ed5f7ea172"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("67bd4c46-d2c1-4e66-956d-4750fe83ef78"));

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentRefId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredAmount = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDestinationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2464));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2472));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2425));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "BackgroundImg", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsActive", "IsLock", "IsRecruiterRequestPending", "LastName", "Location", "ModifiedAt", "Password", "Phone", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("3a3bcccf-2c76-4268-afcc-a0ff27debbdf"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fmrcf7_1730428331026_vendor-10.png?alt=media&token=9e787b31-eea6-4f38-a2c2-fa3c8a2140e1", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nghia@example.com", "Trong", true, false, false, "Nghia", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$zD2J2lknJ27rADmUbwJM9eSS0sX16W/FUw/xVx7XauSjOuxauzeZa", "", 3, "nghia" },
                    { new Guid("3b1c11da-a7fb-440e-938d-09cad22aed8e"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Ftjw6hg_1730428353803_table-img1.png?alt=media&token=fa6ddab5-418a-4cfb-ab75-2aa0d578c164", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2220), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("673a7f90-f91d-4cab-aa79-ba4b002cf865"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fvn1m3b_1730428306808_vendor-4.png?alt=media&token=f1e61339-1c7f-4065-acbf-d49a012dc604", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "quy@example.com", "Nguyen Xuan", true, false, false, "Quy", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$O/urkLFsFi/GN9s0asTeZ.3YnvDozIBPXS5vpDbl6Kvz4RsxZYRIS", "", 2, "quy" },
                    { new Guid("7726f255-5882-4c63-92ca-35fb6572be7a"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2F9xi15_1730428296376_vendor-2.png?alt=media&token=e850aa0f-9798-45da-851a-1b4a7bc6726d", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sang@example.com", "Tran Ngoc", true, false, false, "Sang", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$CwxlScy8xNpcrGL/2sg7V.vDUC1zh.QOjZD1qefQgxmq3vn0Q7R9.", "", 2, "sang" },
                    { new Guid("9c197e36-6d24-4a9d-8860-369502b692b7"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fwobtrg_1730428336088_vendor-11.png?alt=media&token=306e81e3-dee1-4e09-bd09-0ea22d9bcd66", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnweek@example.com", "John", true, false, false, "Week", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$zWTkYvKaD2nrl/FIEzZvAus4fK1zT5kIk9U.IrzNxHZOzLxYzIYNe", "", 3, "johnweek" },
                    { new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2F2q2joa_1730428345764_vendor-14.png?alt=media&token=75952a9b-a099-4ec3-acc5-3240f0839dd2", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" },
                    { new Guid("a5fe7542-f00c-4e13-a82c-8153bfd405a8"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Frijtlx_1730428289939_vendor-1.png?alt=media&token=529439ae-4bc1-4c9a-ad2a-6d97f0c5ae25", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fmau-cua-hang-tap-hoa-12-aeros.webp?alt=media&token=55cb771a-c564-4d29-b0fa-f6cccea186e2", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "huy@example.com", "Tran Duck", true, false, false, "Huy", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$MNV7kUVAks5PkB4cMD8cNuLvONZlKt/ej7.hCdRTGyj4F/csD8oKK", "", 2, "tranduckhuy" },
                    { new Guid("a7fe8ee8-29cc-4e2b-bc54-38e9760b1121"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Ffc2hi5_1730428324559_vendor-9.png?alt=media&token=fa4632f1-2584-4496-9927-d0a645413638", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "thinh@example.com", "Gia", true, false, false, "Thinh", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$kzs6W6lPdNmhq9mAxWfov.FJAHD2YDQJgQ/oiDeeMo78LKzDExz2O", "", 3, "thinh" },
                    { new Guid("abaa32d1-9c14-4847-b448-b41e4d8109bf"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Ftvujfq_1730428311602_vendor-5.png?alt=media&token=65db1056-55f6-4620-990b-c3641807507f", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "thuan@example.com", "Nguyen Dao", true, false, false, "Minh Thuan", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$3hGHatEPOSTNLlvBEUMw.uxZMLNxLz74/Ls47cvbccwwlJlhFELqS", "", 3, "thuan" },
                    { new Guid("add18884-4328-4a21-884b-d061ddc2891c"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2F17mshd_1730428341488_vendor-13.png?alt=media&token=33092b37-f077-4863-9329-63fa6e5964f7", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" },
                    { new Guid("dd335464-f692-489f-8f77-c176d8bf824f"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fkxakd5_1730428320184_vendor-7.png?alt=media&token=9a4cabc8-8372-45d8-9d3e-364766154550", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoang@example.com", "Ngo Gia", true, false, false, "Hoang", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$aYH6ji8QMczfCJxRGoBUqeTA7Ttk1JnanbTXBiafDDrrOQcy6hK7O", "", 3, "hoang" },
                    { new Guid("ebb55028-bd6c-4aaf-a5d3-7f5632d88acd"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Faq8ir_1730428301407_vendor-3.png?alt=media&token=295216c1-4ea0-4a0c-8a61-3c66200f41bb", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hao@example.com", "Nguyen Nhat", true, false, false, "Hao", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$KcwDWaYdePFeLgKTwoJd7OQl6YCi9ZvCzdPDdt7lROYp2paxwpyGC", "", 3, "hao" }
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("06ef3309-2a8b-4302-99b0-61a48d6f74e1"), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2651), 2, "Tổng quan vị trí:\n- Hỗ trợ tổ chức và quản lý các sự kiện.\n- Liên lạc với các nhà cung cấp và khách hàng.\n- Đảm bảo mọi thứ diễn ra suôn sẻ trong sự kiện.\n\nYêu cầu ứng viên:\n- Kỹ năng tổ chức và giao tiếp tốt.\n- Có khả năng làm việc dưới áp lực cao.\n- Nhiệt tình và sáng tạo.", "Tòa nhà S, Đường Nguyễn Thái Học, Phường Lê Lợi, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2651), "500 - 800", 0, "Nhân Viên Tổ Chức Sự Kiện Part-time", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("0b19a2b9-5453-4668-88bd-4b6c2db5a5c1"), new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2657), 2, "Tổng quan vị trí:\n- Nghiên cứu và phân tích thị trường để phát triển chiến lược.\n- Phát triển mối quan hệ với khách hàng và đối tác.\n- Tạo báo cáo và đề xuất các giải pháp kinh doanh.\n\nYêu cầu ứng viên:\n- Tối thiểu 2 năm kinh nghiệm trong phát triển thị trường.\n- Kỹ năng phân tích và giao tiếp tốt.\n- Tốt nghiệp chuyên ngành kinh tế, marketing hoặc tương đương.", "Tòa nhà T, Đường Trần Hưng Đạo, Phường Hải Cảng, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2656), "3.000 - 7.000", 0, "Chuyên Viên Phát Triển Thị Trường", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("25ede3f2-b346-41db-bc0a-a7d7a2abeb94"), new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2646), 2, "Tổng quan vị trí:\n- Tư vấn và quản lý các dịch vụ tài chính cho khách hàng.\n- Phân tích và đánh giá tình hình tài chính của khách hàng.\n- Xây dựng các kế hoạch tài chính phù hợp.\n\nYêu cầu ứng viên:\n- Kinh nghiệm trong lĩnh vực tài chính hoặc ngân hàng.\n- Kỹ năng giao tiếp và thuyết phục tốt.\n- Tốt nghiệp chuyên ngành tài chính hoặc tương đương.", "Tòa nhà R, Đường Trần Nhân Tông, Phường Trần Phú, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2646), "3500 - 4500", 0, "Chuyên Viên Tư Vấn Tài Chính", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("276228a4-2d78-48b7-87ab-a1faa7b56b99"), new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2597), 2, "Tổng quan vị trí:\n- Hỗ trợ thực hiện các kế hoạch kinh doanh.\n- Nghiên cứu thị trường và phân tích dữ liệu khách hàng.\n- Theo dõi và báo cáo kết quả.\n\nYêu cầu ứng viên:\n- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành kinh doanh.\n- Kỹ năng giao tiếp tốt.\n- Có khả năng làm việc nhóm.", "Tòa nhà J, Đường Nguyễn Công Trứ, Phường Lê Lợi, Quy Nhơn, Bình Định", 3, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2597), "400 - 600", 0, "Thực Tập Sinh Kinh Doanh", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("29366e71-f2c2-4955-825f-d2d455631dd6"), new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2561), 2, "Tổng quan vị trí:\n- Hỗ trợ khách hàng qua điện thoại và email.\n- Giải quyết các vấn đề của khách hàng.\n- Cung cấp thông tin về sản phẩm và dịch vụ.\n\nYêu cầu ứng viên:\n- Kỹ năng giao tiếp và lắng nghe tốt.\n- Có khả năng làm việc dưới áp lực.\n- Chịu khó và cầu tiến.", "Tòa nhà D, Đường Phạm Ngũ Lão, Phường Trần Phú, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2560), "500 - 800", 0, "Nhân Viên Hỗ Trợ Khách Hàng Part-time", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("3b4010ec-7aa1-4c14-a68b-45cc4f28ab59"), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2546), 1, "Tổng quan vị trí:\n- Hỗ trợ kỹ thuật cho các sản phẩm công nghệ.\n- Giải quyết các sự cố kỹ thuật của khách hàng.\n- Tham gia vào các dự án nhỏ theo yêu cầu.\n\nYêu cầu ứng viên:\n- Có kiến thức về công nghệ thông tin.\n- Kỹ năng giải quyết vấn đề tốt.\n- Có khả năng làm việc độc lập.", "Tòa nhà B, Đường Trần Hưng Đạo, Phường Hải Cảng, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2545), "700 - 1000", 0, "Nhân Viên Kỹ Thuật Part-time", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("3ba22f63-3318-4088-ab21-95a4a9943baa"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2576), 2, "Tổng quan vị trí:\n- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing.\n- Phân tích dữ liệu và báo cáo kết quả.\n- Tham gia các hoạt động quảng bá sản phẩm.\n\nYêu cầu ứng viên:\n- Có kiến thức về marketing.\n- Kỹ năng phân tích và giao tiếp tốt.\n- Chịu khó và ham học hỏi.", "Tòa nhà F, Đường Lý Thường Kiệt, Phường Xuân Diệu, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2575), "500 - 800", 0, "Nhân Viên Marketing Part-time", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("3e927711-41fd-46da-b747-7a5ad484bcff"), new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2641), 2, "Tổng quan vị trí:\n- Lập kế hoạch và giám sát tiến độ dự án.\n- Quản lý nguồn lực và ngân sách dự án.\n- Đảm bảo các mục tiêu dự án được thực hiện đúng hạn.\n\nYêu cầu ứng viên:\n- Tối thiểu 5 năm kinh nghiệm trong quản lý dự án.\n- Kỹ năng lãnh đạo và quản lý tốt.\n- Tốt nghiệp chuyên ngành quản trị kinh doanh hoặc tương đương.", "Tòa nhà Q, Đường Nguyễn Công Trứ, Phường Lê Lợi, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2640), "4000 - 5000", 0, "Giám Đốc Dự Án", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("47c01e1a-2611-4076-ae0a-4e0c5e19ac4b"), new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2630), 2, "Tổng quan vị trí:\n- Phát triển và duy trì mối quan hệ với khách hàng.\n- Đạt được mục tiêu doanh số hàng tháng.\n- Phân tích nhu cầu của khách hàng để đề xuất các giải pháp phù hợp.\n\nYêu cầu ứng viên:\n- Kinh nghiệm trong lĩnh vực kinh doanh.\n- Kỹ năng giao tiếp và thuyết phục tốt.\n- Tốt nghiệp chuyên ngành kinh tế hoặc tương đương.", "Tòa nhà O, Đường Đống Đa, Phường Bình Định, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2630), "2500 - 3500", 0, "Chuyên Viên Kinh Doanh", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("5c96da7e-0218-4bdf-afa9-9efdaa0807a9"), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2581), 2, "Tổng quan vị trí:\n- Tư vấn sản phẩm cho khách hàng.\n- Hỗ trợ giải quyết thắc mắc của khách hàng.\n- Cập nhật thông tin về sản phẩm mới.\n\nYêu cầu ứng viên:\n- Kỹ năng giao tiếp tốt.\n- Có khả năng làm việc nhóm.\n- Chịu khó và nhiệt tình.", "Tòa nhà G, Đường Đống Đa, Phường Bình Định, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2580), "600 - 900", 0, "Nhân Viên Tư Vấn Khách Hàng Part-time", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("6a660d54-9f31-4cc5-b21f-952fdee32660"), new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2609), 1, "Tổng quan vị trí:\n- Hỗ trợ kỹ thuật trong các dự án IT.\n- Học hỏi và phát triển kỹ năng chuyên môn.\n- Tham gia vào các công việc hàng ngày của nhóm kỹ thuật.\n\nYêu cầu ứng viên:\n- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành IT.\n- Có kiến thức cơ bản về lập trình.\n- Nhiệt tình và ham học hỏi.", "Tòa nhà L, Đường Lý Thường Kiệt, Phường Xuân Diệu, Quy Nhơn, Bình Định", 3, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2608), "400 - 600", 0, "Thực Tập Sinh Kỹ Thuật IT", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("6e541552-90db-470c-8917-797585e9f01a"), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2554), 2, "Tổng quan vị trí:\n- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing.\n- Nghiên cứu thị trường và phân tích dữ liệu khách hàng.\n- Theo dõi và báo cáo kết quả chiến dịch.\n\nYêu cầu ứng viên:\n- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành marketing.\n- Kỹ năng giao tiếp tốt.\n- Có khả năng làm việc nhóm.", "Tòa nhà C, Đường Nguyễn Huệ, Phường Lê Lợi, Quy Nhơn, Bình Định", 3, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2553), "400 - 600", 0, "Thực Tập Sinh Marketing", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("773f2502-a95b-4713-8725-58cfc01c4609"), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2592), 2, "Tổng quan vị trí:\n- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing.\n- Phân tích và báo cáo kết quả chiến dịch.\n- Tham gia vào các hoạt động quảng bá sản phẩm.\n\nYêu cầu ứng viên:\n- Có kiến thức về marketing.\n- Kỹ năng phân tích và giao tiếp tốt.\n- Chịu khó và ham học hỏi.", "Tòa nhà I, Đường Nguyễn Thái Học, Phường Lê Lợi, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2591), "600 - 900", 0, "Nhân Viên Hỗ Trợ Marketing Part-time", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("84ed995a-ccd3-4e10-90c1-a1d0477be638"), new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2603), 2, "Tổng quan vị trí:\n- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing số.\n- Theo dõi và phân tích dữ liệu trên các kênh truyền thông.\n- Cập nhật thông tin về sản phẩm và dịch vụ.\n\nYêu cầu ứng viên:\n- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành marketing.\n- Kỹ năng phân tích và giao tiếp tốt.\n- Chịu khó và nhiệt tình.", "Tòa nhà K, Đường Trần Phú, Phường Trần Phú, Quy Nhơn, Bình Định", 3, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2602), "400 - 600", 0, "Thực Tập Sinh Digital Marketing", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("a589e1c9-5ecc-4672-9917-ee88d8dbbf9d"), new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2625), 1, "Tổng quan vị trí:\n- Phân tích dữ liệu để đưa ra quyết định chiến lược.\n- Tạo báo cáo và trình bày kết quả phân tích.\n- Hỗ trợ các bộ phận khác trong việc sử dụng dữ liệu.\n\nYêu cầu ứng viên:\n- Kinh nghiệm trong phân tích dữ liệu.\n- Kỹ năng sử dụng các công cụ phân tích và báo cáo.\n- Tốt nghiệp chuyên ngành thống kê, kinh tế hoặc tương đương.", "Tòa nhà N, Đường Trần Hưng Đạo, Phường Hải Cảng, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2624), "2000 - 3000", 0, "Chuyên Viên Phân Tích Dữ Liệu", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("b0034f2c-0493-40bb-8f00-242d6b6f416e"), new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2619), 2, "Tổng quan vị trí:\n- Lập kế hoạch và thực hiện các chiến dịch marketing.\n- Quản lý ngân sách marketing và báo cáo kết quả.\n- Phân tích xu hướng thị trường và nhu cầu khách hàng.\n\nYêu cầu ứng viên:\n- Tối thiểu 3 năm kinh nghiệm trong lĩnh vực marketing.\n- Kỹ năng lãnh đạo và giao tiếp tốt.\n- Tốt nghiệp chuyên ngành marketing hoặc tương đương.", "Tòa nhà M, Đường Phạm Ngũ Lão, Phường Trần Phú, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2619), "2500 - 3500", 0, "Quản Lý Marketing", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("b4435d10-57f3-4728-aaf7-8596fdc557b1"), new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2570), 2, "Tổng quan vị trí:\n- Tìm kiếm khách hàng và giới thiệu sản phẩm.\n- Đạt được chỉ tiêu doanh số tháng.\n- Duy trì mối quan hệ với khách hàng hiện tại.\n\nYêu cầu ứng viên:\n- Có kinh nghiệm trong lĩnh vực kinh doanh.\n- Kỹ năng giao tiếp tốt.\n- Có khả năng làm việc độc lập và theo nhóm.", "Tòa nhà E, Đường Nguyễn Công Trứ, Phường Lê Lợi, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2569), "600 - 900", 0, "Nhân Viên Kinh Doanh Part-time", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("d65a4c7c-b738-4d51-93bd-003a08af856f"), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2587), 1, "Tổng quan vị trí:\n- Hỗ trợ kỹ thuật cho các sản phẩm công nghệ.\n- Giải quyết các sự cố kỹ thuật.\n- Tham gia vào các dự án nhỏ theo yêu cầu.\n\nYêu cầu ứng viên:\n- Có kiến thức về kỹ thuật.\n- Kỹ năng giải quyết vấn đề tốt.\n- Có khả năng làm việc độc lập.", "Tòa nhà H, Đường Phạm Văn Đồng, Phường Trần Phú, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2586), "700 - 1000", 0, "Nhân Viên Kỹ Thuật Part-time", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") },
                    { new Guid("dcb62248-823e-4faf-b5cf-505aa649224f"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2527), 4, "Tổng quan vị trí:\n- Tìm kiếm và phát triển khách hàng mới cho tạp hóa.\n- Đạt được mục tiêu doanh số hàng tháng của cửa hàng.\n- Hỗ trợ khách hàng trong quá trình mua sắm tại tạp hóa.\n\nYêu cầu ứng viên:\n- Có kinh nghiệm trong lĩnh vực bán hàng hoặc tạp hóa.\n- Kỹ năng giao tiếp tốt và thân thiện với khách hàng.\n- Có khả năng làm việc theo nhóm và độc lập.", "Tạp Hóa Anh Ba, Đường Lê Lợi, Phường Trần Phú, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2526), "100 - 150", 0, "Nhân Viên Bán Hàng Tạp Hóa Anh Ba", new Guid("a5fe7542-f00c-4e13-a82c-8153bfd405a8") },
                    { new Guid("fd8cfb0f-6be9-40cb-ba16-e42670216cf6"), new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2636), 1, "Tổng quan vị trí:\n- Phát triển và duy trì các ứng dụng phần mềm.\n- Làm việc với các nhóm để phát triển sản phẩm.\n- Thực hiện kiểm thử và sửa lỗi phần mềm.\n\nYêu cầu ứng viên:\n- Có ít nhất 2 năm kinh nghiệm lập trình.\n- Thành thạo một hoặc nhiều ngôn ngữ lập trình.\n- Kỹ năng làm việc nhóm và giải quyết vấn đề tốt.", "Tòa nhà P, Đường Nguyễn Thái Học, Phường Lê Lợi, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2635), "3000 - 4000", 0, "Kỹ Sư Phần Mềm", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId", "Website" },
                values: new object[,]
                {
                    { new Guid("07e45832-9ff3-4e95-a659-c14af1d01288"), new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2346), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0"), null },
                    { new Guid("12fe02c7-8e60-45ea-8137-175916a53c65"), new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2349), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("add18884-4328-4a21-884b-d061ddc2891c"), null },
                    { new Guid("340ae062-51ab-4146-9fac-9a84abc22d5f"), new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2367), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("dd335464-f692-489f-8f77-c176d8bf824f"), null },
                    { new Guid("38d5996a-f5ce-4e05-9482-a0f5a4290d76"), new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2360), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("ebb55028-bd6c-4aaf-a5d3-7f5632d88acd"), null },
                    { new Guid("87d1b1f0-a45c-4b88-86bc-77666c035541"), new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2336), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("3b1c11da-a7fb-440e-938d-09cad22aed8e"), null },
                    { new Guid("95d9d6dd-cace-441f-982a-6360c284d15e"), new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2369), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("a7fe8ee8-29cc-4e2b-bc54-38e9760b1121"), null },
                    { new Guid("98d8d63a-1b74-4ebd-8929-4329fd8815ec"), new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2371), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("3a3bcccf-2c76-4268-afcc-a0ff27debbdf"), null },
                    { new Guid("9ad62d5e-ba4e-49bf-a88f-930b784e6b28"), new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2355), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("7726f255-5882-4c63-92ca-35fb6572be7a"), null },
                    { new Guid("c0a971d5-c63e-4721-bbf5-b0e7dcc9026d"), new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2351), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("9c197e36-6d24-4a9d-8860-369502b692b7"), null },
                    { new Guid("ea276d1c-c45a-41cc-a177-7974fbdcf674"), new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2362), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("abaa32d1-9c14-4847-b448-b41e4d8109bf"), null },
                    { new Guid("f5a3d08d-fbe2-494e-b846-48ee668de39a"), new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2353), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("a5fe7542-f00c-4e13-a82c-8153bfd405a8"), null },
                    { new Guid("ff12e54a-1508-47dd-8d66-9a93f9d4b5eb"), new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2357), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("673a7f90-f91d-4cab-aa79-ba4b002cf865"), null }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ApplicationDate", "CvFile", "Description", "JobPostId", "Status", "UserId" },
                values: new object[] { new Guid("32b78b15-a7c6-49e8-9d3d-e4d6c3e5bb55"), new DateTime(2024, 11, 6, 14, 58, 28, 995, DateTimeKind.Utc).AddTicks(2716), "path/to/cv.pdf", "", new Guid("dcb62248-823e-4faf-b5cf-505aa649224f"), 2, new Guid("add18884-4328-4a21-884b-d061ddc2891c") });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: new Guid("32b78b15-a7c6-49e8-9d3d-e4d6c3e5bb55"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("06ef3309-2a8b-4302-99b0-61a48d6f74e1"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("0b19a2b9-5453-4668-88bd-4b6c2db5a5c1"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("25ede3f2-b346-41db-bc0a-a7d7a2abeb94"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("276228a4-2d78-48b7-87ab-a1faa7b56b99"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("29366e71-f2c2-4955-825f-d2d455631dd6"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("3b4010ec-7aa1-4c14-a68b-45cc4f28ab59"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("3ba22f63-3318-4088-ab21-95a4a9943baa"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("3e927711-41fd-46da-b747-7a5ad484bcff"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("47c01e1a-2611-4076-ae0a-4e0c5e19ac4b"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("5c96da7e-0218-4bdf-afa9-9efdaa0807a9"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("6a660d54-9f31-4cc5-b21f-952fdee32660"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("6e541552-90db-470c-8917-797585e9f01a"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("773f2502-a95b-4713-8725-58cfc01c4609"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("84ed995a-ccd3-4e10-90c1-a1d0477be638"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("a589e1c9-5ecc-4672-9917-ee88d8dbbf9d"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("b0034f2c-0493-40bb-8f00-242d6b6f416e"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("b4435d10-57f3-4728-aaf7-8596fdc557b1"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("d65a4c7c-b738-4d51-93bd-003a08af856f"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("fd8cfb0f-6be9-40cb-ba16-e42670216cf6"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("07e45832-9ff3-4e95-a659-c14af1d01288"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("12fe02c7-8e60-45ea-8137-175916a53c65"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("340ae062-51ab-4146-9fac-9a84abc22d5f"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("38d5996a-f5ce-4e05-9482-a0f5a4290d76"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("87d1b1f0-a45c-4b88-86bc-77666c035541"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("95d9d6dd-cace-441f-982a-6360c284d15e"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("98d8d63a-1b74-4ebd-8929-4329fd8815ec"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("9ad62d5e-ba4e-49bf-a88f-930b784e6b28"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("c0a971d5-c63e-4721-bbf5-b0e7dcc9026d"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("ea276d1c-c45a-41cc-a177-7974fbdcf674"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("f5a3d08d-fbe2-494e-b846-48ee668de39a"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("ff12e54a-1508-47dd-8d66-9a93f9d4b5eb"));

            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Id",
                keyValue: new Guid("dcb62248-823e-4faf-b5cf-505aa649224f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a3bcccf-2c76-4268-afcc-a0ff27debbdf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b1c11da-a7fb-440e-938d-09cad22aed8e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("673a7f90-f91d-4cab-aa79-ba4b002cf865"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7726f255-5882-4c63-92ca-35fb6572be7a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9c197e36-6d24-4a9d-8860-369502b692b7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a054a9b6-402d-4a72-b7cc-dd77245542b0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a7fe8ee8-29cc-4e2b-bc54-38e9760b1121"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("abaa32d1-9c14-4847-b448-b41e4d8109bf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("add18884-4328-4a21-884b-d061ddc2891c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dd335464-f692-489f-8f77-c176d8bf824f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ebb55028-bd6c-4aaf-a5d3-7f5632d88acd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a5fe7542-f00c-4e13-a82c-8153bfd405a8"));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7426));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7383));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7387));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "BackgroundImg", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsActive", "IsLock", "IsRecruiterRequestPending", "LastName", "Location", "ModifiedAt", "Password", "Phone", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2F2q2joa_1730428345764_vendor-14.png?alt=media&token=75952a9b-a099-4ec3-acc5-3240f0839dd2", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "recruiter@example.com", "Recruiter", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$RbvswLANBzRWrHEvwHJajem0x0uEv10NHZ7rFfdRG1Dn4oSulmavm", "", 2, "recruiter" },
                    { new Guid("30d0ec3d-6da4-43d4-b9e2-c259fc9a4e11"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Ftjw6hg_1730428353803_table-img1.png?alt=media&token=fa6ddab5-418a-4cfb-ab75-2aa0d578c164", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7240), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, false, false, "User", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$Qj8ov7RydnsbdkZfYAToaumQQIYDCeWcPyUTMeIW4sdhBoFujJHfm", "", 1, "admin" },
                    { new Guid("3f99986a-953e-43cc-98c5-a842cd0808a1"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fwobtrg_1730428336088_vendor-11.png?alt=media&token=306e81e3-dee1-4e09-bd09-0ea22d9bcd66", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnweek@example.com", "John", true, false, false, "Week", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$zWTkYvKaD2nrl/FIEzZvAus4fK1zT5kIk9U.IrzNxHZOzLxYzIYNe", "", 3, "johnweek" },
                    { new Guid("4272b117-2994-4483-b816-2b8440b71dbb"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fmrcf7_1730428331026_vendor-10.png?alt=media&token=9e787b31-eea6-4f38-a2c2-fa3c8a2140e1", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nghia@example.com", "Trong", true, false, false, "Nghia", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$zD2J2lknJ27rADmUbwJM9eSS0sX16W/FUw/xVx7XauSjOuxauzeZa", "", 3, "nghia" },
                    { new Guid("543d3c1e-b344-4391-8f97-3c14e9e0f67d"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2F9xi15_1730428296376_vendor-2.png?alt=media&token=e850aa0f-9798-45da-851a-1b4a7bc6726d", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sang@example.com", "Tran Ngoc", true, false, false, "Sang", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$CwxlScy8xNpcrGL/2sg7V.vDUC1zh.QOjZD1qefQgxmq3vn0Q7R9.", "", 2, "sang" },
                    { new Guid("5a917248-65fb-44ea-ac6b-ff0c10b84137"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fvn1m3b_1730428306808_vendor-4.png?alt=media&token=f1e61339-1c7f-4065-acbf-d49a012dc604", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "quy@example.com", "Nguyen Xuan", true, false, false, "Quy", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$O/urkLFsFi/GN9s0asTeZ.3YnvDozIBPXS5vpDbl6Kvz4RsxZYRIS", "", 2, "quy" },
                    { new Guid("5c71e821-86d6-4b02-9a7b-98e68a61d3b7"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Ftvujfq_1730428311602_vendor-5.png?alt=media&token=65db1056-55f6-4620-990b-c3641807507f", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "thuan@example.com", "Nguyen Dao", true, false, false, "Minh Thuan", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$3hGHatEPOSTNLlvBEUMw.uxZMLNxLz74/Ls47cvbccwwlJlhFELqS", "", 3, "thuan" },
                    { new Guid("67bd4c46-d2c1-4e66-956d-4750fe83ef78"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Frijtlx_1730428289939_vendor-1.png?alt=media&token=529439ae-4bc1-4c9a-ad2a-6d97f0c5ae25", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fmau-cua-hang-tap-hoa-12-aeros.webp?alt=media&token=55cb771a-c564-4d29-b0fa-f6cccea186e2", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "huy@example.com", "Tran Duck", true, false, false, "Huy", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$MNV7kUVAks5PkB4cMD8cNuLvONZlKt/ej7.hCdRTGyj4F/csD8oKK", "", 2, "tranduckhuy" },
                    { new Guid("9fa449ba-da72-4e9a-80dd-dfd4c022e58c"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Faq8ir_1730428301407_vendor-3.png?alt=media&token=295216c1-4ea0-4a0c-8a61-3c66200f41bb", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hao@example.com", "Nguyen Nhat", true, false, false, "Hao", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$KcwDWaYdePFeLgKTwoJd7OQl6YCi9ZvCzdPDdt7lROYp2paxwpyGC", "", 3, "hao" },
                    { new Guid("a429c4b0-2e25-4cf7-a73b-9d53a3555ee0"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Ffc2hi5_1730428324559_vendor-9.png?alt=media&token=fa4632f1-2584-4496-9927-d0a645413638", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "thinh@example.com", "Gia", true, false, false, "Thinh", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$kzs6W6lPdNmhq9mAxWfov.FJAHD2YDQJgQ/oiDeeMo78LKzDExz2O", "", 3, "thinh" },
                    { new Guid("c58d1f09-d735-4306-b9f9-1a9b9fddc482"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2F17mshd_1730428341488_vendor-13.png?alt=media&token=33092b37-f077-4863-9329-63fa6e5964f7", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jobseeker@example.com", "Job", true, false, false, "Seeker", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$L90P0yqjOYUyP8iuS5YkCe669W9DQnIRqqkzGVw24cJwVTVBhmc3i", "", 3, "jobseeker" },
                    { new Guid("f995d00b-06f5-44b8-bf63-27ed5f7ea172"), "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fkxakd5_1730428320184_vendor-7.png?alt=media&token=9a4cabc8-8372-45d8-9d3e-364766154550", "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoang@example.com", "Ngo Gia", true, false, false, "Hoang", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$aYH6ji8QMczfCJxRGoBUqeTA7Ttk1JnanbTXBiafDDrrOQcy6hK7O", "", 3, "hoang" }
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "CreatedAt", "ExpiredAt", "IndustryId", "JobDescription", "JobLocation", "JobTypeId", "ModifiedAt", "SalaryRange", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("098760d8-6212-46d3-98fe-b6092864d821"), new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7566), 2, "Tổng quan vị trí:\n- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing số.\n- Theo dõi và phân tích dữ liệu trên các kênh truyền thông.\n- Cập nhật thông tin về sản phẩm và dịch vụ.\n\nYêu cầu ứng viên:\n- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành marketing.\n- Kỹ năng phân tích và giao tiếp tốt.\n- Chịu khó và nhiệt tình.", "Tòa nhà K, Đường Trần Phú, Phường Trần Phú, Quy Nhơn, Bình Định", 3, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7566), "400 - 600", 0, "Thực Tập Sinh Digital Marketing", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("18edd806-66bc-47a7-bd24-7e4924097930"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7516), 4, "Tổng quan vị trí:\n- Tìm kiếm và phát triển khách hàng mới cho tạp hóa.\n- Đạt được mục tiêu doanh số hàng tháng của cửa hàng.\n- Hỗ trợ khách hàng trong quá trình mua sắm tại tạp hóa.\n\nYêu cầu ứng viên:\n- Có kinh nghiệm trong lĩnh vực bán hàng hoặc tạp hóa.\n- Kỹ năng giao tiếp tốt và thân thiện với khách hàng.\n- Có khả năng làm việc theo nhóm và độc lập.", "Tạp Hóa Anh Ba, Đường Lê Lợi, Phường Trần Phú, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7515), "100 - 150", 0, "Nhân Viên Bán Hàng Tạp Hóa Anh Ba", new Guid("67bd4c46-d2c1-4e66-956d-4750fe83ef78") },
                    { new Guid("287457cc-8ea2-4587-87ff-a3ce9ec20521"), new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7537), 2, "Tổng quan vị trí:\n- Hỗ trợ khách hàng qua điện thoại và email.\n- Giải quyết các vấn đề của khách hàng.\n- Cung cấp thông tin về sản phẩm và dịch vụ.\n\nYêu cầu ứng viên:\n- Kỹ năng giao tiếp và lắng nghe tốt.\n- Có khả năng làm việc dưới áp lực.\n- Chịu khó và cầu tiến.", "Tòa nhà D, Đường Phạm Ngũ Lão, Phường Trần Phú, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7537), "500 - 800", 0, "Nhân Viên Hỗ Trợ Khách Hàng Part-time", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("33e43b4b-f098-4742-bdf7-037850073908"), new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7591), 2, "Tổng quan vị trí:\n- Lập kế hoạch và giám sát tiến độ dự án.\n- Quản lý nguồn lực và ngân sách dự án.\n- Đảm bảo các mục tiêu dự án được thực hiện đúng hạn.\n\nYêu cầu ứng viên:\n- Tối thiểu 5 năm kinh nghiệm trong quản lý dự án.\n- Kỹ năng lãnh đạo và quản lý tốt.\n- Tốt nghiệp chuyên ngành quản trị kinh doanh hoặc tương đương.", "Tòa nhà Q, Đường Nguyễn Công Trứ, Phường Lê Lợi, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7590), "4000 - 5000", 0, "Giám Đốc Dự Án", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("3c92f177-812c-4fb9-9018-8d57911a5fdf"), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7559), 2, "Tổng quan vị trí:\n- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing.\n- Phân tích và báo cáo kết quả chiến dịch.\n- Tham gia vào các hoạt động quảng bá sản phẩm.\n\nYêu cầu ứng viên:\n- Có kiến thức về marketing.\n- Kỹ năng phân tích và giao tiếp tốt.\n- Chịu khó và ham học hỏi.", "Tòa nhà I, Đường Nguyễn Thái Học, Phường Lê Lợi, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7558), "600 - 900", 0, "Nhân Viên Hỗ Trợ Marketing Part-time", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("404e50cc-ad5d-4a1b-aed3-c01020568729"), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7549), 2, "Tổng quan vị trí:\n- Tư vấn sản phẩm cho khách hàng.\n- Hỗ trợ giải quyết thắc mắc của khách hàng.\n- Cập nhật thông tin về sản phẩm mới.\n\nYêu cầu ứng viên:\n- Kỹ năng giao tiếp tốt.\n- Có khả năng làm việc nhóm.\n- Chịu khó và nhiệt tình.", "Tòa nhà G, Đường Đống Đa, Phường Bình Định, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7548), "600 - 900", 0, "Nhân Viên Tư Vấn Khách Hàng Part-time", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("4cd318c6-794f-4881-bc8a-26da4e0950e9"), new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7541), 2, "Tổng quan vị trí:\n- Tìm kiếm khách hàng và giới thiệu sản phẩm.\n- Đạt được chỉ tiêu doanh số tháng.\n- Duy trì mối quan hệ với khách hàng hiện tại.\n\nYêu cầu ứng viên:\n- Có kinh nghiệm trong lĩnh vực kinh doanh.\n- Kỹ năng giao tiếp tốt.\n- Có khả năng làm việc độc lập và theo nhóm.", "Tòa nhà E, Đường Nguyễn Công Trứ, Phường Lê Lợi, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7541), "600 - 900", 0, "Nhân Viên Kinh Doanh Part-time", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("64ca3f34-e832-4365-93f1-119ec61883ce"), new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7587), 1, "Tổng quan vị trí:\n- Phát triển và duy trì các ứng dụng phần mềm.\n- Làm việc với các nhóm để phát triển sản phẩm.\n- Thực hiện kiểm thử và sửa lỗi phần mềm.\n\nYêu cầu ứng viên:\n- Có ít nhất 2 năm kinh nghiệm lập trình.\n- Thành thạo một hoặc nhiều ngôn ngữ lập trình.\n- Kỹ năng làm việc nhóm và giải quyết vấn đề tốt.", "Tòa nhà P, Đường Nguyễn Thái Học, Phường Lê Lợi, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7586), "3000 - 4000", 0, "Kỹ Sư Phần Mềm", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("6867ac7d-2070-4d33-8e69-cf2d6d139e82"), new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7581), 2, "Tổng quan vị trí:\n- Phát triển và duy trì mối quan hệ với khách hàng.\n- Đạt được mục tiêu doanh số hàng tháng.\n- Phân tích nhu cầu của khách hàng để đề xuất các giải pháp phù hợp.\n\nYêu cầu ứng viên:\n- Kinh nghiệm trong lĩnh vực kinh doanh.\n- Kỹ năng giao tiếp và thuyết phục tốt.\n- Tốt nghiệp chuyên ngành kinh tế hoặc tương đương.", "Tòa nhà O, Đường Đống Đa, Phường Bình Định, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7581), "2500 - 3500", 0, "Chuyên Viên Kinh Doanh", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("695661ec-8d0f-4ecc-8516-3bafc5fc6f27"), new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7578), 1, "Tổng quan vị trí:\n- Phân tích dữ liệu để đưa ra quyết định chiến lược.\n- Tạo báo cáo và trình bày kết quả phân tích.\n- Hỗ trợ các bộ phận khác trong việc sử dụng dữ liệu.\n\nYêu cầu ứng viên:\n- Kinh nghiệm trong phân tích dữ liệu.\n- Kỹ năng sử dụng các công cụ phân tích và báo cáo.\n- Tốt nghiệp chuyên ngành thống kê, kinh tế hoặc tương đương.", "Tòa nhà N, Đường Trần Hưng Đạo, Phường Hải Cảng, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7577), "2000 - 3000", 0, "Chuyên Viên Phân Tích Dữ Liệu", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("6db2fe09-99a8-455a-a5ea-8787f75866b8"), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7598), 2, "Tổng quan vị trí:\n- Hỗ trợ tổ chức và quản lý các sự kiện.\n- Liên lạc với các nhà cung cấp và khách hàng.\n- Đảm bảo mọi thứ diễn ra suôn sẻ trong sự kiện.\n\nYêu cầu ứng viên:\n- Kỹ năng tổ chức và giao tiếp tốt.\n- Có khả năng làm việc dưới áp lực cao.\n- Nhiệt tình và sáng tạo.", "Tòa nhà S, Đường Nguyễn Thái Học, Phường Lê Lợi, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7598), "500 - 800", 0, "Nhân Viên Tổ Chức Sự Kiện Part-time", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("7d443daa-5dc2-4787-bbf7-b14742015e0b"), new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7602), 2, "Tổng quan vị trí:\n- Nghiên cứu và phân tích thị trường để phát triển chiến lược.\n- Phát triển mối quan hệ với khách hàng và đối tác.\n- Tạo báo cáo và đề xuất các giải pháp kinh doanh.\n\nYêu cầu ứng viên:\n- Tối thiểu 2 năm kinh nghiệm trong phát triển thị trường.\n- Kỹ năng phân tích và giao tiếp tốt.\n- Tốt nghiệp chuyên ngành kinh tế, marketing hoặc tương đương.", "Tòa nhà T, Đường Trần Hưng Đạo, Phường Hải Cảng, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7602), "3.000 - 7.000", 0, "Chuyên Viên Phát Triển Thị Trường", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("99750a50-0b0d-4fd3-9626-d533848e9295"), new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7574), 2, "Tổng quan vị trí:\n- Lập kế hoạch và thực hiện các chiến dịch marketing.\n- Quản lý ngân sách marketing và báo cáo kết quả.\n- Phân tích xu hướng thị trường và nhu cầu khách hàng.\n\nYêu cầu ứng viên:\n- Tối thiểu 3 năm kinh nghiệm trong lĩnh vực marketing.\n- Kỹ năng lãnh đạo và giao tiếp tốt.\n- Tốt nghiệp chuyên ngành marketing hoặc tương đương.", "Tòa nhà M, Đường Phạm Ngũ Lão, Phường Trần Phú, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7573), "2500 - 3500", 0, "Quản Lý Marketing", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("aa401aef-c9eb-4e43-9fba-c6c9fecb7ff0"), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7529), 1, "Tổng quan vị trí:\n- Hỗ trợ kỹ thuật cho các sản phẩm công nghệ.\n- Giải quyết các sự cố kỹ thuật của khách hàng.\n- Tham gia vào các dự án nhỏ theo yêu cầu.\n\nYêu cầu ứng viên:\n- Có kiến thức về công nghệ thông tin.\n- Kỹ năng giải quyết vấn đề tốt.\n- Có khả năng làm việc độc lập.", "Tòa nhà B, Đường Trần Hưng Đạo, Phường Hải Cảng, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7528), "700 - 1000", 0, "Nhân Viên Kỹ Thuật Part-time", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("c4fa3bf7-1e7e-489c-9f8d-acd2f44329d5"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7545), 2, "Tổng quan vị trí:\n- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing.\n- Phân tích dữ liệu và báo cáo kết quả.\n- Tham gia các hoạt động quảng bá sản phẩm.\n\nYêu cầu ứng viên:\n- Có kiến thức về marketing.\n- Kỹ năng phân tích và giao tiếp tốt.\n- Chịu khó và ham học hỏi.", "Tòa nhà F, Đường Lý Thường Kiệt, Phường Xuân Diệu, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7545), "500 - 800", 0, "Nhân Viên Marketing Part-time", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("ca7c80eb-636c-40be-b39f-710ea2ea1127"), new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7570), 1, "Tổng quan vị trí:\n- Hỗ trợ kỹ thuật trong các dự án IT.\n- Học hỏi và phát triển kỹ năng chuyên môn.\n- Tham gia vào các công việc hàng ngày của nhóm kỹ thuật.\n\nYêu cầu ứng viên:\n- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành IT.\n- Có kiến thức cơ bản về lập trình.\n- Nhiệt tình và ham học hỏi.", "Tòa nhà L, Đường Lý Thường Kiệt, Phường Xuân Diệu, Quy Nhơn, Bình Định", 3, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7569), "400 - 600", 0, "Thực Tập Sinh Kỹ Thuật IT", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("e3b33627-a210-440e-a3b0-9d55689094a2"), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7533), 2, "Tổng quan vị trí:\n- Hỗ trợ lập kế hoạch và thực hiện các chiến dịch marketing.\n- Nghiên cứu thị trường và phân tích dữ liệu khách hàng.\n- Theo dõi và báo cáo kết quả chiến dịch.\n\nYêu cầu ứng viên:\n- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành marketing.\n- Kỹ năng giao tiếp tốt.\n- Có khả năng làm việc nhóm.", "Tòa nhà C, Đường Nguyễn Huệ, Phường Lê Lợi, Quy Nhơn, Bình Định", 3, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7533), "400 - 600", 0, "Thực Tập Sinh Marketing", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("ea01a830-4be5-4e98-95e8-5dcd8833a173"), new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7562), 2, "Tổng quan vị trí:\n- Hỗ trợ thực hiện các kế hoạch kinh doanh.\n- Nghiên cứu thị trường và phân tích dữ liệu khách hàng.\n- Theo dõi và báo cáo kết quả.\n\nYêu cầu ứng viên:\n- Sinh viên năm cuối hoặc mới tốt nghiệp chuyên ngành kinh doanh.\n- Kỹ năng giao tiếp tốt.\n- Có khả năng làm việc nhóm.", "Tòa nhà J, Đường Nguyễn Công Trứ, Phường Lê Lợi, Quy Nhơn, Bình Định", 3, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7562), "400 - 600", 0, "Thực Tập Sinh Kinh Doanh", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("fd170648-2c79-45a1-8062-310d4254b2c9"), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7555), 1, "Tổng quan vị trí:\n- Hỗ trợ kỹ thuật cho các sản phẩm công nghệ.\n- Giải quyết các sự cố kỹ thuật.\n- Tham gia vào các dự án nhỏ theo yêu cầu.\n\nYêu cầu ứng viên:\n- Có kiến thức về kỹ thuật.\n- Kỹ năng giải quyết vấn đề tốt.\n- Có khả năng làm việc độc lập.", "Tòa nhà H, Đường Phạm Văn Đồng, Phường Trần Phú, Quy Nhơn, Bình Định", 2, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7554), "700 - 1000", 0, "Nhân Viên Kỹ Thuật Part-time", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") },
                    { new Guid("ff151222-a992-4e7b-9c22-ca998380039a"), new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7594), 2, "Tổng quan vị trí:\n- Tư vấn và quản lý các dịch vụ tài chính cho khách hàng.\n- Phân tích và đánh giá tình hình tài chính của khách hàng.\n- Xây dựng các kế hoạch tài chính phù hợp.\n\nYêu cầu ứng viên:\n- Kinh nghiệm trong lĩnh vực tài chính hoặc ngân hàng.\n- Kỹ năng giao tiếp và thuyết phục tốt.\n- Tốt nghiệp chuyên ngành tài chính hoặc tương đương.", "Tòa nhà R, Đường Trần Nhân Tông, Phường Trần Phú, Quy Nhơn, Bình Định", 1, new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7594), "3500 - 4500", 0, "Chuyên Viên Tư Vấn Tài Chính", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAt", "Headline", "ModifiedAt", "Summary", "UserId", "Website" },
                values: new object[,]
                {
                    { new Guid("1adcadfa-a580-4462-be0d-47e9b4799f5d"), new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7349), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("4272b117-2994-4483-b816-2b8440b71dbb"), null },
                    { new Guid("4ca1adc2-cd2e-4506-a58d-06aca4261f8b"), new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7346), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("f995d00b-06f5-44b8-bf63-27ed5f7ea172"), null },
                    { new Guid("56f90d1b-161b-4389-b181-6f189b484184"), new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7333), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("c58d1f09-d735-4306-b9f9-1a9b9fddc482"), null },
                    { new Guid("63358ff0-4f6b-4003-924a-fb19054a6b63"), new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7334), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("3f99986a-953e-43cc-98c5-a842cd0808a1"), null },
                    { new Guid("6d02d55d-f67a-483f-9708-1ee1a396e3f9"), new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7344), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("5c71e821-86d6-4b02-9a7b-98e68a61d3b7"), null },
                    { new Guid("7a844f32-1575-4b1d-801d-3037ac7a2536"), new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7341), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("5a917248-65fb-44ea-ac6b-ff0c10b84137"), null },
                    { new Guid("a9910264-5041-4dc4-9781-4f0682573207"), new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7338), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("67bd4c46-d2c1-4e66-956d-4750fe83ef78"), null },
                    { new Guid("aa4ea6ae-d617-4ae1-a91d-8385d901b704"), new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7326), "Admin Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("30d0ec3d-6da4-43d4-b9e2-c259fc9a4e11"), null },
                    { new Guid("b31ff108-4af6-4e9e-bf30-77ce0e6be1b9"), new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7348), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("a429c4b0-2e25-4cf7-a73b-9d53a3555ee0"), null },
                    { new Guid("b4539aa4-5bb1-4c73-8319-3f64a8c8dde7"), new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7331), "Recruiter Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("1a3bcd57-566a-4176-8b67-346ac1f4e8fb"), null },
                    { new Guid("c5f2ba50-ae50-4e77-b9f5-c2455061c193"), new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7342), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("9fa449ba-da72-4e9a-80dd-dfd4c022e58c"), null },
                    { new Guid("fd4ea0f7-eac1-4582-9aa9-f5102e164796"), new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7340), "Job Seeker Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("543d3c1e-b344-4391-8f97-3c14e9e0f67d"), null }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ApplicationDate", "CvFile", "Description", "JobPostId", "Status", "UserId" },
                values: new object[] { new Guid("1824422b-ef6e-4fd0-8947-8f1b6f51302a"), new DateTime(2024, 11, 1, 2, 59, 20, 768, DateTimeKind.Utc).AddTicks(7642), "path/to/cv.pdf", "", new Guid("18edd806-66bc-47a7-bd24-7e4924097930"), 2, new Guid("c58d1f09-d735-4306-b9f9-1a9b9fddc482") });
        }
    }
}
