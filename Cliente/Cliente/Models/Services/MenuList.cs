using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Helpers;
using Cliente.Models.Entities;

namespace Cliente.Models.Services
{
    public class MenuList
    {
        private readonly List<RootMenuItem> _lista = new List<RootMenuItem>();
        public MenuList()
        {
            MenuLista();
        }

        public List<RootMenuItem> GetLista()
        {
            return _lista;
        }

        public void MenuLista()
        {
            _lista.Clear();
            _lista.Add(
                new RootMenuItem
                {
                    Nome = "Cidades",
                    Pagina = "MainPage",
                    Icone = "ic_location_city_black.png"
                });
            _lista.Add(
                new RootMenuItem
                {
                    Nome = "Categorias",
                    Pagina = "Categoria",
                    Icone = "ic_dashboard_black.png"
                });

            if (Settings.IsLoggedIn)
            {
                _lista.Add(
                    new RootMenuItem
                    {
                        Nome = "Minhas Mensagens",
                        Pagina = "MinhasMensagens",
                        Icone = "ic_chat_black.png"
                    });
            }

            _lista.Add(
                new RootMenuItem
                {
                    Nome = "Quero Anunciar",
                    Pagina = "QueroAnunciar",
                    Icone = "ic_assignment_black.png"
                });
            _lista.Add(
                new RootMenuItem
                {
                    Nome = "Fale Conosco",
                    Pagina = "FaleConosco",
                    Icone = "email.png"
                });

            if (Settings.IsLoggedIn)
            {
                _lista.Add(
                    new RootMenuItem
                    {
                        Nome = "Sair",
                        Pagina = "Empresa",
                        Icone = "ic_exit_to_app_black.png"
                    });
            }
        }
    }
}
