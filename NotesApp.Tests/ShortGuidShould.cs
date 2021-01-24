using NotesApp.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NotesApp.Tests
{
    public class ShortGuidShould
    {
        [Fact]
        public void MakeCorrectConvertation()
        {
            var guid = new Guid();
            var newGuid = new Guid();
            try
            {
                newGuid = (Guid)ShortGuid.FromShortId(ShortGuid.ToShortId(guid));                
            }
            catch (Exception e)
            {
                Assert.True(false, e.Message);
            }
            Assert.Equal(guid, newGuid);
        }

        [Fact]
        public void WorkCorrectlyIfFromShortIdTakesDoubleEquasion()
        {
            
            try
            {
               ShortGuid.FromShortId(Guid.NewGuid().ToShortId() + "==");
            }
            catch (Exception e)
            {
                Assert.True(false, e.Message);
            }
            Assert.True(true);
        }

        [Fact]
        public void CorrectlyConvertStringGuidToGuid()
        {
            try
            {
                Assert.True(ShortGuid.FromShortId(Guid.NewGuid().ToShortId()) is Guid);
            }
            catch (Exception e)
            {
                Assert.True(false, e.Message);
            }
            
        }

        [Fact]
        public void ThrowExceptionIfFromFhortIdArgumentIsNotValid()
        {
            Assert.Throws<FormatException>(() => ShortGuid.FromShortId("Definitely not Guid"));
        }

        [Fact]
        public void ReturnNullIfFromFhortIdArgumentIsNull()
        {
            Assert.Null(ShortGuid.FromShortId(null));
        }
    }
}
