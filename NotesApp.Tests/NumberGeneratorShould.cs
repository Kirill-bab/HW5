using NotesApp.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NotesApp.Tests
{
    public class NumberGeneratorShould
    {
        [Fact]
        public void ThrowExceptionWhenArgumentIsNotValid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NumberGenerator.GeneratePositiveLong(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => NumberGenerator.GeneratePositiveLong(20));
        }

        [Fact]
        public void ReturnNumberLongAsArgument()
        {
            var length = new Random().Next(1, 10);
            Assert.Equal(NumberGenerator.GeneratePositiveLong(length).ToString().Length, length);
        }
    }
}
