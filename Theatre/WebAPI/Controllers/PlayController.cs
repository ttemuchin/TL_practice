using MediatR;
using Microsoft.AspNetCore.Mvc;
using Domain.Repositories;
using Domain.Entities;
using WebAPI.DTO;

namespace WebAPI.Controllers;
[ApiController]
[Route( "api/play" )]
public class PlayController : ControllerBase
{
    private readonly IPlayRepository _playRepository;

    // DI-контейнер
    public PlayController( IPlayRepository playRepository )
    {
        _playRepository = playRepository;
    }

    [HttpGet( "" )]
    public IActionResult GetPlays()
    {
        IReadOnlyList<Play> plays = _playRepository.GetAllPlays();

        return Ok( plays );
    }

    [HttpPost( "" )]
    public IActionResult CreatePlay( [FromBody] CreatePlayRequest request )
    {
        Play play = new( request.Name, request.Description, request.StartDate, request.EndDate, request.TicketPrice, request.TheatreId, request.CompositionId );

        _playRepository.Save( play );
        return Ok();
    }

    [HttpPut( "{id:int}" )]
    public IActionResult ModifyHotel( [FromRoute] int id, [FromBody] ModifyPlayRequest request )
    {
        Play play = new( id, request.Name, request.Description, request.StartDate, request.EndDate, request.TicketPrice, request.TheatreId, request.CompositionId );
        _playRepository.Update( play );
        return Ok();
    }

    [HttpDelete( "{id:int}" )]
    public IActionResult DeleteHotel( [FromRoute] int id )
    {
        _playRepository.Delete( id );

        return Ok();
    }
}
