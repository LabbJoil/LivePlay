﻿
namespace LivePlay.Server.WebApi.Contracts.Base.QuestContracts;

public class QRQuestContract
{
    public int Id { get; set; }
    public byte[] QRInfo { get; set; } = [];
}