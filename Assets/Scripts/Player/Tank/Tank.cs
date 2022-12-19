using System.Collections;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [Header("Tank Scripts")]
    [SerializeField] private Tank_Jump _tankJump = null;
    public Tank_Jump TankJump => _tankJump;

    [SerializeField] private Tank_Fire _tankFire = null;
    public Tank_Fire TankFire => _tankFire;

    [SerializeField] private Tank_Health _tankHealth = null;
    public Tank_Health TankHealth => _tankHealth;

    [SerializeField] private Tank_Movement _tankMovement = null;
    public Tank_Movement TankMovement => _tankMovement;

    [Header("Tank Settings")]
    [SerializeField] private float _immuneDuration = 3f;

    [Header("Shake Settings")]
    [SerializeField] private CinemachineController _cinemachineController = null;
    public CinemachineController CinemachineController => _cinemachineController;

    [SerializeField] private float _intensity = 0.3f;

    private EStatus _currentStatus = EStatus.Normal;

    private float _routineTimer = 0f;

    private bool _isTimerStarted = false;
    private bool _isImmune = false;

    private void Update()
    {
        if (_isTimerStarted)
            _routineTimer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Collectable")
            return;
        
        if (_currentStatus == EStatus.Normal && !_isImmune)
        {
            _tankHealth.DecreaseHealth();

            _tankMovement.Crashed();

            StartCoroutine(ImmuneRoutine());
        }
    }

    public void SetStatus(EStatus newStatus) => _currentStatus = newStatus;
    
    private IEnumerator ImmuneRoutine()
    {
        _isImmune = true;
        _isTimerStarted = true;

        while (_routineTimer < _immuneDuration)
        {
            //Flick materials
            yield return new WaitForSeconds(_immuneDuration / 6);
        }

        _isImmune = false;
        _isTimerStarted = false;
        _routineTimer = 0f;
    }

    public void BuldozeStatus(bool status)
    {
        _isImmune = status;

        if (_currentStatus == EStatus.Buldozer)
            _cinemachineController.ShakeCamera(_intensity);
        else
            _cinemachineController.ShakeCamera(0);
        //true ise kamera shake baslat
        //false ise bitir
    }
}