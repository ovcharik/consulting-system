namespace Database.Models
{
    public class User : BaseModel
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }
}
