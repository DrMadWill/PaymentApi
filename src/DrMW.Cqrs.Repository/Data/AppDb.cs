using Microsoft.EntityFrameworkCore;

namespace DrMW.Cqrs.Repository.Data;

public class AppDb : DbContext
{
    
   

    public AppDb(DbContextOptions<AppDb> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // modelBuilder.Entity<Student>()
        //     .HasOne(s => s.Group)
        //     .WithMany(s => s.Students)
        //     .HasForeignKey(s => s.GroupId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // modelBuilder.Entity<Student>()
        //     .HasOne(s => s.Detail)
        //     .WithOne(s => s.Student)
        //     .HasForeignKey<Detail>(s => s.Id)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        //
        // modelBuilder.Entity<GroupSubject>()
        //     .HasIndex(s => new { s.GroupId, s.SubjectId })
        //     .HasFilter("[Deleted] = 0")
        //     .IsUnique();
            
        
        modelBuilder.ApplyDbSeedData();
    }
}