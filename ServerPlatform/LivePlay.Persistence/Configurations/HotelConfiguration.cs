
using LivePlay.Server.Persistence.EntityModels.Base;
using LivePlay.Server.Persistence.EntityModels.ManyMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivePlay.Server.Persistence.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<HotelEntityModel>
{
    public void Configure(EntityTypeBuilder<HotelEntityModel> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasMany(h => h.Quests)
            .WithMany(q => q.Hotels)
            .UsingEntity<HotelQuestEntityModel>(
                hq => hq.HasOne<QuestEntityModel>().WithMany().HasForeignKey(h => h.QuestId),
                hq => hq.HasOne<HotelEntityModel>().WithMany().HasForeignKey(q => q.HotelId));
    }
}
