namespace Application.Interfaces.Types
{
    public interface ITypeRepository
    {
        Task<IEnumerable<Domain.Entities.Type>> GetAllAsync();
        Task<Domain.Entities.Type?> GetByIdAsync(int id);
        Task AddAsync(Domain.Entities.Type type);
        Task<bool> UpdateAsync(Domain.Entities.Type type);
        Task<bool> DeleteAsync(int id);
    }
}