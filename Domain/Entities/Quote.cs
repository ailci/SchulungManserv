namespace Domain.Entities;

public class Quote
{
    public Guid Id { get; set; }  // Id,ID, Klassenname + Id => PK
    public required string QuoteText { get; set; }
    public Author? Author { get; set; }
    public Guid AuthorId { get; set; }  // => Klassename + Id => FK
}