using NUnit.Framework;
using System;

namespace UnitTestingExamples.Tests
{
    [TestFixture]
    public class FileTest
    {
        private File file;

        [SetUp]
        public void SetUp()
        {
            file = new File("test.txt", 100, "Test content");
        }

        [Test]
        public void TestFileCreation()
        {
            Assert.AreEqual("test.txt", file.GetFilename());
            Assert.AreEqual(100, file.GetSize());
            Assert.AreEqual("Test content", file.GetContent());
        }

        [Test]
        public void TestFileCreationWithEmptyName()
        {
            Assert.Throws<ArgumentException>(() => new File("", 100, "content"));
        }

        [Test]
        public void TestFileCreationWithNegativeSize()
        {
            Assert.Throws<ArgumentException>(() => new File("test.txt", -1, "content"));
        }

        [Test]
        public void TestFileCreationWithNullContent()
        {
            Assert.Throws<ArgumentNullException>(() => new File("test.txt", 100, null));
        }

        [Test]
        public void TestFileEquals()
        {
            var file1 = new File("test.txt", 100, "content");
            var file2 = new File("test.txt", 100, "content");
            var file3 = new File("different.txt", 100, "content");

            Assert.AreEqual(file1, file2);
            Assert.AreNotEqual(file1, file3);
        }
    }
}
