using Flunt.Notifications;
using System;

namespace WebMotors.Shared.Entities
{
    public abstract class Entity : Notifiable
    {

        protected Entity()
        {
        }

        public long Id { get; private set; }

        protected void Update()
        {
        }

        protected abstract void Validate();
    }
}
