using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField]
    private int _maxPoolPoits;

    private Queue<Vector3> _pathPool = new Queue<Vector3>(3);

    public Queue<Vector3> GetPathPool()
    {
        return _pathPool;
    }

    public void AddPointPool(Vector3 value)
    {
        if (_pathPool.Count < _maxPoolPoits)
        {
            _pathPool.Enqueue(value);
        }      
    }

    public void DeletePointPool()
    {
        _pathPool.Dequeue();
    }
}
