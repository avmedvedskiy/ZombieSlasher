using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class UIWaitTimer : MonoBehaviour
{
    public RectTransform rectTransform;
    public Text text;

    public void Start()
    {
        SetTimer(3);
    }

    public void SetTimer(int seconds)
    {
        StopAllCoroutines();
        StartCoroutine(SetTimerCoroutine(seconds));
    }

    public IEnumerator SetTimerCoroutine(int seconds)
    {
        GameController.Instance.SetPause(true);
        for(int i = seconds; i > 0;i--)
        {
            rectTransform.localScale = Vector3.one;
            text.text = i.ToString();
            rectTransform.DOScale(0f, 1f);
            yield return new WaitForSeconds(1f);
        }
        GameController.Instance.SetPause(false);
    }
        
}
