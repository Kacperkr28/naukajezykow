class Program
{
    static void Main()
    {
        var manager = new FlashcardManager();
        var tester = new FlashcardTester(manager);
        var exporter = new PDFExporter();
        var emailSender = new EmailSender();

        while (true) // Pętla działa dopóki użytkownik nie wybierze opcji zakończenia
        {
            Console.Clear(); // Czyści konsolę, aby łatwiej było przeglądać menu
            Console.WriteLine("Witaj w aplikacji BJ!");
            Console.WriteLine("1. Dodaj słowko");
            Console.WriteLine("2. Rozpocznij test");
            Console.WriteLine("3. Eksportuj talie do PDF");
            Console.WriteLine("4. Wyślij statystyki e-mailem");
            Console.WriteLine("5. Zakończ program");
            Console.Write("Wybierz opcję: ");

            string? choiceInput = Console.ReadLine();
            if (!int.TryParse(choiceInput, out int choice))
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                Console.ReadKey();
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Nazwa talii: ");
                    string? deckName = Console.ReadLine();

                    Console.Write("Pytanie: ");
                    string? question = Console.ReadLine();

                    Console.Write("Odpowiedź: ");
                    string? answer = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(deckName) && !string.IsNullOrWhiteSpace(question) && !string.IsNullOrWhiteSpace(answer))
                    {
                        manager.AddFlashcard(deckName, new Flashcard { Question = question, Answer = answer });
                        Console.WriteLine("Fiszka została dodana!");
                    }
                    else
                    {
                        Console.WriteLine("Wszystkie pola muszą być uzupełnione.");
                    }
                    break;

                case 2:
                    Console.Write("Nazwa talii: ");
                    deckName = Console.ReadLine();
                    tester.StartTest(deckName);
                    break;

                case 3:
                    Console.Write("Nazwa talii: ");
                    deckName = Console.ReadLine();
                    var decks = manager.LoadDecks();
                    var deck = decks.FirstOrDefault(d => d.Name == deckName);
                    if (deck != null)
                    {
                        exporter.ExportToPDF(deckName, deck.Flashcards);
                        Console.WriteLine("Talia została wyeksportowana do PDF.");
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono takiej talii.");
                    }
                    break;

                case 4:
                    Console.Write("E-mail odbiorcy: ");
                    string? email = Console.ReadLine();

                    Console.Write("Załącznik (ścieżka do pliku PDF): ");
                    string? attachment = Console.ReadLine();

                    emailSender.SendStatistics(email, "Statystyki nauki", "Twoje statystyki nauki są w załączniku.", attachment);
                    Console.WriteLine("E-mail został wysłany.");
                    break;

                case 5:
                    Console.WriteLine("Dziękujemy za skorzystanie z aplikacji Flashcards. Do zobaczenia!");
                    return; // Zakończenie programu

                default:
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    break;
            }

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby wrócić do menu...");
            Console.ReadKey();
        }
    }
}
