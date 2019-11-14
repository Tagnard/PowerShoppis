using System.Management.Automation;

namespace PowerShoppis
{
    [Cmdlet(VerbsCommon.Get, "Reservations")]
    public class GetReservations : PSCmdlet
    {
        [Parameter(
            Mandatory = false,
            Position = 0,
            HelpMessage = "Login credentials to Shoppis."
        )]
        public PSCredential Credentials { get; set; }

        private SAPI.Client Client;

        protected override void BeginProcessing()
        {
            if (Credentials == null)
            {
                Credentials = this.Host.UI.PromptForCredential("Login to Shoppis", "Enter email and password", "", "");
            }

            Client = new SAPI.Client(Credentials.UserName, Credentials.GetNetworkCredential().Password);
        }

        protected override void ProcessRecord()
        {
            WriteObject(Client.Reservations(), true);
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}
