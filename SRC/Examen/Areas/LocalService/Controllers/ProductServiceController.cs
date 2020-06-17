namespace Examen.Areas.LocalService.Controllers
{
    using Examen.Areas.LocalService.Data.BussinesLogic;
    using System.Net;
    using System.Web.Http;

    public class ProductServiceController : ApiController
    {
        public IHttpActionResult GetProducts()
        {
            QueryManager query = new QueryManager();
            var userObtained = query.GetProducts();
            if (userObtained != null)
            {
                return Ok(userObtained);
            }
            return this.NotFound();
        }

        private IHttpActionResult NotFound(string message)
        {
            return this.Content(HttpStatusCode.NotFound, message);
        }
    }
}
