using System.Collections.ObjectModel;
using RssSample.entity;
using Xamarin.Forms;

namespace RssSample {
    public partial class RssSamplePage : ContentPage {
        ObservableCollection<Rss> rssDatas = new ObservableCollection<Rss>();
        public RssSamplePage() {
            InitializeComponent();
            list.ItemsSource = rssDatas;
            rssDatas.Add(new Rss() { title = "title"});
        }
    }
}
