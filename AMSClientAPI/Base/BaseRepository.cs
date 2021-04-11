using AMSClientAPI.Models;
namespace AMSClientAPI.Base
{
    public class BaseRepository : GenericStorage
    {
        public string SQLScript { get; set; }

        public string Code { get; set; }

        public string WebURL { get; set; }

        public string Module { get; set; }

        public string SiteCode { get; set; }

        public long  SiteID { get; set; }

        public bool IsSupplyChain { get; set; }

        public bool FailOver { get; set; }

        public long ReferenceID { get; set; }

        public long RefDetailID { get; set; }

        public string ReferenceNo { get; set; }

        public bool IsDeleted { get; set; }

        public SimpleModel List { get; set; }

    }
}
