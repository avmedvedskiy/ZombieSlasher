using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

public class BaseUnit : MonoBehaviour, IPointerDownHandler
{
    public float moveSpeed = 2f;
    public bool isEscaped = false;

    public virtual void Start()
    {

    }

    public virtual void Update()
    {
        if (isEscaped)
            return;
        
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (transform.position.z <= 0f)
            Escape();
    }

    public virtual void Escape()
    {
        isEscaped = true;
        GameController.Instance.EscapeMonster();
        Destroy(gameObject);
    }

    public virtual void Kill()
    {
        GameController.Instance.KillMonster();
        Destroy(gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Kill();
    }
}
