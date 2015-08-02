// This is our new template script.
// It'd create cause i get tired always write "using"...
// And i'd preperead to integrate my "ExtBehaviour",
// but i have to work around with networking and decide
// to double code or not to double.
// Althougth it's not already complete
// i find that this is usefull,
// and if this one would change,
// there is no troubles to change head through source.
// Oh, to apply this piece of shit,
// just replace %UNITY_DIR%/Data/Resources/ScriptTemplate/81-C#~100500.cs.txt by this
//
// P.S. Sorry for my english. Yeah, i know that somebody sense butthurt reading
// this shit, but.. i don't know, we can use native to talk here too, but
// if u understand me right now maybe u buy cooler and let me improve my
// english? Yeah, thank you anyway.

using UnityEngine;
using UObject = UnityEngine.Object;
using GObject = UnityEngine.GameObject;
using URandom = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.Networking;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class #SCRIPTNAME# : ExtBehaviour {
	void Start () {
	}

	void Update () {
	}
}
