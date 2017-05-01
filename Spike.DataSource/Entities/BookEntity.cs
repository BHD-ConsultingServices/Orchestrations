
using System.Collections.Generic;

namespace Spike.DataSource.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BookEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Author { get; set; }

        public virtual ICollection<CustomerEntity> RentedCustomer { get; set; }
    }
}
