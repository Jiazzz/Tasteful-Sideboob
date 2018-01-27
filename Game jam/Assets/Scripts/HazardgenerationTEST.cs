using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazardgeneration : MonoBehaviour {

/*
Hazard generate script:

- Load level: scrollende achtergrond met player ships
	(- Tekst over scherm: LEVEL X/FINAL LEVEL)
- Als tekst is verdwenen, kunnen schepen bewegen.

parameters:
- objectID (0 = monster, 1 = asteroid)
- spawn points (X1...X6 of X1...X8), Y = -20
- int strtobj						// Aantal objects to be spawned om te starten
- int desspwn 						// Destroyed objects needed for new spawn
- int cntdes						// Counter for destroyed objects (reset als spawn event)
- int nmrspwn 						// number of objects to spawn
- int cntspwn						// number of spawns
	- if cnt > x, increase nmrspwn, if cnt > y, increase nmrspwn etc.
- Als t=5, begin met generation
- Generate object op random spawnpoint (maar nooit op dezelfde)

- pwrupID (0 =, 1 =)
- int pwrspwn						// Destroyed objects needed for powerup, change if spawn event
*/
/*

    [SerializeField]
    int id;

    [SerializeField]
    string xAxis;
    [SerializeField]
    string yAxis;

    [SerializeField]
    GameObject bigasteroidPrefab;
	[SerializeField]
    GameObject alienPrefab;

    [SerializeField]
    GameObject gameManagerObject;

    GameManager gameManager;


	void InitialGenerateHazards()
	{
		int strtobj = 4;
		GenerateHazards(strtobj);
	}
	
	void Update()			// Hmz, ik wil eigenlijk dat hij in de dieper liggende IF de destroyed status checked, dit voelt niet als een method for in Update... 
	{
		int spwninc = 3;	// na hoeveel spawn cycles aantal spawns wordt verhoogd, 1 hard
		int desspwn = 2;	// na hoeveel hazards destroyed nieuwe hazards spawnen
		int nmrspwn = 2;	// aantal spawns per spawn cycle, 1 easy
		while (level != finished){		
			for (i=0, i < spwninc, i++){
				for (j=0, j < desspwn, j++){
					// TODO: count destroyed hazard objects
					if (cntdes = desspwn){
						GenerateHazards(nmrspwn);
					}
				}
			}
			nmrspwn++;
		}
	}
	
	void GenerateHazards(int nmrspwn)
	{
		//TODO, zorg ervoor dat elke opvolgende xpos niet in de collection van vorige xpos zit
		int cntspwn = 0;
		for (i=1, i<nmrspwn, i++)
		{			
			int rdmObj = random.Next(0, 1);
			string objID = alienPrefab;
			int xpos = random.Next(-7, 7);
			if (rdmObj = 1)
			{
				objID = bigasteroidPrefab;
			}	
			SpawnHazard(objID, xpos);	
		}
	}

    void SpawnHazard(string hazard, int xposition)
    {
		position.x = xposition
		position.y = -20	
        GameObject hazard = Instantiate(hazard, position, 0);
    }
    */
}
