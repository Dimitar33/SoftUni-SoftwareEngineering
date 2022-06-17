namespace Task_1.Web_Api_to_return_data_to_client_apps_systems.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production.ProductDocument")]
    public partial class ProductDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
