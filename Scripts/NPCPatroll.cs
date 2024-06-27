using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatroll : MonoBehaviour
{
    public float startAngle; // Starting angle in degrees
    public float endAngle; // Ending angle in degrees
    public float rotationSpeed; // Degrees per second

    private float currentAngle;
    private bool isGoingUp = true; // Flag to track rotation direction

    void Start()
    {
        currentAngle = startAngle;
    }

    void Update()
    {
        // Update current angle based on direction and speed
        currentAngle += (isGoingUp ? 1 : -1) * rotationSpeed * Time.deltaTime;

        // Check if reaching the limit
        if (isGoingUp && currentAngle >= endAngle)
        {
            currentAngle = endAngle;
            isGoingUp = false;
        }
        else if (!isGoingUp && currentAngle <= startAngle)
        {
            currentAngle = startAngle;
            isGoingUp = true;
        }

        // Apply rotation on the X-axis only
        transform.rotation = Quaternion.Euler(0f, currentAngle, 0f);
    }
}
