using LivePlayMAUI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Models.Domain;

public class QuestItem()
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string TotalDescription { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;

    public QuestStatus Status { get; set; }
    public TypeQuest Type { get; set; }

    public DateTime FinalDate { get; set; } = DateTime.Now;
    public int Reward { get; set; }
}
