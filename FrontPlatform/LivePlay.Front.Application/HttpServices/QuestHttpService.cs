﻿
using LivePlay.Front.Application.Contracts.Responses;
using LivePlay.Front.Application.Interfaces;
using LivePlay.Front.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LivePlay.Front.Application.HttpServices;

public class QuestHttpService(IServiceScopeFactory serviceScopeFactory) : BaseHttpServise(serviceScopeFactory, "user")
{
    public async Task<DisplayError?> TakePart(int idQuest)
    {
        const string route = "/takepart";
        (string, string)[] sendParams = [(nameof(idQuest), idQuest.ToString())];

        var response = await _httpProvider.Get(_baseRoute + route, sendParams);
        if (response.IsSuccess)
            return null;
        else
            return ParseError(response.ResponseData, response.Error);
    }
}
