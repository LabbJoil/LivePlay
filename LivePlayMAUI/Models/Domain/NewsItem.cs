﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Models.Domain;

public class NewsItem()
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Image { get; set; }
}
