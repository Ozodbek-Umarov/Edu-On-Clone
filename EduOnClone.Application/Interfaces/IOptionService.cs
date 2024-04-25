﻿using EduOnClone.Application.DTOs.OptionDtos;

namespace EduOnClone.Application.Interfaces;

public interface IOptionService
{
    Task CreateAsync(AddOptionDto dto);
    Task UpdateAsync(OptionDto dto);
    Task DeleteAsync(int id);
    Task<List<OptionDto>> GetAllAsync();
    Task<OptionDto> GetByIdAsync(int id);
}
