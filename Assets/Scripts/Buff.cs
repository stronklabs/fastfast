﻿using UnityEngine;
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

public abstract class Buff {
    public string name = "";
    public float duration = 0.0f;

    public abstract void Apply(Character character);
    public abstract void Update(Character character);
    public abstract void Remove(Character character);
}
