using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BackEnd.Data
{
    public class SessionizeData
    {
        [JsonPropertyName("sessions")]
        public List<SessionizeSession> Sessions { get; set; }

        [JsonPropertyName("speakers")]
        public List<SessionizeSpeaker> Speakers { get; set; }

        [JsonPropertyName("categories")]
        public List<SessionizeCategory> Categories { get; set; }

        [JsonPropertyName("rooms")]
        public List<SessionizeRoom> Rooms { get; set; }
    }

    public class SessionizeSession
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("startsAt")]
        public DateTime StartsAt { get; set; }

        [JsonPropertyName("endsAt")]
        public DateTime EndsAt { get; set; }

        [JsonPropertyName("isServiceSession")]
        public bool IsServiceSession { get; set; }

        [JsonPropertyName("isPlenumSession")]
        public bool IsPlenumSession { get; set; }

        [JsonPropertyName("speakers")]
        public List<string> Speakers { get; set; }

        [JsonPropertyName("categoryItems")]
        public List<int> CategoryItems { get; set; }

        [JsonPropertyName("roomId")]
        public int RoomId { get; set; }

        [JsonPropertyName("liveUrl")]
        public object LiveUrl { get; set; }

        [JsonPropertyName("recordingUrl")]
        public object RecordingUrl { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("isInformed")]
        public bool IsInformed { get; set; }

        [JsonPropertyName("isConfirmed")]
        public bool IsConfirmed { get; set; }
    }

    public class SessionizeSpeaker
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("bio")]
        public string Bio { get; set; }

        [JsonPropertyName("tagLine")]
        public string TagLine { get; set; }

        [JsonPropertyName("profilePicture")]
        public string ProfilePicture { get; set; }

        [JsonPropertyName("isTopSpeaker")]
        public bool IsTopSpeaker { get; set; }

        [JsonPropertyName("sessions")]
        public List<int> Sessions { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("categoryItems")]
        public List<int> CategoryItems { get; set; }
    }

    public class SessionizeCategory
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("items")]
        public List<SessionizeItem> Items { get; set; }

        [JsonPropertyName("sort")]
        public int Sort { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class SessionizeItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("sort")]
        public int Sort { get; set; }
    }

    public class SessionizeRoom
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("sort")]
        public int Sort { get; set; }
    }
}