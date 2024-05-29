﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Interfaces;
using LivePlayMAUI.Services;
using LivePlayMAUI.Models.Enum;
using System.Collections.ObjectModel;

namespace LivePlayMAUI.Abstracts;

public abstract partial class MainTapeViewModel(DeviceDesignSettings designSettings) : BaseViewModel(designSettings)
{
    //public ObservableCollection<object> TapeItems { get; protected set; } = [];

    public abstract Task GoToTapeItem(object item);
}
