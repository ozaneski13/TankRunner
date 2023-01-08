using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpUIController : MonoBehaviour
{

    [SerializeField]
    GameObject JumpObject;
    [SerializeField]
    GameObject FireObject;
    [SerializeField]
    GameObject BulldozerObject;
    [SerializeField]
    GameObject MagnetObject;

    [SerializeField]
    TMPro.TextMeshProUGUI JumpCountDown;
    [SerializeField]
    TMPro.TextMeshProUGUI FireCountDown;
    [SerializeField]
    TMPro.TextMeshProUGUI BulldozerCountDown;
    [SerializeField]
    TMPro.TextMeshProUGUI MagnetCountDown;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Deactivate UI Elements
        JumpObject.SetActive(false); 
        FireObject.SetActive(false);
        BulldozerObject.SetActive(false);
        MagnetObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Player.Instance.Tank.GetStatus());


        if (Player.Instance.Tank.GetStatus() != EStatus.Normal)
        {
            if(Player.Instance.Tank.GetStatus() == EStatus.Jump)
            {
                if(count == 0)
                {
                    StartCoroutine(ShowIcon(JumpObject, JumpCountDown));
                }
            }
            else if (Player.Instance.Tank.GetStatus() == EStatus.Fire)
            {
                if (count == 0)
                {
                    StartCoroutine(ShowIcon(FireObject, FireCountDown));
                }
            }
            else if (Player.Instance.Tank.GetStatus() == EStatus.Buldozer)
            {
                if (count == 0)
                {
                    StartCoroutine(ShowIcon(BulldozerObject, BulldozerCountDown));
                }
            }
            else if (Player.Instance.Tank.GetStatus() == EStatus.Magnet)
            {
                if (count == 0)
                {
                    StartCoroutine(ShowIcon(MagnetObject, MagnetCountDown));
                }
            }
        }
    }

    IEnumerator ShowIcon(GameObject iconGameObject, TMPro.TextMeshProUGUI iconCountDownText)
    {
        count = 5;
        iconGameObject.SetActive(true);
        while(count > 0)
        {
            iconCountDownText.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }
        iconGameObject.SetActive(false);
    }
}
