﻿namespace BackEnd.Data;

public class Attendee : ConferenceDTO.Attendee
{
    public virtual ICollection<SessionAttendee> SessionsAttendees { get; set; } = null!;
}