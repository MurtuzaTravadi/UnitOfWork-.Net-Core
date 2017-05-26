using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AirlineManagement.Models.Infrastructure.Data;

namespace AirlineManagement.Models.Migrations
{
    [DbContext(typeof(AirlineContext))]
    partial class AirlineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirlineManagement.Models.Domain.Model.Airline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<int>("Credits");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<int>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Airline");
                });

            modelBuilder.Entity("AirlineManagement.Models.Domain.Model.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<int>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Airport");
                });

            modelBuilder.Entity("AirlineManagement.Models.Domain.Model.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool?>("IsActive");

                    b.Property<int?>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("AirlineManagement.Models.Domain.Model.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AirlinesId");

                    b.Property<int?>("AirportsId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<int>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AirlinesId");

                    b.HasIndex("AirportsId");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("AirlineManagement.Models.Domain.Model.SeatManagement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AvalibaleSeat");

                    b.Property<int?>("BookSeat");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModify");

                    b.Property<int?>("ModifiedBy");

                    b.Property<int?>("Price");

                    b.Property<int?>("RouteId");

                    b.Property<string>("TotalSeat");

                    b.HasKey("Id");

                    b.ToTable("SeatManagement");
                });

            modelBuilder.Entity("AirlineManagement.Models.Domain.Model.Transection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AirlineId");

                    b.Property<int?>("AirportId");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int?>("ModifiedBy");

                    b.Property<bool?>("Payment");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Transection");
                });

            modelBuilder.Entity("AirlineManagement.Models.Domain.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModify");

                    b.Property<string>("Fname");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Lname");

                    b.Property<int?>("ModifiedBy");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AirlineManagement.Models.Domain.Model.UserBookHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModify");

                    b.Property<int?>("ModifiedBy");

                    b.Property<int?>("TransectionId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserBookHistory");
                });

            modelBuilder.Entity("AirlineManagement.Models.Domain.Model.UserHotelBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<DateTime>("InTime");

                    b.Property<int?>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<DateTime>("OutTime");

                    b.Property<int>("Price");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserHotelBook");
                });

            modelBuilder.Entity("AirlineManagement.Models.Domain.Model.Route", b =>
                {
                    b.HasOne("AirlineManagement.Models.Domain.Model.Airline", "Airlines")
                        .WithMany("Enrollments")
                        .HasForeignKey("AirlinesId");

                    b.HasOne("AirlineManagement.Models.Domain.Model.Airport", "Airports")
                        .WithMany("Routes")
                        .HasForeignKey("AirportsId");
                });
        }
    }
}
