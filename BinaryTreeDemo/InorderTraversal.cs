namespace BinaryTreeDemo
{
    public static class InorderTraversal
    {
        // Recursive Approach
        public static IList<int> RecursiveApproach(TreeNode root)
        {
            // Initialize a list to store the inorder traversal result
            var result = new List<int>();

            // Call the helper function to perform the inorder traversal recursively
            Inorder(root, result);

            // Return the list containing the inorder traversal result
            return result;
        }

        // Helper method that performs the traversal
        private static void Inorder(TreeNode root, List<int> output)
        {
            // Base case: If the current node is not null
            if (root != null)
            {
                // Traverse the left subtree of the current node recursively
                Inorder(root.left, output);

                // Add the value of the current node to the output list
                output.Add(root.val);

                // Traverse the right subtree of the current node recursively
                Inorder(root.right, output);
            }
        }

        // Iterative approach using a Stack
        public static IList<int> IterativeApproach(TreeNode root)
        {
            // Initialize a list to store the inorder traversal result
            List<int> result = new List<int>();

            // Initialize a stack to store nodes that need to be processed
            Stack<TreeNode> stack = new Stack<TreeNode>();

            // Start with the current node set to the root of the binary tree
            TreeNode curr = root;

            // Continue the loop until either the current node becomes null
            // and the stack becomes empty, indicating that all nodes have been processed
            while (curr != null || stack.Count > 0)
            {
                // Traverse the left subtree of the current node
                while (curr != null)
                {
                    // Push each node onto the stack
                    stack.Push(curr);

                    // Move to the left child node
                    curr = curr.left;
                }

                // Once the left subtree traversal is complete, pop a node from the stack
                // This node will be the current node whose value needs to be added to the result list
                curr = stack.Pop();

                // Add the value of the current node to the result list
                result.Add(curr.val);

                // Move to the right child node to continue the inorder traversal
                curr = curr.right;
            }

            // Once the traversal is complete, return the list containing the inorder traversal result
            return result;
        }

        // Morris Traversal
        public static IList<int> MorrisTraversalApproach(TreeNode root)
        {
            // Initialize a list to store the inorder traversal result
            List<int> result = new List<int>();

            // Initialize the current node pointer to the root of the binary tree
            TreeNode curr = root;

            // Initialize a pointer to keep track of the predecessor node
            TreeNode pre;

            // Continue the loop until the current node becomes null
            while (curr != null)
            {
                // If the current node has no left child
                if (curr.left == null)
                {
                    // Add the value of the current node to the result list
                    result.Add(curr.val);

                    // Move to the next right node
                    curr = curr.right;
                }
                else
                {
                    // If the current node has a left subtree
                    // Find the rightmost node in the left subtree (predecessor node)

                    pre = curr.left;

                    while (pre.right != null)
                    {
                        // Traverse to the rightmost node
                        pre = pre.right;
                    }

                    // Make the current node the right child of the predecessor node
                    pre.right = curr;

                    // Store the current node before moving to its left child
                    TreeNode temp = curr;

                    // Move the current node to the top of the new subtree
                    curr = curr.left;

                    // Set the left child of the original current node to null
                    // This prevents infinite loops when traversing the subtree
                    temp.left = null;
                }
            }

            // Return the list containing the inorder traversal result
            return result;
        }
    }
}