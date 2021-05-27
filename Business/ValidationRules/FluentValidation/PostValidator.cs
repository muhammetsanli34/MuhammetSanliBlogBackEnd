using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class PostValidator:AbstractValidator<Post>
   {
        public PostValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Content).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.Image).NotEmpty();
            RuleFor(p => p.Content).NotEmpty();
            RuleFor(p => p.Title.Length).GreaterThanOrEqualTo(5);
        }
   }
}
