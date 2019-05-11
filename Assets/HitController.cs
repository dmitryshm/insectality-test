using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public int m_DamageAmount = 30;

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
            m_HealthScore -= m_DamageAmount;
        }
        if (m_HealthScore < 1)
        {
            Die();
        }
    }

    void Die()
    {
        RootMotion.Demos.MechSpider script1 = gameObject.GetComponent<RootMotion.Demos.MechSpider>();
        script1.enabled = false;
        foreach(RootMotion.Demos.MechSpiderLeg leg in script1.legs)
        {
            RootMotion.Demos.MechSpiderLeg legScript = leg.GetComponent<RootMotion.Demos.MechSpiderLeg>();
            legScript.enabled = false;
            RootMotion.FinalIK.FABRIK fabrikScript = leg.GetComponent<RootMotion.FinalIK.FABRIK>();
            fabrikScript.enabled = false;
        }
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpiderFoot")
        {
            TakeDamage(HitController.DamageType.LegF);
        }
    }
}
