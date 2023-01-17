using Azure.Core.GeoJson;
using ConsoleApp1.Model.Context;
using ConsoleApp1.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Dynamic;
using System.Threading.Channels;
using System.IO;
using ConsoleApp1;
using Microsoft.Identity.Client;
using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

class Program
{

    static void Main(string[] args)
    {
        ServiceProvider serviceProvider = new ServiceCollection()
                                           .AddDbContext<WordDbContext>(options =>
                                           options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TutorialDB;Trusted_Connection=True;"), ServiceLifetime.Scoped , ServiceLifetime.Scoped)
                                           .AddTransient<Controllers>()
                                           .BuildServiceProvider();




        Controllers control = serviceProvider.GetService<Controllers>();

        Console.WriteLine("");
        Console.WriteLine("WELCOME TO HANGMAN");
        int count = 5;
        String random_word = control.getRandomWord();   /////random word from db    


        String guess = control.createQuestion(random_word);

        while (guess.Contains("_") && count > 0)
        {
            Console.WriteLine("Enter the letter");

            char letter = Convert.ToChar(Console.ReadLine());

            {

                Console.WriteLine("Enter the letter");
                try
                {
                    if (control.checkTheGuess(random_word, letter))
                    {
                        Console.WriteLine("Correct");
                        for (int i = 0; i < random_word.Length; i++)
                        {
                            if (random_word[i] == letter)
                            {
                                guess = guess.Substring(0, i) + letter + guess.Substring(i + 1);

                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Wrong");
                        count--;
                        if (control.IsGameOver(count))
                        {
                            Console.WriteLine("Game Over");
                            Console.WriteLine("the word was " + random_word);
                        }
                        else
                        {
                            Console.WriteLine("You have " + count + " guesses left");
                        }
                    }
                    Console.WriteLine(guess);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


        }
    }
}



