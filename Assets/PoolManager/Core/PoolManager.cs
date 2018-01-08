
using System.Collections.Generic;
using UnityEngine;

public class PoolManager {

    private static PoolManager _ins;

    public static PoolManager Ins
    {
        get { return _ins ?? (_ins = new PoolManager()); }
    }

    public Dictionary<string, OnePrefabPool> PoolScriptsDic { get; set; }

    public PoolManager() {
        PoolScriptsDic = new Dictionary<string, OnePrefabPool>();
    }
    public void AddObjPool(string name,GameObject Obj, GameObject ObjParent, int Num) {
        PoolScriptsDic.Add(name,new OnePrefabPool(Obj, ObjParent, Num));
    }
    public void ClearDic() {
        PoolScriptsDic.Clear();
    }

    public void Init() {
        ClearDic();
        GameObject poolObjParent = new GameObject
        {
            name = "PoolObjParent"
        };
        GameObject.DontDestroyOnLoad(poolObjParent);
        AddObjPool(GameObjectPoolName.Demo_One.ToString(), Resources.Load("Capsule") as GameObject, poolObjParent, 3);
        AddObjPool(GameObjectPoolName.Demo_Two.ToString(), Resources.Load("Cube") as GameObject, poolObjParent, 3);
        AddObjPool(GameObjectPoolName.Demo_Three.ToString(), Resources.Load("Sphere") as GameObject, poolObjParent, 3);
    }
}
