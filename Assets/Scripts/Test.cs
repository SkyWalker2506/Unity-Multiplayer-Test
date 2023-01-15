using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private BulletData _bulletData;
    // Start is called before the first frame update
    void Start()
    {
        var _bulletPool = Resources.Load<BulletPool>("BulletPool");
        Debug.Log(_bulletPool);
        BulletFactory.Instance.GetBullet(_bulletData);
    }

}