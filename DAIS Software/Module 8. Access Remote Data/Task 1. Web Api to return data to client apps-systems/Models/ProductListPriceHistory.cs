namespace Task_1.Web_Api_to_return_data_to_client_apps_systems.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production.ProductListPriceHistory")]
    public partial class ProductListPriceHistory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Column(TypeName = "money")]
        public decimal ListPrice { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
