
using LivePlay.Server.Core.Models;

namespace LivePlay.Server.Core.Interfaces.QuestInterfaces;

public interface ICreativeQuestRepository
{
    public Task<CreativeQuest> GetById(int id);
    public Task<CreativeQuest> GetByQuestId(int questId);
    public Task<CreativeQuest?> GetByQuestIdAndUserId(int questId, Guid userId);
    public void Create(Quest quest);
    public void Edit(Quest quest);
}
