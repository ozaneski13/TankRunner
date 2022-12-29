using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    public void ActivateFadeOut()
    {
        anim.SetTrigger("FadeOut");
    }

    public void ActivateSlowFadeOut()
    {
        anim.SetTrigger("SlowFadeOut");
    }

    public void OnFadeCompleted()
    {
        Debug.Log("FadeCompleted!");
    }

}
