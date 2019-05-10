using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public enum DamageType
    {
        LegF
    }

    /// <summary>
    /// очки здоровья
    /// </summary>
    public int m_HealthScore = 100;

    // Start is called before the first frame update
    void Start()
    {
        m_HealthScore = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(DamageType type)
    {
        if (type == DamageType.LegF)
        {
            m_HealthScore -= 5;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpiderFoot")
        {
            TakeDamage(HitController.DamageType.LegF);
        }
    }
}
