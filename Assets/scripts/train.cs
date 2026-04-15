using UnityEngine;

public class train : MonoBehaviour
{


    private int pathIndex = 0;



    //nos suscribimos a los ticks del time manager

    private void OnEnable()
    {
        timeManager.OnTick += GameTickPassed;
    }

    private void OnDisable()
    {
        timeManager.OnTick -= GameTickPassed;
    }

    void GameTickPassed()
    { 
        transform.position = levelManager.Instance.path[pathIndex].position;

        timeManager.instance.callOnTrainReachedNewStop(pathIndex);
        //ahora que le he dicho al time manager donde estoy ya me puedo empezar mover a la siguiente parada
        
        pathIndex++;
        if (pathIndex >= levelManager.Instance.path.Length) //primera linea de codigo que hacemos con 0 ayuda :) esto basicamente dice que:
                                                            //si el path index = pathLength (ergo el index esta indicando el ultimo punto del array del path) vuelve a 0 para empezar de nuevo y asi hacer el bucle infinito del giro del tren
        {
            pathIndex = 0;
        }

    }





}
