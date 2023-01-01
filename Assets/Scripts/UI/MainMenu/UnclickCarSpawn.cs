using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnclickCarSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart());
        
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.1f);
        foreach (Transform envs in this.transform)
        {
            foreach (Transform env in envs)
            {
                if(env.name == "Spawners")
                {
                    env.gameObject.SetActive(false);
                }
                //Transform spawner = env.Find("Spawners");
                //spawner.gameObject.SetActive(false);
            }
        }
    }
}
