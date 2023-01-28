using System;using System.Numerics;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine.UIElements;

[Serializable]
public struct BulletData : INetworkSerializable
{
    public BulletColor Color;
    public BulletSize Size;

    public BulletData(BulletColor bulletColor, BulletSize bulletSize)
    {
        Color = bulletColor;
        Size = bulletSize;
    }

    public void NetworkSerialize<BulletData>(BufferSerializer<BulletData> serializer) where BulletData : IReaderWriter
    {
        serializer.SerializeValue(ref Color);
        serializer.SerializeValue(ref Size);
    }
}