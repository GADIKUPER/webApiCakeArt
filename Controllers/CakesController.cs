using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CakeArtWebAPI.Models;


namespace CakeArtWebAPI.Controllers
{
    [RoutePrefix("api/cakes")]
    public class CakesController : ApiController
    {
        CakeArtDB db = new CakeArtDB();

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(db.getAllCakes());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }

        }


        [HttpPost]
        public IHttpActionResult Post([FromBody]Product NewCake)
        {
            try
            {
                return Created(new Uri(Request.RequestUri.AbsoluteUri + NewCake.id), db.PostCakes(NewCake));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + $" the post was not created successfully with name = {NewCake.Name}");
            }

        }


        [HttpPut]
        [Route("{id}")]
        // api/special/5
        public IHttpActionResult Put(int id, [FromBody] Product prod)
        {
            try
            {
                int res = db.PutCakes(id, prod);
                return Ok(res);
            }
            catch (Exception)
            {
                //BadRequest(ex.Message);
                return Content(HttpStatusCode.NotFound, $"Cake with id= {id} was not found to update!");
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int res = db.DeleteCake(id);
                return Ok(res);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.NotFound, $"Cake with id = {id} was not found for delete!");
            }




        }
    }
}
