using UnityEngine;
using System.Collections;

public abstract class Spell {
    public string name = "";

    public abstract void Cast(Character caster);
}
