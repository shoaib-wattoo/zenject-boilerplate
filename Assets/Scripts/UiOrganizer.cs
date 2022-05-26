using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public interface IUiCanvas
{
    void ParentThisToCanvas(Transform toBeMadeChild);
    Canvas GetCanvas();
}

public class UiOrganizer : IInitializable, IUiCanvas {
    private readonly Canvas mainCanvas;

    public Canvas GetCanvas()
    {
        return mainCanvas;
    }

    public Transform GetMainCanvasRoot()
    {
        return mainCanvas.transform;
    }

    public void ParentThisToCanvas(Transform toBeMadeChild)
    {
        toBeMadeChild.SetParent(mainCanvas.transform, false);
    }

    public UiOrganizer(Canvas mainCanvas)
    {
        this.mainCanvas = mainCanvas;
    }

    public void Initialize()
    {
        
    }
}