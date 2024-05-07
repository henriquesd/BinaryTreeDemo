using BinaryTreeDemo;

ExecutePreorderTraversalExamples(CreateDemoTree());

ExecuteInorderTraversalExamples(CreateDemoTree());

ExecutePostorderTraversalExamples(CreateDemoTree());

ExecuteLevelOrderTraversalExamples(CreateDemoTree());

ExecuteReverseLevelOrderTraversalExamples(CreateDemoTree());

void ExecutePreorderTraversalExamples(TreeNode treeDemo)
{
    Console.WriteLine("Preorder Traversal");
    var result = PreorderTraversal.RecursiveApproach(treeDemo);

    foreach (var item in result) Console.Write(item);
    Console.Write(" - Recursive approach");
    Console.WriteLine();

    result = PreorderTraversal.IterativeApproach(treeDemo);
    foreach (var item in result) Console.Write(item);
    Console.Write(" - Iterative approach");
    Console.WriteLine();

    result = PreorderTraversal.MorrisTraversalApproach(treeDemo);
    foreach (var item in result) Console.Write(item);
    Console.Write(" - Morris Traversal approach");
    Console.WriteLine(Environment.NewLine);
}

void ExecuteInorderTraversalExamples(TreeNode treeDemo)
{
    Console.WriteLine("Inorder Traversal");

    var result = InorderTraversal.RecursiveApproach(treeDemo);
    foreach (var item in result) Console.Write(item);
    Console.Write(" - Recursive approach");
    Console.WriteLine();

    result = InorderTraversal.IterativeApproach(treeDemo);
    foreach (var item in result) Console.Write(item);
    Console.Write(" - Iterative approach");
    Console.WriteLine();

    result = InorderTraversal.MorrisTraversalApproach(treeDemo);
    foreach (var item in result) Console.Write(item);
    Console.Write(" - Morris Traversal approach");
    Console.WriteLine(Environment.NewLine);
}

void ExecutePostorderTraversalExamples(TreeNode treeDemo)
{
    Console.WriteLine("Postorder Traversal");

    var result = PostorderTraversal.RecursiveApproach(treeDemo);
    foreach (var item in result) Console.Write(item);
    Console.Write(" - Recursive approach");
    Console.WriteLine();

    result = PostorderTraversal.IterativeApproach(treeDemo);
    foreach (var item in result) Console.Write(item);
    Console.Write(" - Iterative approach");
    Console.WriteLine();

    result = PostorderTraversal.MorrisTraversalApproach(treeDemo);
    foreach (var item in result) Console.Write(item);
    Console.Write(" - Morris Traversal approach");
    Console.WriteLine(Environment.NewLine);

}

void ExecuteLevelOrderTraversalExamples(TreeNode treeDemo)
{
    Console.WriteLine("Level Order Traversal");

    // Recursive Approach
    var result = LevelOrderTraversal.RecursiveApproach(treeDemo);

    Console.Write("[");

    for (int i = 0; i < result.Count; i++)
    {
        var level = result[i];

        Console.Write("[");

        for (int j = 0; j < level.Count; j++)
        {
            Console.Write(level[j]);
            if (j < level.Count - 1) // Add a comma if it's not the last element
            {
                Console.Write(", ");
            }
        }

        Console.Write("]"); // Close the inner bracket

        if (i < result.Count - 1) // Add a space between levels
        {
            Console.Write(" ");
        }
    }
    Console.Write("] - Recursive approach");
    Console.WriteLine();

    // Iterative Approach
    result = LevelOrderTraversal.IterativeApproach(treeDemo);

    Console.Write("[");

    for (int i = 0; i < result.Count; i++)
    {
        var level = result[i];

        Console.Write("[");

        for (int j = 0; j < level.Count; j++)
        {
            Console.Write(level[j]);
            if (j < level.Count - 1) // Add a comma if it's not the last element
            {
                Console.Write(", ");
            }
        }

        Console.Write("]"); // Close the inner bracket

        if (i < result.Count - 1) // Add a space between levels
        {
            Console.Write(" ");
        }
    }

    Console.Write("] - Iterative approach");
    Console.WriteLine(Environment.NewLine);
}

void ExecuteReverseLevelOrderTraversalExamples(TreeNode treeDemo)
{
    Console.WriteLine("Reverse Level Order Traversal");

    // Recursive Approach
    var result = ReverseLevelOrderTraversal.RecursiveApproach(treeDemo);

    Console.Write("[");

    for (int i = 0; i < result.Count; i++)
    {
        var level = result[i];

        Console.Write("[");

        for (int j = 0; j < level.Count; j++)
        {
            Console.Write(level[j]);
            if (j < level.Count - 1) // Add a comma if it's not the last element
            {
                Console.Write(", ");
            }
        }

        Console.Write("]"); // Close the inner bracket

        if (i < result.Count - 1) // Add a space between levels
        {
            Console.Write(" ");
        }
    }
    Console.Write("] - Recursive approach");
    Console.WriteLine();

    // Iterative Approach
    result = ReverseLevelOrderTraversal.IterativeApproach(treeDemo);

    Console.Write("[");

    for (int i = 0; i < result.Count; i++)
    {
        var level = result[i];

        Console.Write("[");

        for (int j = 0; j < level.Count; j++)
        {
            Console.Write(level[j]);
            if (j < level.Count - 1) // Add a comma if it's not the last element
            {
                Console.Write(", ");
            }
        }

        Console.Write("]"); // Close the inner bracket

        if (i < result.Count - 1) // Add a space between levels
        {
            Console.Write(" ");
        }
    }

    Console.Write("] - Iterative approach");
    Console.WriteLine(Environment.NewLine);
}

// Tree with nodes [1, 2, 3, 4, 5, 6, null]
//       1
//     /   \
//    2     3
//   / \   / 
//  4   5 6
static TreeNode CreateDemoTree()
{
    return new TreeNode(1)
    {
        left = new TreeNode(2)
        {
            left = new TreeNode(4),
            right = new TreeNode(5)
        },
        right = new TreeNode(3)
        {
            left = new TreeNode(6)
        }
    };
}