using UnityEngine;
using UnityEngine.SceneManagement;

public class Usable_Coin : Usables
{
    [Header("Coin Settings")]
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _point = 100f;

    private bool _isMagnetic = false;

    public override void PlayerCollided()
    {
        base.PlayerCollided();

        PointManager.Instance.PointGained(_point);
    }

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "GameScene")
        {
            transform.gameObject.SetActive(false); 
        }
    }

    private void Update()
    {
        if (_isMagnetic)
            transform.position = Vector3.MoveTowards(transform.position, 
                Player.Instance.Tank.gameObject.transform.position, 
                _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Magnet")
            _isMagnetic = true;

        else if (other.gameObject.tag == "Tank")
            PlayerCollided();
    }

    private void OnDisable()
    {
        _isMagnetic = false;
    }
}