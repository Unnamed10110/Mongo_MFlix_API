using Microsoft.AspNetCore.Mvc;
using Mongo_MFlix_API.Models;
using Mongo_MFlix_API.Services;

namespace Mongo_MFlix_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MFlixController : ControllerBase
    {
        private readonly MFlix_Service mFlix_Service;

        public MFlixController(MFlix_Service mFlix_Service)
        {
            this.mFlix_Service = mFlix_Service;
        }

        [Route("getAllMovies")]
        [HttpGet]
        public ActionResult<List<MFlix_Collection>> GetMovies()
        {
            return Ok(mFlix_Service.GetAll());
        }
        [Route("getOneMovie")]
        [HttpGet]
        public ActionResult<MFlix_Collection> GetMovies(string id)
        {
            return Ok(mFlix_Service.GetOne(id));
        }

        [Route("postOneMovie")]
        [HttpPost]
        public ActionResult<MFlix_Collection> PostMovie(MFlix_Collection document)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100000000);
            document.Id = document.Id + number.ToString();
            mFlix_Service.PostOne(document);
            return Ok(document);
        }

        [Route("updateOneMovie")]
        [HttpPost]
        public ActionResult<MFlix_Collection> UpdateMovie(string id, MFlix_Collection document)
        {
            mFlix_Service.Update(id, document);
            return Ok(document);
        }
        


        [Route("removeOneMovie")]
        [HttpDelete]
        public ActionResult<MFlix_Collection> RemoveMovie(string id)
        {
            var res=mFlix_Service.Delete(id);
            return Ok(new
            {
                MessageResult=$"Deleted document with id:{id}",
                Result=res
            });
        }

    }
}
