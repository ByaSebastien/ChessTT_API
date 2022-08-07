﻿using Labo.API.DTO;
using Labo.BLL.DTO.Tournaments;
using Labo.BLL.Exceptions;
using Labo.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Labo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet]
        [Produces(typeof(IndexDTO<IEnumerable<TournamentDTO>>))]
        public IActionResult Get([FromQuery] TournamentCriteriaDTO criteria)
        {
            try
            {
                return Ok(new IndexDTO<IEnumerable<TournamentDTO>>(
                    _tournamentService.Find(criteria),
                    _tournamentService.Count(criteria)
                ));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id})")]
        public IActionResult Get(Guid id)
        {
            try
            {
                TournamentDetailsDTO dto = _tournamentService.GetWithPlayers(id);
                return Ok(dto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Produces(typeof(Guid))]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] TournamentAddDTO dto)
        {
            try
            {
                Guid id = _tournamentService.Add(dto);
                return Ok(id);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new ValidationErrorDTO(ex));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        [Produces(typeof(Guid))]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tournamentService.Remove(id);
                return Ok(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (TournamentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}