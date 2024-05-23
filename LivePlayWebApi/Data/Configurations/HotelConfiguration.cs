using LivePlayWebApi.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Data.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<HotelEntityModel>
{
    public void Configure(EntityTypeBuilder<HotelEntityModel> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasMany(h => h.Quest)
            .WithMany(q => q.Hotel)
            .UsingEntity<HotelQuestEntityModel>(
                hq => hq.HasOne<QuestEntityModel>().WithMany().HasForeignKey(h => h.QuestId),
                hq => hq.HasOne<HotelEntityModel>().WithMany().HasForeignKey(q => q.HotelId));
    }
}
