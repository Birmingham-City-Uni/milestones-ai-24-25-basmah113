using System.Collections.Generic;
using UnityEngine;

public class DFSPathfinding
{
	public List<Transform> ExploreDeep(Transform start, Transform target, Transform[] nodes)
	{
		Stack<Transform> stack = new Stack<Transform>();
		Dictionary<Transform, Transform> cameFrom = new Dictionary<Transform, Transform>();
		HashSet<Transform> visited = new HashSet<Transform>();

		stack.Push(start);
		visited.Add(start);
		cameFrom[start] = null;

		while (stack.Count > 0)
		{
			Transform current = stack.Pop();

			if (current == target)
			{
				return ReconstructPath(cameFrom, target);
			}

			foreach (Transform neighbor in nodes)
			{
				if (!visited.Contains(neighbor) && Vector3.Distance(current.position, neighbor.position) <= 10f)
				{
					stack.Push(neighbor);
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
