using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "046556a4-2056-46e9-8267-6ba95a344d07");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "1aaed043-b89c-48f6-a329-fc64d5a58a30");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "20411d87-919a-49aa-b336-f5ab0af25e58");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "23483908-8c5b-4c34-8817-8dcec88f0b8c");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "3fb9459b-041e-40af-9133-7a4a18236111");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "49176ed4-24fa-4c1a-a935-77cb92d2c969");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "77c8428a-130b-4c38-831b-67caf3eb4275");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "90c4dea4-c6d3-4295-bb83-e3356634f16f");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "95774e6a-6384-46c3-9067-2b923c03b665");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "9b8bbdd1-c547-4972-88ad-308af7079364");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "ea7cb44b-2636-40d3-b119-6dbfafa73208");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "48675681-8bc4-4b84-bc85-efcd2b9f2dcc");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "530761a3-e09c-4848-8645-c75f1f29c138");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "57cae140-dbd7-4ccd-9359-71536efc48bc");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "86db2b62-ff0c-467e-b004-3e8bacbb8c25");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "8c1dde13-f792-4510-a392-fc285d423812");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "cfcac613-1f68-4c77-b79e-157d0facaf4c");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "d16e6ba0-eada-4967-bc91-b017056403f6");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "e3dc5153-80bd-4803-bd78-fcc264651571");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "e72194b3-84c3-46ac-ae95-72e8c20dca49");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "f6a574ad-3293-4c20-bbe5-a1a78a9e7c72");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "26d39cef-e400-46c5-ad54-21ddb00b1190");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "3071bf66-7260-483d-9da4-9411ca60a3b0");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "451f017f-baa8-4ea7-8600-b48f67484ff5");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "5f29b7ec-fbdf-4c38-861c-e667072bdde6");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "808d7ae2-caa2-4c85-b972-604b13ff1dd3");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "9c55df9d-7970-4cb3-82a7-2fcf57513a58");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "a1c51637-6e05-456d-8d6b-e41b30b14c60");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "d4d5787e-4b0c-470b-b183-7df9b01d8a36");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "e13f46f7-2a4a-4ffa-b231-d5985ce57f9a");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "eba0e1d4-1089-4e44-8a87-5f218d204a0c");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "0f107cf8-dc5d-46c4-97f0-73d3a7302bb4");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "1810aa70-14ba-42da-90f5-7f43b2d9947a");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "3cd5fd76-f683-4b49-9cdd-0605943d22bd");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "58fc9566-38b2-44b1-a60d-5f24acccf703");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "65ff77c5-0a62-4cb4-bce8-9ce3d13d4fad");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "786fb2ad-5844-4b90-a99b-708c10e55873");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "a238ed24-3cd0-461f-bcfe-177e796252a7");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "a2e6a753-d66a-4568-902c-23307d6cd51a");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "acf5736e-0ddf-4c11-9169-9f0932724616");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "b3c38e83-bdc0-47c2-8533-ded6235425e8");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "5ca7d714-24f4-4698-ba52-b5132a760cef");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "8db52f37-96f1-4908-b1b6-c7b4937a6d8d");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "99393b2c-a126-44ba-a7ef-5d921ee884ef");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "e13d6d0c-353e-4f6f-b1e0-c3c4d3e338c3");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "ecee18ba-3fa3-4d8c-a24a-5f6c735b885b");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "1f8c3e6b-c49e-40cd-a69f-10793b060cf3");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "259f6f72-4d29-487d-8a3e-a2279a9975c0");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "25c29aec-7013-432d-903f-790b8ed97d13");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "8475c56a-d1e9-424d-a909-1e51d3a282c6");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "92d9a092-15d4-48b6-8e3f-06b18a355ccd");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "a0218c44-60d2-449d-9e4a-f92b489817b6");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "a70d9a91-b387-43c6-aec5-be4de13be9af");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "ac4299f7-6179-4dc0-a271-73dadf7e8d66");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "eba910db-c9a6-4fa2-93a7-05ccd932acc9");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "ee6d5c0e-10c2-4f4e-b332-a2aa28de8975");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "1816106d-7375-41cc-a77d-0628d2ef49a7");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "cc7d2873-0c41-4124-b167-a0fef61cb8ff");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "04ab429d-9d82-4cde-b5a1-94866859983d");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "15bccc8d-c76e-41eb-9b9d-48520cdaffc4");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "250bb82b-a591-440b-a270-46526cfafd83");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "39f8becd-24a9-41d8-acc3-110aa0fc6d05");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "706e7941-c8be-4f4f-a907-d49bd3ab83ec");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "8fd5cfba-35d5-40a9-a918-fb4e1ea6925d");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "95817303-490f-4b39-9c2d-dad1ec0b3633");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "f165ed0a-5c1c-4180-86a9-691a70a4fd55");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "f948da33-7dc6-40ae-a333-7b1b3c163148");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "fb6d5c46-cb65-4b16-a60a-25192914a7fe");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "66f5cd34-16a8-4d50-b31e-c2cee40ce414");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "7cc99ab6-2252-4732-b0ae-6f4abba7731c");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "a852ead9-5378-4413-aa13-d572434b8be8");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "ef5e0c44-4338-4bc1-af04-44453c337cb7");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "f65bd2a6-4371-4c5e-9be1-3f6c05fd2a11");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "3f5f456e-2f32-4d28-b12e-939cd4fa6aed");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "6c362a4f-e2cb-48a6-a66b-19ed2732db20");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "0d9448e8-e616-4285-a5b6-a7c627bf72bd");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "17bdfb8e-8bd4-4787-9af5-c636d9035336");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "425681f6-f4d4-4145-bc5b-b1523507df8c");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "7c530ed7-3fee-4d23-a7ac-0a3677062bcf");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "924b13be-8d4f-4b49-91c4-47b455842cad");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "99ccd897-2e23-4fce-b3d1-deb7ab636c91");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "c4019ce7-6ddd-4084-baca-5eabef490f0c");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "c675993b-8c2f-4534-9b95-bae101d94087");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "053fce29-5189-4393-85fa-4c46474e3202");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "265dbb7a-7b9e-499e-9f91-4304d2ac006d");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "967f6bb6-eb8c-4a82-b09d-6d606db944de");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "bb35ad9b-c5c9-4a9f-ad67-de66490fcd9a");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "19c541ac-27a2-4783-b8f8-2a420d4ed354");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "45195577-522b-4386-8068-c98a239a0db5");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "6b4754f1-dd78-4168-97e8-72c6d71a00cf");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "cf8d31e1-1c84-4946-a302-4d6f90bb02ef");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "ec724b56-f893-4bbe-8303-7f84b1b478db");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "9400cd48-2be5-41e9-9485-24ec840deecc");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "c90393a5-f30e-4187-a4bd-f01f23bdaaef");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "03e5681e-9002-4d23-94d5-97a376b0fcfc");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "7548857a-291f-4cc6-ad98-94a4855af5ba");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "89ffd27d-7486-4a92-8e87-637baed61c82");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "a2451456-30d8-4cb9-bbe3-c15aa33bd12c");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "a9ff8381-352b-4ba8-895a-0c5506e4fb1a");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "0f07eb8a-e33b-48af-9dd8-c276e1c8e881");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "05eb9387-efb8-4762-bf28-064b00887470");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "402967b6-7913-45fb-888d-1baaf5526351");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "66d79b7f-cce4-430f-8d0a-2aa8bc5dcef7");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "883e9e37-0e76-465d-a028-a06f1b204c00");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "bbb5f529-f012-4a44-97f4-eb853e5c0030");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "238c6a9f-b560-482b-a22c-ed92d0553d43");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "9e948313-1dc8-4571-a46f-cf53af1c67b0");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "bfbec7b0-f090-4402-91ba-9fda40532116");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "59fe4472-a103-475f-b9eb-aaa3c9a646fe");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "854b084a-1f99-438b-930d-aa8c33cbdb2b");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "a34dada6-3406-4190-9717-9f71e1dc02d9");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "de27542e-6db7-4cbf-82a6-bfcb0d0c7474");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "f4d8cdb0-846e-499d-a6df-acb077cdcb64");

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "id", "author_name", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { "1", "Stephen King", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "10", "Nguyễn Phong Sắc", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "2", "J.K. Rowling", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "3", "George R.R. Martin", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "4", "Agatha Christie", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "5", "Haruki Murakami", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "6", "Nguyễn Nhật Ánh", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "7", "Tô Hoài", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "8", "Dương Thụy", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "9", "Trang Hạ", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "category_name", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { "1", "Fiction", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "10", "Art", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "11", "Travel", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "2", "Science", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "3", "History", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "4", "Fantasy", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "5", "Biography", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "6", "Mystery", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "7", "Romance", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "9", "Technology", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "events",
                columns: new[] { "id", "CreatedAt", "DeletedAt", "description", "event_date", "event_name", "UpdatedAt" },
                values: new object[,]
                {
                    { "1", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Grand opening ceremony of the new library.", new DateOnly(2023, 1, 15), "Library Grand Opening", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "10", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Collecting books for donation during winter.", new DateOnly(2023, 12, 1), "Winter Book Drive", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "2", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Annual book fair with discounted books.", new DateOnly(2023, 3, 10), "Book Fair 2023", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "3", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Meet and greet session with author Stephen King.", new DateOnly(2023, 5, 20), "Author Meet & Greet: Stephen King", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "4", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Reading challenge for students during summer.", new DateOnly(2023, 6, 1), "Summer Reading Challenge", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "5", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Weekly story time for young children.", new DateOnly(2023, 7, 5), "Children's Story Time", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "6", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Workshop on improving digital literacy skills.", new DateOnly(2023, 8, 12), "Digital Literacy Workshop", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "7", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Open mic night for poetry enthusiasts.", new DateOnly(2023, 9, 15), "Poetry Slam Night", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "8", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Discussion on the history of the local area.", new DateOnly(2023, 10, 26), "Local History Talk", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "9", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Spooky stories for Halloween.", new DateOnly(2023, 10, 31), "Halloween Story Night", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "publishers",
                columns: new[] { "id", "address", "CreatedAt", "DeletedAt", "phone_number", "publisher_name", "UpdatedAt" },
                values: new object[,]
                {
                    { "1", "New York, USA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Penguin Random House", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "10", "Ho Chi Minh City, Vietnam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Fahasa", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "11", "Ho Chi Minh City, Vietnam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "First News", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "2", "New York, USA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "HarperCollins", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "3", "New York, USA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Simon & Schuster", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "4", "Paris, France", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Hachette Livre", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "5", "London, UK", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Macmillan Publishers", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "6", "Hanoi, Vietnam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Kim Đồng Publishing House", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "7", "Hanoi, Vietnam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Nhã Nam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "9", "Hanoi, Vietnam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Alpha Books", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "CreatedAt", "DeletedAt", "role_name", "UpdatedAt" },
                values: new object[,]
                {
                    { "1", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 0, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "2", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "3", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "id", "author_id", "category_id", "CreatedAt", "DeletedAt", "description", "image_url", "publication_year", "publisher_id", "status", "title", "UpdatedAt" },
                values: new object[,]
                {
                    { "book_01_shining", "1", "1", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Horror novel by Stephen King.", "https://example.com/shining.jpg", (short)1977, "1", "Available", "The Shining", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_02_hp", "2", "4", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "First book in the Harry Potter series.", "https://example.com/hp1.jpg", (short)1997, "2", "Available", "Harry Potter and the Sorcerer's Stone", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_03_got", "3", "4", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "First book of A Song of Ice and Fire.", "https://example.com/got.jpg", (short)1996, "3", "Available", "A Game of Thrones", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_04_none", "4", "6", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Classic mystery novel.", "https://example.com/agatha.jpg", (short)1939, "4", "Available", "And Then There Were None", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_05_norwegian", "5", "1", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Coming-of-age novel by Haruki Murakami.", "https://example.com/norwegian.jpg", (short)1987, "5", "Available", "Norwegian Wood", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_06_hoavang", "6", "1", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Tiểu thuyết của Nguyễn Nhật Ánh.", "https://example.com/hoavang.jpg", (short)2010, "6", "Available", "Tôi Thấy Hoa Vàng Trên Cỏ Xanh", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_07_demen", "7", "1", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Truyện thiếu nhi kinh điển.", "https://example.com/demen.jpg", (short)1941, "7", "Available", "Dế Mèn Phiêu Lưu Ký", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_08_hoacuc", "8", "7", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Tập truyện ngắn lãng mạn.", "https://example.com/hoacuc.jpg", (short)2008, "9", "Available", "Đi Qua Hoa Cúc", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_09_tinhyv", "9", "7", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Tản văn về tình yêu.", "https://example.com/tinhyv.jpg", (short)2007, "10", "Available", "Cho Một Tình Yêu", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_10_tatden", "10", "3", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Tiểu thuyết hiện thực phê phán.", "https://example.com/tatden.jpg", (short)1937, "11", "Available", "Tắt Đèn", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "address", "CreatedAt", "date_of_birth", "DeletedAt", "email", "gender", "image_url", "password_hash", "phone_number", "role_id", "StudentCode", "UpdatedAt", "username" },
                values: new object[,]
                {
                    { "1", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "admin@example.com", null, null, "hashed_password_admin", null, "1", "admin", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "adminuser" },
                    { "10", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "bob.white@example.com", null, null, "hashed_password_bw", null, "3", "ST008", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "bob.white" },
                    { "2", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "lib@example.com", null, null, "hashed_password_lib", null, "2", "librarian", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "librarianuser" },
                    { "3", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "stu1@example.com", null, null, "hashed_password_stu1", null, "3", "ST001", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "student1" },
                    { "4", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "stu2@example.com", null, null, "hashed_password_stu2", null, "3", "ST002", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "student2" },
                    { "5", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "stu3@example.com", null, null, "hashed_password_stu3", null, "3", "ST003", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "student3" },
                    { "6", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "john.doe@example.com", null, null, "hashed_password_jd", null, "3", "ST004", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "john.doe" },
                    { "7", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "jane.smith@example.com", null, null, "hashed_password_js", null, "3", "ST005", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "jane.smith" },
                    { "8", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "peter.jones@example.com", null, null, "hashed_password_pj", null, "3", "ST006", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "peter.jones" },
                    { "9", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "alice.brown@example.com", null, null, "hashed_password_ab", null, "3", "ST007", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "alice.brown" }
                });

            migrationBuilder.InsertData(
                table: "book_copies",
                columns: new[] { "id", "book_id", "copy_code", "CreatedAt", "DeletedAt", "status", "UpdatedAt" },
                values: new object[,]
                {
                    { "book_copy_1", "book_01_shining", "CP-01-01", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_10", "book_05_norwegian", "CP-05-10", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_11", "book_06_hoavang", "CP-06-11", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_12", "book_06_hoavang", "CP-06-12", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_13", "book_07_demen", "CP-07-13", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_14", "book_07_demen", "CP-07-14", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_15", "book_08_hoacuc", "CP-08-15", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_16", "book_08_hoacuc", "CP-08-16", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_17", "book_09_tinhyv", "CP-09-17", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_18", "book_09_tinhyv", "CP-09-18", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_19", "book_10_tatden", "CP-10-19", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_2", "book_01_shining", "CP-01-02", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_20", "book_10_tatden", "CP-10-20", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_3", "book_02_hp", "CP-02-03", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_4", "book_02_hp", "CP-02-04", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_5", "book_03_got", "CP-03-05", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_6", "book_03_got", "CP-03-06", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_7", "book_04_none", "CP-04-07", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_8", "book_04_none", "CP-04-08", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "book_copy_9", "book_05_norwegian", "CP-05-09", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "book_favorites",
                columns: new[] { "id", "added_at", "book_id", "CreatedAt", "DeletedAt", "UpdatedAt", "user_id" },
                values: new object[,]
                {
                    { "1", new DateTime(2023, 12, 2, 10, 0, 0, 0, DateTimeKind.Utc), "book_01_shining", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "3" },
                    { "10", new DateTime(2023, 12, 27, 10, 0, 0, 0, DateTimeKind.Utc), "book_10_tatden", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "4" },
                    { "2", new DateTime(2023, 12, 7, 10, 0, 0, 0, DateTimeKind.Utc), "book_02_hp", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "4" },
                    { "3", new DateTime(2023, 12, 12, 10, 0, 0, 0, DateTimeKind.Utc), "book_03_got", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "5" },
                    { "4", new DateTime(2023, 12, 14, 10, 0, 0, 0, DateTimeKind.Utc), "book_04_none", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "6" },
                    { "5", new DateTime(2023, 12, 17, 10, 0, 0, 0, DateTimeKind.Utc), "book_05_norwegian", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "7" },
                    { "6", new DateTime(2023, 12, 20, 10, 0, 0, 0, DateTimeKind.Utc), "book_06_hoavang", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "8" },
                    { "7", new DateTime(2023, 12, 22, 10, 0, 0, 0, DateTimeKind.Utc), "book_07_demen", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "9" },
                    { "8", new DateTime(2023, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), "book_08_hoacuc", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "10" },
                    { "9", new DateTime(2023, 12, 25, 10, 0, 0, 0, DateTimeKind.Utc), "book_09_tinhyv", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "3" }
                });

            migrationBuilder.InsertData(
                table: "book_reviews",
                columns: new[] { "id", "book_id", "CreatedAt", "DeletedAt", "rating", "review_date", "review_text", "UpdatedAt", "user_id" },
                values: new object[,]
                {
                    { "1", "book_01_shining", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 5, new DateTime(2023, 12, 4, 10, 0, 0, 0, DateTimeKind.Utc), "Amazing horror story, a classic!", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "3" },
                    { "10", "book_10_tatden", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 5, new DateTime(2023, 12, 30, 10, 0, 0, 0, DateTimeKind.Utc), "Phản ánh xã hội sâu sắc.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "4" },
                    { "2", "book_02_hp", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 5, new DateTime(2023, 12, 10, 10, 0, 0, 0, DateTimeKind.Utc), "A magical start to a fantastic series!", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "4" },
                    { "3", "book_03_got", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 4, new DateTime(2023, 12, 13, 10, 0, 0, 0, DateTimeKind.Utc), "Complex characters and intriguing plot.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "5" },
                    { "4", "book_04_none", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 5, new DateTime(2023, 12, 16, 10, 0, 0, 0, DateTimeKind.Utc), "A masterpiece of mystery, highly recommend.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "6" },
                    { "5", "book_05_norwegian", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 4, new DateTime(2023, 12, 19, 10, 0, 0, 0, DateTimeKind.Utc), "Murakami never disappoints, a unique read.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "7" },
                    { "6", "book_06_hoavang", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 5, new DateTime(2023, 12, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Cuốn sách rất ý nghĩa và đầy cảm xúc.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "8" },
                    { "7", "book_07_demen", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 5, new DateTime(2023, 12, 23, 10, 0, 0, 0, DateTimeKind.Utc), "Kỷ niệm tuổi thơ với Dế Mèn.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "9" },
                    { "8", "book_08_hoacuc", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 4, new DateTime(2023, 12, 26, 10, 0, 0, 0, DateTimeKind.Utc), "Truyện ngắn lãng mạn nhẹ nhàng.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "10" },
                    { "9", "book_09_tinhyv", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 4, new DateTime(2023, 12, 28, 10, 0, 0, 0, DateTimeKind.Utc), "Đọc để thấy tình yêu thật đẹp.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "3" }
                });

            migrationBuilder.InsertData(
                table: "book_reservations",
                columns: new[] { "id", "copy_id", "CreatedAt", "DeletedAt", "reservation_date", "status", "UpdatedAt", "user_id" },
                values: new object[,]
                {
                    { "1", "book_copy_1", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 1), "Pending", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "3" },
                    { "10", "book_copy_10", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 10), "Fulfilled", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "4" },
                    { "2", "book_copy_2", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 2), "Pending", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "4" },
                    { "3", "book_copy_3", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 3), "Pending", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "5" },
                    { "4", "book_copy_4", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 4), "Fulfilled", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "6" },
                    { "5", "book_copy_5", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 5), "Pending", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "7" },
                    { "6", "book_copy_6", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 6), "Fulfilled", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "8" },
                    { "7", "book_copy_7", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 7), "Pending", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "9" },
                    { "8", "book_copy_8", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 8), "Fulfilled", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "10" },
                    { "9", "book_copy_9", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 9), "Pending", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "3" }
                });

            migrationBuilder.InsertData(
                table: "borrow_records",
                columns: new[] { "id", "borrow_date", "copy_id", "CreatedAt", "DeletedAt", "due_date", "ExtensionDateCount", "fine", "return_date", "status", "UpdatedAt", "user_id" },
                values: new object[,]
                {
                    { "1", new DateTime(2023, 12, 22, 10, 0, 0, 0, DateTimeKind.Utc), "book_copy_4", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2023, 12, 29, 10, 0, 0, 0, DateTimeKind.Utc), 0, 5.00m, new DateTime(2023, 12, 27, 10, 0, 0, 0, DateTimeKind.Utc), "Returned", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "6" },
                    { "10", new DateTime(2023, 12, 26, 10, 0, 0, 0, DateTimeKind.Utc), "book_copy_10", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "4" },
                    { "2", new DateTime(2023, 12, 17, 10, 0, 0, 0, DateTimeKind.Utc), "book_copy_6", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2023, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, new DateTime(2023, 12, 22, 10, 0, 0, 0, DateTimeKind.Utc), "Returned", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "8" },
                    { "3", new DateTime(2023, 12, 12, 10, 0, 0, 0, DateTimeKind.Utc), "book_copy_8", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2023, 12, 19, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, new DateTime(2023, 12, 17, 10, 0, 0, 0, DateTimeKind.Utc), "Returned", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "10" },
                    { "4", new DateTime(2023, 12, 27, 10, 0, 0, 0, DateTimeKind.Utc), "book_copy_1", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "3" },
                    { "5", new DateTime(2023, 12, 25, 10, 0, 0, 0, DateTimeKind.Utc), "book_copy_2", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "4" },
                    { "6", new DateTime(2023, 12, 30, 10, 0, 0, 0, DateTimeKind.Utc), "book_copy_3", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 6, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "5" },
                    { "7", new DateTime(2023, 12, 31, 10, 0, 0, 0, DateTimeKind.Utc), "book_copy_5", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 7, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "7" },
                    { "8", new DateTime(2023, 12, 29, 10, 0, 0, 0, DateTimeKind.Utc), "book_copy_7", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 5, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "9" },
                    { "9", new DateTime(2023, 12, 28, 10, 0, 0, 0, DateTimeKind.Utc), "book_copy_9", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_11");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_12");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_13");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_14");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_15");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_16");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_17");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_18");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_19");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_20");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "book_favorites",
                keyColumn: "id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "book_reservations",
                keyColumn: "id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "book_reviews",
                keyColumn: "id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "borrow_records",
                keyColumn: "id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "events",
                keyColumn: "id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_1");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_10");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_2");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_3");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_4");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_5");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_6");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_7");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_8");

            migrationBuilder.DeleteData(
                table: "book_copies",
                keyColumn: "id",
                keyValue: "book_copy_9");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "book_06_hoavang");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "book_07_demen");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "book_08_hoacuc");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "book_09_tinhyv");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "book_10_tatden");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "book_01_shining");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "book_02_hp");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "book_03_got");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "book_04_none");

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: "book_05_norwegian");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: "5");

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "id", "author_name", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { "046556a4-2056-46e9-8267-6ba95a344d07", "Nguyễn Phong Sắc", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "053fce29-5189-4393-85fa-4c46474e3202", "Nguyễn Nhật Ánh", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "05eb9387-efb8-4762-bf28-064b00887470", "Haruki Murakami", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "265dbb7a-7b9e-499e-9f91-4304d2ac006d", "Dương Thụy", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "402967b6-7913-45fb-888d-1baaf5526351", "George R.R. Martin", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "66d79b7f-cce4-430f-8d0a-2aa8bc5dcef7", "Agatha Christie", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "883e9e37-0e76-465d-a028-a06f1b204c00", "Stephen King", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "967f6bb6-eb8c-4a82-b09d-6d606db944de", "Tô Hoài", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "bb35ad9b-c5c9-4a9f-ad67-de66490fcd9a", "Trang Hạ", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "bbb5f529-f012-4a44-97f4-eb853e5c0030", "J.K. Rowling", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "category_name", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { "238c6a9f-b560-482b-a22c-ed92d0553d43", "Mystery", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "5ca7d714-24f4-4698-ba52-b5132a760cef", "Art", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "8db52f37-96f1-4908-b1b6-c7b4937a6d8d", "Technology", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "9400cd48-2be5-41e9-9485-24ec840deecc", "History", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "99393b2c-a126-44ba-a7ef-5d921ee884ef", "Travel", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "9e948313-1dc8-4571-a46f-cf53af1c67b0", "Fiction", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "bfbec7b0-f090-4402-91ba-9fda40532116", "Fantasy", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "c90393a5-f30e-4187-a4bd-f01f23bdaaef", "Romance", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "e13d6d0c-353e-4f6f-b1e0-c3c4d3e338c3", "Science", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "ecee18ba-3fa3-4d8c-a24a-5f6c735b885b", "Biography", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "events",
                columns: new[] { "id", "CreatedAt", "DeletedAt", "description", "event_date", "event_name", "UpdatedAt" },
                values: new object[,]
                {
                    { "1f8c3e6b-c49e-40cd-a69f-10793b060cf3", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Meet and greet session with author Stephen King.", new DateOnly(2023, 5, 20), "Author Meet & Greet: Stephen King", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "259f6f72-4d29-487d-8a3e-a2279a9975c0", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Spooky stories for Halloween.", new DateOnly(2023, 10, 31), "Halloween Story Night", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "25c29aec-7013-432d-903f-790b8ed97d13", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Annual book fair with discounted books.", new DateOnly(2023, 3, 10), "Book Fair 2023", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "8475c56a-d1e9-424d-a909-1e51d3a282c6", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Workshop on improving digital literacy skills.", new DateOnly(2023, 8, 12), "Digital Literacy Workshop", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "92d9a092-15d4-48b6-8e3f-06b18a355ccd", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Discussion on the history of the local area.", new DateOnly(2023, 10, 26), "Local History Talk", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "a0218c44-60d2-449d-9e4a-f92b489817b6", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Open mic night for poetry enthusiasts.", new DateOnly(2023, 9, 15), "Poetry Slam Night", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "a70d9a91-b387-43c6-aec5-be4de13be9af", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Collecting books for donation during winter.", new DateOnly(2023, 12, 1), "Winter Book Drive", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "ac4299f7-6179-4dc0-a271-73dadf7e8d66", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Weekly story time for young children.", new DateOnly(2023, 7, 5), "Children's Story Time", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "eba910db-c9a6-4fa2-93a7-05ccd932acc9", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Reading challenge for students during summer.", new DateOnly(2023, 6, 1), "Summer Reading Challenge", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "ee6d5c0e-10c2-4f4e-b332-a2aa28de8975", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Grand opening ceremony of the new library.", new DateOnly(2023, 1, 15), "Library Grand Opening", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "publishers",
                columns: new[] { "id", "address", "CreatedAt", "DeletedAt", "phone_number", "publisher_name", "UpdatedAt" },
                values: new object[,]
                {
                    { "03e5681e-9002-4d23-94d5-97a376b0fcfc", "Hanoi, Vietnam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Kim Đồng Publishing House", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "59fe4472-a103-475f-b9eb-aaa3c9a646fe", "New York, USA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "HarperCollins", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "7548857a-291f-4cc6-ad98-94a4855af5ba", "Ho Chi Minh City, Vietnam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "First News", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "854b084a-1f99-438b-930d-aa8c33cbdb2b", "Paris, France", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Hachette Livre", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "89ffd27d-7486-4a92-8e87-637baed61c82", "Hanoi, Vietnam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Alpha Books", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "a2451456-30d8-4cb9-bbe3-c15aa33bd12c", "Ho Chi Minh City, Vietnam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Fahasa", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "a34dada6-3406-4190-9717-9f71e1dc02d9", "New York, USA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Penguin Random House", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "a9ff8381-352b-4ba8-895a-0c5506e4fb1a", "Hanoi, Vietnam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Nhã Nam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "de27542e-6db7-4cbf-82a6-bfcb0d0c7474", "New York, USA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Simon & Schuster", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "f4d8cdb0-846e-499d-a6df-acb077cdcb64", "London, UK", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "Macmillan Publishers", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "CreatedAt", "DeletedAt", "role_name", "UpdatedAt" },
                values: new object[,]
                {
                    { "0f07eb8a-e33b-48af-9dd8-c276e1c8e881", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "3f5f456e-2f32-4d28-b12e-939cd4fa6aed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 0, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "6c362a4f-e2cb-48a6-a66b-19ed2732db20", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "id", "author_id", "category_id", "CreatedAt", "DeletedAt", "description", "image_url", "publication_year", "publisher_id", "status", "title", "UpdatedAt" },
                values: new object[,]
                {
                    { "19c541ac-27a2-4783-b8f8-2a420d4ed354", "66d79b7f-cce4-430f-8d0a-2aa8bc5dcef7", "238c6a9f-b560-482b-a22c-ed92d0553d43", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Classic mystery novel.", "https://example.com/agatha.jpg", (short)1939, "854b084a-1f99-438b-930d-aa8c33cbdb2b", "Available", "And Then There Were None", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "45195577-522b-4386-8068-c98a239a0db5", "402967b6-7913-45fb-888d-1baaf5526351", "bfbec7b0-f090-4402-91ba-9fda40532116", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "First book of A Song of Ice and Fire.", "https://example.com/got.jpg", (short)1996, "de27542e-6db7-4cbf-82a6-bfcb0d0c7474", "Available", "A Game of Thrones", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "66f5cd34-16a8-4d50-b31e-c2cee40ce414", "f3c3ae36-f575-4b08-9819-4f277c92298e", "9400cd48-2be5-41e9-9485-24ec840deecc", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Tiểu thuyết hiện thực phê phán.", "https://example.com/tatden.jpg", (short)1937, "7548857a-291f-4cc6-ad98-94a4855af5ba", "Available", "Tắt Đèn", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "6b4754f1-dd78-4168-97e8-72c6d71a00cf", "883e9e37-0e76-465d-a028-a06f1b204c00", "9e948313-1dc8-4571-a46f-cf53af1c67b0", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Horror novel by Stephen King.", "https://example.com/shining.jpg", (short)1977, "a34dada6-3406-4190-9717-9f71e1dc02d9", "Available", "The Shining", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "7cc99ab6-2252-4732-b0ae-6f4abba7731c", "053fce29-5189-4393-85fa-4c46474e3202", "9e948313-1dc8-4571-a46f-cf53af1c67b0", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Tiểu thuyết của Nguyễn Nhật Ánh.", "https://example.com/hoavang.jpg", (short)2010, "03e5681e-9002-4d23-94d5-97a376b0fcfc", "Available", "Tôi Thấy Hoa Vàng Trên Cỏ Xanh", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "a852ead9-5378-4413-aa13-d572434b8be8", "265dbb7a-7b9e-499e-9f91-4304d2ac006d", "c90393a5-f30e-4187-a4bd-f01f23bdaaef", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Tập truyện ngắn lãng mạn.", "https://example.com/hoacuc.jpg", (short)2008, "89ffd27d-7486-4a92-8e87-637baed61c82", "Available", "Đi Qua Hoa Cúc", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "cf8d31e1-1c84-4946-a302-4d6f90bb02ef", "bbb5f529-f012-4a44-97f4-eb853e5c0030", "bfbec7b0-f090-4402-91ba-9fda40532116", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "First book in the Harry Potter series.", "https://example.com/hp1.jpg", (short)1997, "59fe4472-a103-475f-b9eb-aaa3c9a646fe", "Available", "Harry Potter and the Sorcerer's Stone", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "ec724b56-f893-4bbe-8303-7f84b1b478db", "05eb9387-efb8-4762-bf28-064b00887470", "9e948313-1dc8-4571-a46f-cf53af1c67b0", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Coming-of-age novel by Haruki Murakami.", "https://example.com/norwegian.jpg", (short)1987, "f4d8cdb0-846e-499d-a6df-acb077cdcb64", "Available", "Norwegian Wood", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "ef5e0c44-4338-4bc1-af04-44453c337cb7", "bb35ad9b-c5c9-4a9f-ad67-de66490fcd9a", "c90393a5-f30e-4187-a4bd-f01f23bdaaef", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Tản văn về tình yêu.", "https://example.com/tinhyv.jpg", (short)2007, "a2451456-30d8-4cb9-bbe3-c15aa33bd12c", "Available", "Cho Một Tình Yêu", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "f65bd2a6-4371-4c5e-9be1-3f6c05fd2a11", "967f6bb6-eb8c-4a82-b09d-6d606db944de", "9e948313-1dc8-4571-a46f-cf53af1c67b0", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Truyện thiếu nhi kinh điển.", "https://example.com/demen.jpg", (short)1941, "a9ff8381-352b-4ba8-895a-0c5506e4fb1a", "Available", "Dế Mèn Phiêu Lưu Ký", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "address", "CreatedAt", "date_of_birth", "DeletedAt", "email", "gender", "image_url", "password_hash", "phone_number", "role_id", "StudentCode", "UpdatedAt", "username" },
                values: new object[,]
                {
                    { "0d9448e8-e616-4285-a5b6-a7c627bf72bd", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "stu3@example.com", null, null, "123123", null, "0f07eb8a-e33b-48af-9dd8-c276e1c8e881", "ST003", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "student3" },
                    { "17bdfb8e-8bd4-4787-9af5-c636d9035336", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "jane.smith@example.com", null, null, "123123", null, "0f07eb8a-e33b-48af-9dd8-c276e1c8e881", "ST005", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "jane.smith" },
                    { "1816106d-7375-41cc-a77d-0628d2ef49a7", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "lib@example.com", null, null, "123123", null, "6c362a4f-e2cb-48a6-a66b-19ed2732db20", "librarian", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "librarianuser" },
                    { "425681f6-f4d4-4145-bc5b-b1523507df8c", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "stu2@example.com", null, null, "123123", null, "0f07eb8a-e33b-48af-9dd8-c276e1c8e881", "ST002", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "student2" },
                    { "7c530ed7-3fee-4d23-a7ac-0a3677062bcf", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "peter.jones@example.com", null, null, "123123", null, "0f07eb8a-e33b-48af-9dd8-c276e1c8e881", "ST006", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "peter.jones" },
                    { "924b13be-8d4f-4b49-91c4-47b455842cad", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "john.doe@example.com", null, null, "123123", null, "0f07eb8a-e33b-48af-9dd8-c276e1c8e881", "ST004", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "john.doe" },
                    { "99ccd897-2e23-4fce-b3d1-deb7ab636c91", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "alice.brown@example.com", null, null, "123123", null, "0f07eb8a-e33b-48af-9dd8-c276e1c8e881", "ST007", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "alice.brown" },
                    { "c4019ce7-6ddd-4084-baca-5eabef490f0c", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "bob.white@example.com", null, null, "123123", null, "0f07eb8a-e33b-48af-9dd8-c276e1c8e881", "ST008", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "bob.white" },
                    { "c675993b-8c2f-4534-9b95-bae101d94087", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "stu1@example.com", null, null, "123123", null, "0f07eb8a-e33b-48af-9dd8-c276e1c8e881", "ST001", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "student1" },
                    { "cc7d2873-0c41-4124-b167-a0fef61cb8ff", null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, null, "admin@example.com", null, null, "123123", null, "3f5f456e-2f32-4d28-b12e-939cd4fa6aed", "admin", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "adminuser" }
                });

            migrationBuilder.InsertData(
                table: "book_copies",
                columns: new[] { "id", "book_id", "copy_code", "CreatedAt", "DeletedAt", "status", "UpdatedAt" },
                values: new object[,]
                {
                    { "04ab429d-9d82-4cde-b5a1-94866859983d", "ec724b56-f893-4bbe-8303-7f84b1b478db", "CP-ec72-9", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "15bccc8d-c76e-41eb-9b9d-48520cdaffc4", "45195577-522b-4386-8068-c98a239a0db5", "CP-4519-4", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "250bb82b-a591-440b-a270-46526cfafd83", "ec724b56-f893-4bbe-8303-7f84b1b478db", "CP-ec72-8", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "39f8becd-24a9-41d8-acc3-110aa0fc6d05", "45195577-522b-4386-8068-c98a239a0db5", "CP-4519-5", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "706e7941-c8be-4f4f-a907-d49bd3ab83ec", "cf8d31e1-1c84-4946-a302-4d6f90bb02ef", "CP-cf8d-3", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "8fd5cfba-35d5-40a9-a918-fb4e1ea6925d", "6b4754f1-dd78-4168-97e8-72c6d71a00cf", "CP-6b47-0", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "95817303-490f-4b39-9c2d-dad1ec0b3633", "19c541ac-27a2-4783-b8f8-2a420d4ed354", "CP-19c5-7", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "f165ed0a-5c1c-4180-86a9-691a70a4fd55", "19c541ac-27a2-4783-b8f8-2a420d4ed354", "CP-19c5-6", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "f948da33-7dc6-40ae-a333-7b1b3c163148", "cf8d31e1-1c84-4946-a302-4d6f90bb02ef", "CP-cf8d-2", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { "fb6d5c46-cb65-4b16-a60a-25192914a7fe", "6b4754f1-dd78-4168-97e8-72c6d71a00cf", "CP-6b47-1", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, "Available", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "book_favorites",
                columns: new[] { "id", "added_at", "book_id", "CreatedAt", "DeletedAt", "UpdatedAt", "user_id" },
                values: new object[,]
                {
                    { "1aaed043-b89c-48f6-a329-fc64d5a58a30", new DateTime(2023, 12, 14, 10, 0, 0, 0, DateTimeKind.Utc), "19c541ac-27a2-4783-b8f8-2a420d4ed354", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "924b13be-8d4f-4b49-91c4-47b455842cad" },
                    { "20411d87-919a-49aa-b336-f5ab0af25e58", new DateTime(2023, 12, 17, 10, 0, 0, 0, DateTimeKind.Utc), "ec724b56-f893-4bbe-8303-7f84b1b478db", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "17bdfb8e-8bd4-4787-9af5-c636d9035336" },
                    { "23483908-8c5b-4c34-8817-8dcec88f0b8c", new DateTime(2023, 12, 25, 10, 0, 0, 0, DateTimeKind.Utc), "ef5e0c44-4338-4bc1-af04-44453c337cb7", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "c675993b-8c2f-4534-9b95-bae101d94087" },
                    { "3fb9459b-041e-40af-9133-7a4a18236111", new DateTime(2023, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), "a852ead9-5378-4413-aa13-d572434b8be8", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "c4019ce7-6ddd-4084-baca-5eabef490f0c" },
                    { "49176ed4-24fa-4c1a-a935-77cb92d2c969", new DateTime(2023, 12, 7, 10, 0, 0, 0, DateTimeKind.Utc), "cf8d31e1-1c84-4946-a302-4d6f90bb02ef", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "425681f6-f4d4-4145-bc5b-b1523507df8c" },
                    { "77c8428a-130b-4c38-831b-67caf3eb4275", new DateTime(2023, 12, 22, 10, 0, 0, 0, DateTimeKind.Utc), "f65bd2a6-4371-4c5e-9be1-3f6c05fd2a11", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "99ccd897-2e23-4fce-b3d1-deb7ab636c91" },
                    { "90c4dea4-c6d3-4295-bb83-e3356634f16f", new DateTime(2023, 12, 2, 10, 0, 0, 0, DateTimeKind.Utc), "6b4754f1-dd78-4168-97e8-72c6d71a00cf", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "c675993b-8c2f-4534-9b95-bae101d94087" },
                    { "95774e6a-6384-46c3-9067-2b923c03b665", new DateTime(2023, 12, 12, 10, 0, 0, 0, DateTimeKind.Utc), "45195577-522b-4386-8068-c98a239a0db5", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "0d9448e8-e616-4285-a5b6-a7c627bf72bd" },
                    { "9b8bbdd1-c547-4972-88ad-308af7079364", new DateTime(2023, 12, 20, 10, 0, 0, 0, DateTimeKind.Utc), "7cc99ab6-2252-4732-b0ae-6f4abba7731c", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "7c530ed7-3fee-4d23-a7ac-0a3677062bcf" },
                    { "ea7cb44b-2636-40d3-b119-6dbfafa73208", new DateTime(2023, 12, 27, 10, 0, 0, 0, DateTimeKind.Utc), "66f5cd34-16a8-4d50-b31e-c2cee40ce414", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "425681f6-f4d4-4145-bc5b-b1523507df8c" }
                });

            migrationBuilder.InsertData(
                table: "book_reviews",
                columns: new[] { "id", "book_id", "CreatedAt", "DeletedAt", "rating", "review_date", "review_text", "UpdatedAt", "user_id" },
                values: new object[,]
                {
                    { "26d39cef-e400-46c5-ad54-21ddb00b1190", "66f5cd34-16a8-4d50-b31e-c2cee40ce414", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 5, new DateTime(2023, 12, 30, 10, 0, 0, 0, DateTimeKind.Utc), "Phản ánh xã hội sâu sắc.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "425681f6-f4d4-4145-bc5b-b1523507df8c" },
                    { "3071bf66-7260-483d-9da4-9411ca60a3b0", "ec724b56-f893-4bbe-8303-7f84b1b478db", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 4, new DateTime(2023, 12, 19, 10, 0, 0, 0, DateTimeKind.Utc), "Murakami never disappoints, a unique read.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "17bdfb8e-8bd4-4787-9af5-c636d9035336" },
                    { "451f017f-baa8-4ea7-8600-b48f67484ff5", "a852ead9-5378-4413-aa13-d572434b8be8", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 4, new DateTime(2023, 12, 26, 10, 0, 0, 0, DateTimeKind.Utc), "Truyện ngắn lãng mạn nhẹ nhàng.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "c4019ce7-6ddd-4084-baca-5eabef490f0c" },
                    { "5f29b7ec-fbdf-4c38-861c-e667072bdde6", "6b4754f1-dd78-4168-97e8-72c6d71a00cf", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 5, new DateTime(2023, 12, 4, 10, 0, 0, 0, DateTimeKind.Utc), "Amazing horror story, a classic!", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "c675993b-8c2f-4534-9b95-bae101d94087" },
                    { "808d7ae2-caa2-4c85-b972-604b13ff1dd3", "cf8d31e1-1c84-4946-a302-4d6f90bb02ef", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 5, new DateTime(2023, 12, 10, 10, 0, 0, 0, DateTimeKind.Utc), "A magical start to a fantastic series!", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "425681f6-f4d4-4145-bc5b-b1523507df8c" },
                    { "9c55df9d-7970-4cb3-82a7-2fcf57513a58", "45195577-522b-4386-8068-c98a239a0db5", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 4, new DateTime(2023, 12, 13, 10, 0, 0, 0, DateTimeKind.Utc), "Complex characters and intriguing plot.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "0d9448e8-e616-4285-a5b6-a7c627bf72bd" },
                    { "a1c51637-6e05-456d-8d6b-e41b30b14c60", "7cc99ab6-2252-4732-b0ae-6f4abba7731c", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 5, new DateTime(2023, 12, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Cuốn sách rất ý nghĩa và đầy cảm xúc.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "7c530ed7-3fee-4d23-a7ac-0a3677062bcf" },
                    { "d4d5787e-4b0c-470b-b183-7df9b01d8a36", "f65bd2a6-4371-4c5e-9be1-3f6c05fd2a11", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 5, new DateTime(2023, 12, 23, 10, 0, 0, 0, DateTimeKind.Utc), "Kỷ niệm tuổi thơ với Dế Mèn.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "99ccd897-2e23-4fce-b3d1-deb7ab636c91" },
                    { "e13f46f7-2a4a-4ffa-b231-d5985ce57f9a", "19c541ac-27a2-4783-b8f8-2a420d4ed354", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 5, new DateTime(2023, 12, 16, 10, 0, 0, 0, DateTimeKind.Utc), "A masterpiece of mystery, highly recommend.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "924b13be-8d4f-4b49-91c4-47b455842cad" },
                    { "eba0e1d4-1089-4e44-8a87-5f218d204a0c", "ef5e0c44-4338-4bc1-af04-44453c337cb7", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, 4, new DateTime(2023, 12, 28, 10, 0, 0, 0, DateTimeKind.Utc), "Đọc để thấy tình yêu thật đẹp.", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "c675993b-8c2f-4534-9b95-bae101d94087" }
                });

            migrationBuilder.InsertData(
                table: "book_reservations",
                columns: new[] { "id", "copy_id", "CreatedAt", "DeletedAt", "reservation_date", "status", "UpdatedAt", "user_id" },
                values: new object[,]
                {
                    { "48675681-8bc4-4b84-bc85-efcd2b9f2dcc", "250bb82b-a591-440b-a270-46526cfafd83", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 9), "Pending", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "c675993b-8c2f-4534-9b95-bae101d94087" },
                    { "530761a3-e09c-4848-8645-c75f1f29c138", "15bccc8d-c76e-41eb-9b9d-48520cdaffc4", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 5), "Pending", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "17bdfb8e-8bd4-4787-9af5-c636d9035336" },
                    { "57cae140-dbd7-4ccd-9359-71536efc48bc", "04ab429d-9d82-4cde-b5a1-94866859983d", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 10), "Fulfilled", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "425681f6-f4d4-4145-bc5b-b1523507df8c" },
                    { "86db2b62-ff0c-467e-b004-3e8bacbb8c25", "8fd5cfba-35d5-40a9-a918-fb4e1ea6925d", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 1), "Pending", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "c675993b-8c2f-4534-9b95-bae101d94087" },
                    { "8c1dde13-f792-4510-a392-fc285d423812", "fb6d5c46-cb65-4b16-a60a-25192914a7fe", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 2), "Pending", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "425681f6-f4d4-4145-bc5b-b1523507df8c" },
                    { "cfcac613-1f68-4c77-b79e-157d0facaf4c", "39f8becd-24a9-41d8-acc3-110aa0fc6d05", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 6), "Fulfilled", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "7c530ed7-3fee-4d23-a7ac-0a3677062bcf" },
                    { "d16e6ba0-eada-4967-bc91-b017056403f6", "f165ed0a-5c1c-4180-86a9-691a70a4fd55", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 7), "Pending", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "99ccd897-2e23-4fce-b3d1-deb7ab636c91" },
                    { "e3dc5153-80bd-4803-bd78-fcc264651571", "706e7941-c8be-4f4f-a907-d49bd3ab83ec", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 4), "Fulfilled", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "924b13be-8d4f-4b49-91c4-47b455842cad" },
                    { "e72194b3-84c3-46ac-ae95-72e8c20dca49", "f948da33-7dc6-40ae-a333-7b1b3c163148", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 3), "Pending", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "0d9448e8-e616-4285-a5b6-a7c627bf72bd" },
                    { "f6a574ad-3293-4c20-bbe5-a1a78a9e7c72", "95817303-490f-4b39-9c2d-dad1ec0b3633", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateOnly(2025, 6, 8), "Fulfilled", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "c4019ce7-6ddd-4084-baca-5eabef490f0c" }
                });

            migrationBuilder.InsertData(
                table: "borrow_records",
                columns: new[] { "id", "borrow_date", "copy_id", "CreatedAt", "DeletedAt", "due_date", "ExtensionDateCount", "fine", "return_date", "status", "UpdatedAt", "user_id" },
                values: new object[,]
                {
                    { "0f107cf8-dc5d-46c4-97f0-73d3a7302bb4", new DateTime(2023, 12, 27, 10, 0, 0, 0, DateTimeKind.Utc), "8fd5cfba-35d5-40a9-a918-fb4e1ea6925d", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "c675993b-8c2f-4534-9b95-bae101d94087" },
                    { "1810aa70-14ba-42da-90f5-7f43b2d9947a", new DateTime(2023, 12, 30, 10, 0, 0, 0, DateTimeKind.Utc), "f948da33-7dc6-40ae-a333-7b1b3c163148", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 6, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "0d9448e8-e616-4285-a5b6-a7c627bf72bd" },
                    { "3cd5fd76-f683-4b49-9cdd-0605943d22bd", new DateTime(2023, 12, 28, 10, 0, 0, 0, DateTimeKind.Utc), "250bb82b-a591-440b-a270-46526cfafd83", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "c675993b-8c2f-4534-9b95-bae101d94087" },
                    { "58fc9566-38b2-44b1-a60d-5f24acccf703", new DateTime(2023, 12, 26, 10, 0, 0, 0, DateTimeKind.Utc), "04ab429d-9d82-4cde-b5a1-94866859983d", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "425681f6-f4d4-4145-bc5b-b1523507df8c" },
                    { "65ff77c5-0a62-4cb4-bce8-9ce3d13d4fad", new DateTime(2023, 12, 31, 10, 0, 0, 0, DateTimeKind.Utc), "15bccc8d-c76e-41eb-9b9d-48520cdaffc4", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 7, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "17bdfb8e-8bd4-4787-9af5-c636d9035336" },
                    { "786fb2ad-5844-4b90-a99b-708c10e55873", new DateTime(2023, 12, 29, 10, 0, 0, 0, DateTimeKind.Utc), "f165ed0a-5c1c-4180-86a9-691a70a4fd55", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 5, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "99ccd897-2e23-4fce-b3d1-deb7ab636c91" },
                    { "a238ed24-3cd0-461f-bcfe-177e796252a7", new DateTime(2023, 12, 12, 10, 0, 0, 0, DateTimeKind.Utc), "95817303-490f-4b39-9c2d-dad1ec0b3633", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2023, 12, 19, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, new DateTime(2023, 12, 17, 10, 0, 0, 0, DateTimeKind.Utc), "Returned", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "c4019ce7-6ddd-4084-baca-5eabef490f0c" },
                    { "a2e6a753-d66a-4568-902c-23307d6cd51a", new DateTime(2023, 12, 22, 10, 0, 0, 0, DateTimeKind.Utc), "706e7941-c8be-4f4f-a907-d49bd3ab83ec", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2023, 12, 29, 10, 0, 0, 0, DateTimeKind.Utc), 0, 5.00m, new DateTime(2023, 12, 27, 10, 0, 0, 0, DateTimeKind.Utc), "Returned", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "924b13be-8d4f-4b49-91c4-47b455842cad" },
                    { "acf5736e-0ddf-4c11-9169-9f0932724616", new DateTime(2023, 12, 17, 10, 0, 0, 0, DateTimeKind.Utc), "39f8becd-24a9-41d8-acc3-110aa0fc6d05", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2023, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, new DateTime(2023, 12, 22, 10, 0, 0, 0, DateTimeKind.Utc), "Returned", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "7c530ed7-3fee-4d23-a7ac-0a3677062bcf" },
                    { "b3c38e83-bdc0-47c2-8533-ded6235425e8", new DateTime(2023, 12, 25, 10, 0, 0, 0, DateTimeKind.Utc), "fb6d5c46-cb65-4b16-a60a-25192914a7fe", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), 0, 0.00m, null, "Borrowed", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "425681f6-f4d4-4145-bc5b-b1523507df8c" }
                });
        }
    }
}
