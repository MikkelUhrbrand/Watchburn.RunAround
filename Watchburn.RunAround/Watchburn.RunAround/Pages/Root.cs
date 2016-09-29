using Watchburn.RunAround.Pages.Entries;
using Xamarin.Forms;

namespace Watchburn.RunAround.Pages
{
	internal class Root : TabbedPage
	{
		public Root()
		{
			Title = "Welcome";

			Children.Add(new EntryNavigationPage());
			Children.Add(new ContentPage
			{
				Title = "Second page",
				Content = new StackLayout
				{
					Children =
					{
						new Label {Text = "Second page"},
						new BoxView
						{
							Color = Color.Green,
							VerticalOptions = LayoutOptions.FillAndExpand
						}
					}
				}
			});
		}
	}
}