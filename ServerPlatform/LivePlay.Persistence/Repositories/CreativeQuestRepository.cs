
using AutoMapper;
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlay.Server.Persistence.Repositories;

public class CreativeQuestRepository(LivePlayDbContext dbContext, IMapper mapper) : ICreativeQuestRepository
{
    private readonly LivePlayDbContext _dbContext = dbContext;
    private readonly QuestRepository _questRepository = new(dbContext, mapper);
    private readonly UserRepository _userRepository = new(dbContext, mapper);
    private readonly IMapper _mapper = mapper;

    public async Task<CreativeQuest> GetById(int id)
    {
        var creativeQuestEntity = await _dbContext.CreativeQuests.FirstOrDefaultAsync(qr => qr.Id == id);
        var creativeQuest = _mapper.Map<CreativeQuest>(creativeQuestEntity);
        return creativeQuest;
    }

    public async Task<CreativeQuest> GetByQuestId(int questId)
    {
        var creativeQuestsEntity = await _dbContext.CreativeQuests.AsNoTracking().FirstOrDefaultAsync(q => q.QuestId == questId)
            ?? throw new ServerException(ErrorCode.DbGetError, $"Couldn't find the subquest by idQuest {questId} in {nameof(CreativeQuestRepository)}");
        var creativeQuests = _mapper.Map<CreativeQuest>(creativeQuestsEntity);
        return creativeQuests;
    }

    public async Task<CreativeQuest?> GetByQuestIdAndUserId(int questId, Guid userId)
    {
        var creativeQuestsEntity = await _dbContext.CreativeQuests.AsNoTracking().FirstOrDefaultAsync(q => q.QuestId == questId && q.UserId == userId);
        if (creativeQuestsEntity == null)
            return null;
        var creativeQuests = _mapper.Map<CreativeQuest>(creativeQuestsEntity);
        return creativeQuests;
    }

    public async Task<(Quest, CreativeQuest)> GetFullQuest(int questId)
    {
        var creativeQuestsEntity = await _dbContext.CreativeQuests.AsNoTracking().FirstOrDefaultAsync(q => q.QuestId == questId)
            ?? throw new ServerException(ErrorCode.DbGetError, $"Couldn't find the subquest by idQuest {questId} in {nameof(CreativeQuestRepository)}");
        var creativeQuests = _mapper.Map<CreativeQuest>(creativeQuestsEntity);
        var quest = await _questRepository.GetById(questId);
        return (quest, creativeQuests);
    }

    public async void Create(Quest quest)
    {
        await _questRepository.Create(quest);
        _dbContext.SaveChanges();
    }

    public void Edit(Quest quest)
    {
        _questRepository.Edit(quest);
        _dbContext.SaveChanges();
    }

    public async void AddCreativeQuest(int questId, Guid userId, CreativeQuest creativeQuest)
    {
        var questEntity = await _questRepository.GetEntityById(questId);
        var userEntity = await _userRepository.GetEntryById(userId);
        var creativeQuestEntity = _mapper.Map<CreativeQuestEntityModel>(creativeQuest);
        creativeQuestEntity.Quest = questEntity;
        creativeQuestEntity.User = userEntity;
        await _dbContext.CreativeQuests.AddAsync(creativeQuestEntity);
    }
}
