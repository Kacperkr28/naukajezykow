using System.Text.Json;

public class FlashcardManager
{
    private const string FilePath = "flashcards.json";

    public List<FlashcardDeck> LoadDecks()
    {
        if (!File.Exists(FilePath))
            return new List<FlashcardDeck>();

        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<FlashcardDeck>>(json) ?? new List<FlashcardDeck>();
    }

    public void SaveDecks(List<FlashcardDeck> decks)
    {
        string json = JsonSerializer.Serialize(decks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

    public void AddFlashcard(string deckName, Flashcard flashcard)
    {
        var decks = LoadDecks();
        var deck = decks.FirstOrDefault(d => d.Name == deckName) ?? new FlashcardDeck { Name = deckName };
        deck.Flashcards.Add(flashcard);

        if (!decks.Contains(deck))
            decks.Add(deck);

        SaveDecks(decks);
    }
}
