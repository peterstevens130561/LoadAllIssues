﻿namespace PeterSoft.SonarQube.Connector.API.Logic
{
    public interface ICredentials
    {
        string Password { get; }
        string Url { get; }
        string Username { get; }
    }
}