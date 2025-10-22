namespace Backend.Models;

public class Review
{
    public User Author { get; private set; }
    public string Text { get; private set; }
    public string ImagePath { get; private set; }
}