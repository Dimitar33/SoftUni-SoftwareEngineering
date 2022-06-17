namespace Task_1.Web_Api_to_return_data_to_client_apps_systems.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HumanResources.JobCandidate")]
    public partial class JobCandidate
    {
        public int JobCandidateID { get; set; }

        public int? BusinessEntityID { get; set; }

        [Column(TypeName = "xml")]
        public string Resume { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
