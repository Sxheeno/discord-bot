using DiscordBot.Services;
using DSharpPlus.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DiscordBot.Controllers;

[ApiController]
[Authorize]
[Route("[controller]/[action]")]
public class PresenceController : ControllerBase
{
    private readonly DiscordService _discordService;

    public PresenceController(DiscordService discordService)
    {
        _discordService = discordService;
    }

    [HttpPost(Name = "players")]
    public async Task PostPlayers(int playerCount)
    {
        Log.Information("Post players");
        await _discordService.Client.UpdateStatusAsync(new DiscordActivity($"with {playerCount} players!", ActivityType.Playing));
    }
}