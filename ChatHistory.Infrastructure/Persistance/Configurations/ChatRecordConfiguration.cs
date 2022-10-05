using ChatHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatHistory.Infrastructure.Persistance.Configurations
{
    public class ChatRecordConfiguration : IEntityTypeConfiguration<ChatRecord>
    {
        public void Configure(EntityTypeBuilder<ChatRecord> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Comment)
                .HasMaxLength(1024);

            builder.Property(x => x.ChatEventType).IsRequired();

            builder.Property(x => x.Time).IsRequired();

            builder.HasOne(x => x.Sender)
                .WithMany(u => u.SentChatRecords)
                .HasForeignKey("SenderId");

            builder.HasOne(x => x.Receiver)
                .WithMany(u => u.ReceivedChatRecords)
                .HasForeignKey("ReceiverId");
        }
    }
}
