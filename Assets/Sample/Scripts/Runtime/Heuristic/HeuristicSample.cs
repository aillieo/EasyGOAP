using System;
using System.Collections.Generic;
using System.Linq;
using AillieoUtils.EasyGOAP;
using AillieoUtils.PropLogics;

namespace Sample
{
    public class HeuristicSample : PlannerAStar.IHeuristicFuncProvider
    {
        private static readonly Dictionary<string, float> predefinedWeights = new Dictionary<string, float>()
        {
            {StateHelper.HashItemKey(ItemTypes.Burger, ItemStatus.Plated), 1000 },
            {StateHelper.HashItemKey(ItemTypes.Burger, ItemStatus.Default), 800 },
        };

        private readonly List<Condition> failedCache = new List<Condition>();
        private readonly Dictionary<string, float> weightCache = new Dictionary<string, float>();

        public float Heuristic(WorldState state, Goal goal)
        {
            failedCache.Clear();

            // 计算 当前世界的状态和目标 的 距离
            bool reached = goal.Reached(state, failedCache);
            if (reached)
            {
                return 0;
            }

            float h = 0;
            foreach (var c in failedCache)
            {
                float weight = GetWeightForKey(c.key);

                // todo 根据 condition 的value差异 计算乘数
                float dist = 1;
                h = h + weight * dist;
            }

            return h;
        }

        private float GetWeightForKey(string key)
        {
            float weightValue = default;

            if (weightCache.TryGetValue(key, out weightValue))
            {
                return weightValue;
            }

            if (predefinedWeights.TryGetValue(key, out weightValue))
            {
                return weightValue;
            }

            weightValue = CalculateWeightForKey(key);
            weightCache[key] = weightValue;

            return weightValue;
        }

        private float CalculateWeightForKey(string key)
        {
            // 运行时计算 weight 需要获取所有action 取最小值
            // todo
            return 100f;
        }
    }
}
