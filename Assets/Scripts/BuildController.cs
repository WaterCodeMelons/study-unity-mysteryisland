using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	/*
	<summary>
	Klasa systemu budowania, wykorzystuje raycast zaczynający się w punkcie oddalonym od gracza wychodzącym z kamery
	i uderza w terrain aby wykryć punkt kolizji oraz wektor normalny płaszczyzny terrain collidera po czym wylicza
	wektor ustawienia obiektu oraz pozwala przeliczyć rotację tego obiektu wokół wektora normalnego płaszczyzny
	terrain collidera
	</summary>
	*/
public class BuildController : MonoBehaviour {

	public GameObject [] buildingsDatabase;
	public Camera playerCamera;
	public GameObject building;
	// Kontrolka blokująca budowanie
	public bool isBuilding = false;
	private RaycastHit hit;
	
	void Update () {

		// TODO: Wybieranie obiektu do budowania z UI, jak na razie KeyCode.B wybiera obiekt 0 z bazy budynków
		if (Input.GetKeyDown(KeyCode.B)) {
			this.build(0);
		}

		// Początkowa pozycja raya, obrana w punkcie 5 jednostek przed kamerą, na środku viewportus
		Vector3 rayStart = playerCamera.transform.position + (playerCamera.transform.forward * 5f);

		// Ray widoczny w edytorze
		Debug.DrawRay(rayStart, Vector3.down * 100);

		// Kolizja z terenem
        if (Physics.Raycast(rayStart, Vector3.down, out hit, 100))
        {
			if (hit.transform.name == "Terrain") {
				building.transform.position = hit.point; // Punkt kolizji raya z terrain colliderem
				/*
				<summary>
				Najważniejszy element klasy budującej. Quaternion.FromToRotation() metoda pozwalająca na ustawienie wektora kierunku obiektu w inny wektor kierunku,
				np ustawienie wektora wychodzącego lokalnie w górę od obiektu [building.transform.up] do wektora normalnego płaszczyzny kolzji terenu [hit.normal].
				Pomnożenie tej rotacji wyliczonej z ustawienia jednego wektora kierunku w stosunku do drugiego pozwala na "ustawienie" predefiniowanej rotacji dla obiektu.
				Jednym zdaniem, bez tej dodatkowej rotacji obiekt będzie rotował od Quaternion.identity do hit.normal, to dodatkowe mnożenie pozwala na ustawienie wcześniejszego
				obrotu za pomocą KeyCode.Q, KeyCode.E.
				</summary>
				*/
				building.transform.rotation = Quaternion.FromToRotation (building.transform.up, hit.normal) * building.transform.rotation;
			}
        }


		// Obracanie obiektu wokół wektora skierowanego ku górze pozycji lokalnej obiektu
		if (Input.GetKey(KeyCode.Q)) {
				building.transform.Rotate(-(Vector3.up * Time.deltaTime * 100));
		}

		if (Input.GetKey(KeyCode.E)) {
				building.transform.Rotate(Vector3.up * Time.deltaTime * 100);
		}

		// "puszczenie" obiektu, pozostawienie go w miejscu zderzenia
		if (Input.GetButtonDown("Fire1")) {
				building = null;
		}

    }

	// Metoda pozwalająca na wybranie obiektu do budowania, ustawi się on w punkcie kolizji raycasta z terenem
	// I będzie można go zatwierdzić za pomocą LMB
	void build (int id) {
		building = Instantiate(buildingsDatabase[0], hit.point, Quaternion.identity);
	}
}
