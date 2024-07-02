
using LivePlay.Server.Core.Models;

namespace LivePlay.Server.Core.Interfaces.QuestInterfaces;

public interface IQuestionQuestRepository
{
    public Task<QuestionQuest> GetById(int id);
    public Task<QuestionQuest[]> GetByQuestId(int questId);
    public void Create(Quest quest, QuestionQuest[] questionQuests);
    public void Edit(Quest quest, QuestionQuest[] questionQuests);
}
