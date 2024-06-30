using LivePlay.Server.Core.Models;

namespace LivePlay.Server.Core.Interfaces.Quests;

public interface IQRQuestRepository
{
    public Task<QRQuest> GetById(int id);
    public Task<QRQuest> GetByQuestId(int idQuest);
    public void Add(Quest quest, QRQuest qrQuest);
    public void Edit(Quest quest, QRQuest qrQuest);
}
