using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColor : MonoBehaviour
{
     public Color lightOnColor;
    public Light lightComponent;

    private Color initialColor;

    FieldOfView See ;

    void Start()
    {
        See = transform.parent.GetComponent<FieldOfView>(); // Assuming the FieldOfView script is on the parent
        if (lightComponent == null)
        {
            lightComponent = GetComponent<Light>();
        }

        initialColor = lightComponent.color;
    }

    void Update()
    {
        if(See.canSeePlayer)
        {
            lightComponent.color = lightOnColor; 
        }

        if(!See.canSeePlayer)
        {
            lightComponent.color = initialColor;
        }
    }
    
}
