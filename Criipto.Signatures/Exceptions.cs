using System;
namespace Criipto.Signatures;

public class GraphQLException : Exception
{
    public GraphQLException()
    {
    }

    public GraphQLException(string message)
        : base(message)
    {
    }

    public GraphQLException(string message, Exception inner)
        : base(message, inner)
    {
    }
}