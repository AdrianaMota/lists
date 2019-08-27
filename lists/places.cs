using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace lists
{
    public class places : ContentPage
    {
        public static List<placesGroup> ItemsSource { get; internal set; }
        public int id { get; set; }
        public string location { get; set; }
        public DateTime checkIn{ get; set; }
        public DateTime checkOut { get; set; }
        public string dates {
            get
            {
                return String.Format("{0} - {1}", checkIn.Date, checkOut.Date);
            } 
       
         }

    }
}

