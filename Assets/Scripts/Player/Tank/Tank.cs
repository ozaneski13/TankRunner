using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private Tank_Magnet _tankMagnet = null;
    public Tank_Magnet TankMagnet => _tankMagnet;

    [SerializeField] private Tank_Movement _tankMovement = null;

    [Header("Tank Settings")]
    [SerializeField] private float _immuneDuration = 3f;
    [SerializeField] private float _flickDuration = 0.2f;
    
    [Header("Shake Settings")]
    [SerializeField] private CinemachineController _cinemachineController = null;
    public CinemachineController CinemachineController => _cinemachineController;
    [SerializeField] private float _intensity = 0.3f;

    private List<Material> materials = new List<Material>();

    private EStatus _currentStatus = EStatus.Normal;

    private float _routineTimer = 0f;

    private bool _isTimerStarted = false;
    private bool _isImmune = false;
    public bool IsImmune => _isImmune;

    private void Update()
    {
        if (_isTimerStarted)
            _routineTimer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Obstacle")
            return;
        
        if (!_isImmune)
        {
            _tankHealth.DecreaseHealth(other.gameObject.GetComponent<Obstacle>().Damage);

            RoadManager.Instance.RoadTreadmill.TankCrashed();
            
            StartCoroutine(ImmuneRoutine());
        }
    }

    public void GetMaterials()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
            foreach (Material material in meshRenderer.materials)
                materials.Add(material);
    }

    public void GetModel()
    {
        Tank_Model[] tankModels = GetComponentsInChildren<Tank_Model>();

        foreach (Tank_Model tankModel in tankModels)
            if (tankModel.gameObject.activeInHierarchy)
            {
                _tankMovement.GetWheels(tankModel);
                break;
            }
    }

    public void SetStatus(EStatus newStatus) => _currentStatus = newStatus;
    public EStatus GetStatus() => _currentStatus;

    private IEnumerator ImmuneRoutine()
    {
        _isImmune = true;
        _isTimerStarted = true;

        while (_routineTimer < _immuneDuration)
        {
            foreach (Material material in materials)
                material.color = new Color(material.color.r, material.color.g, material.color.b, 0);

            yield return new WaitForSeconds(_flickDuration);

            foreach (Material material in materials)
                material.color = new Color(material.color.r, material.color.g, material.color.b, 255);

            yield return new WaitForSeconds(0.5f);
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

        else if (_currentStatus == EStatus.Jump && status)
            return;

        else if (_currentStatus != EStatus.Buldozer || (_currentStatus == EStatus.Jump && !status)) 
            _cinemachineController.ShakeCamera(0);
    }
}