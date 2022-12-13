using System.Collections;
using UnityEngine;

public class TapController : MonoBehaviour
{
    [Header("Tap Settings")]
    [SerializeField] private float _doubleTapThreshold = 0.3f;

    private Player _player = null;

    private int _tapCount = 0;

    private void Start()
    {
        _player = Player.Instance;
    }

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
    }

    private IEnumerator SingleOrDoubleTap()
    {
        yield return new WaitForSeconds(_doubleTapThreshold);

        if (_tapCount == 1)
        {
            _tapCount = 0;
            _player.Jump();
        }

        else if (_tapCount == 2)
        {
            _tapCount = 0;
            _player.Fire();
        }
    }
}