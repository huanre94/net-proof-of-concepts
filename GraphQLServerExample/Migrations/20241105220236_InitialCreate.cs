using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraphQLServerExample.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("276a8aa3-b17a-cbb8-9d3f-e5399908c356"), "Accusamus distinctio exercitationem velit aut eos quia cum fuga.", 0.8474602648760630m },
                    { new Guid("3560b591-9f47-2e5f-dbbb-946db6b780d7"), "Enim quibusdam praesentium. Assumenda a exercitationem sit laborum magnam. Accusantium sint est iure eaque.", 0.944000395564050m },
                    { new Guid("4cded129-8f41-9220-5f06-8bba91ce4595"), "Labore architecto aliquam provident id atque dolorem.\nEt velit occaecati non occaecati quibusdam.\nAut molestiae nihil quas maxime.", 0.9489806664250160m },
                    { new Guid("7eb7df77-f3b2-52bc-bbb6-c0d6f077044a"), "Sint recusandae exercitationem officiis assumenda explicabo aut occaecati. Quaerat cum libero hic aliquid voluptatem sit. Nobis veniam quidem. Ut ab soluta consequatur sit magnam. Id quas consequatur.", 0.1214679666954740m },
                    { new Guid("8050bc0a-1ac2-99ee-78af-8e72a50d78df"), "repellat", 0.4085771238612920m },
                    { new Guid("9c133e69-c69b-8b52-de90-aa07ffc31e34"), "Qui qui ipsam.", 0.422052656336710m },
                    { new Guid("a72b1bd1-80b7-0b8c-2ef3-9e7089dcb11d"), "Illum vel distinctio qui commodi eius esse.\nFugit sequi velit vel animi ipsa quod.\nMolestiae itaque illo nemo.", 0.1455719017922750m },
                    { new Guid("a9eb496d-0671-d05b-366f-592d66f86774"), "doloribus", 0.2899625480164540m },
                    { new Guid("da156d0f-bd23-8713-a196-083a9c29fb8d"), "sed", 0.6717627590380260m },
                    { new Guid("db97138b-50db-b311-d490-6ed7cc351f52"), "Non et nobis iure molestias rerum. Eum ducimus fugiat. Autem nisi qui. Occaecati non commodi et ut aut. Distinctio cum et repellendus enim qui officia. Odit quo ut dolorum.", 0.261748436411820m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
