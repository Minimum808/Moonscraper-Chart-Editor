﻿// Copyright (c) 2016-2017 Alexander Ong
// See LICENSE in project root for license information.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioCalibrationMenuScript : DisplayMenu {
    public InputField audioInput;
    public InputField clapInput;

    protected override void OnEnable()
    {
        base.OnEnable();
        audioInput.text = GameSettings.audioCalibrationMS.ToString();
        clapInput.text = GameSettings.clapCalibrationMS.ToString();
    }
	
    public void audioValChanged(string val)
    {
        valChanged(val, ref GameSettings.audioCalibrationMS);
    }

    public void audioValEndEdit(string val)
    {
        valEndEdit(val, ref GameSettings.audioCalibrationMS);
    }

    public void sfxValChanged(string val)
    {
        valChanged(val, ref GameSettings.clapCalibrationMS);
    }

    public void sfxValEndEdit(string val)
    {
        valEndEdit(val, ref GameSettings.clapCalibrationMS);
    }

    void valChanged(string val, ref int calibration)
    {
        if (val != string.Empty && val != "-")
            calibration = int.Parse(val);
    }

    void valEndEdit(string val, ref int calibration)
    {
        if (val == string.Empty && val == "-")
            calibration = 0;
        else
            valChanged(val, ref calibration);
    }
}
