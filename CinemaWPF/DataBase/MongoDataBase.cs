using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CinemaWPF.Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CinemaWPF.DataBase
{
    public class MongoDataBase
    {
        public static User CurrentUser { get; set; }
        public static Movie CurrentMovie { get; set; }
        public static Hall CurrentHall { get; set; }
        public static Session CurrentSession { get; set; }
        public static Ticket CurrentTicket { get; set; }
        public static string CurrentPlace { get; set; }
        public static bool RedMovie { get; set; }


        //Add
        public static async Task AddUserToDataBase(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<User>("UserList");
            await collection.InsertOneAsync(user);
        }

        public static async Task AddMovieToDataBase(Movie movie)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Movie>("MovieList");
            await collection.InsertOneAsync(movie);
        }

        public static async Task AddHallToDataBase(Hall hall)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Hall>("HallList");
            await collection.InsertOneAsync(hall);
        }

        public static async void AddSessionToDataBase(Session session)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Session>("SessionList");
            await collection.InsertOneAsync(session);
        }

        public static async Task AddTicketToDataBase(Ticket ticket)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Ticket>("TicketList");
            await collection.InsertOneAsync(ticket);
        }

        //Find
        public static User FindByUserLogin(string login)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<User>("UserList");
            var user = collection.Find(x => x.Login == login).FirstOrDefault();

            return user;
        }

        public static Movie FindByMovieName(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Movie>("MovieList");
            var movie = collection.Find(x => x.Name == name).FirstOrDefault();

            return movie;
        }

        public static Hall FindByHallName(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Hall>("HallList");
            var hall = collection.Find(x => x.Name == name).FirstOrDefault();
            return hall;
        }

        public static Session FindSessionByDate(string date, Movie movie, string hallName)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Session>("SessionList");
            var session = collection.Find(x => x.Movie.Id == movie.Id).ToList().Where(x => x.Time.ToString("g") == date && x.Hall.Name == hallName).FirstOrDefault();
            return session;
        }

        public static Ticket FindTicketByName(ObjectId id)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Ticket>("TicketList");
            var ticket = collection.Find(x => x.Id == id).FirstOrDefault();

            return ticket;
        }

        //Replace
        public static async Task UserReplace(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<User>("UserList");
            await collection.ReplaceOneAsync(x => x.Id == user.Id, user);
        }

        public static async Task MovieReplace(Movie movie)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Movie>("MovieList");
            await collection.ReplaceOneAsync(x => x.Id == movie.Id, movie);
        }

        public static async Task SessionReplace(Session session)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Session>("SessionList");
            await collection.ReplaceOneAsync(x => x.Id == session.Id, session);
        }

        //Delete
        public static async Task DeleteUser(ObjectId id)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<User>("UserList");
            await collection.DeleteOneAsync(x => x.Id == id);
        }

        public static async Task DeleteMovie(ObjectId id)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Movie>("MovieList");
            await collection.DeleteOneAsync(x => x.Id == id);
        }

        public static async Task DeleteTicket(ObjectId id)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Ticket>("TicketList");
            await collection.DeleteOneAsync(x => x.Id == id);
        }

        public static async Task DeleteSession(ObjectId id)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Session>("SessionList");
            await collection.DeleteOneAsync(x => x.Id == id);
        }

        /*public static void DeleteExpiredTicket()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Ticket>("TicketList");
            collection.DeleteMany(x => DateTime.Now > x.DateTimeCreate);
        }*/

        //Get
        public static List<Movie> GetMovieList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Movie>("MovieList");
            var movies = collection.Find(x => true).ToList();
            var movieList = new List<Movie>();

            foreach (var m in movies)
            {
                movieList.Add(m);
            }

            movieList.Reverse();
            return movieList;
        }

        public static List<Session> GetSessionList(Movie movie, string hallName)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Session>("SessionList");
            var sessions = collection.Find(x => x.Movie.Id == movie.Id).ToList().Where(x => x.Hall.Name == hallName);
            var sessionList = new List<Session>();

            foreach (var s in sessions)
            {
                sessionList.Add(s);
            }
            return sessionList;
        }

        public static List<string> GetSessionTimeList(string date, string hallName, Movie movie)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Session>("SessionList");
            var sessions = collection.Find(x => x.Movie.Id == movie.Id).ToList().Where(x => x.Time.ToString("d") == date && x.Hall.Name == hallName);
            var timeList = new List<string>();

            foreach (var s in sessions)
            {
                timeList.Add(s.Time.ToString("t"));
            }

            return timeList;
        }

        public static List<string> GetHallList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Hall>("HallList");
            var halls = collection.Find(x => true).ToList();
            var hallList = new List<string>();

            foreach (var h in halls)
            {
                hallList.Add(h.Name);
            }
            return hallList;
        }

        public static List<Ticket> GetTicketList(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Cinema_WPF_DB");
            var collection = database.GetCollection<Ticket>("TicketList");
            var tickets = collection.Find(x => x.User == user).ToList();
            var ticketList = new List<Ticket>();

            foreach (var t in tickets)
            {
                ticketList.Add(t);
            }

            ticketList.Reverse();

            return ticketList;
        }
    }
}
