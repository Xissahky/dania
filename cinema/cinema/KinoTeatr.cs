using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    class KinoTeatr
    {
        private List<User> users;
        private List<Film> films;
        private CinemaSchedule cinemaSchedule;

        public KinoTeatr()
        {
            users = LoadUsers();
            films = LoadFilms();
            cinemaSchedule = new CinemaSchedule();
        }

        public void Login()
        {
            Console.WriteLine("Podaj swój adres e-mail:");
            string email = Console.ReadLine();
            Console.WriteLine("Podaj hasło:");
            string password = Console.ReadLine();

            User user = users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                Console.WriteLine($"Witaj, {user.Nickname}!");
                BuyTicket(user);
            }
            else
            {
                Console.WriteLine("Nieprawidłowy adres e-mail lub hasło. Spróbuj ponownie.");
            }
        }

        public void Register()
        {
            Console.WriteLine("Podaj swój adres e-mail:");
            string email = Console.ReadLine();

            
            if (users.Any(u => u.Email == email))
            {
                Console.WriteLine("Użytkownik o takim adresie e-mail już istnieje.");
                return;
            }

            Console.WriteLine("Podaj hasło:");
            string password = Console.ReadLine();
            Console.WriteLine("Podaj swój pseudonim:");
            string nickname = Console.ReadLine();

            User newUser = new User(email, password, nickname);
            users.Add(newUser);
            SaveUsers(users);

            Console.WriteLine($"Rejestracja zakończona sukcesem, {nickname}!");
            BuyTicket(newUser);
        }

        private void BuyTicket(User user)
        {
            while (true)
            {
                Console.WriteLine("Wybierz film:");
                foreach (Film film in films)
                {
                    Console.WriteLine($"{film.Title} - {film.Time}");
                }

                string chosenFilm = Console.ReadLine();
                Film selectedFilm = films.FirstOrDefault(f => f.Title == chosenFilm);

                if (selectedFilm != null)
                {
                    Console.WriteLine("Podaj liczbę biletów:");
                    int ticketCount = Utils.GetUserChoice(1, 10);

                    Order order = new Order(user.Nickname, selectedFilm.Title, selectedFilm.Time, ticketCount);
                    SaveOrder(order);

                    Console.WriteLine($"Bilety zarejestrowane pomyślnie dla filmu {selectedFilm.Title}, seans {selectedFilm.Time}.");

                    Console.WriteLine("Co chcesz teraz zrobić?");
                    Console.WriteLine("1. Zarejestruj bilety na inny film");
                    Console.WriteLine("2. Wyloguj się");

                    int nextActionChoice = Utils.GetUserChoice(1, 2);

                    if (nextActionChoice == 1)
                    {
                        
                    }
                    else if (nextActionChoice == 2)
                    {
                        Console.WriteLine("Wylogowano pomyślnie.");
                        break; 
                    }
                }
                else
                {
                    Console.WriteLine("Film nie znaleziony. Spróbuj ponownie.");
                }
            }
        }

        private List<User> LoadUsers()
        {
            List<User> loadedUsers = new List<User>();
            if (File.Exists("users_info.txt"))
            {
                string[] lines = File.ReadAllLines("users_info.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    loadedUsers.Add(new User(parts[0], parts[1], parts[2]));
                }
            }
            return loadedUsers;
        }

        private void SaveUsers(List<User> usersToSave)
        {
            File.WriteAllLines("users_info.txt", usersToSave.Select(u => $"{u.Email},{u.Password},{u.Nickname}"));
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

        private void SaveOrder(Order order)
        {
            File.AppendAllLines("orders.txt", new[] { $"{order.UserNickname},{order.FilmTitle},{order.FilmTime},{order.TicketCount}" });
        }
        public void DisplaySchedule()
        {
            cinemaSchedule.DisplaySchedule();
        }
    }
}
