namespace Iskra.Core;

public sealed class HydrationMismatchException : Exception
{
    public HydrationMismatchException(string message) : base(message)
    {
    }
}
