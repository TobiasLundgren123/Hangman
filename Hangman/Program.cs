using System;
using System.Text;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "askew", "munky", "tardy", "charity", "spoiled" };
            StringBuilder sb = new StringBuilder();
            string word = wordselect(words);
            for (int i = 0; i < word.Length; i++) {
                sb.Append("_");
            }
            Console.WriteLine(sb + " has " + sb.Length + " letters in it");
            Console.WriteLine("the word is " + word);


            var keepAlive = true;

            while (keepAlive)
            {
                try
                {
                    for (int guesses = 0; guesses < 10; guesses++)
                    {
                        Console.WriteLine("This is guess number " + guesses + 1);
                        Console.Write("Either guess a letter or guess for the entire word:");
                        Console.WriteLine(sb.ToString() + " is the current word you are guessing on");
                        string guess = Console.ReadLine();
                        Console.WriteLine(guess);
                        if(guess.Length == sb.Length)
                        {
                            if(guess == sb.ToString())
                            {
                                Console.WriteLine("Congratulations, you win! " + sb + " is the correct word!");
                                keepAlive = false;
                            } else
                            {
                                Console.WriteLine("Sorry, that is not the correct word");
                                
                            }
                        } else if (guess.Length == 1)
                        {
                            if(word.Contains(guess))
                            {
                                Console.WriteLine(guess + " is in the word!");
                                int charplace = word.IndexOf(guess);
                                Console.WriteLine(charplace);
                                sb.Replace("_", guess, charplace, 1);
                            } else
                            {
                                Console.WriteLine("Sorry, that character is not in the word");
                            }
                        }
                    }
                        
                        var assignmentChoice = int.Parse(Console.ReadLine() ?? "");


                    Console.ReadKey();
                    Console.Clear();
                }
                catch
                {
                    Console.WriteLine("That is not a valid guess");
                    Console.ResetColor();
                }
            }

        }


        static string wordselect(string[] listofwords) { 
        Random random = new Random();

        int index = random.Next(listofwords.Length);
        Console.WriteLine(listofwords[index]);
            return listofwords[index];
            }

    }
}
