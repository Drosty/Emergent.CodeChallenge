using Emergent.CodeChallenge.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emergent.CodeChallenge.Service.Tests
{
    [TestClass]
    public class ParsedVersionTests
    {
        [TestMethod]
        public void ParsedVersionCorrectly_ThreeParts()
        {
            var parsedVersion = new ParsedVersion("1.4.5");
            Assert.AreEqual(parsedVersion.Major, 1);
            Assert.AreEqual(parsedVersion.Minor, 4);
            Assert.AreEqual(parsedVersion.Release, 5);
            Assert.IsTrue(parsedVersion.IsValid());
        }

        [TestMethod]
        public void ParsedVersionCorrectly_TwoParts()
        {
            var parsedVersion = new ParsedVersion("1.4");
            Assert.AreEqual(parsedVersion.Major, 1);
            Assert.AreEqual(parsedVersion.Minor, 4);
            Assert.AreEqual(parsedVersion.Release, default(int));
            Assert.IsTrue(parsedVersion.IsValid());
        }

        [TestMethod]
        public void ParsedVersionCorrectly_OnePart()
        {
            var parsedVersion = new ParsedVersion("1");
            Assert.AreEqual(parsedVersion.Major, 1);
            Assert.AreEqual(parsedVersion.Minor, default(int));
            Assert.AreEqual(parsedVersion.Release, default(int));
            Assert.IsTrue(parsedVersion.IsValid());
        }

        [TestMethod]
        public void ParsedVersionCorrectly_Incorrect()
        {
            var parsedVersion = new ParsedVersion("a");
            Assert.AreEqual(parsedVersion.Major, default(int));
            Assert.AreEqual(parsedVersion.Minor, default(int));
            Assert.AreEqual(parsedVersion.Release, default(int));
            Assert.IsFalse(parsedVersion.IsValid());
        }

        [TestMethod]
        public void TestParsedVersionCompare()
        {
            Assert.AreEqual(0, CompareVersions("1", "1"));
            Assert.AreEqual(0, CompareVersions("1.1", "1.1"));
            Assert.AreEqual(0, CompareVersions("1.1.1", "1.1.1"));
            Assert.AreEqual(0, CompareVersions("1.1", "1.1.0"));
            Assert.AreEqual(0, CompareVersions("1", "1.0.0"));

            Assert.AreEqual(1, CompareVersions("5.1.1", "1.1.1"));
            Assert.AreEqual(1, CompareVersions("5.1.1", "1.1"));
            Assert.AreEqual(1, CompareVersions("5.1.1", "1"));

            Assert.AreEqual(1, CompareVersions("5.1", "1.1.1"));
            Assert.AreEqual(1, CompareVersions("5.1", "1.1"));
            Assert.AreEqual(1, CompareVersions("5.1", "1"));

            Assert.AreEqual(1, CompareVersions("5", "1.1.1"));
            Assert.AreEqual(1, CompareVersions("5", "1.1"));
            Assert.AreEqual(1, CompareVersions("5", "1"));

            Assert.AreEqual(1, CompareVersions("5.2.1", "5.1.1"));
            Assert.AreEqual(1, CompareVersions("5.2.1", "5.1"));
            Assert.AreEqual(1, CompareVersions("5.2.1", "5"));

            Assert.AreEqual(1, CompareVersions("5.2.3", "5.2.1"));
            Assert.AreEqual(1, CompareVersions("5.2.3", "5.2"));
            Assert.AreEqual(1, CompareVersions("5.2.3", "5"));

        }

        private int CompareVersions(string version1, string version2)
        {
            var one = new ParsedVersion(version1);
            var two = new ParsedVersion(version2);
            return one.CompareTo(two);
        }
    }
}
