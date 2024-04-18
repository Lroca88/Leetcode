
/**
 * Definition for singly-linked list.
 */
public class PNode
{
    public int val;
    public PNode next;
    public PNode(int val = 0, PNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class PalindromeLinkedList
{
    PNode head;
    bool status;
    private bool CheckPalindrome(PNode head2) {
        if (head2 == null) {
            this.status = true;
            return true;
        } else {
            CheckPalindrome(head2.next);
        }
        if (status == false) return status;
        if (head.val != head2.val) {
            status = false;
        }
        head = head.next;
        return status;
    }

    public bool IsPalindrome(PNode head)
    {
        this.head = head;
        return CheckPalindrome(head);
    }

    public PNode BuildLinkedList(int[] list) {
        PNode head, temp;
        head = new PNode();
        temp = head;
        foreach(int val in list) {
            temp.next = new PNode(val);
            temp = temp.next;
        }
        return head.next;
    }
}









/*
Asked in Microsoft Interview

Given a singly linked list, determine if it is a palindrome.

Example 1:

Input: 1->2
Output: false

Example 2:

Input: 1->2->2->1
Output: true

Follow up:
Could you do it in O(n) time and O(1) space?

*/