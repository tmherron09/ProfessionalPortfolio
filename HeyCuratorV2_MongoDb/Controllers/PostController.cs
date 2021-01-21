using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Models;
using tmherronProfessionalSite.Services;

namespace HeyCuratorV2_MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public ActionResult<List<PostModel>> Get()
        {
            return _postService.Get();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:length(24)}", Name = "GetPost")]
        public ActionResult<PostModel> Get(string id)
        {
            var profile = _postService.Get(id);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        [HttpPost]
        public ActionResult<PostModel> Create(PostModel profile)
        {
            profile = _postService.Create(profile);

            return CreatedAtRoute("GetPost", new { id = profile.Id.ToString() }, profile);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, PostModel profileUpdate)
        {
            var profile = _postService.Get(id);
            if (profile == null)
            {
                return NotFound();
            }
            _postService.Update(id, profileUpdate);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var profile = _postService.Get(id);
            if (profile == null)
            {
                return NotFound();
            }
            _postService.Remove(profile.Id);

            return NoContent();
        }


    }
}
