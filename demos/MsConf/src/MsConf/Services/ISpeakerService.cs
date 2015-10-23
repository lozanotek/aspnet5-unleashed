using System.Collections.Generic;
using MsConf.Models;

namespace MsConf.Services
{
    public interface ISpeakerService
    {
        IEnumerable<Speaker> GetSpeakers();
    }
}
