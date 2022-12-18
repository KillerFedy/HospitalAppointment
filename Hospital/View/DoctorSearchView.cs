using System.Text.Json.Serialization;

namespace Hospital.View
{
    public class DoctorSearchView
    {
        [JsonPropertyName("id")]
        public int DoctorId { get; set; }
        [JsonPropertyName("initials")]
        public string Initials { get; set; }
        [JsonPropertyName("specializationId")]
        public int SpecializationId { get; set; }
    }
}
