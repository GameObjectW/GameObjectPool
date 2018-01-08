using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PoolManager.Ins.Init();
	}

    public void SpawnOne()
    {
        PoolManager.Ins.PoolScriptsDic[GameObjectPoolName.Demo_One.ToString()].Spawn();
    }
    public void SpawnTwo()
    {
        PoolManager.Ins.PoolScriptsDic[GameObjectPoolName.Demo_Two.ToString()].Spawn();
    }
    public void SpawnThree()
    {
        PoolManager.Ins.PoolScriptsDic[GameObjectPoolName.Demo_Three.ToString()].Spawn();
    }
}
