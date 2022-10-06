using System.Collections.Generic;

namespace A6.NET
{
    public abstract class Media
    {

        public int Id { get; set; }
        public string title { get; set; }

        public abstract void Display();
    }
}
