using NUnit.Framework;
using Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepository.Extenders
{
    public static class AssertExtenders
    {
        #region AssertThrowsExceptionExtenders
        public static async void ThrowsException(Func<Task> action)
        {
            var actual = await action.InvokeCatch();
            Assert.IsNotNull(actual, "Expected an exception to be thrown, but it didn't.");
        }

        public static async void DoesntThrowException(Func<Task> action)
        {
            var actual = await action.InvokeCatch();
            Assert.IsNull(actual, "Expected an exception to not be thrown, but it did.");
        }

        public static async Task<Exception> InvokeCatch(this Func<Task> action)
        {
            Exception result = null;
            try
            {
                await action();
            }
            catch (Exception exception)
            {
                result = exception;
            }
            return result;
        }
        #endregion



        #region AssertContainsExtenders
        public static void ContainsError(string expected, IEnumerable<IError> errors)
        {
            Assert.NotNull(errors);
            var matches = errors.Where(e => e.ErrorMessage.Contains(expected));
            if (matches.Count() == 0)
                Assert.Fail(String.Format("Expected an error containing message {0}, but only found the following {1} errors: {2}", expected, errors.Count(), string.Join(", ", errors.Select(e => e.ErrorMessage))));
        }

        public static void ContainsNoErrors(IEnumerable<IError> errors)
        {
            Assert.NotNull(errors);
            if (errors.Count() != 0)
                Assert.Fail(String.Format("Expected no errors but found the following {0} errors: {1}", errors.Count(), string.Join(", ", errors.Select(e => e.ErrorMessage))));
        }

        public static void ContainsSuggestion(string expected, IError error)
        {
            Assert.NotNull(error);
            var matches = error.Suggestions.Where(e => e.Contains(expected));
            if (matches.Count() == 0)
                Assert.Fail(String.Format("Expected a suggestion containing message {0}, but only found the following {1} suggestions: {2}", expected, error.Suggestions.Count(), string.Join(", ", error.Suggestions)));
        }
        #endregion
    }
}
