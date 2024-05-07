namespace BinaryTreeDemo
{
    public static class ReverseLevelOrderTraversal
    {
        // The main function to perform the Reverse Level Order Traversal
        public static IList<IList<int>> RecursiveApproach(TreeNode root)
        {
            // List to store the levels of the tree
            IList<IList<int>> levels = new List<IList<int>>();

            // Call the recursive helper function to populate the levels
            ReverseLevelOrder(root, 0, levels);

            // Create a new list to store the reversed levels
            IList<IList<int>> reversedLevels = new List<IList<int>>();

            // Reverse the order of the levels to achieve bottom-up traversal
            for (int i = levels.Count - 1; i >= 0; i--)
            {
                reversedLevels.Add(levels[i]);
            }

            // Return the reversed levels as the result
            return reversedLevels;
        }

        // Helper method that performs the traversal
        private static void ReverseLevelOrder(TreeNode node, int level, IList<IList<int>> levels)
        {
            // If the node is null, return (base case)
            if (node == null) return;

            // If there is no list for the current level, create one
            if (levels.Count <= level)
            {
                levels.Add(new List<int>());
            }

            // Add the current node's value to the list for this level
            levels[level].Add(node.val);

            // Recursively traverse the left subtree, incrementing the level by 1
            ReverseLevelOrder(node.left, level + 1, levels);

            // Recursively traverse the right subtree, incrementing the level by 1
            ReverseLevelOrder(node.right, level + 1, levels);
        }

        public static IList<IList<int>> IterativeApproach(TreeNode root)
        {
            // List to store the levels of the tree
            IList<IList<int>> levels = new List<IList<int>>();

            if (root == null) return levels; // If the tree is empty, return empty list

            // Queue to perform BFS
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root); // Start with the root node

            // Traverse the tree level by level
            while (queue.Count > 0)
            {
                // Get the size of the current level
                int levelSize = queue.Count;
                List<int> currentLevel = new List<int>();

                // Process all nodes in the current level
                for (int i = 0; i < levelSize; i++)
                {
                    // Dequeue the first node
                    TreeNode currentNode = queue.Dequeue();

                    // Add its value to the current level
                    currentLevel.Add(currentNode.val);

                    // Enqueue the left child if it exists
                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }

                    // Enqueue the right child if it exists
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }

                // Add the current level to the levels list
                levels.Add(currentLevel);
            }

            // Reverse the levels to achieve bottom-up order
            IList<IList<int>> reversedLevels = new List<IList<int>>();
            for (int i = levels.Count - 1; i >= 0; i--)
            {
                reversedLevels.Add(levels[i]);
            }

            // Return the reversed levels as the result
            return reversedLevels;
        }
    }
}