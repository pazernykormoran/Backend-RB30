// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RetireBefore30.Data;

namespace RetireBefore30.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RetireBefore30.Models.Config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StrategyInstanceId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StrategyInstanceId");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("RetireBefore30.Models.Ping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("StrategyInstanceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StrategyInstanceId");

                    b.ToTable("Pings");
                });

            modelBuilder.Entity("RetireBefore30.Models.Strategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Strategies");
                });

            modelBuilder.Entity("RetireBefore30.Models.StrategyInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Instrument")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StrategyId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StrategyId");

                    b.ToTable("StrategyInstances");
                });

            modelBuilder.Entity("RetireBefore30.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("Direction")
                        .HasColumnType("int");

                    b.Property<double>("MoneyState")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("StrategyInstanceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StrategyInstanceId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("RetireBefore30.Models.Config", b =>
                {
                    b.HasOne("RetireBefore30.Models.StrategyInstance", "StrategyInstance")
                        .WithMany("Configs")
                        .HasForeignKey("StrategyInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StrategyInstance");
                });

            modelBuilder.Entity("RetireBefore30.Models.Ping", b =>
                {
                    b.HasOne("RetireBefore30.Models.StrategyInstance", "StrategyInstance")
                        .WithMany("Pings")
                        .HasForeignKey("StrategyInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StrategyInstance");
                });

            modelBuilder.Entity("RetireBefore30.Models.StrategyInstance", b =>
                {
                    b.HasOne("RetireBefore30.Models.Strategy", "Strategy")
                        .WithMany("StrategyInstances")
                        .HasForeignKey("StrategyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Strategy");
                });

            modelBuilder.Entity("RetireBefore30.Models.Transaction", b =>
                {
                    b.HasOne("RetireBefore30.Models.StrategyInstance", "StrategyInstance")
                        .WithMany("Transactions")
                        .HasForeignKey("StrategyInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StrategyInstance");
                });

            modelBuilder.Entity("RetireBefore30.Models.Strategy", b =>
                {
                    b.Navigation("StrategyInstances");
                });

            modelBuilder.Entity("RetireBefore30.Models.StrategyInstance", b =>
                {
                    b.Navigation("Configs");

                    b.Navigation("Pings");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
