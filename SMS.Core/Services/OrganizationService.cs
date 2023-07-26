﻿using AutoMapper;
using SMS.Core.IServices;
using SMS.Models.Entities;
using SMS.Persistance.IRepos;
using SMS.VModels.DTOS.Organizations.Commands;
using SMS.VModels.DTOS.Organizations.Queries;

namespace SMS.Core.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepo _organizationRepo;
    private readonly IMapper _mapper;

    public OrganizationService(IOrganizationRepo organizationRepo, IMapper mapper)
    {
        _organizationRepo = organizationRepo;
        _mapper = mapper;
    }

    public List<GetClassDto> GetAll()
    {
        var modelItems = _organizationRepo.GetTableNoTracking();

        return _mapper.Map<List<GetClassDto>>(modelItems);
    }

    public async Task<GetClassDto?> GetById(int id)
    {
        var modelItem = await _organizationRepo.GetByIdAsync(id);
        if (modelItem == null)
            return null;
        return _mapper.Map<GetClassDto>(modelItem);
    }

    public async Task<GetClassDto> Add(AddClassDto dto)
    {
        var modelItem = _mapper.Map<Organization>(dto);

        var model = await _organizationRepo.AddAsync(modelItem);
        await _organizationRepo.SaveChangesAsync();

        return _mapper.Map<GetClassDto>(modelItem);
    }

    public async Task<bool> Update(UpdateClassDto dto)
    {
        var modelItem = await _organizationRepo.GetByIdAsync(dto.Id);

        if (modelItem is null)
            return false;

        _mapper.Map(dto, modelItem);

        var model = _organizationRepo.UpdateAsync(modelItem);
        await _organizationRepo.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Delete(int id)
    {

        var dbModel = await _organizationRepo.GetByIdAsync(id);

        if (dbModel == null)
            return false;

        await _organizationRepo.DeleteAsync(dbModel);
        await _organizationRepo.SaveChangesAsync();
        return true;
    }
}
