using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageLearningQuiz.Models;
using LanguageLearningQuiz.Services;

namespace LanguageLearningQuiz
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Witaj w nauka bj!");
            int correctAnswers = 0;

            var questions = new List<Question>
            {
                new Question("Jak jest 'Cześć' po Hiszpańsku?", "Hola"),
                new Question("Jak jest 'Do widzenia' po Francusku?", "Au revoir"),
                new Question("Jak jest 'Dziękuję' po Niemiecku?", "Danke"),
                new Question("Jak jest 'Proszę' po Włosku?", "Per favore"),
            };

            foreach (var question in questions)
            {
                Console.WriteLine(question.Text);
                string userAnswer = Console.ReadLine()?.Trim();

                if (userAnswer?.ToLower() == question.Answer.ToLower())
                {
                    Console.WriteLine("Poprawnie!");
                    correctAnswers++;
                }
                else
                {
                    Console.WriteLine($"Nieprawidłowo. Odpowiedź to: {question.Answer}");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Odpowiedziałeś {correctAnswers} na {questions.Count} pytań poprawnie!");

            Console.WriteLine("Podaj mail do wysłania wyników: ");
            string email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                await EmailService.SendResultsViaEmail(email, correctAnswers, questions.Count);
            }

            Console.WriteLine("Dziękujemy!");
        }
    }
}
