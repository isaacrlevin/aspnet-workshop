﻿using BackEnd.Data;

namespace BackEnd.Infrastructure;
public static class EntityExtensions
{
    public static ConferenceDTO.SessionResponse MapSessionResponse(this Session session) =>
        new ConferenceDTO.SessionResponse
        {
            Id = session.Id,
            Title = session.Title,
            StartTime = session.StartTime,
            EndTime = session.EndTime,
            Speakers = session.SessionSpeakers?
                              .Select(ss => new ConferenceDTO.Speaker
                              {
                                  Id = ss.SpeakerId,
                                  Name = ss.Speaker.Name
                              })
                               .ToList() ?? new(),
            TrackId = session.TrackId,
            Track = new ConferenceDTO.Track
            {
                Id = session?.TrackId ?? 0,
                Name = session?.Track?.Name
            },
            Abstract = session?.Abstract
        };

    public static ConferenceDTO.SpeakerResponse MapSpeakerResponse(this Speaker speaker) =>
        new ConferenceDTO.SpeakerResponse
        {
            Id = speaker.Id,
            Name = speaker.Name.Trim(),
            Bio = speaker.Bio,
            WebSite = speaker.WebSite,
            Sessions = speaker.SessionSpeakers?
                .Select(ss =>
                    new ConferenceDTO.Session
                    {
                        Id = ss.SessionId,
                        Title = ss.Session.Title
                    })
                .ToList() ?? new()
        };

    public static ConferenceDTO.AttendeeResponse MapAttendeeResponse(this Attendee attendee) =>
        new ConferenceDTO.AttendeeResponse
        {
            Id = attendee.Id,
            FirstName = attendee.FirstName,
            LastName = attendee.LastName,
            UserName = attendee.UserName,
            Sessions = attendee.SessionsAttendees?
                .Select(sa =>
                    new ConferenceDTO.Session
                    {
                        Id = sa.SessionId,
                        Title = sa.Session.Title,
                        StartTime = sa.Session.StartTime,
                        EndTime = sa.Session.EndTime
                    })
                .ToList() ?? new()
        };
}