using System.Web.Http;

namespace Insurance.Api.Controllers.Common
{
    public abstract class BaseApiController : ApiController
    {
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!disposing)
            {
                return;
            }

            OnDisposing();
        }

        protected virtual void OnDisposing()
        {
        }
    }
}
