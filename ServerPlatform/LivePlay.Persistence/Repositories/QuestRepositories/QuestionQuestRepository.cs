
using AutoMapper;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces.QuestInterfaces;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Server.Persistence.Repositories.Quests;

public class QuestionQuestRepository(LivePlayDbContext dbContext, IMapper mapper) : IQuestionQuestRepository
{
    private readonly LivePlayDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<QuestionQuest> GetById(int id)
    {
        var questionQuestEntity = await _dbContext.Quests
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id);
        var questionQuest = _mapper.Map<QuestionQuest>(questionQuestEntity);
        return questionQuest;
    }

    public async Task<QuestionQuest[]> GetByQuestId(int questId)
    {
        var questionQuestsEntity = await _dbContext.QuestionQuests.AsNoTracking().Where(q => q.QuestId == questId).ToArrayAsync()
            ?? throw new ServerException(ErrorCode.DbGetError, $"Couldn't find the subquest by idQuest {questId} in {nameof(QuestionQuestRepository)}");
        var questionQuests = _mapper.Map<QuestionQuest[]>(questionQuestsEntity);
        return questionQuests;
    }

    public async void Create(Quest quest, QuestionQuest[] questionQuests)
    {
        var questEntity = _mapper.Map<QuestEntityModel>(quest);     // TODO: сделать добавление в QuestQuestion
        await _dbContext.AddAsync(questEntity);
        foreach (var questionQuest in questionQuests)
        {
            var questionQuestEntity = _mapper.Map<QuestionQuestEntityModel>(questionQuest);
            questionQuestEntity.Quest = questEntity;
            await _dbContext.AddAsync(questionQuestEntity);
        }
        _dbContext.SaveChanges();
    }

    public async void Edit(Quest quest, QuestionQuest[] questionQuests)
    {
        foreach (var questionQuest in questionQuests)
        {
            var questionQuestEntity = await _dbContext.QuestionQuests.FindAsync(questionQuest.Id);
            questionQuestEntity = _mapper.Map<QuestionQuestEntityModel>(questionQuest);
        }
        await _dbContext.SaveChangesAsync();
    }
}
