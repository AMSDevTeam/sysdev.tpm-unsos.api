/**
 * This class contains all the constant variable of the synchronizer
 * all uri's and api's are define in this class
 * <March 29, 2021></March>
 * 
 */
namespace AMSClientAPI.Base
{
    public class Constant
    {
        // API Credentials
        public const string api_username = "sysdevams";
        public const string api_password = "unsostpm2020";

        // HTTP Methods
        public const string POST = "POST";
        public const string GET = "GET";
        public const string DELETE = "DELETE";
        public const string PUT = "PUT";

        public const string picklist_assignedunit_uri = "api/StandardEntries/AssignedUnit";
        public const string picklist_assignedunit = "AssignedUnit";



        public const string sales_workorder_uri = "api/Sales/WorkOrder";
        public const string sales_workorder = "WorkOrder";

        public const string sales_quotation_uri = "api/Sales/Quotation";
        public const string sales_quotation = "Quotation";

        public const string sales_sales_invoice_uri = "api/Sales/SalesInvoice";
        public const string sales_sales_invoice = "SalesInvoice";

        public enum moduleEnum
        {
            AssignedUnit,
            Quotation,
            SalesInvoice,
            WorkOrder,
            
        }

    }
}
