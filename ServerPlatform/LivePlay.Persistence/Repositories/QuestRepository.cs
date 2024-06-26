
using AutoMapper;
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Server.Persistence.Repositories;

public class QuestRepository(LivePlayDbContext dbContext, IMapper mapper) : IQuestRepository
{
    private readonly LivePlayDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly QuestionQuestRepository _questionQuestRepository = new(dbContext, mapper);
    private readonly QRQuestRepository _qrQuestRepository = new(dbContext, mapper);
    private readonly CreativeQuestRepository _creativeQuestRepository = new(dbContext, mapper);

    public async Task<Quest> GetById(int id)
    {
        var questEntity = await GetEntityById(id);
        var quest = _mapper.Map<Quest>(questEntity);
        return quest;
    }

    internal async Task<QuestEntityModel> GetEntityById(int id)
    {
        var questEntity = await _dbContext.Quests
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id)
            ?? throw new RequestException(ErrorCode.RequestError, "Сouldn't find the quest", $"Quest with id {id} not found");
        return questEntity;
    }

    public async Task<Quest[]> GetAll()
    {
        var questEntities = await _dbContext.Quests
            .AsNoTracking()
            .ToArrayAsync();
        var quests = _mapper.Map<Quest[]>(questEntities);
        return quests;
    }

    public async void Delete(int id)
    {
        var questEntity = await _dbContext.Quests.FindAsync(id)
            ?? throw new RequestException(ErrorCode.DbDeleteError, "Couldn't find the quest, try again later");
        _dbContext.Quests.Remove(questEntity);
    }

    internal async Task<QuestEntityModel> Create(Quest quest)
    {
        var questEntity = _mapper.Map<QuestEntityModel>(quest);
        await _dbContext.AddAsync(questEntity);
        return questEntity;
    }

    internal async void Edit(Quest quest)
    {
        var questEntity = await _dbContext.Quests.FindAsync(quest.Id);
        questEntity = _mapper.Map<QuestEntityModel>(quest);
    }

    public async Task<Quest> GetByIdAndUserId(int id, Guid userId)
    {
        var questEntity = await _dbContext.Quests.FirstOrDefaultAsync(q => q.Id == id && q.Users.FirstOrDefault(u => u.Id == userId) != null);
        var quest = _mapper.Map<Quest>(questEntity);
        return quest;
    }
}
