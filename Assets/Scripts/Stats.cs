using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class Stats : NetworkBehaviour {
    [System.Serializable]
    public class StaticStat {
        public float basic;
        public float buffed;

        public static implicit operator StaticStat(float value) {
            return new StaticStat() { basic = value, buffed = value };
        }
    }

    [System.Serializable]
    public class DynamicStat {
        public float basic;
        public float buffed;
        public float current;

        public static implicit operator DynamicStat(float value) {
            return new DynamicStat() { basic = value, buffed = value, current = value };
        }
    }

    public DynamicStat Health = 1;
    public DynamicStat Mana = 1;
    public DynamicStat Resist = 0;
    public DynamicStat MoveSpeed = 0.1f;
    public DynamicStat JumpStrength = 1;
    public DynamicStat JumpCount = 1;


    void Start() {
    }

    void Update() {
    }
}