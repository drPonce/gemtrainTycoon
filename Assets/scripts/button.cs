using UnityEngine;

public class button : MonoBehaviour
{

    public buildingType buildingType;


    private void OnMouseDown()
    {
        levelManager.Instance.buildBuilding(buildingType);
    }




}
