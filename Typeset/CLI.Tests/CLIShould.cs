using NUnit.Framework;
using Shouldly;

namespace CLI.Tests
{
    [TestFixture]
    public class CLIShould
    {
        [Test]
        public void TypesetMarkdownFile()
        {
            const string inputFilepath = "Resources/AliceInWonderland/AliceInWonderland.md";
            const string outputFilepath = "Resources/AliceInWonderland/AliceInWonderland.pdf";
            var args = new[]
            {
                "-i", inputFilepath,
                "-o", outputFilepath
            };

            Program.Main(args).ShouldBe(0);
        }
    }
}
