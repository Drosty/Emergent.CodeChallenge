using System;
using System.Collections.Generic;
using Emergent.CodeChallenge.Service.Models;

namespace Emergent.CodeChallenge.Service
{
    public class SoftwareService
    {
        public IEnumerable<Software> GetSoftwareGreaterThanVersion(string version)
        {
            if (!string.IsNullOrEmpty(version))
            {
                var softwares = SoftwareManager.GetAllSoftware();
                return FilterSoftware(softwares, version);
            }

            return new List<Software>();
        }

        private IEnumerable<Software> FilterSoftware(IEnumerable<Software> software, string version)
        {
            var filteredVersion = new ParsedVersion(version);
            IList<Software> rtnSoftware = new List<Software>();

            foreach (var item in software)
            {
                var itemParsedVersion = new ParsedVersion(item.Version);

                if (itemParsedVersion.CompareTo(filteredVersion) > 0)
                {
                    rtnSoftware.Add(item);
                }
            }

            return rtnSoftware;
        }
    }
}
