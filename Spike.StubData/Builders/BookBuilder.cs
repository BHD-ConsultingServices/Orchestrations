
namespace Spike.StubData.Builders
{
    using System;
    using Contracts.Books;

    public class BookBuilder : Book
    {
        public BookBuilder(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }

        public BookBuilder Generator(int seed)
        {
            this.Author = $"Author Name [{seed}]";
            this.Title = $"Book Title [{seed}]";
            this.ReleaseDate = DateTime.Now.AddYears(-seed);

            return this;
        }

        public BookBuilder FiveDysfunctions()
        {
            this.Id = Guid.Parse("51867818-FD1B-41B4-B090-A05536D5ED9F");

            this.Title = "The Five Dysfunctions of a Team";
            this.Author = "Patrick M. Lencioni";
            this.ReleaseDate = new DateTime(2008,01,01);

            return this;
        }

        public BookBuilder ThePhoenixProject()
        {
            this.Id = Guid.Parse("D1053824-71CF-4BB1-B5CC-2DC19F48879E");

            this.Title = "The Phoenix Project";
            this.Author = "Gene Kim, Kevin Behr, George Spafford";
            this.ReleaseDate = new DateTime(2013, 01, 01);

            return this;
        }

        public Book Build()
        {
            return new Book
            {
                Id = this.Id,
                Author = this.Author,
                Title = this.Title,
                ReleaseDate = this.ReleaseDate
            };
        }
    }
}
