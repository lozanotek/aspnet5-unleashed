using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNet.Hosting;
using MsConf.Models;

namespace MsConf.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private static IList<Speaker> _speakerList;

        public SpeakerService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IEnumerable<Speaker> GetSpeakers()
        {
            return _speakerList ?? (_speakerList = BuildList());
        }

        protected virtual IList<Speaker> BuildList()
        {
            var document = GetSpeakerXml();
            var rootElement = document.Root;

            var query = from elem in rootElement.Elements()
                select new Speaker
                {
                    Bio = elem.Element("Bio").Value,
                    FirstName = elem.Element("FirstName").Value,
                    LastName = elem.Element("LastName").Value,
                    Id = elem.Element("Id").Value,
                    Picture = elem.Element("Picture").Value,
                    Website = elem.Element("Website").Value,
                };

            return query
                .Where(speaker => !string.IsNullOrEmpty(speaker.Bio))
                .OrderBy(speaker => speaker.LastName)
                .ToList();
        }

        protected virtual XDocument GetSpeakerXml()
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "data\\speakers.xml");
            return XDocument.Load(path);
        }
    }
}
