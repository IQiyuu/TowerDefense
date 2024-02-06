using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] public GameObject _target;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = _target.transform.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("piejofj");   
        if (col.gameObject == _target)
            Destroy(this.gameObject);
    }
}
