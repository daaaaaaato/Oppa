using System.ComponentModel.DataAnnotations.Schema;

namespace Oppa.Data.Models
{
    public class Service : BaseEntity<int>
    {
        public string Name { get; set; }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
