using System;
using System.Collections.Generic;
using FeedbackSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using FeedbackSystem.Core.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FeedbackSystem.Infrastructure.Data;

public partial class ApplicationDbContext : IdentityDbContext<UserModel>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TicketImages> TicketImages { get; set; }
    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Classification> Classifications { get; set; }

    public virtual DbSet<FailedJob> FailedJobs { get; set; }

    public virtual DbSet<FloorNumber> FloorNumbers { get; set; }

    public virtual DbSet<Medium> Media { get; set; }


    public virtual DbSet<PasswordReset> PasswordResets { get; set; }

    public virtual DbSet<PersonalAccessToken> PersonalAccessTokens { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<PlaceType> PlaceTypes { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<RequestType> RequestTypes { get; set; }

    public virtual DbSet<ResponseType> ResponseTypes { get; set; }

    public virtual DbSet<SenderType> SenderTypes { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wing> Wings { get; set; }

    // Add soft Delete functionality
    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            var entity = entry.Entity;

            if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entity.GetType().GetProperty("DeletedAt").SetValue(entity, DateTime.UtcNow);
            };
        }
        return base.SaveChanges();  
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_buildings_id");

            entity.Property(e => e.Activation).HasDefaultValue((short)1);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DeletedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Classification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_classifications_id");

            entity.Property(e => e.Activation).HasDefaultValue((short)1);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DeletedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<FailedJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_failed_jobs_id");
        });

        modelBuilder.Entity<FloorNumber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_floor__numbers_id");

            entity.Property(e => e.Activation).HasDefaultValue((short)1);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DeletedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_media_id");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ModelId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ModelType).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });


        modelBuilder.Entity<PasswordReset>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<PersonalAccessToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_personal_access_tokens_id");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.LastUsedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_places_id");

            entity.Property(e => e.Activation).HasDefaultValue((short)1);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DeletedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<PlaceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_place__types_id");

            entity.Property(e => e.Activation).HasDefaultValue((short)1);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DeletedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_posts_id");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<RequestType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_request__types_id");

            entity.Property(e => e.Activation).HasDefaultValue((short)1);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DeletedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<ResponseType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_response_types_id");

            entity.Property(e => e.Activation).HasDefaultValue((short)1);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DeletedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<SenderType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_sender__types_id");

            entity.Property(e => e.Activation).HasDefaultValue((short)1);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DeletedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_sessions_id");

            entity.Property(e => e.IpAddress).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UserId).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tickets_id");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DeletedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.OtherClassification).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.OtherRequest).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Rate).HasDefaultValue((short)4);
            entity.Property(e => e.ResponseTypeId).HasDefaultValue(1L);
            entity.Property(e => e.SenderEmail).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.SenderName).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.SenderPhone).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_users_id");

            entity.Property(e => e.Activation).HasDefaultValue((short)1);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CurrentTeamId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DeletedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EmailVerifiedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.RememberToken).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Role).HasDefaultValue("user");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Wing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_wings_id");

            entity.Property(e => e.Activation).HasDefaultValue((short)1);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DeletedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
