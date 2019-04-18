using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geoponos.Core.Interfaces
{
    public interface IUseCaseRequestHandler<TUseCaseRequest, TUseCaseResponse>  where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        Task<bool> Handle(TUseCaseRequest message, IOutputPort<TUseCaseResponse> outputPort);
    }
}
