using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    class Order
    {
        public string UserNickname { get; }
        public string FilmTitle { get; }
        public string FilmTime { get; }
        public int TicketCount { get; }

        public Order(string userNickname, string filmTitle, string filmTime, int ticketCount)
        {
            UserNickname = userNickname;
            FilmTitle = filmTitle;
            FilmTime = filmTime;
            TicketCount = ticketCount;
        }
    }
}
