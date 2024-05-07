namespace BinaryTreeDemo
{
    public static class PreorderTraversal
    {
        // Recursive Approach
        // In the Recursive Approach, we visit each node starting from the root node,
        // then recursively visit the left subtree,
        // and finally recursively visit the right subtree.
        public static IList<int> RecursiveApproach(TreeNode root)
        {
            List<int> result = new List<int>();

            // Call the helper function to perform the preorder traversal recursively
            Preorder(root, result);

            return result;
        }

        // Helper method that performs the traversal
        private static void Preorder(TreeNode node, List<int> result)
        {
            if (node == null) return;

            // Visit the current node (root) and add its value to the result list
            result.Add(node.val);

            // Recursively traverse the left subtree
            Preorder(node.left, result);

            // Recursively traverse the right subtree
            Preorder(node.right, result);
        }

        // Iterative Approach using a Stack:
        // In the Iterative approach, a Stack is used to simulate the recursion process.
        // We start from the root and then at each iteration, pop the current node out of the stack and visit this node.
        // Then if this node has a right child we push its right child into the stack, and if this node has a left child
        // we push its left child into the stack (we push the right child first so that we can visit the left child first
        // since the nature of the stack is LIFO - Last In First Out), after that we can continue the next iteration until the stack is empty.
        public static IList<int> IterativeApproach(TreeNode root)
        {
            // Initialize a stack to store nodes that need to be processed
            var stack = new Stack<TreeNode>();

            // Initialize a list to store the preorder traversal result
            var output = new List<int>();

            if (root == null)
            {
                return output;
            }

            stack.Push(root);

            while (stack.Count > 0)
            {
                // Get the current element in the stack
                TreeNode node = stack.Pop();

                // Add the value of the popped node to the output list
                output.Add(node.val);

                // If the popped node has a right child, push it onto the stack
                if (node.right != null)
                {
                    stack.Push(node.right);
                }

                // If the popped node has a left child, push it onto the stack
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
            }

            // Return the output list containing the preorder traversal of the tree
            return output;
        }

        // Morris Traversal Approach:
        // The idea is to go down from the node to its predecessor, and each predecessor will be visited twice.
        // For this go one step left if possible and then always right till the end.
        // When we visit a leaf (node's predecessor) first time, it has a zero right child, so we update output
        // and establish the pseudo link predecessor.right = root to mark the fact the predecessor is visited.
        // When we visit the same predecessor the second time, it already points to the current node, thus we
        // remove the pseudo link and move right to the next node.
        public static IList<int> MorrisTraversalApproach(TreeNode root)
        {
            var output = new List<int>();
            TreeNode node = root;

            // Traverse the tree until we reach the end
            while (node != null)
            {
                // If the current node has no left child
                if (node.left == null)
                {
                    // Add the value of the current node to the output list
                    output.Add(node.val);

                    // Move to the right child of the current node
                    node = node.right;
                }
                else
                {
                    // If the current node has a left child

                    // Find the predecessor of the current node
                    TreeNode predecessor = node.left;

                    while (predecessor.right != null && predecessor.right != node)
                    {
                        predecessor = predecessor.right;
                    }

                    // If the predecessor's right child is null, link it to the current node and move to the left child
                    if (predecessor.right == null)
                    {
                        // Add the value of the current node to the output list
                        output.Add(node.val);

                        // Link the predecessor's right child to the current node
                        predecessor.right = node;

                        // Move to the left child
                        node = node.left;
                    }
                    else
                    {
                        // If the predecessor's right child is not null, unlink it and move to the right child

                        // Unlink the predecessor's right child
                        predecessor.right = null;

                        // Move to the right child
                        node = node.right;
                    }
                }
            }

            // Return the preorder traversal output
            return output;
        }
    }
}