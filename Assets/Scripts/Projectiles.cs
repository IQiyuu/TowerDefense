using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] public GameObject _target;
    [SerializeField] public float areaOfEffectRadius;
    public float _dmg;

    // Update is called once per frame
    void Update()
    {
        if (_target == null) {
            Destroy(this.gameObject);
            return ;
        }
        Vector3 dir = _target.transform.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, _target.transform.position) < 0.1f) {
            if (areaOfEffectRadius != 0) {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, areaOfEffectRadius, LayerMask.GetMask("Ennemy"), -10, 10);
                Debug.Log(colliders[0]);
                foreach (Collider2D col in colliders) {
                    if (col.gameObject != _target)
                        col.GetComponent<Ennemy>().TakeDmg(_dmg / 2);
                }
                _target.GetComponent<Ennemy>().TakeDmg(_dmg);
                Destroy(this.gameObject);
            }
        }
    }
}
