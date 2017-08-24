using System;
using System.Collections.Generic;
using System.Linq;
using Cliente.Models.Services;
using Cliente.ViewModels;
using Xamarin.Forms;

namespace Cliente.Views
{
    public partial class Categoria : ContentPage
    {
        //private readonly RestCategoria _restCategoria = new RestCategoria();
        
        
        public Categoria()
        {
            InitializeComponent();
            
        }

        /*public void GeraGrid()
        {
            var vm = BindingContext as CategoriaViewModel;
            //var lista = await _restCategoria.GetCategories(0);
            var lista = vm.ListaCategorias;

            var qtdRow = Math.Ceiling(Convert.ToDouble(lista.Count) / 2);
            
            var grid = new Grid();
            //grid.HorizontalOptions = LayoutOptions.CenterAndExpand;
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            for (var a = 0; a <= qtdRow; a++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star)});
            }
            //for (var x = 0; x <= qtdRow; x++)
            var row = 0;
            var col = 0;
            foreach (var item in lista)
            {
                var celula = new Label { Text = item.Nome, HorizontalTextAlignment = TextAlignment.Center, Margin = new Thickness(0,10)};
                grid.Children.Add(celula, col, row);
                if (col == 1)
                {
                    col = 0;
                    row++;
                }
                else
                {
                    col++;
                }
            }
            stack.Children.Add(grid);
            //grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1,GridUnitType.Star) });
            
        }*/
    }
}
