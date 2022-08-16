﻿using Labo.BLL.DTO.Matches;
using Labo.BLL.Exceptions;
using Labo.BLL.Services;
using Labo.DL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Labo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery][Required]Guid tournamentId, [FromQuery]int? round)
        {
            try
            {
                return Ok(_matchService.Get(tournamentId, round));
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPatch("{id}/result")]
        [Authorize(Roles = "Admin")]
        public IActionResult Patch([FromRoute] int id, [FromQuery][Required] MatchResult result)
        {
            try
            {
                _matchService.UpdateResult(id, result);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch(TournamentException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
