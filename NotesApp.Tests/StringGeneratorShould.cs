using NotesApp.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NotesApp.Tests
{
    public class StringGeneratorShould
    {
        [Fact]
        public void ReturnEmptyStringIfLengthIsZero()
        {
            Assert.Equal(string.Empty, StringGenerator.GenerateNumbersString(0, true));
        }

        [Fact]
        public void ThrowExceptionIfArgumentsAreNotValid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => StringGenerator.GenerateNumbersString(-1, true));
        }

        [Fact]
        public void GenerateStringWithoutLeadingZeroIfNotAllowed()
        {
            var str = StringGenerator.GenerateNumbersString(10, false);
            Assert.True(str[0] != '0');
        }

        [Fact]
        public void ReturnStringLengthParameterLong()
        {
            var length = new Random().Next(20);
            Assert.Equal(length, StringGenerator.GenerateNumbersString(length, true).Length);
        }

        [Fact]
        public void ReturnStringThatCouldBeParsed()
        {
            var length = new Random().Next(10);
            Assert.True(int.TryParse(StringGenerator.GenerateNumbersString(length, true), out _));
        }
    }
}
