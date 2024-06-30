
using LivePlay.Server.Core.Models;

namespace LivePlay.Server.Core.Interfaces.Quests;

public interface IQuestRepository
{
    public Task<Quest> GetById(int id);
    public Task<Quest[]> GetAll();
    public Task<Quest> GetByIdAndUserId(int id, Guid userId);
    public void Delete(int id);
    public void AddLinkUser(int id, Guid userId);
}
