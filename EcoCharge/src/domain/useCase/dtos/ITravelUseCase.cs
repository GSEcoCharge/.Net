﻿using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface ITravelUseCase
{
    Travel FindById(int id);
    void Create(Travel travel);
    Travel Update(int id, Travel travel);
    void Delete(int id);
}