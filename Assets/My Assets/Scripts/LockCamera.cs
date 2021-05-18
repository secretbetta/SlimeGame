using UnityEngine;
using Cinemachine;
 
/// <summary>
/// An add-on module for Cinemachine Virtual Camera that locks the camera's coordinates
/// </summary>
[ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
public class LockCamera : CinemachineExtension
{
    [Tooltip("Lock the camera's X position to this value")]
    public bool m_X = false;
    public bool m_Y = false;
    public bool m_Z = false;
    
    public float m_XPosition = 10;
    public float m_YPosition = 0;
    public float m_ZPosition = 0;
 
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            if (m_X) {
                pos.x = m_XPosition;
            }
            if (m_Y) {
                pos.y = m_YPosition;
            }
            if (m_Z) {
                pos.z = m_ZPosition;
            }
            state.RawPosition = pos;
        }
    }
}