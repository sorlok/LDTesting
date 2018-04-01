using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
	public GameObject HeroCube;
	public GameObject HeroShield;

	//Shield Attack
	private float shieldAttackSpeed = .2f; 
	private int shieldAttacking = 0;
	private Vector3 shieldStartPosition = new Vector3 (1, 0, 0);
	private Vector3 shieldEndPosition = new Vector3 (6, 0, 0);
	private float shieldWiggle = .2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Move 

		//Shield
		if (Input.GetKey (KeyCode.J) && shieldAttacking == 0) {
			ShieldAttack ();
		}
		if (shieldAttacking != 0) {
			HandleShieldAttack();
		}
	}

	void Move () {

	}

	void ShieldAttack () {
		shieldAttacking = 1;
	}

	void HandleShieldAttack () {
		//HeroShield
		if (shieldAttacking == 1) {
			print ("Shield Attacking");
			//Move
			//HeroShield.transform.localPosition += new Vector3 (shieldAttackSpeed, 0, 0);
			HeroShield.transform.localPosition = Vector3.Lerp(HeroShield.transform.position, shieldEndPosition,.1f);
			//Check
			if (HeroShield.transform.localPosition.x >= (shieldEndPosition.x - shieldWiggle)) {
				shieldAttacking *= -1;
			}
		} 
		else if (shieldAttacking == -1) {
			print ("Shield Returning");
			//Move
			//HeroShield.transform.localPosition -= new Vector3(shieldAttackSpeed, 0, 0);

			//Check
			if (HeroShield.transform.localPosition.x <= (shieldStartPosition.x + shieldWiggle)) {
				shieldAttacking = 0;
				//Snap
				//HeroShield.transform.localPosition = new Vector3 (1, 0, 0);
				HeroShield.transform.localPosition = Vector3.Lerp(HeroShield.transform.localPosition, shieldStartPosition,.1f);

			}
		}

	}
}
