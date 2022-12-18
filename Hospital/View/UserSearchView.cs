using Domain.Entities;
using System.Text.Json.Serialization;

namespace Hospital.View
{
    public class UserSearchView
    {
        [JsonPropertyName("id")]
        public int UserId { get; set; }
        [JsonPropertyName("login")]
        public string Login { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("phonenumber")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("initials")]
        public string Initials { get; set; }
        [JsonPropertyName("role")]
        public UserRole Role { get; set; }
    }
}
