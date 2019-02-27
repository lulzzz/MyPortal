using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using MyPortal.Dtos;
using MyPortal.Models;

namespace MyPortal.Controllers.Api
{
    public class CommentsController : ApiController
    {
        private readonly MyPortalDbContext _context;

        public CommentsController()
        {
            _context = new MyPortalDbContext();
        }

        public CommentsController(MyPortalDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/comments/create")]
        public IHttpActionResult CreateComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Invalid data");
            }

            _context.Comments.Add(comment);
            _context.SaveChanges();
            return Ok("Comment added");
        }

        [HttpDelete]
        [Route("api/comments/delete/{id}")]
        public IHttpActionResult DeleteComment(int id)
        {
            var comment = _context.Comments.SingleOrDefault(x => x.Id == id);

            if (comment == null)
            {
                return Content(HttpStatusCode.NotFound, "Comment not found");
            }

            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return Ok("Comment deleted");
        }

        [HttpGet]
        [Route("api/comments/byId/{id}")]
        public CommentDto GetCommentById(int id)
        {
            var comment = _context.Comments.SingleOrDefault(x => x.Id == id);

            if (comment == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Comment, CommentDto>(comment);
        }

        [HttpGet]
        [Route("api/comments/all")]
        public IEnumerable<CommentDto> GetComments()
        {
            return _context.Comments
                .OrderBy(x => x.Value)
                .ToList()
                .Select(Mapper.Map<Comment, CommentDto>);
        }

        [HttpGet]
        [Route("api/comments/byBank/{id}")]
        public IEnumerable<CommentDto> GetCommentsByCommentBank(int id)
        {
            return _context.Comments
                .Where(x => x.CommentBankId == id)
                .OrderBy(x => x.Value)
                .ToList()
                .Select(Mapper.Map<Comment, CommentDto>);
        }

        [HttpPost]
        [Route("api/comments/update")]
        public IHttpActionResult UpdateComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Invalid data");
            }

            var commentInDb = _context.Comments.SingleOrDefault(x => x.Id == comment.Id);

            if (commentInDb == null)
            {
                return Content(HttpStatusCode.NotFound, "Comment not found");
            }

            commentInDb.Value = comment.Value;
            commentInDb.CommentBankId = comment.CommentBankId;

            _context.SaveChanges();

            return Ok("Comment updated");
        }
    }
}