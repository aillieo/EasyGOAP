namespace Sample
{
    public static class StateHelper
    {
        public static string HashItemKey(string itemType, string itemStatus)
        {
            if (itemStatus == ItemStatus.Default)
            {
                return itemType;
            }

            return $"{itemType}_{itemStatus}";
        }
    }
}
