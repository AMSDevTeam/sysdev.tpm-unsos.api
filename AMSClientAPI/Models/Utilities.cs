namespace AMSClientAPI.Models
{
    public class Scripts
    {
        public string TransactionCode { get; set; }

        public string SiteCode { get; set; }

        public string SystemVersion { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Script { get; set; }

        public string Message { get; set; }

        public byte? RequiredAuthorization { get; set; }

        public byte? RequiredBackUp { get; set; }

        public byte? RequiredExit { get; set; }

        public byte? RequiredShutDown { get; set; }

    }

    public class Chirography
    {

        public string TransactionCode { get; set; }

        public string SiteCode { get; set; }

        public string SystemVersion { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Script { get; set; }

        public string Message { get; set; }

        public byte? Executed { get; set; }

    }

    public class SimpleModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SiteCode { get; set; }
        public bool IsSCMLocation { get; set; }
    }
}
