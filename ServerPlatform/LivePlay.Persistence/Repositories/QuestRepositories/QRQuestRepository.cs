
using AutoMapper;
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces.Quests;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Server.Persistence.Repositories.Quests;

public class QRQuestRepository(LivePlayDbContext dbContext, IMapper mapper) : IQRQuestRepository
{
    private readonly LivePlayDbContext _dbContext = dbContext;
    private readonly QuestRepository _questRepository = new(dbContext, mapper);
    private readonly IMapper _mapper = mapper;

    public async Task<QRQuest> GetById(int id)
    {
        var qrQuestEntity = await _dbContext.QRQuests.FirstOrDefaultAsync(qr => qr.Id == id);
        var qrQuest = _mapper.Map<QRQuest>(qrQuestEntity);
        return qrQuest;
    }

    public async Task<QRQuest> GetByQuestId(int idQuest)
    {
        var qrQuestsEntity = await _dbContext.QuestionQuests.AsNoTracking().FirstOrDefaultAsync(q => q.QuestId == idQuest)
            ?? throw new ServerException(ErrorCode.DbGetError, $"Couldn't find the subquest by idQuest {idQuest} in {nameof(QRQuestRepository)}");
        var questionQuests = _mapper.Map<QRQuest>(qrQuestsEntity);
        return questionQuests;
    }

    public async void Add(Quest quest, QRQuest qrQuest)
    {
        var qrQuestEntity = _mapper.Map<QRQuestEntityModel>(qrQuest);
        qrQuestEntity.Quest = await _questRepository.Create(quest);
        await _dbContext.AddAsync(qrQuestEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async void Edit(Quest quest, QRQuest qrQuest)
    {
        _questRepository.Edit(quest);
        var qrQuestEntity = await _dbContext.QRQuests.FindAsync(qrQuest.Id);
        qrQuestEntity = _mapper.Map<QRQuestEntityModel>(qrQuest);
    }
}
