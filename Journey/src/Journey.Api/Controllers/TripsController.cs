using Journey.Application.UseCases.Trips.Activities.Complete;
using Journey.Application.UseCases.Trips.Activities.Delete;
using Journey.Application.UseCases.Trips.Activities.Register;
using Journey.Application.UseCases.Trips.Delete;
using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestRegisterTripJson request)
        {
            
                var useCase = new RegisterTripUseCase();
                var response = useCase.Execute(request);          
                return Created(string.Empty, response);
        } 

        [HttpGet]
        [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]

        public IActionResult GetAll()
        {
            var useCase = new GetAllTripUseCase();
            var result = useCase.Execute();
            return Ok(result);
        }
        
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] Guid id)
        {
                var useCase = new GetTripByIdUseCase();
                var response = useCase.Execute(id);
                return Ok(response);  
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
                var useCase = new DeleteTripByIdUseCase();
                useCase.Execute(id);
                return NoContent();  
        }

        [HttpPost]
        [Route("{tripId}/activity")]
        [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status404NotFound)]
        public IActionResult RegisterActivity(
            [FromRoute] Guid tripId,
            [FromBody] RequestRegisterActivityJson request)
            {
                var useCase = new RegisterActivityForTripUseCase();
                var response = useCase.Execute(tripId, request);
                return Created(string.Empty, response);
            }

        [HttpPut]
        [Route("{tripId}/activity/{activityId}/complete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status404NotFound)]
        public IActionResult CompleteActivity(
            [FromRoute] Guid tripId,
            [FromRoute] Guid activityId,
            [FromBody] RequestRegisterActivityJson request)
            {
                var useCase = new CompleteActivityForTripUseCase();
                useCase.Execute(tripId, activityId);
                return NoContent();
            }

        [HttpDelete]
        [Route("{tripId}/activity/{activityId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status404NotFound)]
        public IActionResult DeleteActivity(
            [FromRoute] Guid tripId,
            [FromRoute] Guid activityId,
            [FromBody] RequestRegisterActivityJson request)
            {
                var useCase = new DeleteActivityForTripUseCase();
                useCase.Execute(tripId, activityId);
                return NoContent();
            }
        
    }
}


