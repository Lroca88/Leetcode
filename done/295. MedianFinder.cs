using System;
using System.Collections.Generic;

public class MedianFinder {

    /** initialize your data structure here. */
    MaxHeap maxH;
    MinHeap minH;

    public MedianFinder() {
        maxH = new MaxHeap(); 
        minH = new MinHeap();
    }
    
    public void AddNum(int num) {
        if (maxH.GetSize() > 0 && num >= maxH.Peek()) { // If num is bigger than the 1st half it goes to the 2nd half
            minH.Add(num);
        } else {
            maxH.Add(num);
        }
            
        if (Math.Abs(maxH.GetSize() - minH.GetSize()) > 1) { // If there are more than one number of difference
            if (maxH.GetSize() > minH.GetSize()) {
                int number = maxH.Pull();
                minH.Add(number);    
            } else {
                int number = minH.Pull();
                maxH.Add(number);    
            }
        }
    }
    
    public double FindMedian() {
        if (maxH.GetSize() == minH.GetSize()) { // When we have the same ammount we took one from each side
            return (double) (maxH.Peek() + minH.Peek()) / 2;
        }

        if (maxH.GetSize() > minH.GetSize()) {  // If left side has more numbers
            return (double) maxH.Peek();
        }

        return minH.Peek(); // Right side has more numbers
    }
}

// Used to store the largest numbers.
public class MinHeap {
    private List<int> numbers = new List<int>();
    private int size;

    public int GetSize() {
        return size;
    }
    
    public bool HasParent(int cIndex) { return GetParentIndex(cIndex) >= 0;}
    public bool HasLeftChild(int pIndex) { return size > pIndex * 2 + 1;}
    public bool HasRigthChild(int pIndex) { return size > pIndex * 2 + 2;}
    public int GetParentIndex(int cIndex) { return (cIndex - 1) / 2;}
    public int GetLeftChildIndex(int pIndex) { return pIndex * 2 + 1;}
    public int GetRightChildIndex(int pIndex) { return pIndex * 2 + 2;}

    public int Peek() {
        if (size == 0) throw new InvalidOperationException("size cannot be 0");
        return numbers[0];
    }

    public int Pull() {
        var number = numbers[0];
        size --;
        numbers[0] = numbers[size];
        numbers.RemoveAt(size);
        HeapifyDown();
        return number;
    }

    public void Add(int number) {
        numbers.Add(number);
        size++;
        HeapifyUp();
    }

    private void HeapifyUp()
    {
        var index = size - 1;
        while (HasParent(index) && numbers[GetParentIndex(index)] > numbers[index]) {
            int pIndex = GetParentIndex(index);
            Swap(index, pIndex);
            index = pIndex;
        }
    }

    private void HeapifyDown()
    {
        int index = 0;
        while (HasLeftChild(index)) {
            int smallestChildIndex = GetLeftChildIndex(index);
            if (HasRigthChild(index) && numbers[GetRightChildIndex(index)] < numbers[smallestChildIndex])
                smallestChildIndex = GetRightChildIndex(index);
            if (numbers[index] > numbers[smallestChildIndex]) {
                Swap(index, smallestChildIndex);
                index = smallestChildIndex;
            } else {
                break;
            }
        }
    }

    private void Swap(int idx1, int idx2) {
        int temp = numbers[idx1];
        numbers[idx1] = numbers[idx2];
        numbers[idx2] = temp;
    }
}

// Used to store the smallest numbers.
public class MaxHeap {
    private List<int> numbers = new List<int>();
    private int size;

    public int GetSize() {
        return size;
    }
    
    public bool HasParent(int cIndex) { return GetParentIndex(cIndex) >= 0;}
    public bool HasLeftChild(int pIndex) { return size > pIndex * 2 + 1;}
    public bool HasRigthChild(int pIndex) { return size > pIndex * 2 + 2;}
    public int GetParentIndex(int cIndex) { return (cIndex - 1) / 2;}
    public int GetLeftChildIndex(int pIndex) { return pIndex * 2 + 1;}
    public int GetRightChildIndex(int pIndex) { return pIndex * 2 + 2;}

    public int Peek() {
        if (size == 0) throw new InvalidOperationException("size cannot be 0");
        return numbers[0];
    }

    public int Pull() {
        var number = numbers[0];
        size --;
        numbers[0] = numbers[size];
        numbers.RemoveAt(size);
        HeapifyDown();
        return number;
    }

    public void Add(int number) {
        numbers.Add(number);
        size++;
        HeapifyUp();
    }

    private void HeapifyUp()
    {
        var index = size - 1;
        while (HasParent(index) && numbers[GetParentIndex(index)] < numbers[index]) {
            int pIndex = GetParentIndex(index);
            Swap(index, pIndex);
            index = pIndex;
        }
    }

    private void HeapifyDown()
    {
        int index = 0;
        while (HasLeftChild(index)) {
            int biggestChildIndex = GetLeftChildIndex(index);
            if (HasRigthChild(index) && numbers[GetRightChildIndex(index)] > numbers[biggestChildIndex])
                biggestChildIndex = GetRightChildIndex(index);
            if (numbers[index] < numbers[biggestChildIndex]) {
                Swap(index, biggestChildIndex);
                index = biggestChildIndex;
            } else {
                break;
            }
        }
    }
    
    private void Swap(int idx1, int idx2) {
        int temp = numbers[idx1];
        numbers[idx1] = numbers[idx2];
        numbers[idx2] = temp;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */



/**
Median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value.
So the median is the mean of the two middle value.

For example,
[2,3,4], the median is 3

[2,3], the median is (2 + 3) / 2 = 2.5

Design a data structure that supports the following two operations:

void addNum(int num) - Add a integer number from the data stream to the data structure.
double findMedian() - Return the median of all elements so far.
 

Example:
addNum(1)
addNum(2)
findMedian() -> 1.5
addNum(3) 
findMedian() -> 2
 

Follow up:

If all integer numbers from the stream are between 0 and 100, how would you optimize it?
If 99% of all integer numbers from the stream are between 0 and 100, how would you optimize it?

*/