using Eschody.Domain.Models.ValueObjects;

namespace Eschody.Domain.Conctracts.Services;

public interface IRequest
{
    public Guid Identifier { get; }
    public DateTime RequestTime { get; }
}
