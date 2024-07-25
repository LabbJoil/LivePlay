
using LivePlay.Server.WebApi.Contracts.Base.QuestContracts;

namespace LivePlay.Server.WebApi.Contracts.Responses.QuestResponses;

public class FullQuestResponse<T>
{
    public required QuestContract Quest { get; set; }
    public required T Subquest { get; set; }
}
