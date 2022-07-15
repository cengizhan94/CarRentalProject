using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Vlidation
{
    public class ValidationAspect : MethodInterception  
    {
        private Type _validatiorType;

        public ValidationAspect(Type validatiorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatiorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir.");
            }
            _validatiorType = validatiorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatiorType);
            var entityType = _validatiorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
