using UnityEngine;
using System.Collections;

public class BossTigerCombat : AnimalCombat {
    Health health;

    override protected void Start()
    {
        base.Start();
        health = GetComponent<Health>();
    }
	// Update is called once per frame
	override protected void Update () {
        base.Update();
        if (health.current <= health.max / 2)
        {
            waitTime = 0;
        }
	}
}
