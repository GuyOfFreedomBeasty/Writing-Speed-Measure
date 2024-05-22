using System;

namespace MyApp
{
    internal class Program
    {
        static double timeLimit = 15;

        static void Main(string[] args)
        {
            string[] wordsArray = {"hello", "watermelon", "sleep", "happy", "because", "education", "he", "did", "experimental", "worked", "made", "citizen", "when", "fifth"};

            Console.Write("Welcome! Press 'Enter' to start!");
            Console.ReadLine();

            string textToWrite = GetRandomSentance(wordsArray, 30);
            StartTheChallange(textToWrite);
        }

        public static void StartTheChallange(string textToWrite)
        {
            Thread startTimerThread = new Thread(StartTimer);
            startTimerThread.Start();

            Console.Clear();
            Console.Write(textToWrite);
            Console.Write("\nCopy The Text: ");
            string writtenText = Console.ReadLine();

            Console.Clear();

            string[] writtenSplittedWords = writtenText.Split(" ");
            string[] textToWriteSplittedWords = textToWrite.Split(" ");

            double amountOfMatches = GetMatchingsAmount(writtenSplittedWords, textToWriteSplittedWords);

            double writingSpeed = amountOfMatches / (timeLimit / 60);

            Console.WriteLine("Your Speed Is: " + writingSpeed + " WPM");
        }

        public static double GetMatchingsAmount(string[] writtenSplittedWords, string[] wordsToWrite)
        {
            double amount = 0;

            for (int i = 0; i < wordsToWrite.Length; i++)
            {
                bool writtenWordExistsInSentence = Array.IndexOf(writtenSplittedWords, wordsToWrite[i]) != -1;

                if (writtenWordExistsInSentence)
                {
                    writtenSplittedWords[Array.IndexOf(writtenSplittedWords, wordsToWrite[i])] = null;
                    amount++;
                }
            }

            return amount;
        }

        public static void StartTimer()
        {
            DateTime startTime = DateTime.Now;

            while (true)
            {
                DateTime currentTime = DateTime.Now;
                int timePassed = (currentTime - startTime).Seconds;

                if (timePassed > timeLimit)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nTime's Up! (Press enter to stop)");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }
        }

        public static string GetRandomSentance(string[] wordsArray, int amountOfWords)
        {
            string result = "";

            for (int i = 0; i < amountOfWords; i++)
            {
                Random rnd = new Random();

                string randomWord = wordsArray[rnd.Next(0, wordsArray.Length)];
                result += randomWord + " ";
            }

            return result;
        }
    }
}