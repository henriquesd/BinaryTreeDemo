namespace BinaryTreeDemo
{
    public static class LevelOrderTraversal
    {
        // The main function to perform the Level Order Traversal
        public static IList<IList<int>> RecursiveApproach(TreeNode root)
        {
            // Create a new list to store the result of the level order traversal
            IList<IList<int>> levels = new List<IList<int>>();

            // If the root is null, return an empty list
            if (root == null) return levels;

            // Start the recursive traversal from the root at level 0
            LevelOrder(root, 0, levels);

            // Return the list of levels
            return levels;
        }

        // Helper method that performs the traversal
        private static void LevelOrder(TreeNode node, int level, IList<IList<int>> levels)
        {
            // If the list of levels doesn't have a list for the current level, create it
            if (levels.Count == level)
            {
                levels.Add(new List<int>());
            }

            // Add the current node's value to the appropriate level
            levels[level].Add(node.val);

            // Recursively traverse the left subtree, incrementing the level by 1
            if (node.left != null)
            {
                LevelOrder(node.left, level + 1, levels);
            }

            // Recursively traverse the right subtree, also incrementing the level by 1
            if (node.right != null)
            {
                LevelOrder(node.right, level + 1, levels);
            }
        }

        public static IList<IList<int>> IterativeApproach(TreeNode root)
        {
            // List to store the result of the level order traversal
            var levels = new List<IList<int>>();

            // If the tree is empty (root is null), return the empty result list
            if (root == null)
            {
                return levels;
            }

            // Queue to manage Breadth-First Search (BFS)
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);  // Start by enqueuing the root node

            // Loop to process nodes at each level
            while (queue.Count > 0)  // While there are nodes to process
            {
                // Get the current level size (number of nodes at this level)
                int levelSize = queue.Count;

                // Create a list to store the node values for the current level
                var currentLevel = new List<int>();

                // Process all nodes in the current level
                for (int i = 0; i < levelSize; i++)
                {
                    // Dequeue the next node from the front of the queue
                    var currentNode = queue.Dequeue();
                    currentLevel.Add(currentNode.val);  // Add its value to the current level

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

                // Add the current level's node values to the result list
                levels.Add(currentLevel);
            }

            // Return the complete level order traversal as a list of lists
            return levels;
        }
    }
}