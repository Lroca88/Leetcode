public class AddTwo {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode res, sum = new ListNode();
        res = sum;
        int carrier = 0;

        while (l1 != null || l2 != null || carrier > 0) {
            sum.next = new ListNode();
            sum = sum.next;
            if (l1 != null) {
                sum.val = l1.val;
                l1 = l1.next;
            }
            if (l2 != null) {
                sum.val += l2.val;
                l2 = l2.next;
            }
            sum.val += carrier;
            carrier = sum.val / 10;
            sum.val = sum.val %10;
        }

        return res.next;
    }
}


// Definition for singly-linked list.
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}
/**
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example:

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8

Explanation: 342 + 465 = 807.

*/
