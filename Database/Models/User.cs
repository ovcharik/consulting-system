namespace Database.Models
{
    using Repositories;

    public class User : BaseModel
    {
        public enum Roles
        {
            Admin = 0x01,
            User  = 0x02
        }

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string ConfrimPassword { get; set; }
        public virtual Roles Role { get; set; }

        protected internal override void AfterInitialize()
        {
            base.AfterInitialize();
            Role = Roles.User;
        }

        protected override void Validate()
        {
            base.Validate();
            if (Username.Length == 0)
            {
                AddError("Username", "Не может быть пустым");
            }
            if (!isNewRecord)
            {
                User u = UserRepository.GetByUsername(Username);
                if (u != null)
                {
                    AddError("Username", "Имя уже занято");
                }
                if (Password != ConfrimPassword)
                {
                    AddError("ConfrimPassword", "Пароли не совпадают");
                }
            }
        }
    }
}
