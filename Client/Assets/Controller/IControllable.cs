using System;

namespace Client
{
    internal interface IControllable
    {
        void Move(float direction);
        void Rotate(float direction);
        void LookAt(float direction);
        void Action();
    }
}
