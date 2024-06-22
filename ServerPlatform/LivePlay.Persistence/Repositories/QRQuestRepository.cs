
using AutoMapper;
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Server.Persistence.Repositories;

public class QRQuestRepository(LivePlayDbContext dbContext, IMapper mapper) : IQRQuestRepository
{
    private readonly LivePlayDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly QuestRepository _questRepository = new(dbContext, mapper);

    public async Task<QRQuest> GetQRQuest(int id)
    {
        var qrQuestEntity = await _dbContext.QRQuests.FirstOrDefaultAsync(qr => qr.Id == id);
        var qrQuest = _mapper.Map<QRQuest>(qrQuestEntity);
        return qrQuest;
    }

    public async void AddQRQuest(Quest quest, QRQuest qrQuest)
    {
        var qrQuestEntity = _mapper.Map<QRQuestEntityModel>(qrQuest);
        qrQuestEntity.Quest = await _questRepository.AddQuest(quest);
        await _dbContext.AddAsync(qrQuestEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async void DeleteQRQuest(int id)
    {
        var qrQuestEntity = await _dbContext.QRQuests.FindAsync(id)
            ?? throw new RequestException(ErrorCode.DbDeleteError, "Couldn't find the quest, try again later");
        _dbContext.Remove(qrQuestEntity);
        await _dbContext.SaveChangesAsync();
    }
}
