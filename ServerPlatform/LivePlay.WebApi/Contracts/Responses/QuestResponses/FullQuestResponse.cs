
using LivePlay.Server.WebApi.Contracts.Base.Quest;

namespace LivePlay.Server.WebApi.Contracts.Responses.Quest;

public class FullQuestResponse<T>
{
    public required QuestContract Quest { get; set; }
    public required T Subquest { get; set; }
}
