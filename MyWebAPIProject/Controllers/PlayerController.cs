﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebAPIProject.Model;
using MyWebAPIProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace MyWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public PlayerController(IPlayerRepository playerRepository, ApplicationDbContext applicationDbContext)
        {
            _playerRepository = playerRepository;
            _applicationDbContext = applicationDbContext;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetAllPlayers()
        {
            var players = await _playerRepository.GetAllPlayers();
            return Ok(players);
        }
        [HttpGet("{playerName}")]
        public async Task<ActionResult<Player>> GetPlayerByName(string playerName)
        {
            var player = await _applicationDbContext.Players.FirstOrDefaultAsync(p => p.Name == playerName);
            if (player == null)
            {
                return NotFound("Such a player doesn't exists!");
            }
            return Ok(player);
        }
        [HttpGet("{id:int}", Name = "GetPlayer")]
        public async Task<ActionResult<Player>> GetPlayerById(int id)
        {
            var player = await _playerRepository.GetPlayerById(id);
            if (player == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(player);

        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<Player>> UpdatePlayer(Player player, int id)
        {

            if (player == null)
            {
                return NotFound();
            }
            if (player.Id != id)
            {
                return BadRequest();
            }
            if(await _playerRepository.SamePlayerExists(player.Name))
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            if (ModelState.IsValid)
                await _playerRepository.UpdatePlayer(player);
            return Ok(player);
        }
        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer(Player player)
        {
            if (player == null)
            {
                return BadRequest();
            }
            if (await _playerRepository.SamePlayerExists(player.Name))
                return StatusCode(StatusCodes.Status400BadRequest);
            if (ModelState.IsValid)
            {
                await _playerRepository.AddPlayer(player);
            }
            return CreatedAtRoute("GetPlayer", new { id = player.Id }, player);
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePlayer(int id)
        {
            var playerToDelete = _applicationDbContext.Players.FirstOrDefault(p => p.Id == id);
            if (playerToDelete == null)
            {
                return NotFound();
            }
            _applicationDbContext.Players.Remove(playerToDelete);
            _applicationDbContext.SaveChanges();
            return NoContent();

        }
    }
}
