﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;


namespace PetsDates.Data.Migrations
{
    [DbContext(typeof(PetsDatesDbContext))]
    partial class PetsDatesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PetsDates.Data.Models.CatBreed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CatBreeds");
                });

            modelBuilder.Entity("PetsDates.Data.Models.DogBreed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DogBreeds");
                });

            modelBuilder.Entity("PetsDates.Data.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pet");
                });

            modelBuilder.Entity("PetsDates.Data.Models.Cat", b =>
                {
                    b.HasBaseType("PetsDates.Data.Models.Pet");

                    b.Property<int>("CatBreedId")
                        .HasColumnType("int");

                    b.HasIndex("CatBreedId");

                    b.HasDiscriminator().HasValue("Cat");
                });

            modelBuilder.Entity("PetsDates.Data.Models.Dog", b =>
                {
                    b.HasBaseType("PetsDates.Data.Models.Pet");

                    b.Property<int>("DogBreedId")
                        .HasColumnType("int");

                    b.HasIndex("DogBreedId");

                    b.HasDiscriminator().HasValue("Dog");
                });

            modelBuilder.Entity("PetsDates.Data.Models.Cat", b =>
                {
                    b.HasOne("PetsDates.Data.Models.CatBreed", "Breed")
                        .WithMany("Cats")
                        .HasForeignKey("CatBreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breed");
                });

            modelBuilder.Entity("PetsDates.Data.Models.Dog", b =>
                {
                    b.HasOne("PetsDates.Data.Models.DogBreed", "Breed")
                        .WithMany("Cats")
                        .HasForeignKey("DogBreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breed");
                });

            modelBuilder.Entity("PetsDates.Data.Models.CatBreed", b =>
                {
                    b.Navigation("Cats");
                });

            modelBuilder.Entity("PetsDates.Data.Models.DogBreed", b =>
                {
                    b.Navigation("Cats");
                });
#pragma warning restore 612, 618
        }
    }
}
