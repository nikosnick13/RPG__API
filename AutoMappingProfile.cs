using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RPG__API.Models;

namespace RPG__API
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile( )
        { 
            CreateMap<Character, GetCharacterDTOs>(); // create for GET CHARACTER
            CreateMap<AddCharacterDTOs, Character>(); // Creaare for POST CHARACTER
            //CreateMap<UpdateCharacterDTOs, Character>();


        }
    }
}