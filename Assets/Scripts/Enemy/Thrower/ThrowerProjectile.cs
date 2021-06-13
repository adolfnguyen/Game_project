using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerProjectile : MonoBehaviour
{
    public Transform Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;

    private Transform m_myTransform;
    public Transform Projectile;
    private void Awake()
    {
        m_myTransform = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SimulateThrowing());
    }

    IEnumerator SimulateThrowing()
    {
        yield return new WaitForSeconds(1.5f);

        //Thay đổi offset nếu cần thiết
        Projectile.position = m_myTransform.position + new Vector3(0, 0, 0);
        //Tính toán khoảng cách của target
        float targetDistance = Vector3.Distance(Projectile.position, Target.position);

        //Tính toán vận tốc cần thiết để ném đến mục tiêu với 1 góc độ xác định
        float projectileVelocity = targetDistance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        //Lấy ra thành phần x, y của vận tốc
        float Vx = Mathf.Sqrt(projectileVelocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectileVelocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        //Tính toán thời gian bay
        float flightDuration = targetDistance / Vx;

        //Xoay lựu đạn về phía target
        Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

        float elapseTime = 0;

        while (elapseTime < flightDuration)
        {
            Projectile.Translate(0, (Vy - (gravity * elapseTime)) * Time.deltaTime, Vx * Time.deltaTime);
            elapseTime += Time.deltaTime;
            yield return null;
        }
    }
}
