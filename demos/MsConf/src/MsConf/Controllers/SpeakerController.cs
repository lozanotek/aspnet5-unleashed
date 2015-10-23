using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using MsConf.Models;
using MsConf.Services;

namespace MsConf.Controllers
{
    [Route("api/speakers")]
    public class SpeakerController
    {
        private readonly ISpeakerService _speakerService;

        public SpeakerController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [HttpGet, Route("")]
        public IEnumerable<Speaker> GetSpeakers()
        {
            return _speakerService.GetSpeakers();
        }
    }
}
