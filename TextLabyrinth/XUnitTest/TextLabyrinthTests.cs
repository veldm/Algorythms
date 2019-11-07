using System;
using Xunit;

namespace XUnitTest
{
    public class TextLabyrinthTests
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(true.ToString(), CoreTextLabyrinth.Program.WordSearch("AEJ").ToString());
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(false.ToString(), CoreTextLabyrinth.Program.WordSearch("AEJA").ToString());
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(true.ToString(), CoreTextLabyrinth.Program.WordSearch("CBD").ToString());
        }

        [Fact]
        public void Test4()
        {
            Assert.Equal(false.ToString(), CoreTextLabyrinth.Program.WordSearch("CBC").ToString());
        }

        [Fact]
        public void Test5()
        {
            Assert.Equal(false.ToString(), CoreTextLabyrinth.Program.WordSearch("").ToString());
        }

        [Fact]
        public void Test6()
        {
            Assert.Equal(true.ToString(), CoreTextLabyrinth.Program.WordSearch("DAB").ToString());
        }

        [Fact]
        public void Test7()
        {
            Assert.Equal(false.ToString(), CoreTextLabyrinth.Program.WordSearch("ADAD").ToString());
        }
    }
}
