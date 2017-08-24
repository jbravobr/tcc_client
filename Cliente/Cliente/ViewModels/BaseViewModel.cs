using Prism.Mvvm;
using Prism.Navigation;

namespace Cliente.ViewModels
{
	public class BaseViewModel : BindableBase, INavigationAware
	{
		public virtual void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public virtual void OnNavigatedTo(NavigationParameters parameters)
		{

		}

		public virtual void OnNavigatingTo(NavigationParameters parameters)
		{

		}
	}
}
