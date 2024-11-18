public class FlashcardTester
{
    private readonly FlashcardManager _manager;

    public FlashcardTester(FlashcardManager manager)
    {
        _manager = manager;
    }

    public void StartTest(string deckName)
    {
        var decks = _manager.LoadDecks();
        var deck = decks.FirstOrDefault(d => d.Name == deckName);

        if (deck == null || deck.Flashcards.Count == 0)
        {
            Console.WriteLine("Talia nie istnieje lub jest pusta.");
            return;
        }

        foreach (var card in deck.Flashcards)
        {
            Console.WriteLine($"Pytanie: {card.Question}");
            Console.Write("Odpowiedü: ");
            string userAnswer = Console.ReadLine();

            if (userAnswer?.Trim().ToLower() == card.Answer.ToLower())
            {
                Console.WriteLine("Dobrze!");
                card.CorrectAttempts++;
            }
            else
            {
                Console.WriteLine($"èle! Prawid≥owa odpowiedü: {card.Answer}");
                card.IncorrectAttempts++;
            }
        }

        _manager.SaveDecks(decks);
    }
}
