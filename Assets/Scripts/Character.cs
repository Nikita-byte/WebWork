using UnityEngine;

[RequireComponent(typeof(UnitMotor), typeof(PlayerStats))]
public class Character : Unit
{

    [SerializeField] float reviveDelay = 5f;
    [SerializeField] GameObject gfx;

    Vector3 startPosition;
    float reviveTime;

    void Start()
    {
        startPosition = transform.position;
        reviveTime = reviveDelay;
    }

    void Update()
    {
        OnUpdate();
    }

    protected override void OnDeadUpdate()
    {
        base.OnDeadUpdate();
        if (reviveTime > 0)
        {
            reviveTime -= Time.deltaTime;
        }
        else
        {
            reviveTime = reviveDelay;
            Revive();
        }
    }

    protected override void Die()
    {
        base.Die();
        gfx.SetActive(false);
    }

    protected override void Revive()
    {
        base.Revive();
        transform.position = startPosition;
        gfx.SetActive(true);
        if (isServer)
        {
            motor.MoveToPoint(startPosition);
        }
    }

    // функции для управления персонажем при помощи контролера

    public void SetMovePoint(Vector3 point)
    {
        if (!isDead)
        {
            motor.MoveToPoint(point);
        }
    }
}
