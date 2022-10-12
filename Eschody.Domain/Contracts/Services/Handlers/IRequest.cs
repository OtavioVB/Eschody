using Eschody.Domain.Models.ValueObjects;

namespace Eschody.Domain.Contracts.Services.Handlers;

public interface IRequest
{
    public Guid Identifier { get; }
    public DateTime RequestTime { get; }
}
