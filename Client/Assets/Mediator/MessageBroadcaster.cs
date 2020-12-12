using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public abstract class MessageBroadcaster
    {
		protected Mediator m;
		protected string name;

		public MessageBroadcaster(Mediator mediator, string newName)
		{
			m = mediator;
			name = newName;
		}

		public abstract void SendMessage(string message);
		public abstract void ReceiveMessage(string name, string message);
	}
}
