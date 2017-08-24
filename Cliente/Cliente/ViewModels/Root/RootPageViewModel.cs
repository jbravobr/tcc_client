using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Cliente.Helpers;
using Cliente.Models.Entities;
using Cliente.Models.Services;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;


namespace Cliente.ViewModels.Root
{
    
        public class RootPageViewModel : BaseViewModel
        {
            private readonly INavigationService _navigationService;
            IPageDialogService _dialogService;
            private readonly MenuList _menuList = new MenuList();
            public DelegateCommand<RootMenuItem> NavegarCommand { get; set; }
            public DelegateCommand LoginCommand { get; set; }

            private List<RootMenuItem> _itensMenu = new List<RootMenuItem>();
            public List<RootMenuItem> ItensMenu
            {
                get => _itensMenu;
                set => SetProperty(ref _itensMenu, value);
            }

            private RootMenuItem _listMenuItem;
            public RootMenuItem ListMenuItem
            {
                get => _listMenuItem;
                set { SetProperty(ref _listMenuItem, value); ExecuteNavegarCommand(value); }
            }

            private string _cidadeNome;
            public string CidadeNome
            {
                get => _cidadeNome;
                set => SetProperty(ref _cidadeNome, value);
            }

            private string _loginIcone;
            public string LoginIcone
            {
                get => _loginIcone;
                set => SetProperty(ref _loginIcone, value);
            }

            private string _loginText;
            public string LoginText
            {
                get => _loginText;
                set => SetProperty(ref _loginText, value);
            }


            public RootPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            {
                _navigationService = navigationService;
                _dialogService = dialogService;
                NavegarCommand = new DelegateCommand<RootMenuItem>(ExecuteNavegarCommand);
                LoginCommand = new DelegateCommand(ExecuteLoginCommand);
                ItensMenu = _menuList.GetLista();

                LoginLogout();

            }

            private void LoginLogout()
            {
                if (Settings.IsLoggedIn)
                {
                    LoginIcone = "ic_exit_to_app_black.png";
                    LoginText = "SAIR";
                }
                else
                {
                    LoginIcone = "ic_person_white.png";
                    LoginText = "LOGAR";
                }
            }

            private async void ExecuteLoginCommand()
            {
                if (!Settings.IsLoggedIn)
                {
                    await _navigationService.NavigateAsync("Login", null, true);
                }
                else
                {
                    //OneSignal.Current.DeleteTag(Settings.UserSubscribeSettings);
                    Settings.UserIdSettings = string.Empty;
                    Settings.UserNomeSettings = string.Empty;
                    Settings.UserSubscribeSettings = string.Empty;
                    await _navigationService.NavigateAsync(new Uri("http://www.brianlagunas.com/MyNavigation/MainPage", UriKind.Absolute));
                }

            }

            

            private async void ExecuteNavegarCommand(RootMenuItem obj)
            {
                if (obj.Pagina.Equals("MainPage"))
                    await _navigationService.NavigateAsync(new Uri("http://www.brianlagunas.com/MyNavigation/MainPage", UriKind.Absolute));

                //if (obj.Pagina.Equals("MainPage"))
                  //  await _navigationService.NavigateAsync(obj.Pagina, null, true);

                await _navigationService.NavigateAsync("MyNavigation/" + obj.Pagina);
            }
        }

}
