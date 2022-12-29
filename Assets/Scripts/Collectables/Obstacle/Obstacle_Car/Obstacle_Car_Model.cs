using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Car_Model : MonoBehaviour
{
    [SerializeField] private List<Transform> _wheels = new List<Transform>();
    public List<Transform> Wheels => _wheels;
}