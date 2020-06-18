using Entities;
using FluentValidation;
using GeoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoApplication.Validation
{
    public class CityValidation:AbstractValidator<City>
    {
        private readonly GeoDBContext _dataDBContext;

        public CityValidation(GeoDBContext dataDBContext)
        {
            _dataDBContext = dataDBContext;
        }

        public CityValidation()
        {
            RuleFor(x => x.CityId).NotNull();
            RuleFor(n => n.CityName).NotNull().NotEmpty().WithMessage("City name is empty");
            RuleFor(x => x.CityCode).NotNull()
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(m => m).Must(model =>
                         !CheckDuplicateName(model.CityCode, model.CityId))
                        .WithMessage("City Code is already exists for this type");


                });
        }

        private bool CheckDuplicateName(string cityCode, int cityId)
        {
            return _dataDBContext.Set<City>().Any(u => u.CityCode == cityCode && u.CityId != cityId);
        }
    }
}
