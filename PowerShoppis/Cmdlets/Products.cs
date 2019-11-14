using PowerShoppis.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace PowerShoppis
{
    [Cmdlet(VerbsCommon.Get, "ShoppisProducts")]
    public class GetShoppisProducts : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = "Login credentials to Shoppis."
        )]
        public PSCredential Credential { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            HelpMessage = "Skip the amount of items."
        )]
        public int Skip { get; set; } = 0;

        [Parameter(
            Mandatory = false,
            Position = 2,
            HelpMessage = "Sets the amount of items to get."
        )]
        public int Limit { get; set; } = 25;

        [Parameter(
            Mandatory = false,
            Position = 3,
            HelpMessage = "Get all products"
        )]
        public bool All { get; set; }

        private SAPI.Client Client;

        protected override void BeginProcessing()
        {
            Client = new SAPI.Client(Credential);
        }

        protected override void ProcessRecord()
        {
            if (All)
            {
                (List<Product> items, int total) = Client.AllProducts();
                WriteObject(items, true);
                WriteVerbose("Total items: " + total);
            }
            else
            {
                (List<Product> items, int total) = Client.Products(Skip, Limit);
                WriteObject(items, true);
                WriteVerbose("Total items: " + total);
            }   
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }

    [Cmdlet(VerbsCommon.Find, "ShoppisProduct")]
    public class FindShoppisProduct : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = "Login credentials to Shoppis."
        )]
        public PSCredential Credential { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            HelpMessage = "Search for a product."
        )]
        public string Query { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            HelpMessage = "Sets the amount of items to get."
        )]
        public int Limit { get; set; } = 25;

        private API.Client Client;

        protected override void BeginProcessing()
        {
            Client = new API.Client(Credential);
        }

        protected override void ProcessRecord()
        {
            WriteObject(Client.SearchProducts(Query, 0, Limit), true);
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}
