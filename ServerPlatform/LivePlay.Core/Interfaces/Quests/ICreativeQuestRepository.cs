using LivePlay.Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlay.Server.Core.Interfaces.Quests;

public interface ICreativeQuestRepository
{
    public Task<CreativeQuest> GetById(int id);
    public Task<CreativeQuest> GetByQuestId(int questId);
    public Task<CreativeQuest?> GetByQuestIdAndUserId(int questId, Guid userId);
    public void Create(Quest quest);
    public void Edit(Quest quest);
}
