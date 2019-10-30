using System;

namespace BO
{
    public abstract class Base
    {
        public Base()
        {
            IsActive = true;
            RCT = DateTime.Now;
            RUT = DateTime.Now;
        }
        public long Id { get; set; }
        public long RCB { get; set; }
        public long RUB { get; set; }
        public DateTime RCT { get; set; }
        public DateTime RUT { get; set; }
        public bool? IsActive { get; set; }
    }
}
