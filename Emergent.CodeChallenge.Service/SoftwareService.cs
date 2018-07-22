using System;
using System.Collections.Generic;

namespace Emergent.CodeChallenge.Service
{
    public class SoftwareService
    {
        public IEnumerable<Software> GetSoftwareGreaterThanVersion(string version)
        {
            if (!string.IsNullOrEmpty(version))
            {
                var softwares = SoftwareManager.GetAllSoftware();
                var comparor = new SoftwareComparor(softwares, version);
                return comparor.GetFilteredSoftware();
            }

            return new List<Software>();
        }
    }
}
