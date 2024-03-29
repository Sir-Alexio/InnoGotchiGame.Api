﻿using InnoGotchi_backend.Models.Entity;

namespace InnoGotchi_backend.Repositories.Abstract
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public Task<User?> GetUserByEmail(string email);
        public Task<User?> GetUserWithColaboratorsAsync(string email);
        public Task<User?> GetUserWithIAmCollaborator(string email);
    }
}
