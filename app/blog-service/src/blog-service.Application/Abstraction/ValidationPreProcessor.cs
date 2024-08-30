using FluentValidation;
using MediatR;
using MediatR.Pipeline;

namespace blog_service.Application.Abstraction
{
    internal sealed class ValidationPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
        where TRequest : IRequest
    {
        private readonly IEnumerable<IValidator<TRequest>> _Validators;
        public ValidationPreProcessor(IEnumerable<IValidator<TRequest>> validators)
        {
            _Validators = validators;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_Validators.Select(c => c.ValidateAsync(context)));

            var validationFailures = validationResults
                .Where(c => !c.IsValid);

            if (validationFailures.Any())
            {
                throw new Exception("TODO ERROR");
            }
        }
    }
}
