
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Interfaces.QuestInterfaces;
using LivePlay.Server.Core.Models;
using System.Security.Claims;

namespace LivePlay.Server.Application.Services.QuestServices;

public class QuestionQuestService(IUserRepository userRepository, IQuestRepository questRepository, IQuestionQuestRepository questionQuestRepository, IJwtProvider jwtProvider)
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IQuestRepository _questRepository = questRepository;
    private readonly IQuestionQuestRepository _questionQuestRepository = questionQuestRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task AddQuest(Quest quest, QuestionQuest[] questionQuests)
    {
        await _questionQuestRepository.Create(quest, questionQuests);
    }

    public void EditQuest(Quest quest, QuestionQuest[] questionQuests)
    {
        _questionQuestRepository.Edit(quest, questionQuests);
    }

    public async Task<QuestionQuest[]> GetQuestQuestions(int questId)
    {
       return await _questionQuestRepository.GetByQuestId(questId);
    }

    public async Task<(int, int)> CompleteQuest(ClaimsPrincipal claimsPrincipal, int questId, Dictionary<int, int> questIdAndAnswers)
    {
        var userId = _jwtProvider.GetUserId(claimsPrincipal);
        var completeQuest = await _questRepository.GetByIdAndUserId(questId, userId);
        if (completeQuest != null)
            throw new RequestException(ErrorCode.RequestError, $"Quest {questId} has already been completed by user {userId}");

        const string notTrueMessage = "Some questions are not answered correctly";
        var quest = await _questRepository.GetById(questId);
        var questionQuests = await _questionQuestRepository.GetByQuestId(questId);

        foreach (var question in questionQuests)
        {
            var questIdAndAnswer = questIdAndAnswers.FirstOrDefault(qa => qa.Key == question.Id);
            if (questIdAndAnswer.Equals(default(KeyValuePair<int, int>)))
                throw new RequestException(ErrorCode.RequestError, notTrueMessage, $"Question {question.Id} has not been answered");

            if (questIdAndAnswer.Value != question.RightAnswer)
                throw new RequestException(ErrorCode.RequestError, notTrueMessage, $"The answer to question {question.Id} is incorrect. Correct - {question.RightAnswer}, given - {questIdAndAnswer.Value}");
        }

        var userPoints = await _userRepository.IncreasePoints(userId, quest.Reward);
        return (userPoints, quest.Reward);
    }
}
