using Journey.Communication.Requests;
using Journey.Exception.ExceptionsBase;
using Journey.Exception;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;
using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripUseCase
    {
        public ResponseShortTripJson Execute(RequestRegisterTripJson request)
        {
            Validate(request);
            var dbContext = new JourneyDBContext();
            var entity = new Trip
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };
            dbContext.Trips.Add(entity);
            dbContext.SaveChanges();
            
            return new ResponseShortTripJson
            {
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                Name = entity.Name,
                Id = entity.Id
            };
        }

        private void Validate(RequestRegisterTripJson request)
        {
            var validator = new RegisterTripValidation();
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errormessage = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errormessage);
            }
        }
    }
}