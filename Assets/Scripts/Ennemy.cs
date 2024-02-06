using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] private float _dmg;
    [SerializeField] private float _hp;
    private int _index;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(_speed,0,0) * Time.deltaTime;
    }

    public void SetIndex(int i) {
        _index = i;
        //Debug.Log("Index set: " + _index);
    }

    public int GetIndex() {
        return _index;
    }

    public float GetHp(){
        return _hp;
    }
    public float GetDmg(){
        return _dmg;
    }

    public bool TakeDmg(float amount) { // return true si la tourelle est encore en vie false sinon
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
    
    void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Ennemy") {
            if (_index < col.GetComponent<Ennemy>().GetIndex()) {
                int tmp = _index;
                _index = col.GetComponent<Ennemy>().GetIndex();
                col.GetComponent<Ennemy>().SetIndex(tmp);
                //Debug.Log("avant: " + tmp + "mtn: " + _index);
            }
        }
    }
}
