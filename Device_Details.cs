using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Device_Details : MonoBehaviour 

{

    public Text Device_Model_Text;
    public Text Graphics_Device_Text;
    public Text Graphics_Memmory_Size_Text;
    public Text Processor_Type_Text;
    public Text System_Memmory_Size_Text;

    public string Device_Model;
    public string Graphics_Device;
    public float Graphics_Memmory_Size;
    public string Processor_Type;
    public float Processor_Count;
    public float System_Memmory_Size;

    void Update () 

	{

        Device_Model = SystemInfo.deviceModel;
        Graphics_Device = SystemInfo.graphicsDeviceName;
        Graphics_Memmory_Size = SystemInfo.graphicsMemorySize;
        Processor_Type = SystemInfo.processorType;
        Processor_Count = SystemInfo.processorCount;
        System_Memmory_Size = SystemInfo.systemMemorySize;

        Device_Model_Text.text = Device_Model;
        Processor_Type_Text.text = Processor_Type + " X " + Processor_Count;
        Graphics_Device_Text.text = Graphics_Device;
        Graphics_Memmory_Size_Text.text = "Graphics Memmory Size" + " " + Graphics_Memmory_Size + "MB";
        System_Memmory_Size_Text.text = "System Memmory Size" + " " + System_Memmory_Size + "MB";

    }
		
}