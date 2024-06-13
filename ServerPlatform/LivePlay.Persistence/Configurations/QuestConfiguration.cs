
using LivePlay.Server.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivePlay.Server.Persistence.Configurations;

public class QuestConfiguration : IEntityTypeConfiguration<QuestEntityModel>
{
    public void Configure(EntityTypeBuilder<QuestEntityModel> builder)
    {
        builder.HasKey(qq => qq.Id);

        builder.HasOne(qq => qq.QuestionQuest)
            .WithOne(q => q.Quest)
            .HasForeignKey<QuestionQuestEntityModel>(qq => qq.QuestId);

        builder.HasOne(qq => qq.QRQuest)
            .WithOne(q => q.Quest)
            .HasForeignKey<QRQuestEntityModel>(qrq => qrq.QuestId);
    }
}
