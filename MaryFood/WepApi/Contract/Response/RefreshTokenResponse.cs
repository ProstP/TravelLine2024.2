﻿namespace WebApi.Contract.Response;

public class RefreshTokenResponse
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}
