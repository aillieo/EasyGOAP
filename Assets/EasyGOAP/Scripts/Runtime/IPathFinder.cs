using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.EasyGOAP
{
    public interface IGraph<T>
    {
        IEnumerable<T> CollectNeighbors(T node);
    }

    public interface IPathfinder<T>
    {
        IEnumerable<T> FindPath(T fromNode, T toNode);
    }
}
