using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine
{
    //initializing variables for the engine
    private int energy;
    public float power = 0;
    private bool isOn = false;

    //SetEnergy method
    public void SetEnergy(int energy)
    {
        this.energy = energy;
    }

    //GetEnergy method
    public int GetEnergy()
    {
        return this.energy;
    }

    //SetPower method
    public void SetPower(float power)
    {
        this.power = power;
    }

    //GetPower method
    public float GetPower()
    {
        return this.power;
    }

    //GetIsOn method
    public bool GetIsOn()
    {
        return this.isOn;
    }

    //SetIsOn method
    public void SetIsOn(bool isOn)
    {
        this.isOn = isOn;
    }
}
