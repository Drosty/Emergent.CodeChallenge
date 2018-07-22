using System;
using System.Collections.Generic;
using Emergent.CodeChallenge.Service.Models;

namespace Emergent.CodeChallenge.Service
{
    public class SoftwareComparor
    {
        IEnumerable<Software> software;
        ParsedVersion filteredVersion;

        public SoftwareComparor(IEnumerable<Software> software, string version)
        {
            this.software = software;
            this.filteredVersion = new ParsedVersion(version);
        }

        public IEnumerable<Software> GetFilteredSoftware()
        {
            IList<Software> rtnSoftware = new List<Software>();

            foreach(var item in software)
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
