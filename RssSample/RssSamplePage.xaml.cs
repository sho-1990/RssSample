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
            list.ItemsSource = rssDatas;
        }
    }
}
