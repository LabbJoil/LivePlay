
using LivePlay.Server.Core.Models;

namespace LivePlay.Server.Core.Interfaces;

public interface IQuestRepository
{
    public Task<Quest[]> GetAll();
    public Task<Quest> GetByIdAndUserId(int iId, Guid userId);
    public void Delete(int id);
}
