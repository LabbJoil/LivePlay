
using LivePlay.Front.Core.Models;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure.Abstracts;
using LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Add;
using LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Complete;
using LivePlay.Front.Infrastructure.Contracts.Responses;

namespace LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;

public class QuestionQuestHttpService(IServiceScopeFactory serviceScopeFactory) : BaseHttpServise(serviceScopeFactory)
{
    protected override string BaseRoute => "QuestionQuest";

    public async Task<DisplayError?> AddQuest(Quest quest, IEnumerable<QuestionQuest> questionQuest)
    {
        const string route = "/add";
        var addingQuestionQuest = new AddingQuestionQuestRequest
        {
            BaseQuest = _mapper.Map<AddingQuestContract>(quest),
            Questions = _mapper.Map<AddingQuestionQuestContract[]>(questionQuest)
        };
        var response = await _httpProvider.Post(BaseRoute + route, addingQuestionQuest);
        return ParseError(response.ResponseData, response.Error);
    }

    public async Task<(QuestionQuest[], DisplayError?)> GetQuestions(int questId)
    {
        questId = 6; //TODO incorect
        const string route = "/getQuestQuestions";
        var response = await _httpProvider.Get(BaseRoute + route, (nameof(questId), questId.ToString()));
        if (response.IsSuccess)
        {
            var (questionQuestResponse, error) = ParseResponse<QuestionQuestResponse[]>(response);
            if (questionQuestResponse != default)
            {
                var questionQuest = _mapper.Map<QuestionQuest[]>(questionQuestResponse);
                return (questionQuest, null);
            }
            return ([], error);
        }
        else
            return ([], ParseError(response.ResponseData, response.Error));
    }

    public async Task<(int, DisplayError?)> Complete(int id, Dictionary<int, int> answers)
    {
        const string route = "/complete";

        var completeBody = new CompletingQuestionQuestRequest
        {
            QuestId = id,
            AnswerQuestions = answers
        };
        var response = await _httpProvider.Post(BaseRoute + route, completeBody);
        if (response.IsSuccess)
        {
            var (reward, error) = ParseResponse<int>(response);
            if (reward != default)
                return (reward, null);
            return (default, error);
        }
        else
            return (default, ParseError(response.ResponseData, response.Error));
    }
}
