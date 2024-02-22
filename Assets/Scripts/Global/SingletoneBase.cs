using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if( _instance == null)
            {
                string typeName = typeof(T).FullName;
                GameObject go = new GameObject(typeName);
                _instance = go.AddComponent<T>();

                DontDestroyOnLoad(go);
            }

            return _instance;
        }
    }

    protected void Init()
    {
        Debug.Log(transform.name + " is Init");
    }
}
