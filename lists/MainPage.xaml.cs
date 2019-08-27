using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace lists
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private Services _Services;
        private List<placesGroup> _placesGroup;

        public MainPage()
        {
            InitializeComponent();

            _Services = new Services();

            list(_Services.GetRecentSearches());
        }
        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            list(_Services.GetRecentSearches(e.NewTextValue));
        }

        private void list(IEnumerable<places> searches)
        {
            _placesGroup = new List<placesGroup>
            {
                new placesGroup("Recent Searches", searches)
            };

            listView.ItemsSource = _placesGroup;
        }
        void Delete_Clicked(object sender, System.EventArgs e)
        {
            var place = (sender as MenuItem).CommandParameter as places;

            _placesGroup[0].Remove(place);
            _Services.DeletePlace(place.id);

        }
        void Handle_Refreshing(object sender, System.EventArgs e)
        {
            list(_Services.GetRecentSearches(searchBar.Text));
            listView.EndRefresh();
        }
        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var place = e.Item as places;
            DisplayAlert(place.location, string.Format("Check in: {0} \n Check out: {1}", place.checkIn, place.checkOut), "OK");
        }


    }
}
