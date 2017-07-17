using System;
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
            setupThumbnails();
            list.ItemsSource = rssDatas;
            list.ItemTapped += (object sender, ItemTappedEventArgs e) => {
                Rss r = (Rss)e.Item;
                string url = r.link;
                if (url != null) {
                    Device.OpenUri(new Uri(url));
                }
            };
        }

        private void setupThumbnails() {
			foreach (Rss r in rssDatas) {
				if (r.enclosureUrl != null) {
					r.thumbnail = ImageSource.FromUri(new Uri(r.enclosureUrl));
				}
			}
        }
    }
}
