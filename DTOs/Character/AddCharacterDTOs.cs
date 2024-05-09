using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG__API.Models;

namespace RPG__API.DTOs.Character
{
    public class AddCharacterDTOs
    {
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}