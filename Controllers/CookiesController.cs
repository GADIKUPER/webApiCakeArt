using CakeArtWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CakeArtWebAPI.Controllers
{
    [RoutePrefix("api/cookies")]
    public class CookiesController : ApiController
    {
        CakeArtDB db = new CakeArtDB();

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(db.getAllCookies());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }

        }


        [HttpPost]
        public IHttpActionResult Post([FromBody]Product NewCookie)
        {
            try
            {
                return Created(new Uri(Request.RequestUri.AbsoluteUri + NewCookie.id), db.PostCookies(NewCookie));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + $" the post was not created successfully with Name = {NewCookie.Name}");
            }
        }

        [HttpPut]
        [Route("{id}")]
        // api/special/5
        public IHttpActionResult Put(int id, [FromBody] Product prod)
        {
            try
            {
                int res = db.PutCookies(id, prod);
                return Ok(res);
            }
            catch (Exception)
            {
                //BadRequest(ex.Message);
                return Content(HttpStatusCode.NotFound, $"Cookie with id= {id} was not found to update!");
            }

        }


        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int res = db.DeleteCookies(id);
                return Ok(res);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.NotFound, $"Cookie with id = {id} was not found for delete!");
            }


        }
    }
}
