using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public interface IMediator
    {
        void AddUser(User entity);
        void BroadcastMessage(string name, string msg);
    }
}
