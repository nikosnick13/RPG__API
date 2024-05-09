using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG__API.DTOs.Character;
using RPG__API.Models;

namespace RPG__API.Services.Interface
{
    public interface ICharacterService
    {
        Task  <ServiceResposne<List<GetCharacterDTOs>>> GetAllCharacter();

        Task<ServiceResposne<GetCharacterDTOs>> GetCharacterById(int id);

        Task<ServiceResposne<List<GetCharacterDTOs>>> AddCharacter(AddCharacterDTOs newCharacter); 

        Task<ServiceResposne<GetCharacterDTOs>> UpdateCharacter(UpdateCharacterDTOs updateCharacter);

        Task<ServiceResposne<List<GetCharacterDTOs>>> DeleteCharacter(int id); 
        



    }
}