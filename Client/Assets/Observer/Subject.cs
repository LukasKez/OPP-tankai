using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Subject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver o)
        {
            observers.Add(o);
        }

        public void Detach(IObserver o)
        {
            observers.Remove(o);
        }

        protected void Notify()
        {
            foreach (var observer in observers)
            {
                observer.OnSubjectUpdate();
            }
        }
    }
}
