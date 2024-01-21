namespace PaparaApp.API.Exceptions;

public class ClientValidationError : Exception
{
    public ClientValidationError(string message) : base(message)
    {
    }
}