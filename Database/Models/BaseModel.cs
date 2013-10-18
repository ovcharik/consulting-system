using System;
using System.Collections.Generic;

namespace Database.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            Id = 0;
            _Errors = new Dictionary<string, List<string>>();
            AfterInitialize();
        }

        public virtual Int64 Id { get; set; }

        public virtual bool isNewRecord
        {
            get { return Id == 0; }
        }

        public virtual bool isValid
        {
            get
            {
                Validate();
                return Errors.Count == 0;
            }
        }
        protected virtual void Validate()
        {
            _Errors.Clear();
        }

        private Dictionary<string, List<string>> _Errors;
        public virtual Dictionary<string, List<string>> Errors { get { return _Errors; } }
        protected void AddError(string key, string value)
        {
            if (!_Errors.ContainsKey(key))
            {
                _Errors.Add(key, new List<string>());
            }
            _Errors[key].Add(value);
        }

        protected internal virtual void AfterInitialize() { ; }
        protected internal virtual void BeforeValidate() { ; }
        protected internal virtual void AfterValidate() { ; }
        protected internal virtual void BeforeSave() { ; }
        protected internal virtual void BeforeCreate() { ; }
        protected internal virtual void AfterCreate() { ; }
        protected internal virtual void AfterSave() { ; }
        protected internal virtual void BeforeDelete() { ; }
    }
}
