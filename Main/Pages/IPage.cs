using System;

namespace Main.Pages
{
    public interface IPage
    {
        Int32 NextOffset();
        void Clear();
    }
}
