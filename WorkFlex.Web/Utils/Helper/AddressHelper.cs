using WorkFlex.Web.Untils.Helper.Interface;

namespace WorkFlex.Web.Untils.Helper
{
    public class AddressHelper : IAddressHelper
    {
        public string ExtractCityProvince(string fullAddress)
        {
            // Check if fullAddress is null or empty (including whitespace-only strings)
            if (string.IsNullOrEmpty(fullAddress) || fullAddress.Trim() == "")
                return "Location not updated yet.";

            // Split the address into parts using commas
            string[] addressParts = fullAddress.Split(',');

            // Remove empty or whitespace-only parts from the address
            var filteredParts = addressParts
                .Select(part => part.Trim()) // Trim whitespace from each part
                .Where(part => !string.IsNullOrEmpty(part)) // Exclude empty parts
                .ToList();

            // If no valid parts remain, return "Location not updated yet."
            if (filteredParts.Count == 0)
                return "Location not updated yet.";

            // Limit the number of parts to a maximum of 5
            int maxIndex = Math.Min(5, filteredParts.Count);

            // Extract city and province from the last two parts
            string city = filteredParts[maxIndex - 2];
            string province = filteredParts[maxIndex - 1];

            // Return the city and province joined by a comma
            return $"{city}, {province}";
        }
    }
}
