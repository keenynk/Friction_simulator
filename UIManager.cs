using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public FrictionController frictionController; // ค่าใน physics materials ของพื้นเอียง
    public FrictionController frictionController2; // ค่าใน physics materials ของกล่อง
    public Text angleText;  // ค่ามุมของพื้นเอียง
    public Text PlanedynamicFrictionText;  // ค่า Dynamic Friction coefficient ของพื้นเอียง
    public Text PlanestaticFrictionText;   // ค่า Static Friction coefficient ของพื้นเอียง
    public Text CubedynamicFrictionText;  // ค่า Dynamic Friction coefficient ของกล่อง
    public Text CubestaticFrictionText;   // ค่า Static Friction coefficient ของกล่อง
    public InputField cubeDynamicFrictionInput; // ช่องแก้ค่า Dynamic Friction coefficient ของกล่อง
    public InputField cubeStaticFrictionInput; // ช่องแก้ค่า Static Friction coefficient ของกล่อง
    public InputField planeDynamicFrictionInput; // ช่องแก้ค่า Dynamic Friction coefficient ของพื้นเอียง
    public InputField planeStaticFrictionInput; // ช่องแก้ค่า Static Friction coefficient ของพื้นเอียง
void Update()
{
    // Check if frictionController is not null
    if (frictionController != null && frictionController.frictionMaterial != null)
    {
        // แสดงตัวเลขค่ามุมของพื้นเอียง
        if (angleText != null)
            angleText.text = "Plane Angle: " + frictionController.GetPlaneAngle().ToString("F2") + " degrees";
        
        // แสดงค่า Dynamic Friction coefficient ของพื้นเอียง
        PlanedynamicFrictionText.text = "Plane Dynamic Friction: " + frictionController.frictionMaterial.dynamicFriction.ToString("F2");
        
        // แสดงค่า Static Friction coefficient ของพื้นเอียง
        PlanestaticFrictionText.text = "Plane Static Friction: " + frictionController.frictionMaterial.staticFriction.ToString("F2");
    }

    // Check if frictionController2 is not null
    if (frictionController2 != null && frictionController2.frictionMaterial != null)
    {
        // แสดงค่า Dynamic Friction coefficient ของกล่อง
        CubedynamicFrictionText.text = "Cube Dynamic Friction: " + frictionController2.frictionMaterial.dynamicFriction.ToString("F2");
        
        // แสดงค่า Static Friction coefficient ของกล่อง
        CubestaticFrictionText.text = "Cube Static Friction: " + frictionController2.frictionMaterial.staticFriction.ToString("F2");
    }
}
public void UpdateCubePhysicsMaterialValues()
    {
        // ฟังก์ชันสำหรับแก้ค่า coefficient ของกล่อง
        frictionController.UpdatePhysicsMaterialValues(frictionController.cubeFrictionMaterial, cubeDynamicFrictionInput, cubeStaticFrictionInput);
    }

    public void UpdatePlanePhysicsMaterialValues()
    {
        // ฟังก์ชันสำหรับแก้ค่า coefficient ของพื้นเอียง
        frictionController.UpdatePhysicsMaterialValues(frictionController.planeFrictionMaterial, planeDynamicFrictionInput, planeStaticFrictionInput);
    }
 public void SetAllPhysicsMaterialValues()
    {
        // Update ค่า coefficient ของพื้นและกล่อง
        frictionController.UpdatePhysicsMaterialValues(frictionController.cubeFrictionMaterial, cubeDynamicFrictionInput, cubeStaticFrictionInput);
        frictionController.UpdatePhysicsMaterialValues(frictionController.planeFrictionMaterial, planeDynamicFrictionInput, planeStaticFrictionInput);
    }
    public void RespawnBoxButton()
    {
        // ฟังก์ชันสำหรับ respawn กล่อง
        if (frictionController != null)
        {
            frictionController.RespawnBox();
        }
    }
}
