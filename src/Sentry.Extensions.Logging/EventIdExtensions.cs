using Microsoft.Extensions.Logging;

namespace Sentry.Extensions.Logging
{
    internal static class EventIdExtensions
    {
        public const string TupleName = "eventId";

        /// <summary>
        /// Returns a tuple (eventId,value) if the event is not empty, otherwise null.
        /// </summary>
        public static (string name, string value)? ToTupleOrNull(this EventId eventId)
        {
            (string, string)? data = null;

            if (eventId.Id != 0 || eventId.Name != null)
            {
                data = (TupleName, eventId.ToString());
            }

            return data;
        }
    }
}