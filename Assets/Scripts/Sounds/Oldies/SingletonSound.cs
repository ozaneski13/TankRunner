using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonSound : MonoBehaviour
{

    private static SingletonSound instance = null;

    public static SingletonSound Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if(instance !=null && instance !=this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

}
