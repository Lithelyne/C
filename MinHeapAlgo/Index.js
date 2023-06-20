/**
 * Class to represent a MinHeap which is a Priority Queue optimized for fast
 * retrieval of the minimum value. It is implemented using an array but it is
 * best visualized as a tree structure where each 'node' has left and right
 * children except the 'node' may only have a left child.
 * - parent is located at: Math.floor(i / 2);
 * - left child is located at: i * 2
 * - right child is located at: i * 2 + 1
 */
class MinHeap {
    constructor() {
        /**
         * 0th index not used, so null is a placeholder. Not using 0th index makes
         * calculating the left and right children's index cleaner.
         * This also effectively makes our array start at index 1.
         */
        this.heap = [null];
    }

    extract() {
        // check if the heap is empty
        if (this.heap.length <= 1) {
            return null;
        }
        // save the first node to a temporary variable
        const min = this.heap[1];
        // replace the root with the last node in the heap
        let idx1 = this.heap.pop();
        this.heap[1] = idx1;
        // swap down the heap to maintain the heap property
        let idx = 1;
        while (true) {
            // calculate the indices of the left and right child nodes
            const leftIdx = this.idxOfLeftChild(idx);
            const rightIdx = this.idxOfRightChild(idx);
            // check if both child indices are out of bounds
            if (leftIdx >= this.heap.length && rightIdx >= this.heap.length) {
                break;
            }
            // determine the index of the child with the smalles value
            let minChildIdx = leftIdx;
            if (
                rightIdx < this.heap.length &&
                this.heap[rightIdx] < this.heap[leftIdx]
            ) {
                minChildIdx = rightIdx;
            }
            // compare the current node with the smallest child
            if (this.heap[idx] < this.heap[minChildIdx]) {
                break;
            }
            // swap the current node with the smallest child
            this.swap(idx, minChildIdx);
            idx = minChildIdx;
        }
        // return the minimum value that was initially saved
        return min;
    }

    /**
     * Retrieves the top (minimum number) in the heap without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {?number} Null if empty.
     */
    top() {
        if (this.isEmpty()) {
            return null;
        }
        return this.heap[0];
    }

    /**
     * Inserts a new number into the heap and maintains the heaps order.
     * 1. Push new num to back then.
     * 2. Iteratively swap the new num with it's parent while it is smaller than
     *    it's parent.
     * - Time: O(log n) logarithmic due to shiftUp / iterative swapping.
     * - Space: O(1) constant.
     * @param {number} num The num to add.
     */
    insert(num) {
        this.heap.push(num); // Step 1: Push new num to the back

        let currentIndex = this.heap.length - 1; // Index of the newly inserted element

        while (currentIndex > 0) {
            const parentIndex = Math.floor((currentIndex - 1) / 2); // Calculate the parent index

            if (this.heap[currentIndex] >= this.heap[parentIndex]) {
                break; // The new num is in the correct position, so we stop swapping
            }

            // Swap the new num with its parent
            [this.heap[currentIndex], this.heap[parentIndex]] = [this.heap[parentIndex], this.heap[currentIndex]];

            currentIndex = parentIndex; // Update the current index to the parent index
        }
    }


    /**
     * Logs the tree horizontally with the root on the left and the index in
     * parenthesis using reverse inorder traversal.
     */
    printHorizontalTree(parentIdx = 1, spaceCnt = 0, spaceIncr = 10) {
        if (parentIdx > this.heap.length - 1) {
            return;
        }

        spaceCnt += spaceIncr;
        this.printHorizontalTree(parentIdx * 2 + 1, spaceCnt);

        console.log(
            " ".repeat(spaceCnt < spaceIncr ? 0 : spaceCnt - spaceIncr) +
            `${this.heap[parentIdx]} (${parentIdx})`
        );

        this.printHorizontalTree(parentIdx * 2, spaceCnt);
    }
}