using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f; // Unity içinden değerleri değiştirebilmek için [SerializeField] kullanıldı.
    [SerializeField] float moveSpeed = 15f; // Unity'deki ..Speed değerleri buradakinden bağımsız olarak değiştirilebilmekte.
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; // deltaTime ile oyunumuzun anlık verdiği kare hızını (fps) yavaş ve hızlı cihazlarda eşitliyoruz.
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount); // steer başına gelen eksi sayesinde öncesinde ters olan kontroller düzeldi. A tuşu sola, D tuşu sağa yön veriyor.
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
            moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Boost" )
        {
            moveSpeed = boostSpeed;
        }
    }
}
