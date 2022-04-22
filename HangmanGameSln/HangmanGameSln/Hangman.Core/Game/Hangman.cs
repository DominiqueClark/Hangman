using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private string _myProgress;
        private int _myLives;
       
        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
             
        }



        public void Run()
        {
            _myLives = 6;
            

            _renderer.Render(5, 5, 6); // loop from 6 to 0 representing how many lives you have left.
            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Your current guess: ");


            Console.WriteLine("--------------");
            Console.SetCursorPosition(0, 17);

            Console.ForegroundColor = ConsoleColor.Green;

        
            Random random = new Random();
            string[] Mywords = { "grumpy", "hello", "song", "vote", "independance", "prestige", "relevant", "annihilate", "bejewel", "bartender", "praise", "voyage", "stallion", "underdeveloped", "ordain", "dilution", "menace", "touche", "bald", "humorous" };

            var index = random.Next(0, 9);

            string Wordlist = Mywords[index];

        
            char[] Myguess = Wordlist.ToCharArray();

            



            for (int i = 0; i < Myguess.Length; i++)
            {
                _myProgress += "_";
                Console.SetCursorPosition(0, 17);

            }

            while (_myLives > 0)
            {
                _renderer.Render(5, 5, _myLives);

                Console.SetCursorPosition(0, 17);

                char contenderguess = char.Parse(Console.ReadLine().ToLower());

                char[] myProgressArray = _myProgress.ToCharArray();

                bool accurate = false;  

                for (int i = 0; i < Myguess.Length; i++)
                {
                    if (Myguess[i] == contenderguess)
                    {
                       myProgressArray[i] = Myguess[i];
                        accurate = true;
                       

                    }

                }
                _myProgress = new string(myProgressArray);
                Console.SetCursorPosition(0, 18);

                Console.WriteLine(_myProgress);

                if (!accurate)
                {
                    _myLives--;

                    _renderer.Render(5, 5, _myLives);
                }
                

               
            }

            Console.SetCursorPosition(2, 22);

            if (_myLives > 0)
            {
                Console.WriteLine("You have survived");
            }



            if (_myLives == 0)
            {
                Console.WriteLine($"You just died{_myLives} left");
                Console.WriteLine($"Correct word:" + Wordlist);
            }
            



        }

    }
}
