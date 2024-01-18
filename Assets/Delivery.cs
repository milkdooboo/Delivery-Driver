using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);


    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage; // 기본값은 false : 시작할 때 Package를 갖고 있지 않음

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage) // Package를 한 번에 1개씩만 pickup 할 수 있게함 : Package를 갖고 있지 않은지 확인
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delievered");
            hasPackage = false; // 물건을 한 번 배달하면 더 이상 물건이 없음을 나타냄
            spriteRenderer.color = noPackageColor;
        }
    }
}
