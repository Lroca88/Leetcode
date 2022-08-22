using System;
using System.Collections.Generic;
using System.Text;
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
public class MergeTwoSortedLists
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var solution = new ListNode();
        var head = solution;

        if (list1 == null && list2 == null)
        {
            return null;
        }

        while (list1 != null || list2 != null)
        {
            head.next = new ListNode();
            head = head.next;

            if (list1 != null && (list2 == null || list1.val <= list2.val))
            {
                head.val = list1.val;
                list1 = list1.next;
            }
            else if (list2 != null && (list1 == null || list2.val <= list1.val))
            {
                head.val = list2.val;
                list2 = list2.next;
            }
        }

        return solution.next;
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
