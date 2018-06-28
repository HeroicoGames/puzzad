using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPuzzleButton : MonoBehaviour {
	[Serializable]
	public struct Bridge {
		public GameObject bridgeObject;
		public Vector3 positionToMove;
	}
	public List<Bridge> bridges = new List<Bridge>();
	 // TODO: se me ocurrio que debería crear un diccionario con los puentes y 
	// las coordenadas para hacía donde se deberían mover los puentes
	// ejemplo: Bridge1 (GameObject) coordenate1 (Vector3)
	// Si es muy dificil con diccionarios, mejor hacerlo con dos listas
	// una lista con los GameObjects y otra con las Vector3

	// Notas: Que sucede cuando dos botones modifican la position de un Bridge
	// Ejemplo: El puente solo se pondrá en la posición correcta si se presionan los botones en el orden
	// correcto, o si simplemente se deben presionar los dos botones para que la plataforma se mueva... Etc.

	void ActivateBridges() {
		for(int i = 0; i < bridges.Count; i++) {
			bridges [i].bridgeObject.transform.Translate (bridges [i].positionToMove);
			// bridges [i].transform.Translate (0f, 6f, 0f);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.name == "Hero") {
			ActivateBridges ();
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
