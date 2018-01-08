using UnityEngine;
using System.Collections.Generic;
public class OnePrefabPool {
    public GameObject Prefab;
    public GameObject PrefabCollection;
    public GameObject CollectionObj;
    public int PrefabForInstantiateNum;
    public List<GameObject> PrefabDeActiveList;

    public OnePrefabPool(GameObject prefab, GameObject prefabParent, int Num)
    {
        Prefab = prefab;
        PrefabForInstantiateNum = Num;
        CollectionObj = prefabParent;
        Init();
    }

    public void Init() {
        PrefabCollection = new GameObject();
        PrefabCollection.name = Prefab.name + "_Collection";
        PrefabCollection.transform.parent = CollectionObj.transform;

        PrefabDeActiveList = new List<GameObject>(PrefabForInstantiateNum);
        PrefabDeActiveList.Clear();
        for (int i = 0; i < PrefabForInstantiateNum; i++)
        {
            GameObject obj = GameObject.Instantiate(Prefab);
            obj.SetActive(false);
            obj.transform.parent = PrefabCollection.transform;
            PrefabDeActiveList.Add(obj);
        }
    }
    public GameObject Spawn() {
        if (Prefab != null && CheckListIsNull(PrefabDeActiveList))
        {
            Debug.Log("目前缓冲池中没有足够的" + Prefab.name);
            GameObject Obj = GameObject.Instantiate(Prefab);
            Obj.SetActive(true);
            return Obj;
        }
        else if(!CheckListIsNull(PrefabDeActiveList))
        {
            GameObject currentObject = PrefabDeActiveList[0];
            PrefabDeActiveList.RemoveAt(0);
            currentObject.SetActive(true);
            return currentObject;
        }
        return null;
    }
    public void DeSpawn(GameObject prefabToPool) {
        if (CheckListIsFull(PrefabDeActiveList))
        {
            Debug.Log("目前缓冲池中没有足够的位置存放" + Prefab.name);
            GameObject.Destroy(prefabToPool);
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
