using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : Bird
{
    [SerializeField]
    public float _boostForce = 150;
    public bool _hasBoost = false;
    private BirdState _state;
    private float _minVelocity = 0.05f;
    private bool _flagDestroy = false;

    public void Boost()
    {
        if (State == BirdState.Thrown && !_hasBoost)
        {
            RigidBody.AddForce(RigidBody.velocity * _boostForce);
            _hasBoost = true;
        }
    }

    private IEnumerator DestroyAfter(float second)
    {
        yield return new WaitForSeconds(second);
        Destroy(gameObject);
    }



    void OnDestroy()
    {
        if (_state == BirdState.Thrown || _state == BirdState.HitSomething)
            OnBirdDestroyed();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        _state = BirdState.HitSomething;
    }
    public override void OnTap()
    {
        Boost();
    }

}
