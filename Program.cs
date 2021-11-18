using DatabaseConnection.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DatabaseConnection
{
    class Program
    {
        private static IConfiguration _iconfiguration;

        static void Main(string[] args)
        {
            Console.Write("Please enter the userID\n");
            var userId = int.Parse(Console.ReadLine());
            GetAppSettingsFile();
            PrintUsers(userId);
            PrintScores(userId);
        }

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }

        static void PrintUsers(int userId)
        {
            var userDal = new UserDAL(_iconfiguration);
            var listOfUsers = userDal.GetList(userId);
            listOfUsers.ForEach(item =>
            {
                Console.WriteLine(item.username);
                Console.WriteLine(item.password);
            });
        }

        static void PrintScores(int userId)
        {
            var scoreDAL = new ScoreDAL(_iconfiguration);
            var listOfUsers = scoreDAL.GetList(userId);
            listOfUsers.ForEach(item =>
            {
                Console.WriteLine("Aces :"+ item.aces);
                Console.WriteLine("Twos :" + item.twos);
                Console.WriteLine("Threes :" + item.threes);
                Console.WriteLine("UserID :" + item.userId);
            });
        }
    }
}
