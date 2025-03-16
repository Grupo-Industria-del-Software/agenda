using Application.DTOs.TypesDTOs;

namespace Application.Interfaces.Types
{
    public interface ITypeService
    {
        Task<IEnumerable<TypeResponseDTO>> GetAllAsync();
        Task<TypeResponseDTO?> GetByIdAsync(int id);
        Task<TypeResponseDTO> CreateAsync(TypeRequestDTO dto);
        Task<bool> UpdateAsync(int id, TypeRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}

