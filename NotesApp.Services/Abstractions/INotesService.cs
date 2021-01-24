using System;
using NotesApp.Services.Models;

namespace NotesApp.Services.Abstractions
{
    public interface INotesService
    {
        void AddNote(Note note, int userId);
        bool DeleteNote(Guid noteId, int userId);
    }
}