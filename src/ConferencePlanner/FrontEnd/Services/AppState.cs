using ConferenceDTO;

namespace FrontEnd.Services
{
    public class AppState
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public event Action OnChange;

        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsAttendee { get; set; }

        public bool IsLoggedIn => !string.IsNullOrEmpty(UserName);

        public List<SessionResponse> AllSessions { get; set; } = new List<SessionResponse>();

        public void SetAllSessions(List<SessionResponse> sessions)
        {
            AllSessions = sessions;
            NotifyStateChanged();
        }

        public List<SessionResponse> UserSessions { get; set; } = new List<SessionResponse>();

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

        private void NotifyStateChanged() => OnChange?.Invoke();

        public AppState(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.User != null)
            {
                SetUserName(httpContextAccessor.HttpContext.User.Identity.Name);
            }
        }
    }
}
