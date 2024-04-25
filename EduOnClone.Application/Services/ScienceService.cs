using EduOnClone.Application.Common.Exceptions;
using EduOnClone.Application.Common.Validators;
using EduOnClone.Application.DTOs.ScienceDtos;
using EduOnClone.Application.Interfaces;
using EduOnClone.Data.Interfaces;
using EduOnClone.Domain.Entities;
using FluentValidation;
using System.Net;

namespace EduOnClone.Application.Services;

public class ScienceService(IUnitOfWork unitOfWork,
                            IValidator<Science> validator) : IScienceService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Science> _validator = validator;

    public async Task CreateAsync(AddScienceDto dto)
    {
        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());

        await _unitOfWork.Science.CreateAsync((Science)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var science = await _unitOfWork.Science.GetByIdAsync(id);
        if (science is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Mavzu mavjud emas");
        await _unitOfWork.Science.DeleteAsync(science);
    }

    public async Task<List<ScienceDto>> GetAllAsync()
    {
        var sciences = await _unitOfWork.Science.GetAllAsync();
        var subjects = await _unitOfWork.Subject.GetAllAsync();

        var entities = new List<ScienceDto>();

        foreach (var science in sciences)
        {
            var subject  = subjects.First(p => p.Id == science.SubjectId);
            var dto = (ScienceDto)science;
            dto.Subject = new Subject()
            {
                Id = subject.Id,
                SubjectName = subject.SubjectName,
                SubjectDescription = subject.SubjectDescription,
                Author = subject.Author,
            };

            entities.Add(dto);
        }
        return entities;
    }

    public async Task<ScienceDto> GetByIdAsync(int id)
    {
        var science = await _unitOfWork.Science.GetByIdAsync(id);
        if(science is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Mavzu topilmadi");

        var subject = await _unitOfWork.Subject.GetByIdAsync(science.SubjectId);
        var entity = (ScienceDto)science;

        entity.Subject = new Subject()
        {
            Id = entity.SubjectId,
            SubjectName = entity.Name,
            SubjectDescription = entity.Description,
            Author = entity.Author,
        };
        return entity;
    }

    public Task<List<ScienceDto>> GetByNameAsync(string name)
    {

    }

    public Task UpdateAsync(ScienceDto dto)
    {

    }
}
