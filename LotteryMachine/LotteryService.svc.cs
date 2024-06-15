using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace LotteryMachine
{
    public class LotteryService : ILotteryMachineService, IPlayerService
    {
        private static List<Player> players = new List<Player>();
        private static ICallBack proxy;
        delegate void MessageArrivedDelegate(string message);
        static event MessageArrivedDelegate onMessageArrived;
        private static Dictionary<string, ICallBack> playersCallBacks = new Dictionary<string, ICallBack>(); 


        public void InitPlayer(string playerName, int number1, int number2, double amount)
        {
            proxy = OperationContext.Current.GetCallbackChannel<ICallBack>();

            if (players.Exists(p => p.Name == playerName))
            {
                proxy.MessageArrived($"Player with the name {playerName} already exists.");
                return;
            }

            onMessageArrived += OperationContext.Current.GetCallbackChannel<ICallBack>().MessageArrived;
            playersCallBacks.Add(playerName, proxy);

            players.Add(new Player { Name = playerName, Number1 = number1, Number2 = number2, Amount = amount });
            proxy.MessageArrived($"Player {playerName} has entered the game with numbers {number1} and {number2}, betting {amount}.");

        }

        public void DrawNumbers()
        {

            int drawnNumber1 = GenerateRandomNumber();
            int drawnNumber2;

            do
            {
                drawnNumber2 = GenerateRandomNumber();
            }
            while (drawnNumber1 == drawnNumber2);

            Dictionary<string, double> playersGuessedNumbers = new Dictionary<string, double>();

            onMessageArrived?.Invoke($"\n\nDrawn numbers are: {drawnNumber1} and {drawnNumber2}\n");

            int countWinners = 0;
            foreach (var player in players)
            {

                if ((player.Number1 == drawnNumber1 && player.Number2 == drawnNumber2) || (player.Number1 == drawnNumber2 && player.Number2 == drawnNumber1))
                {
                    countWinners++;
                    playersGuessedNumbers.Add(player.Name, 2);
                    playersCallBacks[player.Name].MessageArrived($"You guessed 2/2 of numbers and WON the sum:{player.Amount * 5}");
                }
                else if (player.Number1 == drawnNumber1 || player.Number2 == drawnNumber2 || player.Number1 == drawnNumber2 || player.Number2 == drawnNumber1)  
                {
                    playersGuessedNumbers.Add(player.Name, 1);
                    playersCallBacks[player.Name].MessageArrived($"You guessed one of the two numbers and won the sum of your last payment:{player.Amount}");
                }
                else
                {
                    playersGuessedNumbers.Add(player.Name, 0);
                    playersCallBacks[player.Name].MessageArrived($"You have not guessed either of the two numbers and won amount: 0");
                }
            }
            Dictionary<string, double> sortedPlayers = SortPlayersAmount(playersGuessedNumbers);

            int ranking = 1;
            foreach(var player in sortedPlayers)
            {
                playersCallBacks[player.Key].MessageArrived($"Your ranking in the table of all players is {ranking}. in terms of hit combination numbers\n\n");
                ranking++;
            }

            onMessageArrived?.Invoke($"\nThe new game begins, pay your combinations");
            playersCallBacks = new Dictionary<string, ICallBack>();
            players = new List<Player>();
            onMessageArrived = null;

        }

        private int GenerateRandomNumber()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[1];
                do
                {
                    rng.GetBytes(randomNumber);
                }
                while (randomNumber[0] >= 250);

                return (randomNumber[0] % 10) + 1; 
            }
        }
        public static Dictionary<string, double> SortPlayersAmount(Dictionary<string, double> playersAmount)
        {
            return playersAmount
                .OrderByDescending(pair => pair.Value)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private class Player
        {
            public string Name { get; set; }
            public int Number1 { get; set; }
            public int Number2 { get; set; }
            public double Amount { get; set; }
        }
    }

}
