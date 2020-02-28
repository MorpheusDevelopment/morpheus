using System.Collections.Generic;

namespace Objects.Interfaces
{
    public interface IResult<out T>
    {
        IList<IError> Errors { get; }
        bool Successful { get; }
        T Value { get; }
    }
}
