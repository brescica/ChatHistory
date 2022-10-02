using ChatHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatHistory.Application.Persistance;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    DbSet<ChatRecord> ChatRecords { get; }
}
