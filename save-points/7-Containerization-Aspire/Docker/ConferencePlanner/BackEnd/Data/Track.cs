﻿namespace BackEnd.Data;

public class Track : ConferenceDTO.Track
{
    public virtual ICollection<Session> Sessions { get; set; } = null!;
}