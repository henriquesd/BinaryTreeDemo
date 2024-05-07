namespace BinaryTreeDemo
{
    public static class PostorderTraversal
    {
        // Recursive Approach
        public static IList<int> RecursiveApproach(TreeNode root)
        {
            List<int> result = new List<int>();

            Postorder(root, result);

            return result;
        }

        // Helper method that performs the traversal
        private static void Postorder(TreeNode root, List<int> result)
        {
            if (root == null) return;

            // Traverse the left subtree
            Postorder(root.left, result);

            // Traverse the right subtree
            Postorder(root.right, result);

            // Visit the current node
            result.Add(root.val);
        }

        // Iterative approach using a Stack
        public static IList<int> IterativeApproach(TreeNode root)
        {
            // Initialize a list to store the result of the postorder traversal
            List<int> result = new List<int>();

            // Initialize a stack to perform iterative traversal
            Stack<TreeNode> stack = new Stack<TreeNode>();

            // If the root is null, return the empty result list
            if (root == null) return result;

            // Push the root node onto the stack to start traversal
            stack.Push(root);

            // Continue traversal while the stack is not empty
            while (stack.Count > 0)
            {
                // Pop the top node from the stack
                TreeNode node = stack.Pop();

                // Insert the value of the current node at the beginning of the result list
                // This is done to achieve the reverse order of postorder traversal
                result.Insert(0, node.val); // Insert at the beginning for postorder traversal

                // Push the right child onto the stack first (if exists)
                // This ensures that the right subtree is processed before the left subtree
                if (node.left != null)
                {
                    stack.Push(node.left);
                }

                // Push the left child onto the stack (if exists)
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
            }

            return result;
        }

        // Morris Traversal
        public static IList<int> MorrisTraversalApproach(TreeNode root)
        {
            // Create a list to store the postorder traversal result
            var output = new List<int>();

            // Initialize the current node as the root of the tree
            TreeNode node = root;

            // Traverse the tree until the current node is not null
            while (node != null)
            {
                if (node.right == null)
                {
                    // If the current node has no right child, process the current node

                    // Add the value of the current node to the output list
                    output.Add(node.val);

                    // Move to the left child of the current node
                    node = node.left;
                }
                else
                {
                    // If the current node has a right child

                    // Find the inorder successor of the current node
                    TreeNode successor = node.right;

                    while (successor.left != null && successor.left != node)
                    {
                        // Traverse to the leftmost node of the right subtree
                        successor = successor.left;
                    }

                    if (successor.left == null)
                    {
                        // If the successor's left child is null, link it to the current node and move to the right child
                        // This indicates that we haven't visited the right subtree yet
                        successor.left = node;

                        // Add the value of the current node to the output list
                        output.Add(node.val);

                        // Move to the right child
                        node = node.right;
                    }
                    else
                    {
                        // If the successor's left child is not null, unlink it and process the current node
                        // This indicates that we have already visited the right subtree
                        successor.left = null;

                        // Move to the left child
                        node = node.left;
                    }
                }
            }

            // Reverse the output to get the postorder traversal
            output.Reverse();

            // Return the postorder traversal result
            return output;
        }
    }
}