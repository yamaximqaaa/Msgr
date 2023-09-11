using System.Data.Common;
using Microsoft.EntityFrameworkCore;

using MsngBack.Models.Conversation;
using MsngBack.Models.Message;
using MsngBack.Models.User;

namespace MsngBack.DataLayer.Db;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<UserBase> User { get; set; }
    public DbSet<MessageBase> Message { get; set; }
    public DbSet<ConversationBase> Conversation { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // --- To override table name in db
        modelBuilder.Entity<UserBase>().ToTable("Users");
        modelBuilder.Entity<MessageBase>().ToTable("Messages");
        modelBuilder.Entity<ConversationBase>().ToTable("Conversations");
        // ---
    }
    
}