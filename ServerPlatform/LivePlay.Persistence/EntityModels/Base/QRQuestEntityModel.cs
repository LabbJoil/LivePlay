﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LivePlay.Server.Persistence.EntityModels.Base;

[Table("QRQuest")]
public class QRQuestEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public int QuestId { get; set; }
    [Required]
    public byte[] QRInfo { get; set; }

    public required QuestEntityModel Quest { get; set; }
}
