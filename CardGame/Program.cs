using System;
using System.Collections;
using System.Collections.Generic;

namespace CardGame
{
    enum UserOptions
    {
        PlayCard = 1,
        Shuffle,
        Restart,
        Exit
    }

    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<UserOptions> userOptions = Extensions.GetValues<UserOptions>();
            Console.WriteLine("Welcome to the cards game.");
            Console.WriteLine("Setting the deck for you.");
            Deck deck = new Deck();
            bool exit = false;
            while (!exit)
            {
                foreach (var userOption in userOptions)
                {
                    if (!(userOption == UserOptions.Restart && deck.CardsCount == 52))
                    {
                        Console.WriteLine($"{(int)userOption}. {userOption}");
                    }
                }
                var input = Console.ReadLine();
                if (!int.TryParse(input, out int key))
                {
                    Console.WriteLine("Please enter an valid key(eg. 1)");
                    continue;
                }
                if (!Enum.IsDefined(typeof(UserOptions), key))
                {
                    Console.WriteLine("Please enter an valid key from the set");
                    continue;
                }
                else
                {
                    var userOption = (UserOptions)key;
                    switch (userOption)
                    {
                        case UserOptions.PlayCard:
                            {
                                try
                                {
                                    Console.WriteLine(deck.PlayCard());
                                }
                                catch (InvalidOperationException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                catch
                                {
                                    Console.WriteLine("Some error occurred.");
                                }
                                break;
                            }
                        case UserOptions.Shuffle:
                            {
                                try
                                {
                                    deck.Suffle();
                                    Console.WriteLine("Deck has been shuffled");
                                }
                                catch (InvalidOperationException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                catch
                                {
                                    Console.WriteLine("Some error occurred.");
                                }
                                break;
                            }
                        case UserOptions.Restart:
                            {
                                try
                                {
                                    deck.Restart();
                                    Console.WriteLine("Game is restarted");
                                }
                                catch (InvalidOperationException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                catch
                                {
                                    Console.WriteLine("Some error occurred.");
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Thank you for playing the game. See ya later!!");
                                exit = true;
                                break;
                            }
                    }
                }
            }
        }
    }
}
