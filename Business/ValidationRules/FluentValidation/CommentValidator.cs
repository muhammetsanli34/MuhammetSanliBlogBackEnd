using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidator:AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(c => c.Content).NotEmpty();
            RuleFor(c => c.PostId).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();            
        }
    }
}
