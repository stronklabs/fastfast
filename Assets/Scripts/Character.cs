using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;

public abstract class Character : NetworkBehaviour {
    public class StatsNotFound : Exception { }

    public bool IsOnGround;
    public bool IsStay;
    public List<Buff> CurrentBuffs = new List<Buff>();

    public event Func<Character, Spell, int> onCast;
    public event Func<Character, Buff, int> onBuffApply;
    public event Func<Character, Buff, int> onBuffRemove;
    public event Func<Character, int> onDamageApply;
    public event Func<Character, int> onStaying;
    public event Func<Character, int> onMoving;
    public event Func<Character, int> onJump;
    public event Func<Character, int> onFly;

    protected Stats stats;

	protected void Start () {
        if ((stats = GetComponent<Stats>()) == null) {
            throw new StatsNotFound();
        }

        onCast += (a, b) => { return 0; };
        onBuffApply += (a, b) => { return 0; };
        onBuffRemove += (a, b) => { return 0; };
        onDamageApply += (a) => { return 0; };
        onStaying += (a) => { return 0; };
        onMoving += (a) => { return 0; };
        onJump += (a) => { return 0; };
        onFly += (a) => { return 0; };
	}
	
	void Update () {
        if (!IsOnGround) {
            onFly(this);
        } else if (IsStay) {
            onStaying(this);
        } else {
            onMoving(this);
        }


        List<Buff> toRemove = new List<Buff>();
        foreach (Buff buff in CurrentBuffs) {
            if (buff.duration > 0.0f) {
                buff.Apply(this);
                buff.duration -= Time.deltaTime;
            } else {
                toRemove.Add(buff);
            }
        }
        foreach (Buff remove in toRemove) {
            remove.Remove(this);
            CurrentBuffs.Remove(remove);
        }
	}

    public abstract void MoveLeft();
    public abstract void MoveRight();
    public abstract void Stop();

    public virtual void Jump() {
        onJump(this);
    }

    public virtual void ReceiveDamage(Damage damage) {
        onDamageApply(this);
    }

    public virtual void ReceiveBuff(Buff buff) {
        buff.Apply(this);
    }

    public virtual void CastSpell(Spell spell) {
        onCast(this, spell);
    }
}
