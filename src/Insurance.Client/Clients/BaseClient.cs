using Insurance.Client.Interfaces;
using System;

namespace Insurance.Client.Clients
{
    public abstract class BaseClient : IBaseClient
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseClient()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                OnDispose();
            }
        }
        
        protected abstract void OnDispose();

    }
}
