using EduOnClone.Domain.Entities;
using FluentValidation;

namespace EduOnClone.Application.Common.Validators;

public class ScienceValidator : AbstractValidator<Science>
{
    public ScienceValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Mavzu nomi bo'sh bolmasin")
            .Length(3, 50).WithMessage("Mavzu 3 va 50 orasida bo'lsin");
        RuleFor(x => x.Description)
             .NotEmpty().WithMessage("Description bo'sh bo'lmasin");
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title bo'sh bo'lmasin")
            .Length(3, 50).WithMessage("3 va 50 orasida bo'lsin");
        RuleFor(x => x.SubjectId)
            .NotEmpty().WithMessage("Bo'sh bo'lmasin")
            .GreaterThan(0).WithMessage("Fanni kiriting");
        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Author bo'sh bo'lmasin")
            .Length(3, 50).WithMessage("3 va 50 orasida bo'lsin");
    }
}
