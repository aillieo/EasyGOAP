using AillieoUtils.EasyGOAP;

namespace Sample
{
    public abstract class SampleDefaultAction : DefaultAction
    {
        public override WorldState GetAssociatedState()
        {
            return GameManager.Instance.world.GetWorldState();
        }
    }
}
