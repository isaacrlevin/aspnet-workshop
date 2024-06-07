
using System.Text.Json;

namespace BackEnd.Data
{
    public class SessionizeDataLoader : DataLoader
    {
        public override Task LoadDataAsync(Stream fileStream, ApplicationDbContext db)
        {
            throw new NotImplementedException();
        }

        public override async Task LoadSessionizeDataAsync(string url, ApplicationDbContext db)
        {
            var addedSpeakers = new Dictionary<string, BackEnd.Data.Speaker>();
            var addedTracks = new Dictionary<int, BackEnd.Data.Track>();

            var client = new HttpClient();

            var sessionizeDataString = await client.GetStringAsync(url);

            var sessionizeData = JsonSerializer.Deserialize<SessionizeData>(sessionizeDataString);

            var tracks = sessionizeData.Categories.Where(a => a.Title == "Track").FirstOrDefault().Items;

            foreach (var sessionizeTrack in tracks)
            {
                var track = new Track
                {
                    Name = sessionizeTrack.Name
                };
                db.Tracks.Add(track);
                addedTracks.Add(sessionizeTrack.Id, track);
            }

            foreach (var sp in sessionizeData.Speakers)
            {
                var speaker = new Speaker
                {
                    Name = sp.FullName,
                    Bio = sp.Bio
                };
                db.Speakers.Add(speaker);
                addedSpeakers.Add(sp.Id, speaker);
            }

            foreach (SessionizeSession sessionizeSession in sessionizeData.Sessions)
            {
                //These are all required to add to the schedule
                var speakers = sessionizeSession.Speakers;
                var categories = sessionizeSession.CategoryItems;
                if (speakers is null || speakers.Count == 0
                    || sessionizeSession.StartsAt == DateTime.MinValue
                    || sessionizeSession.EndsAt == DateTime.MinValue
                    || categories is null || categories.Count == 0)
                {
                    continue;
                }

                Track track = null;
                foreach (var category in categories)
                {

                    var foundTrack = tracks.Where(a => a.Id == category).FirstOrDefault();
                    if (foundTrack is not null)
                    {
                        track = new Track
                        {
                            Name = foundTrack.Name
                        };
                        break;
                    }
                }

                var session = new Session
                {
                    Title = sessionizeSession.Title,
                    StartTime = sessionizeSession.StartsAt,
                    EndTime = sessionizeSession.EndsAt,
                    Track = track,
                    Abstract = sessionizeSession.Description
                };

                session.SessionSpeakers = new List<SessionSpeaker>();
                foreach (var sp in speakers)
                {
                    session.SessionSpeakers.Add(new SessionSpeaker
                    {
                        Session = session,
                        Speaker = addedSpeakers[sp]
                    });
                }

                db.Sessions.Add(session);
            }
        }
    }
}
