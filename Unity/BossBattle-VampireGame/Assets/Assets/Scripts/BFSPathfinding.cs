using System.Collections.Generic;
using UnityEngine;

public class BFSPathfinding
{
	public List<Transform> FindShortestPath(Transform start, Transform target, Transform[] nodes)
	{
		Queue<Transform> queue = new Queue<Transform>();
		Dictionary<Transform, Transform> cameFrom = new Dictionary<Transform, Transform>();
		HashSet<Transform> visited = new HashSet<Transform>();

		queue.Enqueue(start);
		visited.Add(start);
		cameFrom[start] = null;

		while (queue.Count > 0)
		{
			Transform current = queue.Dequeue();

			if (current == target)
			{
				return ReconstructPath(cameFrom, target);
			}

			foreach (Transform neighbor in nodes)
			{
				if (!visited.Contains(neighbor) && Vector3.Distance(current.position, neighbor.position) <= 10f)
				{
					queue.Enqueue(neighbor);
					visited.Add(neighbor);
					cameFrom[neighbor] = current;
				}
			}
		}

		return new List<Transform>();
	}

	private List<Transform> ReconstructPath(Dictionary<Transform, Transform> cameFrom, Transform target)
	{
		List<Transform> path = new List<Transform>();
		Transform current = target;

		while (current != null)
		{
			path.Add(current);
			current = cameFrom[current];
		}

		path.Reverse();
		return path;
	}
}
