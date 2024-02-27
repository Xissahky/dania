using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    class Film
    {
        public string Title { get; }
        public string Time { get; }

        public Film(string title, string time)
        {
            Title = title;
            Time = time;
        }
    }
}
