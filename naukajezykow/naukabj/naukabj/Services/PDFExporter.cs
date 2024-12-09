using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Borders;
using iText.Kernel.Pdf.Canvas.Draw;

public class PDFExporter
{
    public void ExportToPDF(string deckName, List<Flashcard> flashcards)
    {
        string fileName = $"{deckName}.pdf";

        using var writer = new PdfWriter(fileName);
        using var pdf = new PdfDocument(writer);
        var document = new Document(pdf);

        document.Add(new Paragraph($"Talia: {deckName}").SetFontSize(20));

        foreach (var card in flashcards)
        {
            document.Add(new Paragraph($"Pytanie: {card.Question}"));
            document.Add(new Paragraph($"Odpowiedü: {card.Answer}"));

            // Dodaj separator linii
            var lineSeparator = new LineSeparator(new SolidLine());
            document.Add(lineSeparator);
        }

        document.Close();
        Console.WriteLine($"Eksportowano do {fileName}");
    }
}
