using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BaseUnit : MonoBehaviour, IPointerDownHandler
{
    public float moveSpeed = 2f;
    public bool isEscaped = false;
    public bool isKilled = false;

    private Animator m_Animator;
    public Animator Animator
    {
        get { return m_Animator ?? (m_Animator = GetComponent<Animator>()); }
    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {
        if (isEscaped)
            return;

        Move();

        if (transform.position.x <= 0f)
            Escape();
    }

    public virtual void Move()
    {
        if (GameController.Instance.isGamePaused)
            return;
        if (GameController.Instance.isGameComplete)
            return;

        if (isKilled)
            return;

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public virtual void Escape()
    {
        isEscaped = true;
        Destroy(gameObject);
    }

    public virtual void Kill()
    {
        isKilled = true;
        Animator.SetTrigger("DeathTrigger");
        Destroy(gameObject,2);
    }

    public void Restart()
    {
        Destroy(gameObject);
    }

    public void OnEnable()
    {
        GameController.Instance.OnGameRestart += Restart;
    }

    public void OnDisable()
    {
        if(GameController.Instance)
            GameController.Instance.OnGameRestart -= Restart;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isKilled)
            return;
        Kill();
        SkillController.Instance.UseActiveSkill(this);
    }
}
