
namespace Spike.Contracts.Books
{
    using System;

    public interface IBookEditable
    {
        DateTime ReleaseDate { get; set; }
        string Author { get; set; }
    }
}
