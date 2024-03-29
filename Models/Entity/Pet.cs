﻿using InnoGotchi_backend.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace InnoGotchi_backend.Models.Entity
{
    [Index(nameof(PetName), IsUnique = true)]
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        [Required]
        public string PetName { get; set; }
        [Required]
        public DateTime AgeDate { get; set; }
        [Required]
        public DateTime LastHungerLevel { get; set; }
        [Required]
        public DateTime LastThirstyLevel { get; set; }
        [Required]
        public int HappyDaysCount { get; set; } = 0;
        public DateTime LastHappyDaysCountUpdated { get; set; } = DateTime.Now;
        public string? Body { get; set; }
        public string? Eyes { get; set; }
        public string? Mouth { get; set; }
        public string? Nose { get; set; }
        [Required]
        public int FarmId { get; set; }
        public virtual ICollection<PetFeeding>? Feedings { get; set; }
        public virtual ICollection<PetDrinking>? Drinkings { get; set; }
        public virtual Farm Farm { get; set; }

    }
}
