using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.TypesDTOs;
using Application.Interfaces.Types;
using Domain.Entities;

namespace Application.Services
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<IEnumerable<TypeResponseDTO>> GetAllAsync()
        {
            var types = await _typeRepository.GetAllAsync();
            return types.Select(t => new TypeResponseDTO { Id = t.Id, Name = t.Name });
        }

        public async Task<TypeResponseDTO?> GetByIdAsync(int id)
        {
            var type = await _typeRepository.GetByIdAsync(id);
            return type is null ? null : new TypeResponseDTO { Id = type.Id, Name = type.Name };
        }

        public async Task<TypeResponseDTO> CreateAsync(TypeRequestDTO dto)
        {
            var type = new Domain.Entities.Type { Name = dto.Name };
            await _typeRepository.AddAsync(type);
            return new TypeResponseDTO { Id = type.Id, Name = type.Name };
        }

        public async Task<bool> UpdateAsync(int id, TypeRequestDTO dto)
        {
            var type = await _typeRepository.GetByIdAsync(id);

            if (type is null)
                return false;

            type.Name = dto.Name;
            return await _typeRepository.UpdateAsync(type);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _typeRepository.DeleteAsync(id);
        }
    }
}
