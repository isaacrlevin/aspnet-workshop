using ConferenceDTO;

namespace FrontEnd.Services
{
    public class AppState
    {
        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsAttendee { get; set; }

        public bool IsLoggedIn => !string.IsNullOrEmpty(UserName);

        public List<SessionResponse> AllSessions { get; set; } = new List<SessionResponse>();

        public List<SessionResponse> UserSessions { get; set; } = new List<SessionResponse>();

        public void SetAllSessions(List<SessionResponse> sessions)
        {
            AllSessions = sessions;
            NotifyStateChanged();
        }

        public void SetUserSessions(List<SessionResponse> sessions)
        {
            UserSessions = sessions;
            NotifyStateChanged();
        }

        public void SetUserName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                UserName = name;
                NotifyStateChanged();
            }
        }

        public void SetIsAdmin(bool admin)
        {
            IsAdmin = admin;
            NotifyStateChanged();
        }

        public void SetIsAttendee(bool attendee)
        {
            IsAttendee = attendee;
            NotifyStateChanged();
        }

        public void AddSessionToUser(int sessionId)
        {
            UserSessions.Add(AllSessions.Where(a => a.Id == sessionId).FirstOrDefault());
            NotifyStateChanged();
        }

        public void RemoveSessionFromUser(int sessionId)
        {
            UserSessions.Remove(UserSessions.Where(a => a.Id == sessionId).FirstOrDefault());
            NotifyStateChanged();
        }
    }
}
