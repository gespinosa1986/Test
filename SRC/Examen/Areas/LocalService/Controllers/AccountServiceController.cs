namespace Examen.Areas.LocalService.Controllers
{
    using Examen.Areas.LocalService.Data.BussinesLogic;
    using Examen.Models.Entities;
    using System.Net;
    using System.Web.Http;

    public class AccountServiceController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login([FromBody] ModelUser model)
        {
            QueryManager query = new QueryManager();
            var userObtained = query.Login(model.Email, model.Password);
            if (userObtained != null)
            {
                userObtained.Url = "/Home/Products?user=" + userObtained.Id;
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
