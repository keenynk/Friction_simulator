using UnityEngine;
using UnityEngine.UI;

public class FrictionController : MonoBehaviour
{
    private UIManager uiManager; // Reference to UIManager
    public PhysicMaterial frictionMaterial; 
    public PhysicMaterial cubeFrictionMaterial; // ค่าใน physics material ของกล่อง
    public PhysicMaterial planeFrictionMaterial;// ค่าใน physics material ของพื้นเอียง
    private Vector3 initialPosition; // เก็บค่าตำแหน่งการปล่อยกล่อง
    public GameObject boxPrefab; // Reference to the prefab of the box
    public InputField cubeDynamicFrictionInput;
    public InputField cubeStaticFrictionInput;
    public InputField planeDynamicFrictionInput;
    public InputField planeStaticFrictionInput;


     void Start()
    {
        // Set default values for physics materials
        SetPhysicsMaterialValues(cubeFrictionMaterial, cubeDynamicFrictionInput, cubeStaticFrictionInput);
        SetPhysicsMaterialValues(planeFrictionMaterial, planeDynamicFrictionInput, planeStaticFrictionInput);

        initialPosition = transform.position;
        // Subscribe to OnValueChanged events
        cubeDynamicFrictionInput.onValueChanged.AddListener(delegate { UpdatePhysicsMaterialValues(cubeFrictionMaterial, cubeDynamicFrictionInput, cubeStaticFrictionInput); });
        cubeStaticFrictionInput.onValueChanged.AddListener(delegate { UpdatePhysicsMaterialValues(cubeFrictionMaterial, cubeDynamicFrictionInput, cubeStaticFrictionInput); });
        planeDynamicFrictionInput.onValueChanged.AddListener(delegate { UpdatePhysicsMaterialValues(planeFrictionMaterial, planeDynamicFrictionInput, planeStaticFrictionInput); });
        planeStaticFrictionInput.onValueChanged.AddListener(delegate { UpdatePhysicsMaterialValues(planeFrictionMaterial, planeDynamicFrictionInput, planeStaticFrictionInput); });
    }
    public void IncreasePlaneAngle()
    {
        // Increase the angle of the plane around the Z axis
        float newAngle = transform.eulerAngles.z + 0.1f;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, newAngle);
    }

    public void DecreasePlaneAngle()
    {
        // Decrease the angle of the plane around the Z axis
        float newAngle = transform.eulerAngles.z - 0.1f;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, newAngle);
    }

    public float GetPlaneAngle()
    {
        // Return the current angle of the plane
        return transform.eulerAngles.z;
    }
    public void SetPhysicsMaterialValues(PhysicMaterial frictionMaterial, InputField dynamicFrictionInput, InputField staticFrictionInput)
    {
        // Set values from input fields to physics material
        if (frictionMaterial != null)
        {
            // Retrieve dynamic friction value from input field
            float dynamicFrictionValue;
            
            if (float.TryParse(dynamicFrictionInput.text, out dynamicFrictionValue))
            {
                frictionMaterial.dynamicFriction = dynamicFrictionValue;
            }

            // Retrieve static friction value from input field
            float staticFrictionValue;
            if (float.TryParse(staticFrictionInput.text, out staticFrictionValue))
            {
                frictionMaterial.staticFriction = staticFrictionValue;
            }
        }
    }
    public void UpdatePhysicsMaterialValues(PhysicMaterial frictionMaterial, InputField dynamicFrictionInput, InputField staticFrictionInput)
    {
        // Check if input fields are assigned
        if (dynamicFrictionInput != null && staticFrictionInput != null)
        {
            // Update dynamic friction value from input field
            float dynamicFrictionValue;
            if (float.TryParse(dynamicFrictionInput.text, out dynamicFrictionValue))
            {
                frictionMaterial.dynamicFriction = dynamicFrictionValue;
            }

            // Update static friction value from input field
            float staticFrictionValue;
            if (float.TryParse(staticFrictionInput.text, out staticFrictionValue))
            {
                frictionMaterial.staticFriction = staticFrictionValue;
            }
        }
    }
    public void RespawnBox()
    {
        // Instantiate a new box at the initial position
        GameObject newBox = Instantiate(boxPrefab, initialPosition, Quaternion.identity);

        // Set the physics material values for the new box
        SetPhysicsMaterialValues(newBox.GetComponent<FrictionController>().cubeFrictionMaterial, cubeDynamicFrictionInput, cubeStaticFrictionInput);
        SetPhysicsMaterialValues(newBox.GetComponent<FrictionController>().planeFrictionMaterial, planeDynamicFrictionInput, planeStaticFrictionInput);
    }
}

