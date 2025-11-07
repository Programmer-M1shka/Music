using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicPlayer player = new MusicPlayer();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== Music Player Menu ===");
                Console.WriteLine("1 - Add Song");
                Console.WriteLine("2 - Remove Song");
                Console.WriteLine("3 - Play Current Song");
                Console.WriteLine("4 - Next Song");
                Console.WriteLine("5 - Previous Song");
                Console.WriteLine("6 - Show All Songs");
                Console.WriteLine("7 - Set Volume");
                Console.WriteLine("8 - Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Song Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Artist Name: ");
                        string artist = Console.ReadLine();
                        player.AddSong(new Song { Title = title, Artist = artist });
                        break;

                    case "2":
                        Console.Write("Enter Song Title to Remove: ");
                        string removeTitle = Console.ReadLine();
                        player.RemoveSong(removeTitle);
                        break;

                    case "3":
                        player.Play();
                        break;

                    case "4":
                        player.NextMusic();
                        break;

                    case "5":
                        player.PreviousMusic();
                        break;

                    case "6":
                        player.ShowAllSongs();
                        break;

                    case "7":
                        Console.Write("Set Volume (0-100): ");
                        if (int.TryParse(Console.ReadLine(), out int vol))
                        {
                            player.Volume = vol;
                            Console.WriteLine($"Volume set to {player.Volume}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "8":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}
