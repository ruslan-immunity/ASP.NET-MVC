using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using First_project.Models;

namespace First_project.Models
{
    public class UnitOfWork : IDisposable
    {
        private  BookContext db = new BookContext();
        private BookRepository bookRepository;

        public BookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing) // очистка
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}