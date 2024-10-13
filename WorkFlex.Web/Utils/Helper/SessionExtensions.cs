using Newtonsoft.Json;

namespace WorkFlex.Web.Utils.Helper
{
    public static class SessionExtensions
    {
        // Save an object to the session as a JSON string
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            // Serialize the object into a JSON string
            var jsonString = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonString); // Save the JSON string in the session
        }

        // Retrieve an object from the session by deserializing the JSON string
        public static T GetObject<T>(this ISession session, string key)
        {
            var jsonString = session.GetString(key); // Get the JSON string from the session

            if (string.IsNullOrEmpty(jsonString))
            {
                return default(T)!; // Return default value if the session doesn't contain the key
            }

            // Deserialize the JSON string back into the object
            return JsonConvert.DeserializeObject<T>(jsonString)!;
        }
    }
}
