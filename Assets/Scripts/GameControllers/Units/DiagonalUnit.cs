using UnityEngine;
using System.Collections;

public class DiagonalUnit : BaseUnit
{
    public float maxAngle = 30f;

    public float fieldSize = 1.5f;

    protected float m_StartAngle;

    public override void Start()
    {
        base.Start();
        m_StartAngle = transform.eulerAngles.y;
        RandomRotate();
    }

    public void RandomRotate()
    {
        float angle = Random.Range(-maxAngle, maxAngle);
        transform.eulerAngles = new Vector3(0f, m_StartAngle + angle, 0f);
    }

    public void RandomRotate(float sign)
    {
        float angle = Random.Range(0f, sign * maxAngle);
        transform.eulerAngles = new Vector3(0f, m_StartAngle + angle, 0f);
    }

    public override void Move()
    {
        base.Move();

        if (Mathf.Abs(transform.position.x) >= fieldSize)
            RandomRotate(Mathf.Sign(transform.position.x));
    }

    public override void Kill()
    {
        base.Kill();

        GameController.Instance.KillMonster();
    }

    public override void Escape()
    {
        base.Escape();
        GameController.Instance.EscapeMonster();
    }
}
