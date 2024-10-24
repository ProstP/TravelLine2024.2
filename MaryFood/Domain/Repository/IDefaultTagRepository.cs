using Domain.Entity;

namespace Domain.Repository;

public interface IDefaultTagRepository
{
    Task<List<DefaultTag>> Get();
}
