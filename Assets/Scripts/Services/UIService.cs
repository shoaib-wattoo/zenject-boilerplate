using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIService : MonoBehaviour
{
    [Inject] SignalBus signalBus;
    // Start is called before the first frame update
    void Start()
    {
        signalBus.Subscribe<VolumeChangeSignal>(OnUpdateVolume);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnUpdateVolume(VolumeChangeSignal data)
    {
        print("Signal Revceid :: " + data.volume);
    }
}
