using System.Collections.ObjectModel;
using System.Diagnostics;
using RssSample.api;
using RssSample.entity;
using Xamarin.Forms;

namespace RssSample {
    public partial class RssSamplePage : ContentPage {
        ObservableCollection<Rss> rssDatas = new ObservableCollection<Rss>();
        public RssSamplePage() {
            InitializeComponent();
            call();
        }

        private async void call() {
			rssDatas = await ApiRss.Get();
            foreach(Rss r in rssDatas) {
                Debug.WriteLine(r.title);
                Debug.WriteLine(r.link);
                Debug.WriteLine(r.pubDate);
                Debug.WriteLine(r.enclosureUrl);
                Debug.WriteLine(r.enclosureType);
            }

            list.ItemsSource = rssDatas;
        }
    }
}
