using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool Targetable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float _health ;
    public bool _targetable = true;
    public HealthBar healthBar;


    public string mainMenu;
    public void OnHit(float damage, Vector2 knockback)
    {
        throw new System.NotImplementedException();
    }

    public void OnHit(float damage)
    {
        _health -= damage ;
        healthBar.SetHealth(_health);
        Debug.Log(_health);
        if (_health <= 0)
        {
            OnObjectDestroyed();
        }

    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
        //Time.timeScale = 0f;
        SceneManager.LoadScene(mainMenu);
    }


}
