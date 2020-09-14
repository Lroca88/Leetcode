using System;
using System.Collections.Generic;

public class CheapestFlights {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
        List<Dictionary<int, int>> adjM = new List<Dictionary<int, int>>(); 
        int[] prices = new int[n];
        MinHeap Q = new MinHeap(); 
            
        for(var vertex = 0; vertex < n; vertex++) {     
            adjM.Add(new Dictionary<int, int>());
            prices[vertex] = Int32.MaxValue;
        }
        
        foreach (var flight in flights) {
            adjM[flight[0]][flight[1]] = flight[2];    
        }
        
        prices[src] = 0;
        Q.Add(new int[] {src, 0, K + 1});
        
        while(!Q.IsEmpty()) {
            int[] cityData = Q.Pull();
            int city = cityData[0];
            int currentPrice = cityData[1];
            int stops = cityData[2];
            
            if (city == dst)  return prices[dst]; 
            if (stops <= 0) continue;
            
            foreach(var edge in adjM[city]) {
                int altPrice = edge.Value + currentPrice;
                if (prices[edge.Key] > altPrice) prices[edge.Key] = altPrice;
                Q.Add(new int[] {edge.Key, altPrice, stops - 1});
            }
            
        }
        
        // If I get here it means that there is no solution.
        return -1;
    }
    
    public class MinHeap {
        private List<int[]> items = new List<int[]>();
        
        public bool IsEmpty() { return items.Count == 0; }
        public int Size() { return items.Count; }
        public int GetLeftChildIndex(int pIndex) { return pIndex * 2 + 1; }
        public bool HasLeftChild(int pIndex) { return GetLeftChildIndex(pIndex) < Size(); }
        public int GetRightChildIndex(int pIndex) { return pIndex * 2 + 2; }
        public bool HasRightChild(int pIndex) { return GetRightChildIndex(pIndex) < Size(); }
        public int GetParentIndex(int cIndex) { return (cIndex - 1) / 2; }
        public bool HasParent(int cIndex) { return  GetParentIndex(cIndex) >= 0; }
        
        public int[] Peek() {
            if (IsEmpty()) throw new InvalidOperationException("Heap can't be empty");
            return items[0];
        }
        
        public int[] Pull() {
            int[] response = items[0];
            items[0] = items[Size() - 1];
            items.RemoveAt(Size() - 1);
            HeapifyDown();
            return response;
        }
        
        public void Add(int[] item) {
            items.Add(item);
            HeapifyUp();
        }
          
        private void HeapifyDown() {
            int index = 0;
            while(HasLeftChild(index)) { // While there is a child do, if there is no left child, for sure there is no right one
                int minChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index)) {
                    int rightChildIndex = GetRightChildIndex(index);
                    if (items[rightChildIndex][1] < items[minChildIndex][1]) 
                        minChildIndex = GetRightChildIndex(index);
                }
                
                if (items[minChildIndex][1] < items[index][1]) { 
                    Swap(minChildIndex, index);
                    index = minChildIndex;
                }  else {
                    break;  
                } 
            }
        }
        
        private void HeapifyUp() {
            int index = Size() - 1;
            while (HasParent(index)) {
                int pIndex = GetParentIndex(index);
                if (items[pIndex][1] > items[index][1]) {
                    Swap(pIndex, index);
                    index = pIndex;
                } else {
                    break;
                }
            }
        }
        
        private void Swap(int index1, int index2) {
            int[] temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }
        
    }
}



/**



                     4
               ------>------
               |           |
      2     2  |  1     1  |
   0 --> 1 --> 2 --> 3 --> 4     K = 2
   |           |
   ------>------
         5
          
Step 1:
Min Heap:
{
    [City, Distance, Stops]
    [0, 0, 3]
      
}
           0   1   2   3   4
distance: [0   inf inf inf inf]

Step 2:
For Node 0
Sorted Dictionary:
{
    [City, Distance, Stops]
    [1, 2, 2]
    [2, 5, 2]
}
           0   1   2   3   4
distance: [0   2   5   inf inf]

Step 3:
For Node 1
Sorted Dictionary:
{
    [City, Distance, Stops]
    [2, 4, 1]
    [2, 5, 2]
}
           0   1   2   3   4
distance: [0   2   4   inf inf]

Step 4:
For Node 2
Sorted Dictionary:
{
    [City, Distance, Stops]
    [2, 5, 2]
    [3, 5, 0]
    [4, 8, 0]
}
           0   1   2   3   4
distance: [0   2   4   5   8]

Step 5:
For Node 2
Sorted Dictionary:
{
    [City, Distance, Stops]
    [3, 5, 0]
    [3, 6, 1]
    [4, 8, 0]
    [4, 9, 1]
}
           0   1   2   3   4
distance: [0   2   4   5   8]

Step 6:
For Node 3 I can't do anything because currentK = 0, no more hops.
Sorted Dictionary:
{
    [City, Distance, Stops]
    [3, 6, 1]
    [4, 8, 0]
    [4, 9, 1]
}
           0   1   2   3   4
distance: [0   2   4   5   8]


Step 7:
For Node 3
Sorted Dictionary:
{
    [City, Distance, Stops]      [3, 6, 1]
    [4, 7, 0]
    [4, 8, 0]
    [4, 9, 1]
}
           0   1   2   3   4
distance: [0   2   4   5   7]

Step 8:
For Node 4
Node 4 == Destination. Therefore I return distance[4] = 7
    
*/


/*

There are n cities connected by m flights. Each flight starts from city u and arrives at v with a price w.

Now given all the cities and flights, together with starting city src and the destination dst, your task is to find the cheapest price from src to dst with up to k stops. If there is no such route, output -1.

Example 1:
Input: 
n = 3, edges = [[0,1,100],[1,2,100],[0,2,500]]
src = 0, dst = 2, k = 1
Output: 200

Explanation: 
The graph looks like this:
          0
     100/   \500
       /_____\
      1  100  2
The cheapest price from city 0 to city 2 with at most 1 stop costs 200, as marked red in the picture.

Example 2:
Input: 
n = 3, edges = [[0,1,100],[1,2,100],[0,2,500]]
src = 0, dst = 2, k = 0
Output: 500

Explanation: 
The graph looks like this:
          0
     100/   \500
       /_____\
      1  100  2

The cheapest price from city 0 to city 2 with at most 0 stop costs 500, as marked blue in the picture.
 

Constraints:

The number of nodes n will be in range [1, 100], with nodes labeled from 0 to n - 1.
The size of flights will be in range [0, n * (n - 1) / 2].
The format of each flight will be (src, dst, price).
The price of each flight will be in the range [1, 10000].
k is in the range of [0, n - 1].
There will not be any duplicated flights or self cycles.


*/