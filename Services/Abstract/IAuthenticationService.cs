﻿namespace InnoGotchi_backend.Services.Abstract
{
    public interface IAuthenticationService
    {
        public Task<bool> ValidateUser(string password,string email);
        public Task<string> CreateToken();
    }
}
