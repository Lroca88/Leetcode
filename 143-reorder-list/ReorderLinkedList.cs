/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class ReorderLinkedList {
    int total;
    int current;
    ListNode head2;

    public void Reorder(ListNode head)
    {
        if (head == null) return;

        total++;
        Reorder(head.next);

        if (current < total) {
            ListNode temp = head2.next;
            head2.next = head;
            head2 = head2.next;
            current++;
            if (total - current > 0) {
                head2.next = temp;
                head2 = head2.next;
                current++;
            }
            if (total - current == 0) {
                head2.next = null;
            }
        }
    }

    public void ReorderList(ListNode head) {
        head2 = head;
        current = 1;
        Reorder(head);
    }
}