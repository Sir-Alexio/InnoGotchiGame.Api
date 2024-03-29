﻿using InnoGotchi_backend.Models.Dto;
using InnoGotchi_backend.Models.Entity;

namespace InnoGotchi_backend.Services.Abstract
{
    public interface IUserService
    {
        public Task<bool> UpdateUser(UserDto dto);
        public Task<bool> Registrate(UserDto userDto);
        public Task<bool> ChangePassword(ChangePasswordModel changePassword, string email);
        public Task<User> GetUser(string email);
        public Task<List<User>> GetAll();
        public Task SetRefreshTokenToUser(RefreshToken refreshToken, string email);
        public Task<List<User>> GetUsersWithNoInvited(string email);
        public Task InviteUserToColab(string invitedUserEmail, string currentUserEmail);
        public  Task<List<User>> GetCollaborators(string email);
        public Task<List<User>> GetUsersIAmCollab(string email);
        public Task DeleteCollaborator(string myEmail, string deleteEmail);
    }
}
