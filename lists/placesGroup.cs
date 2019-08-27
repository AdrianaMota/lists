using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace lists
{
    public class placesGroup : List<places>
    {
        public string Title { get; set; }
        public int Id { get; internal set; }

        public placesGroup(string title, IEnumerable<places> searches = null) : base(searches)
        {
            Title = title;
        }

    }
}

