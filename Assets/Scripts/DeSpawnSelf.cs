using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawnSelf : MonoBehaviour
{

    public GameObjectPoolName PoolName;
	// Use this for initialization
	void OnEnable () {
		Invoke("DeSpawn",3);
	}

    private void DeSpawn()
    {
        PoolManager.Ins.PoolScriptsDic[PoolName.ToString()].DeSpawn(gameObject);
    }

}
