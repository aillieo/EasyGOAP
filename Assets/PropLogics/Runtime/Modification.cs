namespace AillieoUtils.PropLogics
{
    public class Modification
    {
        public readonly string key;
        public readonly PropertyModification propertyModification;

        public Modification(string key, ModifyMode op, Property value)
        {
            this.key = key;
            this.propertyModification = new PropertyModification()
            {
                op = op,
                operand = value,
            };
        }

        public void ApplyModifications(IPropertyProvider properties)
        {
            Property prop = properties.Get(key);
            properties.Set(key, propertyModification.ApplyModification(prop));
        }
    }
}
