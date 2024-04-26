using EduOnClone.Application.Common.Exceptions;
using EduOnClone.Application.Common.Validators;
using EduOnClone.Application.DTOs.SubjectDtos;
using EduOnClone.Application.Interfaces;
using EduOnClone.Data.Interfaces;
using EduOnClone.Domain.Entities;
using FluentValidation;
using System.Net;

namespace EduOnClone.Application.Services;

public class SubjectService(IUnitOfWork unitOfWork,
                            IValidator<Subject> validator) : ISubjectService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Subject> _validator = validator;

    public async Task CreateAsync(AddSubjectDto dto)
    {
        var subject = await _unitOfWork.Subject.GetByNameAsync(dto.SubjectName);
        if (subject != null)
            throw new StatusCodeExeption(HttpStatusCode.AlreadyReported, "Subject oldin foydalanilgan");
        await _unitOfWork.Subject.CreateAsync((Subject)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var subject = await _unitOfWork.Subject.GetByIdAsync(id);
        if (subject is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Fan topilmadi");

        await _unitOfWork.Subject.DeleteAsync(subject);
    }

    public async Task<List<SubjectDto>> GetAllAsync()
    {
        var subject = await _unitOfWork.Subject.GetAllAsync();
        return subject.Select(item => (SubjectDto)item).ToList();
    }

    //public async Task<List<SubjectDto>> GetAllAsync()
    //{
    //    var subjects = await _unitOfWork.Subject.GetAllAsync();
    //    return subjects.Select(subject => new SubjectDto
    //    {
    //        Id = subject.Id,
    //        SubjectName = subject.SubjectName,
    //        SubjectDescription = subject.SubjectDescription,
    //        Author = subject.Author,
    //    }).ToList();
    //}

    public async Task<SubjectDto?> GetByIdAsync(int id)
    {
        var subject = await _unitOfWork.Subject.GetByIdAsync(id);
        if (subject is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Fan mavjud emas");

        return (SubjectDto)subject;
    }

    public async Task<SubjectDto?> GetByNameAsync(string name)
    {
        var subject = await _unitOfWork.Subject.GetByNameAsync(name);
        if (subject is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Fan mavjud emas");

        return (SubjectDto)subject;
    }


    public async Task UpdateAsync(SubjectDto dto)
    {
        var subject = await _unitOfWork.Subject.GetByIdAsync(dto.Id);
        if (subject is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Fan topilmadi");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        subject.SubjectName = dto.SubjectName;
        subject.SubjectDescription = dto.SubjectDescription;
        subject.Author = dto.Author;

        await _unitOfWork.Subject.UpdateAsync(subject);
    }

}
