using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG__API.Data;
using RPG__API.Models;

namespace RPG__API.Services.Interface
{
    
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _context;
        public CharacterService(IMapper maper, ApplicationDBContext context)
        {
            _mapper = maper;
            _context = context;
        }   

        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{Name = "Sam",Id = 1}
        };

        //ADD CHARACTER
        public async Task<ServiceResposne<List<GetCharacterDTOs>>> AddCharacter(AddCharacterDTOs newCharacter)
        {
            //This is serviscesRespone

            var servicesResponse = new ServiceResposne<List<GetCharacterDTOs>>();
            
            var characterId = _mapper.Map<Character>(newCharacter);
            characterId.Id = characters.Max(x => x.Id) + 1;

            characters.Add(characterId);
            servicesResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTOs>(c)).ToList(); 
            return  servicesResponse;
           
        }

        public async Task<ServiceResposne<List<GetCharacterDTOs>>> GetAllCharacter()
        {
            var servicesResponse = new ServiceResposne<List<GetCharacterDTOs>>();
            var dbcharacter  = await _context.Characters.ToListAsync();
            servicesResponse.Data = dbcharacter.Select(c => _mapper.Map<GetCharacterDTOs>(c)).ToList(); 
            return servicesResponse;
        }

        public async Task<ServiceResposne<GetCharacterDTOs>> GetCharacterById(int id)
        {
            var servicesResponse = new ServiceResposne<GetCharacterDTOs>();

            var dbcharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            servicesResponse.Data = _mapper.Map<GetCharacterDTOs>(dbcharacter);
            
            return servicesResponse;
            
            
            
        }
        
        //UPDATE Character
        public async Task<ServiceResposne<GetCharacterDTOs>> UpdateCharacter(UpdateCharacterDTOs updateCharacter)
        {
            var servicesResponse = new ServiceResposne<GetCharacterDTOs>();

            try
            {
                var dbcharacter = await  _context.Characters.FirstOrDefaultAsync(c => c.Id ==  updateCharacter.Id);

                //check if character id is null
                if(dbcharacter is null) throw new Exception($"Character with Id: {updateCharacter.Id} is not valid");
                

                _mapper.Map(updateCharacter,characters);

                //Allazoume ton character
                dbcharacter.Name = updateCharacter.Name;
                dbcharacter.HitPoints = updateCharacter.HitPoints;
                dbcharacter.Strength = updateCharacter.Strength;
                dbcharacter.Defense = updateCharacter.Defense;
                dbcharacter.Intelligence = updateCharacter.Intelligence;
                dbcharacter.Class = updateCharacter.Class;

                servicesResponse.Data = _mapper.Map<GetCharacterDTOs>(dbcharacter);
            }
            catch(Exception ex)
            {
                servicesResponse.Success = false;
                servicesResponse.Massage = ex.Message;
            }
            return servicesResponse;
        }

        public async Task<ServiceResposne<List<GetCharacterDTOs>>> DeleteCharacter(int id)
        {
            
            var servicesResponse =  new ServiceResposne<List<GetCharacterDTOs>>(); //epidi theloume na girname lista
            try
            {
                var dbcharacter = await _context.Characters.FirstAsync(c => c.Id == id); //briskoyme to id meso to first method
                if(dbcharacter is null) throw new Exception($"Character with Id: {id} is not valid");  //check if id exiest

                characters.Remove(dbcharacter); //Remove the character from the  characters List()

                servicesResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTOs>(c)).ToList();  


            }
            catch(Exception ex)
            {
                servicesResponse.Success = false ;
                servicesResponse.Massage = ex.Message;
            }
            
            return servicesResponse;
             
        }
    }
}