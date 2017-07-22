using System;
using UnityEngine;

[Serializable]
public class ParticleConnection
{
    public GameObject OtherGameObject;
    public SpringJoint2D Spring;
    public LineRenderer LineRenderer;
}
