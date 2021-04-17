using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using CakeArtWebAPI.Models;

namespace CakeArtWebAPI.Controllers
{

    [RoutePrefix("api/special")]
    public class SpecialController : ApiController
    {

        CakeArtDB db = new CakeArtDB();

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(db.getAllSpecial());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }

        }



        [HttpPost]
        public IHttpActionResult Post([FromBody]Product NewSpecial)
        {
            try
            {
                return Created(new Uri(Request.RequestUri.AbsoluteUri + NewSpecial.id), db.PostSpecial(NewSpecial));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + $" the post was not created successfully with Name = {NewSpecial.Name}");
            }

        }

        [HttpPut]
        [Route("{id}")]
        // api/special/5
        public IHttpActionResult Put(int id, [FromBody] Product prod)
        {
            try
            {
                int res = db.PutSpecial(id, prod);
                return Ok(res);
            }
            catch (Exception)
            {
                //BadRequest(ex.Message);
                return Content(HttpStatusCode.NotFound, $"Special with id= {id} was not found to update!");
            }

        }


        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int res = db.DeleteSpecial(id);
                return Ok(res);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.NotFound, $"Special with id = {id} was not found for delete!");
            }
        }


    }
}
