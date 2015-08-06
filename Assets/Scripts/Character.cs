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

public abstract class Character : NetworkBehaviour {
    public class StatsNotFound : Exception { }

    public bool IsOnGround;
    public bool IsStay;

    protected Stats stats;

	protected void Start () {
        if ((stats = GetComponent<Stats>()) == null) {
            throw new StatsNotFound();
        }
	}
	
	void Update () {
	}

    public abstract void MoveLeft();
    public abstract void MoveRight();
    public abstract void Stop();
	public abstract void Jump ();

	// on damage event we just call BroadcastMessage
    void ReceiveDamage(Damage damage) {
		// here we have to implement order-logic
		foreach (Buff b in GetComponents<Buff>()) {
			damage = b.OnDamage (damage);
		}

		ApplyDamage (damage);
    }

	// here we implement on damagable characters
	public abstract void ApplyDamage (Damage damage);

	public virtual void ReceiveBuff<B>() where B: Buff {
		gameObject.AddComponent<B> ();
    }
}