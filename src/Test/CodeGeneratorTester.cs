using Core.Features.Codes;
using NUnit.Framework;
using Shouldly;

namespace Test
{
    [TestFixture]
    public class CodeGeneratorTester
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            Generator = new CodeGenerator();
        }

        public CodeGenerator Generator { get; set; }

        [Test]
        public void TwoCodesShouldNotEqualEachOther()
        {
            var code1 = Generator.Generate(5);
            var code2 = Generator.Generate(5);
            code1.ShouldNotBe(code2);
        }
    }
}