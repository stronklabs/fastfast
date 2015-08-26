using UnityEngine;
using UObject = UnityEngine.Object;
using GObject = UnityEngine.GameObject;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Networking;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public abstract class Spell : ExtBehaviour {
    public string Name = "";
	public float Duration = 0.0f;

	void Update() {
		if ((Duration -= Time.deltaTime) < 0) {
			Destroy (this);
		}
	}
}

public static class SpellExt {
	public static void CastSpell<S> (this Character caster) where S: Spell  {
		caster.gameObject.AddComponent<S> ();
	}
}