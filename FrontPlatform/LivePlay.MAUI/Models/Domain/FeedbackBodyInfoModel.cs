using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Models.Domain;

public class FeedbackBodyInfoModel
{
    public string Text { get; set; } = string.Empty;
    public byte[] FirstImage { get; set; } = [];
}
