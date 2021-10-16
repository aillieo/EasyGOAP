using System.Collections;
using System.Collections.Generic;

namespace Sample
{
    public static class ItemTypes
    {
        public const string Burger = nameof(Burger);
        public const string Beef = nameof(Beef);
        public const string Tomato = nameof(Tomato);
        public const string Cheese = nameof(Cheese);
        public const string Bun = nameof(Bun);
    }

    public static class ItemStatus
    {
        public const string Default = nameof(Default);
        public const string Raw = nameof(Raw);
        public const string Chopped = nameof(Chopped);
        public const string Cooked = nameof(Cooked);
        public const string Plated = nameof(Plated);
    }
}
