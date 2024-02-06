using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMove : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] private float _dmg;
    [SerializeField] private float _hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(_speed,0,0) * Time.deltaTime;
    }

    public float getHp(){
        return _hp;
    }
    public float getDmg(){
        return _dmg;
    }

    public bool takeDmg(float amount) { // return true si la tourelle est encore en vie false sinon
        _hp -= amount;
        //Debug.Log(amount + " damage taken, " + _hp + " left.");
        if (_hp <= 0) {
            //Debug.Log("Dead.");
            Destroy(this.gameObject);
            return (false);
        }
        return (true);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Board") {
            print("OUTCH! " + _dmg + " damages taken");
            Destroy(this.gameObject);
        }
    }
}
