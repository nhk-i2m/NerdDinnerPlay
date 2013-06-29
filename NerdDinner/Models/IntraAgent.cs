using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class IntraAgent
    {
        public int Id { get; set; }
	    public string UserName { get; set; }
	    public string IntraUserName { get; set; }
	    public string IntraPassword{ get; set; }
	    public bool AgentRunning { get; set; }

    }
}