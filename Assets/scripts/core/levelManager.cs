using UnityEngine;

public class levelManager : MonoBehaviour
{

    public static levelManager Instance;

    [Header("Train Path")]
    public Transform[] path;
    public Transform startingPoint;

    [Header("BuildingPrefabs")]
    public GameObject quarryPrefab;
    public GameObject marketPrefab;
    public GameObject factoryPrefab;

    [Header("PublicInfoDuringGame")]
    public plot currentlyHighlightedPlot;

    private void Awake()
    {
        Instance = this;
    }
    public void buildBuilding(buildingType buildingType)
    {
        Vector3 spawnPosition = currentlyHighlightedPlot.transform.position;
        GameObject futureBuilding;

            if (buildingType == buildingType.quarry)
            {
                futureBuilding = quarryPrefab;
            }
            else if (buildingType == buildingType.market)
            {
                futureBuilding = marketPrefab;
            }
            else
            {
                futureBuilding = factoryPrefab;
            }

        Instantiate(futureBuilding, spawnPosition, Quaternion.identity);
    }

}



//Vector3 spawnPosition = levelManager.Instance.currentlyHighlightedPlot.transform.position;
//Instantiate(gameObject, spawnPosition, Quaternion.identity);