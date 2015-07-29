using UnityEngine;
using System.Collections;

public struct Damage {
    public enum Type {
        physical,
        frost,
        fire
    };

    public float count;
    public Type type;
}
