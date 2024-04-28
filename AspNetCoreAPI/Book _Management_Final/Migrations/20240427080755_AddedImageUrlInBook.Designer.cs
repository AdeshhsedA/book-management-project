﻿// <auto-generated />
using Book__Management_Final.DataAccess.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Book__Management_Final.Migrations
{
    [DbContext(typeof(BookManagementDbContext))]
    [Migration("20240427080755_AddedImageUrlInBook")]
    partial class AddedImageUrlInBook
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Book__Management_Final.DataAccess.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Book__Management_Final.DataAccess.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookShelfNo")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ISBN")
                        .HasColumnType("bigint");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("ShelfRowNo")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Book__Management_Final.DataAccess.Models.RentedBook", b =>
                {
                    b.Property<int>("RentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("ExpectedReturnDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RentedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReturnedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RentId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("RentedBooks");
                });

            modelBuilder.Entity("Book__Management_Final.DataAccess.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Book__Management_Final.DataAccess.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("Contact")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("User");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Book__Management_Final.DataAccess.Models.Book", b =>
                {
                    b.HasOne("Book__Management_Final.DataAccess.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book__Management_Final.DataAccess.Models.Subject", "Subject")
                        .WithMany("Books")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Book__Management_Final.DataAccess.Models.RentedBook", b =>
                {
                    b.HasOne("Book__Management_Final.DataAccess.Models.Book", "Book")
                        .WithMany("RentedBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book__Management_Final.DataAccess.Models.User", "User")
                        .WithMany("RentedBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Book__Management_Final.DataAccess.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Book__Management_Final.DataAccess.Models.Book", b =>
                {
                    b.Navigation("RentedBooks");
                });

            modelBuilder.Entity("Book__Management_Final.DataAccess.Models.Subject", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Book__Management_Final.DataAccess.Models.User", b =>
                {
                    b.Navigation("RentedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
