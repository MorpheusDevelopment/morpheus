using System.Collections.Generic;

namespace Objects.Interfaces
{
    public interface IError
    {
        string ErrorMessage { get; }
        IEnumerable<string> Suggestions { get; }
    }
}
