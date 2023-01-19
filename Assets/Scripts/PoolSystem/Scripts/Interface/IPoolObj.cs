using System;
using UnityEngine;

namespace PoolSystem
{
    public interface IPoolObj
    {
        Action<IPoolObj> OnRelease { get; set; }
        Transform Transform { get; }
        IPool Pool { get;}
        void Initialize(IPool pool);
        void Release();

    }
}