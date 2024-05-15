﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Models.Domain;

public class QuestItem
{
    private string? Title;
    private string? Description;
    private string? Image;
    private string? TotalDescription;
    private DateTime? FinalDate;
    private int Reward;

    public string? TitleView 
    { 
        get => Title;   // тут
        set => Title ??= value;
    }

    public string? DescriptionView
    {
        get => Description; // обрезать размер до опр. символа
        set => Description ??= value;
    }

    public string? ImageView
    {
        get => Image;
        set => Image ??= value;
    }
}