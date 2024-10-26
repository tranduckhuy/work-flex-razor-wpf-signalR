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

            // Extract city and province based on the number of parts
            string city = null!;
            string province = null!;

            if (filteredParts.Count == 1)
            {
                // Only one part, assume it is the province
                province = filteredParts[0];
            }
            else if (filteredParts.Count >= 2)
            {
                // If there are two or more parts, take the last as province and the second last as city
                province = filteredParts.Last();
                city = filteredParts[filteredParts.Count - 2];
            }

            // Construct the result based on the available data
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(province))
            {
                return $"{city}, {province}";
            }
            else if (!string.IsNullOrEmpty(province))
            {
                return province;
            }
            else
            {
                return "Location not updated yet.";
            }
        }
    }
}
