using UnityEngine.UI;
using UnityEngine;


public class ShieldController : MonoBehaviour
{

    public ShieldModel shield;
    private ShieldView sView;

    void Start()
    {
        //Create new ShieldModel object
        shield = new ShieldModel();
        sView = GetComponent<ShieldView>();
        sView.UpdateShieldStatus(shield.GetIsOn());
        sView.UpdateShieldHealth(shield.GetShieldHealth(), shield.GetShieldStrength());
        sView.UpdateShieldStrength(shield.GetShieldStrength());
        
    }

    private void Update()
    {
        sView.UpdateShieldHealth(shield.GetShieldHealth(), shield.GetShieldStrength());
        
    }

    public void ChangeStrength(Slider StrengthSlider) // changing shield strength with slider
    {
        if(shield.isOn)
        {
            shield.SetShieldStrength((StrengthSlider.value));
            sView.UpdateShieldStrength(shield.GetShieldStrength());
            StrengthSlider.gameObject.SetActive(true); // allow to move slider if shield active
        }
        else
        {
            StrengthSlider.gameObject.SetActive(false); // can't move slider if shield inactive
            Debug.Log("Shield is not on, can't change power.");
        }
    }

    public void TurnOnShield() // turn shield on 
    {
        if(!shield.GetIsOn())
        {
            Debug.Log("Shield turned on");
            shield.SetIsOn(true);
            sView.UpdateShieldStatus(shield.GetIsOn());
           
        }
        else
        {
            Debug.Log("Shield already on!");
        }
    }
    public void TurnOffShield() // turn shield off
    {
        if (shield.GetIsOn())
        {
            Debug.Log("Shield turned off");
            shield.SetIsOn(false); // set shield bool to false
            sView.UpdateShieldStatus(shield.GetIsOn()); // update
            shield.SetShieldStrength(0); // remove shield strength, set to 0 
            
        }
        else
        {
            Debug.Log("Shield if already off");
        }

    }

    public void RegenShield (bool WasDamaged)
    {
        if(shield.GetWasDamaged())
        {
            Debug.Log("Regeneration happens after 5 seconds");
            // more to be figured out here
        }
    }
    void OnCollisionEnter(Collision col) // on collision, depending on tag type, apply damage to health
    {
        if(col.gameObject.tag == "Cannon")
        {
            shield.ShieldHealth = shield.ShieldHealth - 100; 
            Debug.Log("Hit by a cannon. -100 health.");
            shield.SetWasDamaged(true);
            Invoke("RegenShield", 5);// run regenshield method after 5 seconds
        }
        if(col.gameObject.tag == "Missile")
        {
            shield.ShieldHealth = shield.ShieldHealth - 150;
            Debug.Log("Hit by a missile. -150 health");
            shield.SetWasDamaged(true);
            Invoke("RegenShield", 5); // run regenshield method after 5 seconds
        }
    }
}
