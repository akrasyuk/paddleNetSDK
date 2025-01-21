using PaddleBilling.Core.API.v1.Resources;

namespace PaddleBilling.Core.API.v1;

public abstract class PaddleResponse<TData>
{
    public TData Data { get; set; }

    public Dictionary<string, object> Meta { get; set; }
}

public class PaddleResponseForEntity<TEntity> 
    : PaddleResponse<TEntity> 
    where TEntity : Entity
{
}

public class PaddleResponseForCollection<TEntity>
    : PaddleResponse<ICollection<TEntity>>
    where TEntity : Entity
{
}