using UnityEngine;
using UnityEngine.UI;


public class RadarScan : MonoBehaviour
{
	GameObject Enemy;
	GameObject TimerDisplay;
	GameObject Asteroid;
	public Image EnemyImageToChange;
    public Image AsteroidImageToChange;
    int timerSeconds = 5;
    Text t_display;
        
	void Start() 
	{       
		Enemy = GameObject.Find("Enemy");   
		TimerDisplay = GameObject.Find ("Radar_TimerDisplay");
		Asteroid = GameObject.Find ("Asteroid");
     }

	public void ChangeImage(Image UpdateImage)
    {
		if (Enemy.tag == "Enemy" & Asteroid.tag == "Asteroid")
        {
            timerSeconds = 5;
			InvokeRepeating ("RadarChangeImage", 1, 1);
		} 
    }

	public void RadarChangeImage()
	{
		timerSeconds--;
		t_display = TimerDisplay.GetComponent<Text> ();
		t_display.text = timerSeconds.ToString();

		if (timerSeconds < 1) {
			CancelInvoke ("RadarChangeImage");	
			Radar.RegisterRadarObject (Enemy, EnemyImageToChange);
            Radar.RegisterRadarObject(Asteroid, AsteroidImageToChange);
        }
	}
}

