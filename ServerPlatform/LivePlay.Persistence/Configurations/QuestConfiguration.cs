
using LivePlay.Server.Persistence.EntityModels.Base;
using LivePlay.Server.Persistence.EntityModels.ManyMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivePlay.Server.Persistence.Configurations;

public class QuestConfiguration : IEntityTypeConfiguration<QuestEntityModel>
{
    public void Configure(EntityTypeBuilder<QuestEntityModel> builder)
    {
        builder.HasKey(q => q.Id);

        builder.HasMany(q => q.QuestionQuests)
            .WithOne(qq => qq.Quest)
            .HasForeignKey(qq => qq.QuestId);

        builder.HasOne(q => q.QRQuest)
            .WithOne(qrq => qrq.Quest)
            .HasForeignKey<QRQuestEntityModel>(qrq => qrq.QuestId);

        builder.HasOne(q => q.CreativeQuest)
            .WithOne(cq => cq.Quest)
            .HasForeignKey<CreativeQuestEntityModel>(cq => cq.QuestId);
    }
}
