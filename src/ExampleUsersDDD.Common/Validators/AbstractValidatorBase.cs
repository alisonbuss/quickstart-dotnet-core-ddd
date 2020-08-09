
using FluentValidation;

namespace ExampleUsersDDD.Common.Validators
{
    public abstract class AbstractValidatorBase<TEntity> : AbstractValidator<TEntity> where TEntity : class
    {
        
    }
}
