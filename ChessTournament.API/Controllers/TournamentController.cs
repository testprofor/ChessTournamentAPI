﻿using ChessTournament.BLL.DTO.Tournaments;
using ChessTournament.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        ITournamentService _service;

        public TournamentController(ITournamentService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(TournamentAddDTO tournamentAddDTO)
        {
            _service.Create(tournamentAddDTO);
            return Ok();
        }
        
        [HttpGet]
        public IActionResult LastTenTournamentUpdated() 
        { 
            return Ok(); 
        }

        [HttpGet("{Id}")]
        public IActionResult GetTournament(string id)
        {
            Guid guid;
            try
            {
                guid = new Guid(id);
                if (guid == Guid.Empty) return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            try
            {
                TournamentDTO t = _service.Get(guid);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("Start")]
        [Authorize("Admin")]
        public IActionResult StartTournament(TournamentIdDTO dto)
        {
            try
            {
                _service.StartTournament(dto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        [Authorize("Admin")]
        public IActionResult AdvanceRound(TournamentIdDTO dto)
        {
            try
            {
                _service.AdvanceRound(dto);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("score/{id}/round/{round}")]
        public IActionResult GetRoundScores(string id, int round)
        {
            Guid guid;
            try
            {
                guid = new Guid(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            try
            {
                IEnumerable<PlayerRoundScoreDTO> scores =  _service.GetRoundScores(guid, round);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
