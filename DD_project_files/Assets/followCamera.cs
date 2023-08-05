using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    // Hareket halinde olan nesnenin konumunu (karakter veya araba) sürekli olarak kameraya iletmemiz gerekir.

    void LateUpdate() // Update yerine LateUpdate kullandık, aksi halde aracımızda titremeler meydana gelebilirdi. Unity fizik motoru farklı katmanlar içerdiği için sürekli yapılan Update sağlıklı olmayacaktır.
    {
        transform.position = thingToFollow.transform.position + new Vector3 (0,0,-10); // burada Z eksenine -10 değerini verdik çünük aracımıza üstten bakıyoruz, vermediğimiz takdirde kamera zeminin içerisinde gözükecektir.
    }
}
