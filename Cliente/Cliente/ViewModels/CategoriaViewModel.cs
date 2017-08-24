using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Cliente.Models.Entities;
using Cliente.Models.Services;
using Prism.Navigation;
using Prism.Services;

namespace Cliente.ViewModels
{
    public class CategoriaViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        private readonly RestCategoria _restCategoria = new RestCategoria();

        

        public DelegateCommand<Categoria> CategoriaCommand { get; set; }

        private List<Categoria> _itensCategoria = new List<Categoria>();
        public List<Categoria> ListaCategorias
        {
            get => _itensCategoria;
            set => SetProperty(ref _itensCategoria, value);
        }

        private Categoria _categoriaSelecionada;
        public Categoria CategoriaSelecionada
        {
            get => _categoriaSelecionada;
            set => SetProperty(ref _categoriaSelecionada, value);
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

       

        public CategoriaViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            CategoriaCommand = new DelegateCommand<Categoria>(ExecuteCategoriaCommand);
            SetCategoriesList();
        }
        
        private async void SetCategoriesList(int categoriaPai=0)
        {
            try
            {
                ListaCategorias = await _restCategoria.GetCategories(categoriaPai);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _dialogService.DisplayAlertAsync("Ops!!!", "Não foi possível carregar as categorias. Certifique-se de que esta conectada à internet.", "OK");

            }
            finally
            {
                IsLoading = false;
            }
        }

        private void ExecuteCategoriaCommand(Categoria obj)
        {
            var p = new NavigationParameters();

            if (obj.QuantidadeEmpresas > 0)
            {
                p.Add("categoria", obj.Id);
                p.Add("categoriaNome", obj.Nome);
                _navigationService.NavigateAsync("Empresas", p);
            }
            else
            {
                p.Add("CategoriaPai", obj.Id);
                _navigationService.NavigateAsync("Categoria", p);
            }
        }
    }
}
