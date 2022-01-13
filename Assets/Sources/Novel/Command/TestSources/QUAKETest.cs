using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class QUAKETest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Ld(new StringValue("c"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1")));
            SystemData.instance.command.Add(new Print(new NumericValue(100)));
            SystemData.instance.command.Add(new Maintext(new StringValue("before quake")));
            
            int shakeTimeMs = 5000;
            int shakeSpeedMilliHz = 3000;
            SystemData.instance.command.Add(new Quake(new NumericValue(100), new NumericValue(150), new NumericValue(shakeTimeMs), new NumericValue(shakeSpeedMilliHz)));
            SystemData.instance.command.Add(new Quake(new NumericValue(200), new NumericValue(100), new NumericValue(shakeTimeMs), new NumericValue(shakeSpeedMilliHz), new StringValue("sine_curve")));
            SystemData.instance.command.Add(new Quake(new NumericValue(-100), new NumericValue(200), new NumericValue(shakeTimeMs), new NumericValue(shakeSpeedMilliHz), new StringValue("Damped_Oscillation_")));
            SystemData.instance.command.Add(new Quake(new NumericValue(-200), new NumericValue(200), new NumericValue(shakeTimeMs), new NumericValue(shakeSpeedMilliHz), new StringValue("dam_ped_Osci_l_la_tion_fast")));
            SystemData.instance.command.Add(new Maintext(new StringValue("finish")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}
