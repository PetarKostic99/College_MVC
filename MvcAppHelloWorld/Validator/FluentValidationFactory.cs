using FluentValidation;
using System;
using System.Collections.Generic;

namespace MvcAppHelloWorld.Validator
{
    public class FluentValidationFactory : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        static FluentValidationFactory()
        {
            validators.Add(typeof(IValidator<CollegeViewModel>), new CollegeStudentsValidatorModel());
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator;
            if (validators.TryGetValue(validatorType, out validator)) ;
            {
                return validator;
            }
            return validator;
        }
    }
}