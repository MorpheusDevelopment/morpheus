using Objects.Interfaces;
using System.Collections.Generic;

namespace Objects
{
    public class Error : IError
    {
        public string ErrorMessage { get; set; }
        public IEnumerable<string> Suggestions { get; set; }
    }
}
