﻿using InnoGotchi_backend.DataContext;
using InnoGotchi_backend.Models;
using InnoGotchi_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi_backend.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationContext db) : base(db)
        {
        }

    }
}