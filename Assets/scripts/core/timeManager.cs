using System;
using UnityEngine;


public class timeManager : MonoBehaviour
{

    public static timeManager instance;
    //esto de hacer el instance como public static es para que el resto de scripts puedan acceder facilmente a el sin hacer el findObjectOfType. 
    //es lo que se llama singleton. funciona muy bien para actores que solo hay uno en cada sesion de juego (level manager, time manager, economy data etc)

    [Header("Tiempo y velocidad")]
    public float tickDuration = 1f; //esto son los segundos que tarda cada tick
    public float gameSpeed = 1f; //esto es el multiplicador que voy a tocar con el gamespeed button como en el pkmn z


    private float timer;

    [Header("PublicInfoDuringGame")]
    public int trainCurrentStation = 0;



    public static event Action OnTick;
    public static event Action OnTrainReachedNewStop;



    private void Awake()
    {
        instance = this;
    }




    void Update()
    {
        timer += Time.deltaTime * gameSpeed; // recuerda que += es lo mismo que hacer timer = timer + blablabla

        if (timer > tickDuration)
        {
            timer -= tickDuration; //esto tiene el mismo aura que hacer timer = 0 pero es mas exacto y no tiene perdidas de tiempo porque la duracion de los frames en unity no es exacta y se puede pasar del tiempo exacto del tick duration (en nuestro caso 1)
                                   //i get it now. imaginate que de frame a frame va de 0.78 // 0.95  // 1.08.   si lo reseteamos a 0 en vez de resetearlo a 0.08 habra perdidas de tiempo y el proximo tick ira mas lento de lo que esperamos.

            OnTick?.Invoke(); //esto basicamente esta llamando al evento para que se enteren todos los que estan escuchando
                              // el signo de interrogacion despues de on tick es una manera rapida de decir if OnTick != null. es como el is valid de unreal. 
                              //esta evitando que se invoque en el caso de que onTick sea null para evitar errores.
            
        }
    }

    public void callOnTrainReachedNewStop(int newStopIndex)
    {
        trainCurrentStation=newStopIndex;
        OnTrainReachedNewStop?.Invoke();
    }


}
