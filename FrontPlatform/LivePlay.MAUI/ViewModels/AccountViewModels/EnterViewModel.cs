﻿
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.OverApplicationSettings;
using LivePlay.Front.MAUI.Pages;
using LivePlay.Front.MAUI.Pages.AccountPages;
using LivePlay.Front.MAUI.Pages.AdminPages;
using LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;
using LivePlay.Front.MAUI.Pages.Reward;
using LivePlay.Front.MAUI.Services;

namespace LivePlay.Front.MAUI.Models.ViewModels.AccountViewModels;

public partial class EnterViewModel(NavigateThrowLoading navigateThrowLoading, DeviceDesignSettings designSettings, DevicePermissions permissions) : BaseViewModel(designSettings)
{
    public DevicePermissions Permissions { get; } = permissions;
    public NavigateThrowLoading NavigateLoading { get; } = navigateThrowLoading;

    [ObservableProperty]
    public string _email = string.Empty;

    [ObservableProperty]
    public string _password = string.Empty;

    [RelayCommand]
    public async Task LoginUser()
    {
        RequestPermissions:
        bool havePermissions = await Permissions.GetPermission();
        if (!havePermissions)
        {
            if (await Shell.Current.DisplayAlert("Нет доступа к хранилищу", $"Предоставьте, пожалуйста, доступ к хранилищу", "ok", "no"))
                goto RequestPermissions;
            else
                return;
        }

        

        await NavigateLoading.GoToRootPage($"//{nameof(MainPage)}");

        //if (Email == "tre@gmail.com")
        //    await NavigateLoading.GoToRootPage($"//{nameof(EmptyPage)}");
        //else if (Email == "lio@gmail.com")
        //    await NavigateLoading.GoToRootPage($"//{nameof(TapeNewsPage)}");
        //else
        //    await Shell.Current.DisplayAlert("Нет доступа", $"Неправильный логин или пароль", "ok");
    }
}