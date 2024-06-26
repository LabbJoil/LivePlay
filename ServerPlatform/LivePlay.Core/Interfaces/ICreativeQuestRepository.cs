
using LivePlay.Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlay.Server.Core.Interfaces;

public interface ICreativeQuestRepository
{
    public Task<(Quest, CreativeQuest)> GetFullQuest(int questId);
    public Task<CreativeQuest?> GetByQuestIdAndUserId(int questId, Guid userId);
    public void Create(Quest quest);
    public void Edit(Quest quest);
}
