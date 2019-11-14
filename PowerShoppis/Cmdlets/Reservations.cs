﻿using System.Management.Automation;

namespace PowerShoppis
{
    [Cmdlet(VerbsCommon.Get, "Reservations")]
    public class GetReservations : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = "Login credentials to Shoppis."
        )]
        public PSCredential Credential { get; set; }

        private SAPI.Client Client;

        protected override void BeginProcessing()
        {
            Client = new SAPI.Client(Credential);
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
