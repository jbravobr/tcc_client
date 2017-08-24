using Prism.Navigation;
using Xamarin.Forms;

namespace Cliente.Views.Root
{
    public partial class RootPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public RootPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new Categoria());
            MasterBehavior = MasterBehavior.Split;
        }

        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;

        protected override void OnAppearing()
        {
            //Master = new RootMenu {BindingContext = this.BindingContext};
            MasterMenu.BindingContext = BindingContext;
        }
    }
}