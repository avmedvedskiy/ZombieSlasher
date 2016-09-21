using UnityEngine;
using System.Collections;

public class UIWindow : MonoBehaviour
{
    public string windowName;

    public bool IsOpen { get { return gameObject.activeInHierarchy; } }

    public void Start()
    {
        if (IsOpen)
            Show();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public virtual void Toggle()
    {
        if (IsOpen)
            Hide();
        else
            Show();
    }

}
