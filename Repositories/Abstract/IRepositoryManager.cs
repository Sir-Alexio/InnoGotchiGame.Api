﻿using InnoGotchi_backend.Repositories;

namespace InnoGotchi_backend.Repositories.Abstract
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IFarmRepository Farm { get; }
        void Save();
    }
}