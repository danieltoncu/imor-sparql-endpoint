using System;
using System.Collections.Generic;
using Imor.Api.Contracts;
using Imor.Business;
using Imor.Database;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Imor.Api.Controllers
{
    [Route("api/Images")]
    public class ImagesController : Controller
    {
        [HttpGet]
        public IEnumerable<ImorImage> Get()
        {
            var repo = new ImagesRepository();

            return repo.GetImages();
        }

        [HttpGet("byUri")]
        public ImorImage Get(string imageUri)
        {
            var repo = new ImagesRepository();

            return repo.GetImageByUri(imageUri);
        }

        [HttpGet("similar")]    
        public IEnumerable<ImorImage> GetSimmilarImages(string imageUri)
        {
            var repo = new ImagesRepository();

            return repo.GetSimilarImages(imageUri, 10);
        }

        [HttpGet("byTag")]
        public IEnumerable<ImorImage> GetImagesForTag(string tagUri)
        {
            var repo = new ImagesRepository();

            return repo.SearchImagesByTag(tagUri);
        }

        [HttpPost]
        [Route("create")]
        public void Post([FromBody]CreateImageCommand request)
        {
            var repository = new ImagesRepository();

                var tagRepository = new TagsRepository();

                var tags = new List<ImorTag>();

                foreach (var tag in request.Tags)
                {
                    var existingTag = tagRepository.GetTagByUri(tag);

                    if (existingTag != null)
                    {
                        tags.Add(existingTag);
                    }
                }

                repository.InsertImage(new ImorImage
                {
                    Uri = request.Uri,
                    Description = request.Description,
                    Content = request.Content,
                    Tags = tags
                });
            }
        }
    }
