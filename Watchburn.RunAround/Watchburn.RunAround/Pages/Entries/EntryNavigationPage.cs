using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Watchburn.RunAround.Services;
using Xamarin.Forms;

namespace Watchburn.RunAround.Pages.Entries
{
	internal class EntryNavigationPage : ContentPage
	{
		private static readonly ObservableCollection<string> ScannedValues = new ObservableCollection<string>();
		private Label _label;

		public EntryNavigationPage()
		{
			_label = new Label();
			ScannedValues.Add("Something");

			Title = "Entries";

			var scanButton = new Button
			{
				Text = "Scan QR-code"
			};
			scanButton.Clicked += ScanButtonClicked;

			var entries = new ListView
			{
				BindingContext = ScannedValues,
				ItemsSource = ScannedValues
			};

			Content = new StackLayout
			{
				Children =
				{
					new Label {Text = "Entries"},
					scanButton,
					entries,
					_label
				}
			};
		}

		private async void ScanButtonClicked(object send, EventArgs args)
		{
			try
			{
				var scanningService = DependencyService.Get<IQrCodeScanningService>();
				var output = await scanningService.ScanAsync();

				ScannedValues.Add($"scanned: {output}");
			}
			catch (Exception e)
			{
				_label.Text = e.Message;
			}
		}
	}
}