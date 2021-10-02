using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.GOAP
{
    public interface IGraph<T>
    {
        IEnumerable<T> CollectNeighbors(T node);
    }

    public interface IPathFinder<T>
    {
        IEnumerable<T> FindPath(T fromNode, T toNode);
    }
}
