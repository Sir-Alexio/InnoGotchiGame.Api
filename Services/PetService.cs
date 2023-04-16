﻿using InnoGotchi_backend.Models;
using InnoGotchi_backend.Models.Dto;
using InnoGotchi_backend.Models.DTOs;
using InnoGotchi_backend.Models.Enums;
using InnoGotchi_backend.Repositories.Abstract;
using InnoGotchi_backend.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi_backend.Services
{
    public class PetService : IPetService
    {
        private readonly IRepositoryManager _repository;
        private readonly IFarmService _farmSevice;
        public PetService(IRepositoryManager repository, IFarmService farmService)
        {
            _repository = repository;
            _farmSevice = farmService;
        }
        public StatusCode GetCurrentPet(string petName, out Pet? pet)
        {
            pet = _repository.Pet.GetByCondition(x => x.PetName == petName, false).FirstOrDefault();

            if (pet == null) { return StatusCode.DoesNotExist; }

            return StatusCode.Ok;
        }
        public StatusCode CreatePet(Pet pet)
        {
            if (pet == null)
            {
                return StatusCode.DoesNotExist;
            }
            else if (_repository.Pet.GetByCondition(x => x.PetName == pet.PetName, false).FirstOrDefault() != null)
            {
                return StatusCode.IsAlredyExist;
            }

            _repository.Pet.Create(pet);

            try
            {
                _repository.Save();
            }
            catch (DbUpdateException)
            {
                return StatusCode.UpdateFailed;
            }

            return StatusCode.Ok;
        }

        public StatusCode GetAllPets(string email, out List<Pet> pets)
        {
            pets = new List<Pet>();

            _farmSevice.GetFarm(email, out Farm? farm);

            if (farm == null)
            {
                return StatusCode.DoesNotExist;
            }

            pets = _repository.Pet.GetByCondition(x=>x.FarmId == farm.FarmId,false).ToList();

            return StatusCode.Ok;
        }
    }
}
