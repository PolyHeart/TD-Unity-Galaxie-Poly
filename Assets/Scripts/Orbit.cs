using UnityEngine;
public class Orbits : MonoBehaviour
{
    //Centre de l’orbite (ex: le Soleil)
    public Transform pivot;
    //Vitesse angulaire en degrés/seconde
    public float angularSpeed = 20f;
    //Rotation propre de la planète en degrés/seconde
    public float selfRotationSpeed = 30f;
    void Update()
    {
        if (pivot != null)
        {
            // orbite autour du pivot (axe Y)
            transform.RotateAround(pivot.position, Vector3.up, angularSpeed * Time.deltaTime);
        }
        // rotation sur soi-même (axe Y)
        transform.Rotate(Vector3.up, selfRotationSpeed * Time.deltaTime, Space.Self);
    }
}
