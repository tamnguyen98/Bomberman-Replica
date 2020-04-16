using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour {

	public Tilemap tilemap;

	public Tile wallTile;
	public Tile destructibleTile;

	public GameObject explosionPrefab;

	int maxBlastRange = 1;

	public void Explode(Vector2 worldPos)
	{
		Vector3Int originCell = tilemap.WorldToCell(worldPos);

		ExplodeCell(originCell);
		bool[] keepGoing = new bool[] {true, true,true,true};
		for (int i = 1; i <= maxBlastRange; i++)
		{
			if (keepGoing[0])
				keepGoing[0] = ExplodeCell(originCell + new Vector3Int(i, 0, 0));
			if (keepGoing[1])
				keepGoing[1] = ExplodeCell(originCell + new Vector3Int(0, i, 0));
			if (keepGoing[2])
				keepGoing[2] = ExplodeCell(originCell + new Vector3Int(-i, 0, 0));
			if (keepGoing[3])
				keepGoing[3] = ExplodeCell(originCell + new Vector3Int(0, -i, 0));
		}

	}

	bool ExplodeCell (Vector3Int cell)
	{
		Tile tile = tilemap.GetTile<Tile>(cell);

		if (tile == wallTile)
		{
			return false;
		}

		if (tile == destructibleTile)
		{
			tilemap.SetTile(cell, null);
		}

		Vector3 pos = tilemap.GetCellCenterWorld(cell);
		Instantiate(explosionPrefab, pos, Quaternion.identity);

		return true;
	}

}
