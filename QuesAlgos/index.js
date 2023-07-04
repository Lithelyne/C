/**
 * Class to represent a queue using an array to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
class Queue {
    constructor() {
        this.items = [];
    }

    /**
     * Determines whether the sum of the left half of the queue items is equal to
     * the sum of the right half. Avoid indexing the queue items directly via
     * bracket notation, use the queue methods instead for practice.
     * Use no extra array or objects.
     * The queue should be returned to it's original order when done.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {boolean} Whether the sum of the left and right halves is equal.
     */
    isSumOfHalvesEqual() {

        let sum1 = 0;
        let sum2 = 0;
        let size = this.size();

        if (this.isEmpty() || this.size() === 1) {
            console.log("This Queue does not have two halves.")
            return false
        }

        for (let i = 0; i < size; i++) {
            let temp

            if (i < (size / 2) &&  (i + .5) != (size/2)) {
                temp = this.dequeue()
                sum1 += temp
                this.enqueue(temp)
            }
            //can remove temp with front enqueue

            else if (i >= (size / 2)) {
                temp = this.dequeue()
                sum2 += temp
                this.enqueue(temp)
            }

            else {
                temp = this.dequeue()
                this.enqueue(temp)
            }
        }
        // console.log(sum1)
        // console.log(sum2)
        return sum1 === sum2;
    }

    /**
     * Compares this queue to another given queue to see if they are equal.
     * Avoid indexing the queue items directly via bracket notation, use the
     * queue methods instead for practice.
     * Use no extra array or objects.
     * The queues should be returned to their original order when done.
     * - Time: O(n^2) quadratic, n = queue length. Quadratic due to dequeue on an
     *     array queue being O(n).
     * - Space: O(1) constant.
     * @param {Queue} q2 The queue to be compared against this queue.
     * @returns {boolean} Whether all the items of the two queues are equal and
     *    in the same order.
     */
    compareQueues(q2) {
        if (this.size() !== q2.size()) {
            return false;
        }
        let count = 0;
        let isEqual = true;
        const len = this.size();

        while (count < len) {
            const dequeued1 = this.dequeue();
            const dequeued2 = q2.dequeue();

            if (dequeued1 !== dequeued2) {
                isEqual = false;
            }

            this.enqueue(dequeued1);
            q2.enqueue(dequeued2);
            count++;
        }
        return isEqual;
    }

    /**
     * Determines if the queue is a palindrome (same items forward and backwards).
     * Avoid indexing queue items directly via bracket notation, instead use the
     * queue methods for practice.
     * Use only 1 stack as additional storage, no other arrays or objects.
     * The queue should be returned to its original order when done.
     * - Time: O(n^2) quadratic, n = queue length. Quadratic due to dequeue on an
     *     array queue being O(n).
     * - Space: O(n) from the stack being used to store the items again.
     * @returns {boolean}
     */
    isPalindrome() {
        let isPalin = true;
        const stack = new Stack(),
            len = this.size();

        for (let i = 0; i < len; i++) {
            let dequeued = this.dequeue();
            stack.push(dequeued);
            // add it back so the queue items and order is restored at the end
            this.enqueue(dequeued);
        }

        for (let i = 0; i < len; i++) {
            let dequeued = this.dequeue();
            let popped = stack.pop();

            if (popped !== dequeued) {
                isPalin = false;
            }

            // add it back so the queue items and order is restored at the end
            this.enqueue(dequeued);
        }
        return isPalin;
    }

    /**
     * Adds a new given item to the back of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @param {any} item The new item to add to the back.
     * @returns {number} The new size of this queue.
     */
    enqueue(item) {
        this.items.push(item);
        return this.size();
    }

    /**
     * Removes and returns the first item of this queue.
     * - Time: O(n) linear, due to having to shift all the remaining items to
     *    the left after removing first elem.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    dequeue() {
        return this.items.shift();
    }

    /**
     * Retrieves the first item without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    front() {
        return this.items[0];
    }

    /**
     * Returns whether or not this queue is empty.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean}
     */
    isEmpty() {
        return this.items.length === 0;
    }

    /**
     * Retrieves the size of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {number} The length.
     */
    size() {
        return this.items.length;
    }
}


let test = new Queue

test.enqueue(1)
test.enqueue(4)
test.enqueue(6)
test.enqueue(2)
test.enqueue(3)


console.log(test.items)
console.log(test.isSumOfHalvesEqual())
console.log(test.items)

/* Rebuild the above class using a linked list instead of an array. */