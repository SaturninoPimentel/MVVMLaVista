using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DemoView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void BtnBehaviors_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Behaviors));
        }

        private void BtnResources_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Resources));
        }

        private void BtnStyles_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StylesPage));
        }

        private void BtnTransformations_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Transformations));
        }

        private void ellipse_Loaded(object sender, RoutedEventArgs e)
        {
            Motion.Begin(); 
        }
    }
}
