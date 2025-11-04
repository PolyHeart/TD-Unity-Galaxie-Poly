using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Orbits[] orbits;

    private bool isStopped = false;
    private float[] initialAngularSpeeds;
    private float[] initialSelfRotationSpeeds;

    void Start()
    {
        initialAngularSpeeds = new float[orbits.Length];
        initialSelfRotationSpeeds = new float[orbits.Length];

        for (int i = 0; i < orbits.Length; i++)
        {
            initialAngularSpeeds[i] = orbits[i].angularSpeed;
            initialSelfRotationSpeeds[i] = orbits[i].selfRotationSpeed;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStopped = !isStopped; 

            if (isStopped)
            {
                Debug.Log("STOP!");
                foreach (var orbit in orbits)
                {
                    orbit.angularSpeed = 0f;
                    orbit.selfRotationSpeed = 0f;
                }
            }
            else
            {
                Debug.Log("GO!");
                for (int i = 0; i < orbits.Length; i++)
                {
                    orbits[i].angularSpeed = initialAngularSpeeds[i];
                    orbits[i].selfRotationSpeed = initialSelfRotationSpeeds[i];
                }
            }
        }
    }
}
