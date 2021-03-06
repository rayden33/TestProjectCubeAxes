using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    [SerializeField] private GameObject playerCube;
    [SerializeField] private Slider rotationSlider;

    private int[] xyzCheckBoxValues = new int[3] {1, 0, 0};     /// X, Y, Z
    private float[] lastValueXYZ = new float[3] {0, 0, 0};      /// X, Y, Z
    private float[] newValueXYZ = new float[3];                 /// X, Y, Z
    private float[] lastSliderValues = new float[3] {0,0,0};    /// X, Y, Z
    private int lastIndexXYZ = 0;                             /// 0 - X

    public void changeCheckBox(int checkBoxIndex)
    {
        xyzCheckBoxValues[0] = 0;
        xyzCheckBoxValues[1] = 0;
        xyzCheckBoxValues[2] = 0;
        xyzCheckBoxValues[checkBoxIndex] = 1;

        lastSliderValues[lastIndexXYZ] = rotationSlider.value;
        lastIndexXYZ = checkBoxIndex;
        rotationSlider.value = lastSliderValues[checkBoxIndex];

        //logAll();
    }
    public void changeRotation()
    {
        float a = rotationSlider.value * 360;
        

        for(int i = 0; i < 3; i++)
            newValueXYZ[i] = lastValueXYZ[i] * ((xyzCheckBoxValues[i] + 1) % 2) + a * (xyzCheckBoxValues[i] % 2);
        
        playerCube.transform.rotation = Quaternion.Euler(newValueXYZ[0] , newValueXYZ[1], newValueXYZ[2]);
        lastValueXYZ[0] = newValueXYZ[0];
        lastValueXYZ[1] = newValueXYZ[1];
        lastValueXYZ[2] = newValueXYZ[2];

    }
}
