﻿// <auto-generated />
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(MonthlyIncomeExpenseDbContext))]
    partial class MonthlyIncomeExpenseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Entities.InExType", b =>
                {
                    b.Property<int>("InExTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InExName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InExTypeID");

                    b.ToTable("InExTypes");

                    b.HasData(
                        new
                        {
                            InExTypeID = 1,
                            InExName = "Gelir"
                        },
                        new
                        {
                            InExTypeID = 2,
                            InExName = "Gider"
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entities.IncomeExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageBase64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InExTypeID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InExTypeID");

                    b.ToTable("IncomeExpenses");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.IncomeExpense", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.InExType", "InExType")
                        .WithMany()
                        .HasForeignKey("InExTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InExType");
                });
#pragma warning restore 612, 618
        }
    }
}
