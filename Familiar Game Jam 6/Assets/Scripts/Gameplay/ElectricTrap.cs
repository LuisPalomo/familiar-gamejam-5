using UnityEngine;
using System.Collections;

public class ElectricTrap : MonoBehaviour
{
    public ElectricArc[] electricArcList;


    public float timeC;
    public float timeS;

    float timeA;
    float timeB;

    // Use this for initialization
    void Start()
    {
        timeA = timeC;
        timeB = timeS;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeA == timeC)
        {
            foreach (var electricArc in electricArcList)
            {
                electricArc.gameObject.SetActive(false);
            }
        }
        timeA -= Time.deltaTime;
        
        if (timeA < 0)
        {
           
            if (timeB == timeS)
            {
                foreach (var electricArc in electricArcList)
                {
                    electricArc.gameObject.SetActive(true);
                }
            }
            timeB -= Time.deltaTime;
            if (timeB < 0)
            {
                timeA = timeC;
                timeB = timeS;
            }
                
        }
            
    }
}
