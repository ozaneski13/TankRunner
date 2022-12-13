using System.Collections.Generic;
using UnityEngine;

public class LaneController : MonoBehaviour
{
    [Header("Lane Coordinates")]
    [SerializeField] private List<int> _lanesXCoords = new List<int>();
    public List<int> LanesXCoord => _lanesXCoords;
}