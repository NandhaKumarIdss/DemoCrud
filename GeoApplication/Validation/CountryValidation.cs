
using Entities;
using FluentValidation;
using GeoData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeoApplication.Validation
{

    public class CountryValidation : AbstractValidator<Country>
    {
        private readonly GeoDBContext _dataDBContext;

        public CountryValidation(GeoDBContext dataDBContext)
        {
            _dataDBContext = dataDBContext;
        }



        public CountryValidation()
        {
            RuleFor(x => x.CountryId).NotNull();
            RuleFor(n => n.CountryName).NotNull().NotEmpty().WithMessage("Country name is empty");
            RuleFor(x => x.CountryCode).NotNull()
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(m => m).Must(model =>
                         !CheckDuplicateName(model.CountryCode, model.CountryId))
                        .WithMessage("CountryCode is already exists for this type");


                });
        }

        private bool CheckDuplicateName(string countryCode, int id)
        {
            return _dataDBContext.Set<Country>().Any(u => u.CountryCode == countryCode && u.CountryId != id);
        }
    }
}
