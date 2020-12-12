using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Mediator : IMediator
    {
        List<User> users = new List<User>();

        public void AddUser(User entity)
        {
            users.Add(entity);
        }

        public void BroadcastMessage(string name, string msg)
        {
            foreach (var user in users)
            {
                user.ReceiveMessage(name, msg);
                Networking.SendMessageAsync(name, msg);
            }
        }
    }
}
