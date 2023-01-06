using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Fire : MonoBehaviour
{
    [Header("Fire Settings")]
    [SerializeField] private List<Transform> _muzzlePositions = null;
    [SerializeField] private Transform _muzzleParticle = null;
    [SerializeField] private Transform _fireBox = null;
    [SerializeField] private LayerMask _hitLayers;

    [Header("Shake Settings")]
    [SerializeField] private CinemachineController _cinemachineController = null;
    [SerializeField] private float _intensity = 0.2f;
    [SerializeField] private float _shakeDuration = 0.1f;

    public void Fire()
    {
        _muzzleParticle.position = _muzzlePositions[(int)Player.Instance.CurrentTank].position;

        _muzzleParticle.gameObject.SetActive(true);
        _cinemachineController.ShakeCamera(_intensity);

        Collider[] hits = Physics.OverlapBox(_fireBox.position, _fireBox.localScale/2, Quaternion.identity ,_hitLayers);

        foreach (Collider hit in hits)
            hit.GetComponent<Obstacle>().PlayerCollided();

        StartCoroutine(FireShakeRoutine());
    }

    private IEnumerator FireShakeRoutine()
    {
        yield return new WaitForSeconds(_shakeDuration);

        _cinemachineController.ShakeCamera(0);
        _muzzleParticle.gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireCube(_fireBox.position, _fireBox.localScale);
    }
}