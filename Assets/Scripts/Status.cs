using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public string name;
    public int atkStat;
    public int defStat;

    public Status()
    {

    }

    public Status(string _name, int _atk, int _def)
    {
        this.name = _name;
        this.atkStat = _atk;
        this.defStat = _def;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
