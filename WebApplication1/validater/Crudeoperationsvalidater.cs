using FluentValidation;
using System.Data;
using WebApplication1.models;

namespace WebApplication1.validater
{
    public class Crudeoperationsvalidater: AbstractValidator<Emplistclass>
    { 
      
        public Crudeoperationsvalidater()
        {
            RuleFor(x => x.Name).NotEmpty();      
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(20).NotEmpty();
            RuleFor(x =>x.Designation).NotEmpty();
            RuleFor(x => x.Salary).NotEmpty();
            
        }

    
    }
}
