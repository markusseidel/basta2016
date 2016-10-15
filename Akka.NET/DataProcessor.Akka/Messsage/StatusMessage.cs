using Akka.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor.Akka.Messsage
{
    public class StatusMessage
    {
        //public string Text { get; set; }
        public int Id { get; set; }
        public ProcessStatus Status { get; set; }

        public StatusMessage(string senderPath, int id, ProcessStatus status)
        {
            this.Id = id;
            this.Status = status;
            //Text = string.Format("[{0}]: {1}", senderPath, msg);
        }
    }
}
