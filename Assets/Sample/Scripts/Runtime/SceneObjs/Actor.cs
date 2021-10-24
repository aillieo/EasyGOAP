using System;
using AillieoUtils.EasyGOAP;
using UnityEngine;
using System.Linq;
using AillieoUtils.PropLogics;

namespace Sample
{
    public class Actor : SceneObj
    {
        public string actorName;
        public float speed;

        [NonSerialized]
        public Agent agent;

        private static IAction[] actions = new IAction[]
        {
            new A_BeefChopping(),
            new A_BeefCooking(),
            new A_BurgerAssemblingCheese(),
            new A_BurgerAssemblingTomato(),
            new A_TomatoChopping(),
            new A_BurgerPlating(),
        };

        private void Start()
        {
            agent = GameManager.Instance.world.CreateAgent();
            agent.AddAvailableActions(actions);

            agent.moveSpeed = speed;
            agent.SetGoal(new Goal(new Condition(StateHelper.HashItemKey(ItemTypes.Burger, ItemStatus.Plated), ConditionMode.GreaterEqual, 1)));
            agent.Init();
        }

        private void OnDestroy()
        {
            agent.CleanUp();
        }

        private void Update()
        {
            agent.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            transform.position = agent.GetPosition().ToVector3();
        }
    }
}
