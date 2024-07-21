namespace KuzyaBackend.Services.Exceptions;

public class NoSuchEntityInDatabaseException(string message) : Exception(message);