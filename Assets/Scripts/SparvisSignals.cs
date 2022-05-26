using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparvisSignals
{

}

public class NewPlayerSignal{}

public class UsernameUpdateSignal{}
public class UserAvatareUpdateSignal { }

public class MarketplaceItemSelectionSignal
{

}
public class VolumeChangeSignal {

    public float volume;

    public VolumeChangeSignal(float volume)
    {
        this.volume = volume;
    }
}
