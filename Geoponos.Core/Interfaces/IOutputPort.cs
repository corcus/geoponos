using System;
using System.Collections.Generic;
using System.Text;

namespace Geoponos.Core.Interfaces
{
    public interface IOutputPort <TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response);
    }
}
