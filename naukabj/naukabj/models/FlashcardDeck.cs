using System.Collections.Generic;

public class FlashcardDeck
{
    public string Name { get; set; }
    public List<Flashcard> Flashcards { get; set; } = new();
}
