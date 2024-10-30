using Microsoft.AspNetCore.Mvc;
using Posts_project.Entities;

namespace Posts_project.Services
{
    public class CommentService
    {
        static List<Comment> comments = new List<Comment>(){
            new Comment
            { 
                Id =1,
                Content ="hello to every one!!!",
                AuthorId =1,
                PostId =1,
                CreatedAt =DateTime.Now
            },
            new Comment
            {
                Id =2,
                Content ="hello to every body!!!",
                AuthorId =1,
                PostId =1,
                CreatedAt =DateTime.Now
            },
            new Comment
            {
                Id =3,
                Content ="hi every one!!!",
                AuthorId =2,
                PostId =1,
                CreatedAt =DateTime.Now
            }};
        public List<Comment> Get() => comments;

        public Comment GetById(int id) => comments.FirstOrDefault(x => x.Id == id);

        public bool AddComment(Comment comment)
        {
            comments.Add(comment);
            return true;
        }
        public bool Update(int id, Comment comment)
        {
            Comment existingCommentToUpdate = comments.FirstOrDefault(x => x.Id == id);
            if (existingCommentToUpdate != null)
            {
                existingCommentToUpdate.PostId = comment.PostId;
                existingCommentToUpdate.AuthorId = comment.AuthorId;
                existingCommentToUpdate.CreatedAt = comment.CreatedAt;
                existingCommentToUpdate.Content = comment.Content;
                existingCommentToUpdate.Id = comment.Id;
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return  comments.Remove(comments.FirstOrDefault(x => x.Id == id));
        }
    }
}
