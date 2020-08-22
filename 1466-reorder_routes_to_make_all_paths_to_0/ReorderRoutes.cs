using System.Collections.Generic;
using System.Linq;

public class ReorderRoutes {
    public int MinReorder(int n, int[][] connections) {
        // This solution is BFS.
        List<List<int>> roads = new List<List<int>>();
        bool[] roadProcessed = new bool[n - 1];
        Queue<int> nextCity = new Queue<int>();
        int reordered = 0;
        
        // Initializing Roads
        for(int i = 0; i < n; i++) {
            roads.Add(new List<int>());
        }
        
        // Creating the roads adjacency list
        for(var roadIndex = 0; roadIndex < connections.Length; roadIndex++) {
            int cityA = connections[roadIndex][0];
            int cityB = connections[roadIndex][1];
            roads[cityA].Add(roadIndex);
            roads[cityB].Add(roadIndex);
        }
        
        nextCity.Enqueue(0);

        // While there are cities, keep processing
        while(nextCity.Count > 0) {
            int city = nextCity.Dequeue();
            foreach(var roadIndex in roads[city]) {
                if (roadProcessed[roadIndex] == true) continue;
                // If city is in first position, it needs to be reordered
                if (connections[roadIndex][0] == city) {
                    reordered++;
                    nextCity.Enqueue(connections[roadIndex][1]);
                } else {
                     nextCity.Enqueue(connections[roadIndex][0]);
                }
                roadProcessed[roadIndex] = true;
            }
        }
        
        return reordered;
    }
}


/**

There are n cities numbered from 0 to n-1 and n-1 roads such that there is only one way to travel between two different cities (this network form a tree). Last year, The ministry of transport decided to orient the roads in one direction because they are too narrow.

Roads are represented by connections where connections[i] = [a, b] represents a road from city a to b.

This year, there will be a big event in the capital (city 0), and many people want to travel to this city.

Your task consists of reorienting some roads such that each city can visit the city 0. Return the minimum number of edges changed.

It's guaranteed that each city can reach the city 0 after reorder.

 

Example 1:


  ---->1---->3<----2
 /
0
 \
  <----4---->5


Input: n = 6, connections = [[0,1],[1,3],[2,3],[4,0],[4,5]]
Output: 3
Explanation: Change the direction of edges show in red such that each node can reach the node 0 (capital).

Example 2:

0<---1--->2<---3--->4

Input: n = 5, connections = [[1,0],[1,2],[3,2],[3,4]]
Output: 2
Explanation: Change the direction of edges show in red such that each node can reach the node 0 (capital).
Example 3:

Input: n = 3, connections = [[1,0],[2,0]]
Output: 0
 

Constraints:

2 <= n <= 5 * 10^4
connections.length == n-1
connections[i].length == 2
0 <= connections[i][0], connections[i][1] <= n-1
connections[i][0] != connections[i][1]

*/

//////////////////////////////////////////////////////////////////////////////////////////////////////

/*

    First Solution:
    This solution works, but the fact that we are processing roads from the HashSet
    and if I can't process the road it remains in the HashSet makes the worst case run time O(N^2)
    I'll try to improve the run time in the second iteration.

    public int MinReorder(int n, int[][] connections) {
        int total = 0;
        int reordered = 0;
        bool[] cities = new bool[connections.Length + 1];
        HashSet<int[]> roads = new HashSet<int[]>();
        
        for(int i = 0; i < connections.Length; i++) {
            roads.Add(connections[i]);
        }
            
        while(total < connections.Length) {
            foreach(var road in roads.ToList()) {
                if(road[0] == 0 || cities[road[0]] == true) {
                    reordered++;
                    total++;
                    cities[road[1]] = true;
                    roads.Remove(road);
                }
                if(road[1] == 0 || cities[road[1]] == true) {
                    total++;
                    cities[road[0]] = true;
                    roads.Remove(road);
                }
            }
        }
        
        return reordered;
    }
*/

//////////////////////////////////////////////////////////////////////////////////////////////////////

/*
    Second solution has been implemented using a BFS.
*/




