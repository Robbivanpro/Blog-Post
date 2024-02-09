using CodePulse.API.Models.Domini;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Implementation;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase

    {
        private readonly IBlogPostRepository blogPostRepository;
        public BlogPostsController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        [HttpPost]

        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDTO request)
        {
            var blogPost = new BlogPost
            {
                Author = request.Author,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                IsVisible = request.IsVisible,
                Title = request.Title,
                PublishedDate = request.PublishedDate,
                ShortDescription = request.ShortDescription,
                UrlHandle = request.UrlHandle,

            };

            blogPost = await blogPostRepository.CreateAsync(blogPost);

            //Convert Domain Model Back to DTO
            var response = new BlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl= blogPost.FeaturedImageUrl,
                IsVisible= blogPost.IsVisible,
                PublishedDate= blogPost.PublishedDate,
                ShortDescription= blogPost.ShortDescription,
                UrlHandle= blogPost.UrlHandle,


            };
            return Ok();
        }

        //Qui creiamo la get all
        [HttpGet]
        
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await blogPostRepository.GetAllAsync();

            //Convertiamo il nostro modello in DTO 
            var response = new List<BlogPostDto>();
            foreach(var blogPost in blogPosts)
            {
                response.Add(new BlogPostDto
                {
                    Id=blogPost.Id,
                    Title = blogPost.Title,
                    Author = blogPost.Author,
                    Content = blogPost.Content,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    IsVisible= blogPost.IsVisible,
                    PublishedDate= blogPost.PublishedDate,
                    ShortDescription= blogPost.ShortDescription,
                    UrlHandle= blogPost.UrlHandle,

                });

            }
            return Ok(response);

        }


    }


}

    
        



        

    

