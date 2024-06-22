
using AutoMapper;
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Server.Persistence.Repositories;

public class QuestRepository(LivePlayDbContext dbContext, IMapper mapper) : IQRQuestRepository
{
    private readonly LivePlayDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<Quest> GetQuestById(int id)
    {
        var questEntity = await _dbContext.Quests
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id);
        var quest = _mapper.Map<Quest>(questEntity);
        return quest;
    }

    public async Task<QuestEntityModel> AddQuest(Quest quest)
    {
        var questEntity = _mapper.Map<QuestEntityModel>(quest);
        await _dbContext.AddAsync(questEntity);
        await _dbContext.SaveChangesAsync();
        return questEntity;
    }

}
