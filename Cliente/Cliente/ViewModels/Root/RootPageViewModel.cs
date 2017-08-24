using System;
using System.Collections.ObjectModel;

using Cliente.Helpers;
using Cliente.Models.Entities;
using Cliente.Models.Services;

using Prism.Navigation;
using Prism.Commands;
using Prism.Services;

namespace Cliente.ViewModels
{
	public class RootPageViewModel : BaseViewModel
	{
		INavigationService _navigationService { get; }
		IPageDialogService _dialogService { get; }

		MenuList _menuList = new MenuList();

		public DelegateCommand<RootMenuItem> NavegarCommand { get; private set; }
		public DelegateCommand LoginCommand { get; private set; }

		public ObservableCollection<RootMenuItem> ItensMenu { get; private set; }

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


		public RootPageViewModel(INavigationService navigationService,
		                         IPageDialogService dialogService)
		{
			_navigationService = navigationService;
			_dialogService = dialogService;

			NavegarCommand = new DelegateCommand<RootMenuItem>(ExecuteNavegarCommand);
			LoginCommand = new DelegateCommand(ExecuteLoginCommand);

			ItensMenu = new ObservableCollection<RootMenuItem>(_menuList.GetLista());
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
				await _navigationService.NavigateAsync("Login");
			}
			else
			{
				//OneSignal.Current.DeleteTag(Settings.UserSubscribeSettings);
				Settings.UserIdSettings = string.Empty;
				Settings.UserNomeSettings = string.Empty;
				Settings.UserSubscribeSettings = string.Empty;
				await _navigationService.NavigateAsync(new Uri("http://www.brianlagunas.com/NavigationPage/MainPage", UriKind.Absolute));
			}
		}

		private async void ExecuteNavegarCommand(RootMenuItem obj)
		{
			if (obj.Pagina.Equals("MainPage"))
				await _navigationService.NavigateAsync(new Uri("/NavigationPage/MainPage", UriKind.Absolute));

			//if (obj.Pagina.Equals("MainPage"))
			//  await _navigationService.NavigateAsync(obj.Pagina, null, true);

			await _navigationService.NavigateAsync("MyNavigation/" + obj.Pagina);
		}
	}

}
