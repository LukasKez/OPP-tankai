

using System.Collections.Generic;

namespace Client
{
    class Caretaker
    {
        List<Memento> mementos;

        public Caretaker()
        {
            mementos = new List<Memento>();
        }
        public void AddMemento(Memento m)
        {
            mementos.Add(m);
        }
        public Memento GetMemento(int index)
        {
            return mementos[index];
        }


    }
}
