using UnityEngine;
using UnityEngine.Networking;


public class UnitStats : NetworkBehaviour
{
    [SerializeField] int maxHealth;
    [SyncVar] int _curHealth;

    public Stat damage;

    public int curHealth { get { return _curHealth; } }

    public override void OnStartServer()
    {
        _curHealth = maxHealth;
    }

    public void SetHealthRate(float rate)
    {
        _curHealth = rate == 0 ? 0 : (int)(maxHealth / rate);
    }
}