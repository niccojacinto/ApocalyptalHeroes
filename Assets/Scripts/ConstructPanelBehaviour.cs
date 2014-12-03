using UnityEngine;
using System.Collections;

public class ConstructPanelBehaviour : MonoBehaviour {

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
}
