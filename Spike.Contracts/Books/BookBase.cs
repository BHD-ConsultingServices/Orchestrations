
using System.Collections.Generic;

namespace Spike.Contracts.Books
{
    using System;

    public class BookBase : IBookEditable
    {
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Author { get; set; }
    }
}
