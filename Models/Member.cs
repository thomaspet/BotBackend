
namespace BotBackend.Models
{
    public class Member
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Discriminator { get; set; }
        public long Salary { get; set; }
    }
}
