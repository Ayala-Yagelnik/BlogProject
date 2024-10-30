using Posts_project.Entities;

namespace Posts_project.Services
{
    public class TagService
    {
        static List<Tag> tags = new List<Tag>(){
            new Tag
            {
                Id=1,
                Name="popular",
                UsageAmount=2,
                Description="manny people read this post",
                CreatorId=1,
                IsActive=true,

            },
            new Tag
            {
                Id=2,
                Name="supported",
                UsageAmount=1,
                Description="the creator give support to the readers",
                CreatorId=1,
                IsActive=true,
            }};
        public List<Tag> Get() => tags;
        public Tag GetById(int id) => tags.FirstOrDefault(x => x.Id == id);
        public bool AddTag(Tag t)
        {
            tags.Add(t);
            return true;
        }
        public bool Update(int id, Tag t)
        {
            Tag existingTagToUpdate = tags.FirstOrDefault(x => x.Id == id);
            if (existingTagToUpdate != null)
            {
                existingTagToUpdate.Name = t.Name;
                existingTagToUpdate.UsageAmount = t.UsageAmount;
                existingTagToUpdate.Description = t.Description;
                existingTagToUpdate.CreatorId = t.CreatorId;
                existingTagToUpdate.Id = t.Id;
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return tags.Remove(tags.FirstOrDefault(x => x.Id == id));
        }
    }
}
