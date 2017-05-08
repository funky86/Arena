using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Wheel objects transforms")]
    [SerializeField] Transform m_WheelFLTransform;
    [SerializeField] Transform m_WheelFRTransform;
    [SerializeField] Transform m_WheelBLTransform;
    [SerializeField] Transform m_WheelBRTransform;

    [Header("Wheel colliders")]
    [SerializeField] WheelCollider m_WheelFLCollider;
	[SerializeField] WheelCollider m_WheelFRCollider;
	[SerializeField] WheelCollider m_WheelBLCollider;
	[SerializeField] WheelCollider m_WheelBRCollider;

    [Header("Physics parameters")]
	[SerializeField] float m_MaxMotorTorque = 1.0f;
	[SerializeField] float m_BreakTorque = 1.0f;
	[SerializeField] float m_MaxSteerAngle = 1.0f;

    const string m_InputAxisVertial = "Vertical";
    const string m_InputAxisHorizontal = "Horizontal";

    float SteerAngle = 0f;

    void Update()
    {
        m_WheelFLTransform.localRotation = Quaternion.Euler(0, SteerAngle, 0);
        m_WheelFRTransform.localRotation = Quaternion.Euler(0, SteerAngle, 0);

        ApplyWheelPosition(m_WheelFLCollider, m_WheelFLTransform);
        ApplyWheelPosition(m_WheelFRCollider, m_WheelFRTransform);
        ApplyWheelPosition(m_WheelBLCollider, m_WheelBLTransform);
        ApplyWheelPosition(m_WheelBRCollider, m_WheelBRTransform);
    }

    void FixedUpdate()
	{
		float accelerate = Input.GetAxis(m_InputAxisVertial);
        float motorTorque = accelerate * m_MaxMotorTorque;

        m_WheelFLCollider.motorTorque = motorTorque;
		m_WheelFRCollider.motorTorque = motorTorque;
        m_WheelBLCollider.motorTorque = motorTorque;
        m_WheelBRCollider.motorTorque = motorTorque;

        if (Input.GetKey(KeyCode.Space))
        {
            m_WheelBLCollider.brakeTorque = m_BreakTorque;
            m_WheelBRCollider.brakeTorque = m_BreakTorque;
        }
        else
        {
            m_WheelBLCollider.brakeTorque = 0.0f;
            m_WheelBRCollider.brakeTorque = 0.0f;
        }

        float steer = Input.GetAxis(m_InputAxisHorizontal);
        SteerAngle = steer * m_MaxSteerAngle;
        
        m_WheelFLCollider.steerAngle = SteerAngle;
		m_WheelFRCollider.steerAngle = SteerAngle;
    }

    void ApplyWheelPosition(WheelCollider sourceWheelCollider, Transform targetTransform)
    {
        Vector3 position;
        Quaternion rotation;
        sourceWheelCollider.GetWorldPose(out position, out rotation);

        targetTransform.position = position;
    }
}
