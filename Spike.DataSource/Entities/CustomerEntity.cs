
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spike.DataSource.Entities
{
    public class CustomerEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string IdentityNumer { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<BookEntity> RentedBooks { get; set; }
    }
}
