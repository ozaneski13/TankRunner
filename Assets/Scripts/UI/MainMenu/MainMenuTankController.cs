using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTankController : MonoBehaviour
{

    public List<GameObject> TankModels = new List<GameObject>();

    private Transform FrontWheelsTransform;
    private Transform RearWheelsTransform;

    private Vector3 RotationSpeed = new Vector3(-500f, 0, 0);

    private bool isInitializationDone = false;

    // Start is called before the first frame update
    void Start()
    {

        foreach(GameObject tankModel in TankModels)
        {
            tankModel.gameObject.SetActive(false);
        }
        TankModels[(int)Player.Instance.CurrentTank].gameObject.SetActive(true);

        // ------------------------------------------------------------------------------------

        char firstModel = 'A';
        string frontModelName = "Tank_" + (char)(Convert.ToUInt16(firstModel) + (int)Player.Instance.CurrentTank) + "_Gear_F";
        string rearModelName = "Tank_" + (char)(Convert.ToUInt16(firstModel) + (int)Player.Instance.CurrentTank) + "_Gear_R";
        FrontWheelsTransform = TankModels[(int)Player.Instance.CurrentTank].gameObject.transform.Find(frontModelName);
        RearWheelsTransform = TankModels[(int)Player.Instance.CurrentTank].gameObject.transform.Find(rearModelName);
        
        isInitializationDone = true;
    }

    private void Update()
    {
        if(isInitializationDone)
        {
            RotateWheels();
        }
    }

    void RotateWheels()
    {
        FrontWheelsTransform.Rotate(RotationSpeed * Time.deltaTime);
        RearWheelsTransform.Rotate(RotationSpeed * Time.deltaTime);
    }
    
}
