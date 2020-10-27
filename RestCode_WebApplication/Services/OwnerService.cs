﻿using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<IEnumerable<Owner>> ListAsync()
        {
            return await _ownerRepository.ListAsync();
        }

        public async Task<OwnerResponse> GetByIdAsync(int id)
        {
            var existingOwner = await _ownerRepository.FindById(id);

            if (existingOwner == null)
                return new OwnerResponse("Owner not found");
            return new OwnerResponse(existingOwner);
        }

        public async Task<OwnerResponse> SaveAsync(Owner owner)
        {
            try
            {
                await _ownerRepository.AddAsync(owner);

                return new OwnerResponse(owner);
            }
            catch (Exception ex)
            {
                return new OwnerResponse($"An error ocurred while saving the Owner: {ex.Message}");
            }
        }

        public async Task<OwnerResponse> UpdateAsync(int id, Owner owner)
        {
            var existingOwner = await _ownerRepository.FindById(id);

            if (existingOwner == null)
                return new OwnerResponse("Owner not found");

            existingOwner.RUC = owner.RUC;

            try
            {
                _ownerRepository.Update(existingOwner);

                return new OwnerResponse(existingOwner);
            }
            catch (Exception ex)
            {
                return new OwnerResponse($"An error ocurred while updating Owner: {ex.Message}");
            }

        }

        public async Task<OwnerResponse> DeleteAsync(int id)
        {
            var existingOwner = await _ownerRepository.FindById(id);

            if (existingOwner == null)
                return new OwnerResponse("Owner not found");

            try
            {
                _ownerRepository.Remove(existingOwner);

                return new OwnerResponse(existingOwner);
            }
            catch (Exception ex)
            {
                return new OwnerResponse($"An error ocurred while deleting Owner: {ex.Message}");
            }
        }
    }
}
