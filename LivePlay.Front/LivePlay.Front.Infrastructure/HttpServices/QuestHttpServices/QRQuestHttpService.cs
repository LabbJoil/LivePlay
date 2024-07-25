
using LivePlay.Front.Core.Models;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure.Abstracts;
using LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Add;

namespace LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;

public class QRQuestHttpService(IServiceScopeFactory serviceScopeFactory) : BaseHttpServise(serviceScopeFactory)
{
    protected override string BaseRoute => "QRQuest";

    public async Task<DisplayError?> AddQuest(Quest quest, QRQuest qrQuest)
    {
        const string route = "/add";
        var addingQRQuest = new AddingQRQuestRequest
        {
            BaseQuest = _mapper.Map<AddingQuestContract>(quest),
            QrQuest = _mapper.Map<AddingQRQuestContract>(qrQuest)
        };
        var response = await _httpProvider.Post(BaseRoute + route, addingQRQuest);
        return ParseError(response.ResponseData, response.Error);
    }
}
