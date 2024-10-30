using Posts_project.Entities;

namespace Posts_project.Services
{
    public class PostService
    {
        static List<Post> posts = new List<Post>(){
        new Post
        {
            Id = 3,
            Title = "Third Post",
            Content = "This is the content of the third post.",
            AuthorId = 2,
            CategoryId = 1,
            CreatedAt = DateTime.Now,
            Tags = new List<Tag> { new Tag { Id = 5, Name = "Tag5" }, new Tag { Id = 6, Name = "Tag6" } },
            ViewsAmount = 200,
            Image = new byte[] { 0x11, 0x22, 0x33 },
            LastUpdatedAt = DateTime.Now,
            LastViewedAt = DateTime.Now
        }
    };
        public List<Post> Get() => posts;

        public Post GetById(int id) => posts.FirstOrDefault(x => x.Id == id);

        public bool AddPost(Post p)
        {
            posts.Add(p);
            return true;
        }
        public bool Update(int id, Post p)
        {
            Post existingPostToUpdate = posts.FirstOrDefault(x => x.Id == id);
            if (existingPostToUpdate != null)
            {
                existingPostToUpdate.Title = p.Title;
                existingPostToUpdate.AuthorId = p.AuthorId;
                existingPostToUpdate.Content = p.Content;
                existingPostToUpdate.CategoryId = p.CategoryId;
                existingPostToUpdate.CreatedAt = p.CreatedAt;
                existingPostToUpdate.Tags = p.Tags;
                existingPostToUpdate.ViewsAmount = p.ViewsAmount;
                existingPostToUpdate.Image = p.Image;
                existingPostToUpdate.LastViewedAt = p.LastViewedAt;
                existingPostToUpdate.LastUpdatedAt = p.LastUpdatedAt;
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return posts.Remove(posts.FirstOrDefault(x => x.Id == id));
        }
    }
}
