namespace Projekt_Kontenery;


public class OverfillException : Exception
{
    public OverfillException(string? message) : base(message)
    {
        
    }
}