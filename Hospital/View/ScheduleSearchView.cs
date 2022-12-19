using System.Text.Json.Serialization;

namespace Hospital.View
{
    public class ScheduleSearchView
    {
        [JsonPropertyName("doctorId")]
        public int DoctorId { get; set; }
        [JsonPropertyName("starttime")]
        public DateTime StartWorkTime { get; set; }
        [JsonPropertyName("endtime")]
        public DateTime EndWorkTime { get; set; }
    }
}
