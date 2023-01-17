using ConsoleApp1.Model.Context;
using ConsoleApp1.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Controllers
    {
        WordDbContext _dbContext;

        public Controllers(WordDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Boolean checkTheGuess(String word, char letter) { return (word.Contains(letter)); }



        public Boolean IsGameOver(int count) { return (count == 0); }

        public String createQuestion(String random_word)
        {
            String guess = "";
            int wordlen = random_word.Length;

            for (int i = 0; i < wordlen; i++)
            {
                if (random_word[i] == ' ')
                    guess += " ";
                else
                    guess += "_";

            }
            Console.WriteLine(guess);
            return guess;
        }

        public String getRandomWord()
        {
            List<String> words = new List<String>();

            //using (WordDbContext _dbContext = new WordDbContext())
            //{
            //    foreach (var item in _dbContext.Words)
            //    {
            //        Console.WriteLine($"{item.ID} {item.Word}");
            //        words.Add(item.Word);
            //    };
            //}

            WordDbContext _dbContext = new WordDbContext();

            foreach (var item in _dbContext.Words)
            {
                Console.WriteLine($"{item.ID} {item.Word}");
                words.Add(item.Word);
            };

            _dbContext.Dispose();

            Random random = new Random();
            int index = random.Next(words.Count);
            return words[index];
            return "";
        }


    }
}
