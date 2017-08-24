using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Cliente.Models.Entities;
using Cliente.Models.Services;
using Prism.Services;

namespace Cliente.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        private readonly RestCidade _restCidade;

        // TROQUEI PARA OBSERVABLE COLLECTION POIS ESTA JÁ IMPLEMENTA INOTIFYPROPERTYCHANGED
        // E É ENTÃO O TIPO DE OBJETO CORRETO PARA LISTAS QUE PRECISAM DESTA IMPLEMENTAÇÃO
        public ObservableCollection<Cidade> ListaCidades { get; private set; }

        private Cidade _cidadeSelecionada;
        public Cidade CidadeSelecionada
        {
            get => _cidadeSelecionada;
            set => SetProperty(ref _cidadeSelecionada, value, ExecuteCidadeCommand);
        }

        //public DelegateCommand<Cidade> CidadeCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            _restCidade = new RestCidade();

            // GARANTINDO QUE A TASK É INVOCADA NA THREAD PRINCIPAL >> UI
            Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => await SetCitiesList());
        }

        async Task SetCitiesList()
        {
            try
            {
                var list = await _restCidade.GetCities();
                if (list == null)
                    throw new ArgumentNullException(nameof(list), "Lista de Cidades vazia.");

                // DEFININDO O NOVO VALOR DA LISTA OBSERVÁVEL QUE SERÁ O ITEMSOURCE DO PICKER
                // ISSO AQUI SERVE PARA QUALQUER LISTA QUE SEJA UTILIZADA COMO SOURCE EM CONTROLES
                // NO XAML
                ListaCidades = new ObservableCollection<Cidade>(list);

                // REQUISITANDO A NOTIFICAÇÃO DA MUDANÇA NA PROPRIEDADE DA LISTA
                RaisePropertyChanged("ListaCidades");
            }
            catch (Exception)
            {

                //throw;
                await _dialogService.DisplayAlertAsync("Ops!!!", "Não foi possível carregar as cidades. Certifique-se de que esta conectada à internet.", "OK");

            }
        }

        private async void ExecuteCidadeCommand()
        {
            if (_cidadeSelecionada == null)
                throw new ArgumentNullException(nameof(_cidadeSelecionada), "Parâmetro Cidade vazio.");

            var navigationParams = new NavigationParameters
            {
                { "cidade", _cidadeSelecionada }
            };
            //await _navigationService.NavigateAsync(new Uri("http://www.brianlagunas.com/RootPage", UriKind.Absolute));
            await _navigationService.NavigateAsync("app:///RootPage");;

           //Debug.WriteLine("ERROR NAVEGACAO: " + result);
        }

    }
}
