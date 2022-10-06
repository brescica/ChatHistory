using ChatHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatHistory.Application.Persistance.Interfaces;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    DbSet<ChatRecord> ChatRecords { get; }
}
