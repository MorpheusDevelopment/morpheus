using Objects.Interfaces;
using System.Collections.Generic;

namespace Objects.Generics
{
    public class Result<T> : IResult<T>
    {
        public IList<IError> Errors { get; set; }
        public T Value { get; set; }

        public bool Successful { get { return Errors == null || Errors.Count == 0; } }

        public Result() => Errors = new List<IError>();
    }
}
