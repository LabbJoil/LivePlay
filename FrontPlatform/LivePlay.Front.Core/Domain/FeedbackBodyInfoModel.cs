﻿
namespace LivePlay.Front.Core.Models.Domain;

public class FeedbackBodyInfoModel
{
    public string Text { get; set; } = string.Empty;
    public byte[] FirstImage { get; set; } = [];
}
