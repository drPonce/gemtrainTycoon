using UnityEngine;

public class HUD : MonoBehaviour
{

    public static HUD Instance;


    public GameObject buildPannel;
    public bool buildPannelVisible = false;

    private void Awake()
    {
        Instance = this;
        buildPannel.SetActive(false);
    }

    public void showHideBuildPannel(bool trueMeansShow)
    {
        buildPannel.SetActive(trueMeansShow);
        buildPannelVisible = !buildPannelVisible;
        if (buildPannelVisible == false)
        {
            levelManager.Instance.currentlyHighlightedPlot = null;
        }
    }




}

