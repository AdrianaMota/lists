using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace lists
{
    public class Services : ContentPage
    {

        private List<places> _places = new List<places>
        {
            new places {
                 
                    id =1, 
                    location = "Hotel Santo Domingo, Santo Domingo, DR", 
                    checkIn = Convert.ToDateTime("07/19/17").Date, 
                    checkOut = Convert.ToDateTime("07/25/17").Date

                },

                new places { 

                    id=2, 
                    location = "Intercontinental, Santo Domingo, DR", 
                    checkIn = Convert.ToDateTime("01/20/18").Date, 
                    checkOut = Convert.ToDateTime("01/30/18").Date

                },

                new places { 

                    id=3, 
                    location = "Rosen Inn, Miami, USA", 
                    checkIn = Convert.ToDateTime("10/17/18").Date, 
                    checkOut = Convert.ToDateTime("10/17/18").Date

                }
        };
        public IEnumerable<places> GetRecentSearches(string filter = null)
        {
            if (String.IsNullOrWhiteSpace(filter))
                return _places;
                
            return _places.Where(s => s.location.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase));
        }
        public void DeletePlace(int placeId)
        {
            _places.Remove(_places.Single(s => s.id == placeId));

        }
    }
}

