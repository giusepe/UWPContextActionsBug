using Xamarin.Forms;

namespace UWPContextActionsBug
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            BindingContext = new MainPageViewModel();
            InitializeComponent();
		}
	}
}
