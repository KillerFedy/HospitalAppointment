using System.Text.Json.Serialization;

namespace Hospital.View
{
    public class ReceptionSearchView
    {
        [JsonPropertyName("starttime")]
        public DateTime StartTime { get; set; }
        [JsonPropertyName("endtime")]
        public DateTime EndTime { get; set; }
        [JsonPropertyName("userid")]
        public int UserId { get;set; }
        [JsonPropertyName("doctorid")]
        public int DoctorId { get; set; }
    }
}
