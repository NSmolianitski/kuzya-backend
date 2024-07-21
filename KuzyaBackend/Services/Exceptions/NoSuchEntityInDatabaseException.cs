namespace Kuzya_Backend.Services.Exceptions;

public class NoSuchEntityInDatabaseException(string message) : Exception(message);