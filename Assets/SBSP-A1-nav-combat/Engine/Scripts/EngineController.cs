using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EngineView))]
public class EngineController : MonoBehaviour {

    private EngineView engView;
    private Engine engine;
    public string axis;

    // Use this for initialization
    void Start () {
        engine = new Engine();
        engView = GetComponent<EngineView>();
        engView.UpdatePower(engine.GetPower());
        engView.UpdateEngineState(engine.GetIsOn());
	}

	// Update is called once per frame
	void Update () {
        if(axis == "Forward")
        {
            transform.parent.Translate(engine.GetPower() * Vector3.forward * Time.deltaTime);
        }
        if (axis == "Backward")
        {
            float changeToMinus = 0 - engine.GetPower();

            transform.parent.Translate(changeToMinus * Vector3.forward * Time.deltaTime);
        }
    }

    //TrunOnEngine method
    //sets power of the engine to zero and isOn to true
    public void TurnOnEngine()
    {
        if (!engine.GetIsOn())
        {
            engine.SetPower(0);
            engine.SetIsOn(true);
            engView.UpdateEngineState(engine.GetIsOn());
        }
        else
        {
            Debug.Log("Cannot turn on engine, engine is ON");
        }

    }

    //TrunOffEngine method
    //sets power of the engine to zero and isOn to true
    public void TurnOffEngine()
    {
        if (engine.GetIsOn())
        {
            engine.SetPower(0);
            engine.SetIsOn(false);
            engView.UpdateEngineState(engine.GetIsOn());
        }
        else
        {
            Debug.Log("Cannot turn off engine, engine is OFF");
        }
    }

    public void Accelerate(Slider slider)
    {
        if (engine.GetIsOn())
        {
            engine.SetPower((slider.value));
            engView.UpdatePower(engine.GetPower());
        }
        else
        {
            Debug.Log("Cannot accelerate, engine is OFF");
        }
    }
}
