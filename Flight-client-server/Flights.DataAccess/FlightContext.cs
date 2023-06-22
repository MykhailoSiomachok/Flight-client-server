using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Flights.DataAccess;

public partial class FlightContext : DbContext
{
    public FlightContext()
    {
    }

    public FlightContext(DbContextOptions<FlightContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Flight> Flights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Port=5433;Server=localhost;Database=Flights;UserId=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Flight_pkey");

            entity.ToTable("Flight");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasColumnType("character varying");
            entity.Property(e => e.FlightName).HasColumnType("character varying");
            entity.Property(e => e.Route).HasColumnType("character varying");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
