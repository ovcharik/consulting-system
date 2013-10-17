using System;

namespace Database.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            Id = 0;
        }

        public virtual Int64 Id { get; set; }
        public virtual bool isNewRecord
        {
            get { return Id == 0; }
        }
    }
}
