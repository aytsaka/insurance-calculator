using Insurance.Domain.Interfaces;
using System;

namespace Insurance.Domain.Services
{
    public abstract class BaseService : IBaseService
    {
        /// <summary>
        /// Public implementation of Dispose pattern callable by consumers.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                OnDispose();
            }
        }

        /// <summary>
        /// Free any unmanaged objects.
        /// </summary>
        protected abstract void OnDispose();
    }
}
