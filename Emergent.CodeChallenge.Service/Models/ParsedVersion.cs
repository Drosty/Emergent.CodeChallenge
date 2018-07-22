using System;
namespace Emergent.CodeChallenge.Service.Models
{
    public class ParsedVersion : IComparable
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Release { get; set; }

        public ParsedVersion(string version)
        {
            if (version == null)
            {
                return;
            }

            var parts = version.Split('.');

            if (parts.Length > 0)
            {
                int major;
                int.TryParse(parts[0], out major);
                this.Major = major;
            }

            if (parts.Length > 1)
            {
                int minor;
                int.TryParse(parts[1], out minor);
                this.Minor = minor;
            }

            if (parts.Length > 2)
            {
                int release;
                int.TryParse(parts[2], out release);
                this.Release = release;
            }
        }

        public bool IsValid()
        {
            return Major != default(int);
        }

        public int CompareTo(object obj)
        {
            ParsedVersion other = (ParsedVersion)obj;

            if (this.Major > other.Major) 
            {
                return 1;
            }

            if (this.Major < other.Major) 
            {
                return -1;
            }

            if (this.Minor > other.Minor)
            {
                return 1;
            }

            if (this.Minor < other.Minor)
            {
                return -1;
            }

            if (this.Release > other.Release)
            {
                return 1;
            }

            if (this.Release < other.Release)
            {
                return -1;
            }

            return 0;
        }
    }
}
