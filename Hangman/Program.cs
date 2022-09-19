using System;
using System.Text;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "askew", "munky", "tardy", "charity", "spoiled" };
            string guessedchars = "";
            StringBuilder sb = new StringBuilder();
            string word = wordselect(words);
            for (int i = 0; i < word.Length; i++) {
                sb.Append("_");
            }
            //Console.WriteLine(sb + " has " + sb.Length + " letters in it");
            //Console.WriteLine("the word is " + word);


            var keepAlive = true;

            while (keepAlive)
            {
                try
                {
                    for (int guesses = 0; guesses < 10; guesses++)
                    {
                        Console.WriteLine("This is guess number " + guesses + 1);
                        Console.Write("Either guess a letter or guess for the entire word:");
                        if (guesses > 0)
                        {
                            Console.WriteLine("Guesses so far: " + guessedchars);
                        }

                        Console.WriteLine(sb.ToString() + " is the current word you are guessing on");
                        string guess = Console.ReadLine();
                        if(guess.Length == sb.Length)
                        {
                            if (guess.Contains(word))
                            {
                                Console.WriteLine("Congratulations, you win! " + word + " is the correct word!");
                                keepAlive = false;
                                //break;

                            } else
                            {
                                Console.WriteLine("Sorry, that is not the correct word");
                                
                            }
                        } else if (guess.Length == 1)  {
                            if (guessedchars.Contains(guess) || sb.ToString().Contains(guess)) {
                                Console.WriteLine("You have already guessed that char. Try again");
                                    guesses -= 1;
                            }

                            else if(word.Contains(guess))
                            {
                                Console.WriteLine(guess + " is in the word!");
                                int charplace = word.IndexOf(guess);
                                sb.Replace("_", guess, charplace, 1);
                            } else
                            {
                                Console.WriteLine("Sorry, that character is not in the word");
                                guessedchars = guessedchars.Insert(0, guess);
                                guessedchars = String.Concat(guessedchars.OrderBy(c => char.ToLower(c)));
                                
                            }
                        } else
                        {
                            Console.WriteLine("Try again - guess one character or the entire word");
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
        //Console.WriteLine(listofwords[index]);
            return listofwords[index];
            }

    }
}
