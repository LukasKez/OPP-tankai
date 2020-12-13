using Server.Hubs;
using System;

namespace Server
{
    public abstract class Validator
    {
        protected Validator next;

        protected Validator()
        {

        }

        public Validator SetNext(Validator nextValidator)
        {
            Validator lastValidator = this;

            while (lastValidator.next != null)
            {
                lastValidator = lastValidator.next;
            }

            lastValidator.next = nextValidator;
            return this;
        }

        public bool Validate(GameHub hub)
        {
            if (!Validation(hub))
            {
                return false;
            }

            if (next != null)
            {
                return next.Validate(hub);
            }

            return true;
        }

        abstract protected bool Validation(GameHub hub);
    }
}
