using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.SeriesQueries;

namespace SeriesApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesesController : ControllerBase
    {
        private readonly GetSeriesQueryHandler _getSeriesQueryHandler;
        private readonly GetSeriesByIdQueryHandler _getSeriesByIdQueryHandler;
        private readonly CreateSeriesCommandHandler _createSeriesCommandHandler;
        private readonly UpdateSeriesCommandHandler _updateSeriesCommandHandler;
        private readonly RemoveSeriesCommandHandler _removeSeriesCommandHandler;
        private readonly GetSeriesWithCategoryQueryHandler _getSeriesWithCategoryQueryHandler;

        public SeriesesController(GetSeriesQueryHandler getSeriesQueryHandler, GetSeriesByIdQueryHandler getSeriesByIdQueryHandler, CreateSeriesCommandHandler createSeriesCommandHandler, UpdateSeriesCommandHandler updateSeriesCommandHandler, RemoveSeriesCommandHandler removeSeriesCommandHandler, GetSeriesWithCategoryQueryHandler getSeriesWithCategoryQueryHandler)
        {
            _getSeriesQueryHandler = getSeriesQueryHandler;
            _getSeriesByIdQueryHandler = getSeriesByIdQueryHandler;
            _createSeriesCommandHandler = createSeriesCommandHandler;
            _updateSeriesCommandHandler = updateSeriesCommandHandler;
            _removeSeriesCommandHandler = removeSeriesCommandHandler;
            _getSeriesWithCategoryQueryHandler = getSeriesWithCategoryQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> SeriesList()
        {
            var value = await _getSeriesQueryHandler.Handle();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeries(CreateSeriesCommand command)
        {
            await _createSeriesCommandHandler.Handle(command);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            await _removeSeriesCommandHandler.Handle(new RemoveSeriesCommand(id));
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeries(UpdateSeriesCommand command)
        {
            await _updateSeriesCommandHandler.Handle(command);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("GetSeries")]
        public async Task<IActionResult> GetSeries(int id)
        {
            var value = await _getSeriesByIdQueryHandler.Handle(new GetSeriesByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("GetSeriesWithCategory")]
        public async Task<IActionResult> GetSeriesWithCategory()
        {
            var values = await _getSeriesWithCategoryQueryHandler.Handle();
            return Ok(values);
        }
    }
}
