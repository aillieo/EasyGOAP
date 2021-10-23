using System;

namespace AillieoUtils.PropLogics
{
    public class Condition
    {
        public readonly string key;
        public readonly PropertyCondition propertyCondition;

        public Condition(string key, ConditionMode op, Property value)
        {
            this.key = key;
            this.propertyCondition = new PropertyCondition()
            {
                op = op,
                referenceValue = value,
            };
        }

        public bool Evaluate(IPropertyProvider properties)
        {
            Property prop = properties.Get(key);
            //if (!prop.Valid())
            //{
            //    return false;
            //}

            return propertyCondition.EvaluateWith(prop);
        }

        //public Condition And(Condition other)
        //{
        //    throw new NotImplementedException();
        //}

        //public Condition Or(Condition other)
        //{
        //    throw new NotImplementedException();
        //}

        //public Condition Not()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
