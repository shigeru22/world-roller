using System;

public class InvalidValueException : Exception
{
    public InvalidValueException() : base("Invalid values used in game object.") { }
    public InvalidValueException(string message) : base($"Invalid values used in game object: {message}.") { }
}