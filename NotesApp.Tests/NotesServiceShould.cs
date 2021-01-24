using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NotesApp.Services.Abstractions;
using NotesApp.Services.Models;
using NotesApp.Services.Services;
using NSubstitute;
using Xunit;

namespace NotesApp.Tests
{
    
    public class NotesServiceShould
    {
        Mock<INotesStorage> storageMoq = new Mock<INotesStorage>();
        Mock<INoteEvents> eventsMoq = new Mock<INoteEvents>();

        [Fact]
        public void ThrowExceptionWhenAddedNoteIsNull()
        {            
            var sut = new NotesService(storageMoq.Object, eventsMoq.Object);
            Assert.Throws<ArgumentNullException>(() => sut.AddNote(null, 1));
        }

        [Fact]
        public void PublishMessageIfNoteIsAdded()
        {
            var sut = new NotesService(storageMoq.Object, eventsMoq.Object);
            sut.AddNote(new Note(), 2);
            eventsMoq.Verify(f => f.NotifyAdded(It.IsAny<Note>(), 2), Times.AtLeast(1));
        }

        [Fact]
        public void NotPublishMessageIfAddNoteIsFailed()
        {
            var sut = new NotesService(storageMoq.Object, eventsMoq.Object);
            try
            {
                sut.AddNote(null, 2);
            }
            catch (Exception) { }
            finally
            {              
                eventsMoq.Verify(f => f.NotifyAdded(It.IsAny<Note>(), 2), Times.Never);
            }
        }

        [Fact]
        public void PublishMessageIfNoteIsDeleted()
        {
            var sut = new NotesService(storageMoq.Object, eventsMoq.Object);
            storageMoq.Setup(ev => ev.DeleteNote(It.IsAny<Guid>())).Returns(true);
            sut.DeleteNote(new Guid(), 2);
            eventsMoq.Verify(f => f.NotifyDeleted(It.IsAny<Guid>(), 2), Times.AtLeast(1));
        }

        [Fact]
        public void NotPublishMessageIfDeleteNoteIsFailed()
        {
            var sut = new NotesService(storageMoq.Object, eventsMoq.Object);
            storageMoq.Setup(ev => ev.DeleteNote(It.IsAny<Guid>())).Returns(false);
            sut.DeleteNote(new Guid(), 2);
            eventsMoq.Verify(f => f.NotifyDeleted(It.IsAny<Guid>(), 2), Times.Never);
        }
    }
}
