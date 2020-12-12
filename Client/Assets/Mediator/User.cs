using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class User : MessageBroadcaster
    {
        public User(Mediator mediator, string newName) : base(mediator, newName)
        {
        }

        public override void SendMessage(string msg)
        {
            m.BroadcastMessage(Options.name, msg);
        }

        public override void ReceiveMessage(string senderName, string msg)
        {
            Console.WriteLine("receiving message from ("+ senderName +"): " + msg);
        }
    }
}
