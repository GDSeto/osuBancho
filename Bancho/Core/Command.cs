﻿using osuBancho.Core.Serializables;

namespace osuBancho.Core
{
    internal struct Command
    {
        internal short Id;
        internal bSerializable Serializable;
        internal object RegularType;
        internal bool noHasData;

        public Command(Commands command, object serializable)
            : this((short)command, serializable)
        {
        }

        public Command(short id, object serializable)
        {
            this.Id = id;
            this.noHasData = serializable == null;
            if (this.noHasData)
            {
                this.Serializable = null;
                this.RegularType = null;
                return;
            }
            this.Serializable = serializable as bSerializable;
            this.RegularType = this.Serializable == null ? serializable : null;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, {1}", Id.ToString(), this.Serializable != null ? this.Serializable.GetType().Name : this.RegularType.GetType().Name);
        }
    }
}