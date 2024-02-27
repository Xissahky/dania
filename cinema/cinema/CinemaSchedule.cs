using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    class CinemaSchedule
    {
        private List<Film> films;

        public CinemaSchedule()
        {
            films = LoadFilms();
        }

        public void DisplaySchedule()
        {
            Console.WriteLine("Cinema Schedule:");
            foreach (Film film in films)
            {
                Console.WriteLine($"{film.Title} - {film.Time}");
            }
        }

        private List<Film> LoadFilms()
        {
            List<Film> loadedFilms = new List<Film>();
            if (File.Exists("films_info.txt"))
            {
                string[] lines = File.ReadAllLines("films_info.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    loadedFilms.Add(new Film(parts[0], parts[1]));
                }
            }
            return loadedFilms;
        }
    }

}
