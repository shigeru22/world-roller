using System;

public class InvalidObjectException : Exception
{
    public InvalidObjectException() : base("Wrong object triggered.") { }
    public InvalidObjectException(string message) : base($"Wrong object triggered: {message}.") { }
}