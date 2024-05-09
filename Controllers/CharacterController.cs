using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPG__API.Models;
using RPG__API.Services.Interface;

namespace RPG__API.Controllers
{

    [ApiController]

    [Route("/api/[controller]")]

    public class CharacterController : ControllerBase
    {        
        


        protected readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        
        [HttpGet]
        [Route("GetAll")]
        // [HttpGet("GetAll")] EINIA TO IΔΙΟ
        public async Task<ActionResult<ServiceResposne<List<GetCharacterDTOs>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacter());
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<ServiceResposne<List<GetCharacterDTOs>>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
        
        [HttpPost]
        public async Task <ActionResult<ServiceResposne<List<GetCharacterDTOs>>>> AddCharacter(AddCharacterDTOs newCharacter)
        {
             return Ok(await _characterService.AddCharacter(newCharacter));
        }


        [HttpPut]
        public async Task<ActionResult<ServiceResposne<List<GetCharacterDTOs>>>> UpdateCharacter(UpdateCharacterDTOs updateCharacter)
        {
            var respone  =  await _characterService.UpdateCharacter(updateCharacter);

            // WE check if the respone data is null and return a 404 error
            if(respone.Data is null) 
            {
                return NotFound(respone);
            }
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResposne<List<GetCharacterDTOs>>>> DeleteCharacter (int id)
        {
            var respone = await _characterService.DeleteCharacter(id);

            if(respone.Data is null)
            {
                return NotFound(respone);
            }

            return Ok();
        }
    }

}