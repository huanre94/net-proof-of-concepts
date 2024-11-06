﻿// <auto-generated />
using System;
using GraphQLServerExample;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphQLServerExample.Migrations
{
    [DbContext(typeof(GQLContext))]
    [Migration("20241105220236_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("GraphQLServerExample.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4cded129-8f41-9220-5f06-8bba91ce4595"),
                            Name = "Labore architecto aliquam provident id atque dolorem.\nEt velit occaecati non occaecati quibusdam.\nAut molestiae nihil quas maxime.",
                            Price = 0.9489806664250160m
                        },
                        new
                        {
                            Id = new Guid("8050bc0a-1ac2-99ee-78af-8e72a50d78df"),
                            Name = "repellat",
                            Price = 0.4085771238612920m
                        },
                        new
                        {
                            Id = new Guid("9c133e69-c69b-8b52-de90-aa07ffc31e34"),
                            Name = "Qui qui ipsam.",
                            Price = 0.422052656336710m
                        },
                        new
                        {
                            Id = new Guid("a9eb496d-0671-d05b-366f-592d66f86774"),
                            Name = "doloribus",
                            Price = 0.2899625480164540m
                        },
                        new
                        {
                            Id = new Guid("a72b1bd1-80b7-0b8c-2ef3-9e7089dcb11d"),
                            Name = "Illum vel distinctio qui commodi eius esse.\nFugit sequi velit vel animi ipsa quod.\nMolestiae itaque illo nemo.",
                            Price = 0.1455719017922750m
                        },
                        new
                        {
                            Id = new Guid("da156d0f-bd23-8713-a196-083a9c29fb8d"),
                            Name = "sed",
                            Price = 0.6717627590380260m
                        },
                        new
                        {
                            Id = new Guid("db97138b-50db-b311-d490-6ed7cc351f52"),
                            Name = "Non et nobis iure molestias rerum. Eum ducimus fugiat. Autem nisi qui. Occaecati non commodi et ut aut. Distinctio cum et repellendus enim qui officia. Odit quo ut dolorum.",
                            Price = 0.261748436411820m
                        },
                        new
                        {
                            Id = new Guid("7eb7df77-f3b2-52bc-bbb6-c0d6f077044a"),
                            Name = "Sint recusandae exercitationem officiis assumenda explicabo aut occaecati. Quaerat cum libero hic aliquid voluptatem sit. Nobis veniam quidem. Ut ab soluta consequatur sit magnam. Id quas consequatur.",
                            Price = 0.1214679666954740m
                        },
                        new
                        {
                            Id = new Guid("3560b591-9f47-2e5f-dbbb-946db6b780d7"),
                            Name = "Enim quibusdam praesentium. Assumenda a exercitationem sit laborum magnam. Accusantium sint est iure eaque.",
                            Price = 0.944000395564050m
                        },
                        new
                        {
                            Id = new Guid("276a8aa3-b17a-cbb8-9d3f-e5399908c356"),
                            Name = "Accusamus distinctio exercitationem velit aut eos quia cum fuga.",
                            Price = 0.8474602648760630m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
