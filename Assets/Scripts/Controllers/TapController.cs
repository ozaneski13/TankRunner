using System.Collections;
using UnityEngine;

public class TapController : MonoBehaviour
{
    [Header("Tap Settings")]
    [SerializeField] private float _doubleTapThreshold = 0.3f;

    private int _tapCount = 0;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                _tapCount++;
                StartCoroutine(SingleOrDoubleTap());
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Player.Instance.PowerUpController.TestJump();
        }
    }

    private IEnumerator SingleOrDoubleTap()
    {
        yield return new WaitForSeconds(_doubleTapThreshold);

        if (_tapCount == 1)
        {
            _tapCount = 0;
            Player.Instance.PowerUpController.Jump();
        }

        else if (_tapCount == 2)
        {
            _tapCount = 0;
            Player.Instance.PowerUpController.Fire();
        }
    }
}