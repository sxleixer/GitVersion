using System.Linq;
using GitVersion.MSBuildTask.Tasks;
using GitVersion.OutputVariables;
using GitVersionCore.Tests.Helpers;
using Microsoft.Build.Framework;
using NUnit.Framework;
using Shouldly;

namespace GitVersion.MSBuildTask.Tests
{
    [TestFixture]
    public class GetVersionTaskTests : TestBase
    {
        [Test]
        public void OutputsShouldMatchVariableProvider()
        {
            var taskProperties = typeof(GetVersion)
                .GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(OutputAttribute), false).Any())
                .Select(p => p.Name);

            var variablesProperties = VersionVariables.AvailableVariables;

            taskProperties.ShouldBe(variablesProperties, ignoreOrder: true);
        }
    }
}
