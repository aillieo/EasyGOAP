using UnityEngine;

namespace Sample
{
    public class SceneObj : MonoBehaviour
    {
        public Vector2 GetPosition()
        {
            return this.transform.position.ToVector2();
        }

        public void SetPosition(Vector2 newPosition)
        {
            this.transform.position = newPosition.ToVector3();
        }
    }
}
