using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;




namespace CmdLet
{
    [Cmdlet(VerbsCommon.Get, "NetworkAdapter")]
    [OutputType(typeof(NetworkAdapter))]
    public class GetExcerciseEmCmdlet: Cmdlet
    {
        [Parameter]
        public string Name { get; set; }
        [Parameter]
        public string Manufacturer { get; set; }
        [Parameter]
        public bool PhysicalAdapter { get; set; }
        [Parameter]
        public int MaxEntries { get; set; }
    }
    public class NetworkAdapter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DeviceId { get; set; }
        public string Manufacturer { get; set; }
        public string NetConnectionId { get; set; }
        public bool PhysicalAdapter { get; set; }
    }
}
