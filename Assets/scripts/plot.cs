using UnityEngine;

public class plot : MonoBehaviour
{
    [Header("Referencias")]
    public SpriteRenderer plotSprite;

    [Header("Atributos")]
    public gemType plotGemType = gemType.water; //ponemos water por defecto


    //on validate es literalmente el construction script de unreal
    private void OnValidate()
    {
    if (plotSprite != null)
        {
            if (plotGemType == gemType.water)
            {
                plotSprite.color = Color.blue;
            }

            else if (plotGemType == gemType.fire)
            {
                plotSprite.color = Color.red;
            }
            else if (plotGemType == gemType.earth)
            {
                plotSprite.color = Color.green;
            }
            else if (plotGemType == gemType.air)
            {
                plotSprite.color = Color.gray;
            }
            else
            {
                plotSprite.color = Color.pink;
            }
        }
    }

    //ARGGGHH FUNCIONO A LA PRIMERA. IM GETTING THE HANG OF IT
    private void OnMouseDown()
    {
        //si el build pannel no estaba abierto lo abro
        if (!HUD.Instance.buildPannelVisible)
        {
            HUD.Instance.showHideBuildPannel(true);
        }

        //si he clicado dos veces en el mismo plot (el highlighted plot era yo), then i hide the build pannel
        if (levelManager.Instance.currentlyHighlightedPlot == this)
        {
            HUD.Instance.showHideBuildPannel(false);
        }

        //set myself as the highlighted plot
        levelManager.Instance.currentlyHighlightedPlot = this;
    }


}
