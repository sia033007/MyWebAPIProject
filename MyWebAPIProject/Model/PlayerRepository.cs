using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyWebAPIProject.Data;

namespace MyWebAPIProject.Model
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _applicationDbContext;

        public PlayerRepository(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }
        public async Task<Player> AddPlayer(Player player)
        {
            await _applicationDbContext.Players.AddAsync(player);
            await _applicationDbContext.SaveChangesAsync();
            return player;
        }

        public async Task DeletePlayer(int id)
        {
            var playerToDelete = await _applicationDbContext.Players.FirstOrDefaultAsync(p => p.Id == id);
            _applicationDbContext.Players.Remove(playerToDelete);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await _applicationDbContext.Players.ToListAsync();
        }

        public async Task<Player> GetPlayerById(int id)
        {
            return await _applicationDbContext.Players.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
            _applicationDbContext.Players.Update(player);
            await _applicationDbContext.SaveChangesAsync();
            return player;
        }

        public async Task<bool> SamePlayerExists(string playerName)
        {
            return await _applicationDbContext.Players.AnyAsync(p => p.Name == playerName);
        }
        public string CreateToken()
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(_configuration
                .GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: new List<Claim>
                {
                    new Claim("firstName", "Amin"),
                    new Claim("lastName", "Khosravi")
                },
                signingCredentials: creds,
                expires: DateTime.UtcNow.AddMinutes(15)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
