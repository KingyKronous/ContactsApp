﻿namespace ContactsApp.Shared.Services.Contracts
{
    public interface ISecurityService
    {
        string GenerateJwtToken(string username, string role = null);
    }
}
