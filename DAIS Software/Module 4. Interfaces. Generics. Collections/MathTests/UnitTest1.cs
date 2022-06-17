using Task_1._Static_class;

namespace MathTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AbsWorkCorrect()
        {
            Assert.That(Mathematics.Abs(-2), Is.EqualTo(2));
        }
        [Test]
        public void CeilingWorkCorrect()
        {
            Assert.That(Mathematics.Ceiling(2.21), Is.EqualTo(3));
        }
        [Test]
        public void BigMulWorkCorrect()
        {
            Assert.That(Mathematics.BigMul(2, 3), Is.EqualTo(6));
        }
        [Test]
        public void FloorWorkCorrect()
        {
            Assert.That(Mathematics.Floor(2.21), Is.EqualTo(2));
        }
        [Test]
        public void ExpWorkCorrect()
        {
            Assert.That(Mathematics.Exp(2), Is.EqualTo(4));
        }
        [Test]
        public void MaxWorkCorrect()
        {
            Assert.That(Mathematics.Max(2, 5), Is.EqualTo(5));
        }

        [Test]
        public void MinWorkCorrect()
        {
            Assert.That(Mathematics.Min(2, 5), Is.EqualTo(2));
        }

        [Test]
        public void RoundWorkCorrect()
        {
            Assert.That(Mathematics.Round(2.1234), Is.EqualTo(2));
        }
    }
}