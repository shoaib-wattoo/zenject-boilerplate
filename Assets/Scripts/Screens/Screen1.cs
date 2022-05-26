using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Screen1 : MonoBehaviour
{
    [Inject] SignalBus signalBus;

    //[Inject] public Screen2 screen;

    [Inject] [SerializeField]
    public UserService userService;

    // Start is called before the first frame update
    void Start()
    {
        //print(userService.Test());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireSignal()
    {
        signalBus.Fire(new VolumeChangeSignal(666));
    }
}
