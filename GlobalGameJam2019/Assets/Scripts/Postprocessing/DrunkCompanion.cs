using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class DrunkCompanion : MonoBehaviour
{
    public PostProcessingProfile m_drunkPostProcessingProfile = null;

    [Header("Vignette Options")]
    public float m_minVignetteIntensity = 0.5f;
    public float m_maxVignetteIntensity = 1.0f;
    private float m_vignetteIntensityDiff = 0.0f;
    public float m_vignettePacing = 0.5f;

    [Header("Depth of Field Options")]
    public float m_minDOFDistance = 5.0f;
    public float m_maxDOFDistance = 10.0f;
    private float m_DOFDistanceDiff = 0.0f;
    public float m_DOFPacing = 0.5f;

    private void Start()
    {
        m_vignetteIntensityDiff = m_maxVignetteIntensity - m_minVignetteIntensity;
        m_DOFDistanceDiff = m_maxDOFDistance - m_minDOFDistance;
    }

    public void UpdatePostProcesing(bool[] p_drunkEffects)
    {
        if (p_drunkEffects[(int)Player.DRUNK_EFFECTS.VIGNETTE])
        {
            m_drunkPostProcessingProfile.vignette.enabled = true;
            VignetteModel.Settings vignetteSettings = m_drunkPostProcessingProfile.vignette.settings;
            //MOAR MAGIC HERE
            vignetteSettings.intensity = m_vignetteIntensityDiff * Mathf.Sin(Time.timeSinceLevelLoad * m_vignettePacing) + (m_minVignetteIntensity + m_vignetteIntensityDiff/2.0f);
            m_drunkPostProcessingProfile.vignette.settings = vignetteSettings;
        }
        else
            m_drunkPostProcessingProfile.vignette.enabled = false;

        if (p_drunkEffects[(int)Player.DRUNK_EFFECTS.DOF])
        {
            m_drunkPostProcessingProfile.depthOfField.enabled = true;
            DepthOfFieldModel.Settings DOFSettings = m_drunkPostProcessingProfile.depthOfField.settings;
            //MOAR MAGIC HERE
            DOFSettings.focusDistance = m_DOFDistanceDiff * Mathf.Sin(Time.timeSinceLevelLoad * m_vignettePacing) + (m_minDOFDistance + m_DOFDistanceDiff / 2.0f);
            m_drunkPostProcessingProfile.depthOfField.settings = DOFSettings;
        }
        else
            m_drunkPostProcessingProfile.depthOfField.enabled = false;
    }

}
