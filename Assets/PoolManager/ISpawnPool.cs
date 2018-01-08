using UnityEngine;
using System.Collections.Generic;
public abstract class PrefabPool:MonoBehaviour {
    public GameObject Prefab;
    public int PrefabForInstantiateNum;
   // private List<GameObject> PrefabActiveList;
    private List<GameObject> PrefabDeActiveList;
    public void Init() {
   //     PrefabActiveList = new List<GameObject>();
        PrefabDeActiveList = new List<GameObject>();
    //    PrefabActiveList.Clear();
        PrefabDeActiveList.Clear();
        for (int i = 0; i < PrefabForInstantiateNum; i++)
        {
            PrefabDeActiveList.Add(GameObject.Instantiate(Prefab));
        }
    }
    public GameObject Spawn() {
        if (Prefab != null && CheckListIsNull(PrefabDeActiveList))
        {
            Debug.Log("目前缓冲池中没有足够的" + Prefab.name);
            return GameObject.Instantiate(Prefab);
        }
        else {
            GameObject currentObject = PrefabDeActiveList[0];
            PrefabDeActiveList.RemoveAt(0);
            currentObject.SetActive(true);
     //       PrefabActiveList.Add(currentObject);
            return currentObject;
        }
    }
    public void DeSpawn(GameObject prefabToPool) {
        if (CheckListIsFull(PrefabDeActiveList))
        {
            Debug.Log("目前缓冲池中没有足够的位置存放" + Prefab.name);
            DestroyImmediate(prefabToPool, false);
            return;
        }
        else {
            prefabToPool.SetActive(false);
            PrefabDeActiveList.Add(prefabToPool);
        }
    }
    public bool CheckListIsNull(List<GameObject> listNeedToCheck) {
        return listNeedToCheck.Count == 0;
    }
    public bool CheckListIsFull(List<GameObject> listNeedToCheck)
    {
        return listNeedToCheck.Count== listNeedToCheck.Capacity;
    }
}
