using EduOnClone.Domain.Entities;
using FluentValidation;

namespace EduOnClone.Application.Common.Validators;

public class SubjectValidator : AbstractValidator<Subject>
{
    public SubjectValidator()
    {
        RuleFor(x => x.SubjectName)
            .NotEmpty().WithMessage("Fan nomini kiriting")
            .Length(3, 40).WithMessage("Fan 3 va 40 orasida bo'lsin");
        RuleFor(x => x.SubjectDescription)
            .NotEmpty().WithMessage("Fan haqida ma'lumot kiriting")
            .Length(3, 100).WithMessage("Fan ma'lumoti 3 va 100 orasida bo'lsin");
        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Fan Yozuvchisini kiriting")
            .Length(3, 40).WithMessage("Yozuvchi 3 va 40 orasida bo'lsin");
    }
}
