using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    public TimerController timeController;
    public GameObject directionalLight;
    public Light light;

    private double minutesInTheDay;

    private double lower = 360d; //6 am
    private double upper = 1200d; // 8pm

    private float angleOfSun;

    private float beginningOfDay;

    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        beginningOfDay = 0;
    }

    public void restartDay() {
        beginningOfDay = 0;
    }
    // Update is called once per frame
    void Update()
    {

        beginningOfDay += Time.deltaTime ;
        // argument for cosine
        float phi = beginningOfDay / duration * 2 * Mathf.PI;

        // get cosine and transform from -1..1 to 0..1 range
        float amplitude = Mathf.Cos(phi) * 0.5f + 0.5f;

        // set light color
        light.intensity = amplitude;

        //double minutesInTheDay = (timeController.timePlaying.TotalMinutes % 1440);

        //float angleOfSun = 30f;

        //Debug.Log(minutesInTheDay);

        //if (minutesInTheDay >= lower && minutesInTheDay <= upper) { //6am and 8pm
        //    angleOfSun = (float)((((minutesInTheDay-lower) / (upper))*180d)+45); 
        //}
        //Debug.Log(angleOfSun);

        //directionalLight.transform.eulerAngles = new Vector3(
        //    angleOfSun,
        //    directionalLight.transform.eulerAngles.y,
        //    0
        //);
    }
}
