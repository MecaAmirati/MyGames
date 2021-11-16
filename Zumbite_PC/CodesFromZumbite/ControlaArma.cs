using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{

	public GameObject Bala;
	public GameObject CanoDaArma;
	AudioSource SomDoTiro;

    public void Start()
    {
		SomDoTiro = GetComponent<AudioSource>();
    }

    void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			SomDoTiro.PlayOneShot(SomDoTiro.clip);
			Instantiate(Bala, CanoDaArma.transform.position, CanoDaArma.transform.rotation);
			
		}

	}
}
