﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.PipelineBehaviours
{
    public class ValidationBehaviour<TRequset, TResponse> : IPipelineBehavior<TRequset, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequset>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequset>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequset request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequset>(request);
            var failures = _validators.Select(x => x.Validate(context))
                                       .SelectMany(x => x.Errors)
                                       .Where(x => x != null)
                                       .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
            return next();
        }
    }
}
