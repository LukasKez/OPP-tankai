using System;

namespace Client
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }
}
