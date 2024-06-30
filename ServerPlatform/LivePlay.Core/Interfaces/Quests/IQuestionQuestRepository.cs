using LivePlay.Server.Core.Models;
using System.Security.Claims;

namespace LivePlay.Server.Core.Interfaces.Quests;

public interface IQuestionQuestRepository
{
    public Task<QuestionQuest> GetById(int id);
    public Task<QuestionQuest[]> GetByQuestId(int questId);
    public void Create(Quest quest, QuestionQuest[] questionQuests);
    public void Edit(Quest quest, QuestionQuest[] questionQuests);
}
