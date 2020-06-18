using Entities;
using FluentValidation;
using GeoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoApplication.Validation
{
    public class StateValidation :AbstractValidator<State>
    {
        private readonly GeoDBContext _dataDBContext;

        public StateValidation(GeoDBContext dataDBContext)
        {
            _dataDBContext = dataDBContext;
        }

        public StateValidation()
        {
            RuleFor(x => x.StateId).NotNull();
            RuleFor(n => n.StateName).NotNull().NotEmpty().WithMessage("State name is empty");
            RuleFor(x => x.StateCode).NotNull()
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(m => m).Must(model =>
                         !CheckDuplicateName(model.StateCode, model.StateId))
                        .WithMessage("State Code is already exists for this type");


                });
        }

        private bool CheckDuplicateName(string stateCode, int stateId)
        {
            return _dataDBContext.Set<State>().Any(u => u.StateCode == stateCode && u.StateId != stateId );
        }
    }
}
