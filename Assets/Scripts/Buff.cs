using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public abstract class Buff {
    public string name = "";
    public float duration = 0.0f;

    public abstract void Apply(Character character);
    public abstract void Update(Character character);
    public abstract void Remove(Character character);
}
