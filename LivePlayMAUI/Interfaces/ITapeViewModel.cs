using CommunityToolkit.Mvvm.ComponentModel;
using LivePlayMAUI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Interfaces;

interface ITapeViewModel
{
    public bool IsRefreshing { get; set; }
    public void Refresh();

    public void GoToTapeItem(object item);

}
