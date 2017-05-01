
namespace Spike.Contracts.Books
{
    using System;

    public class Book : BookBase
    {
        public Guid Id { get; set; }

        public override string ToString()
        {
            return $"ID [{Id}] Title [{Title}] Author [{Author}] Release Date [{ReleaseDate.ToShortDateString()}]";
        }
    }
}
