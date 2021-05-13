using System;

public class BinaryTree
{
	public Node root;
	public int size;
	public int number;

	public void put(int ID)
	{
		//Adds to the binary tree a number value.
		if (root == null)
		{ 
			root = new Node(ID);
			size++;
		}

		else 
		{
			_put(ID, root);
		}
	}

	public void _put(int ID, Node node)
	{
		//Recursivly Adds to the binary tree a number value if regular put does not work.
		if (node != null) 
		{
			if (node.ID == ID)
			{
				Console.WriteLine(node.ID);
			}

			else if (node.ID > ID)
			{
				if (node.r_child == null)
				{
					node.r_child = new Node(ID);

				}
				else
				{
					_put(ID, node.r_child);
				}
			}

			else if (node.ID < ID)
			{
				if (node.l_child == null)
				{
					node.l_child = new Node(ID);

				}
				else
				{
					_put(ID, node.l_child);
				}
			}
		}
	}

	public void put(Node node)
	{
		//Adds a new node that contains employee data.
		if (root == null)
		{
			root = node;
			size++;
		}

		else
		{
			_put(node, root);
		}
	}

	public void _put(Node node1, Node node)
	{
		//Branches employee data to other nodes if previous node is occupied.
		if (node != null)
		{
			if (node.ID == node1.ID)
			{
				/*Console.WriteLine(node.ID);*/
			}

			else if (node.ID > node1.ID)
			{
				if (node.r_child == null)
				{
					node.r_child = node1;

				}
				else
				{
					_put(node1, node.r_child);
				}
			}

			else if (node.ID < node1.ID)
			{
				if (node.l_child == null)
				{
					node.l_child = node1;
				}
				else
				{
					_put(node1, node.l_child);
				}
			}
		}
	}


	public Node _searchTree(int ID, Node node) 
	{
		//Allows the user to search the binary tree.
		if (node.ID == ID)
		{
			return node;
		}

		if (node.ID < ID)
		{
			if (node.l_child != null) 
			{
				return _searchTree(ID, node.l_child);
			}
		}


		if (node.ID > ID)
		{
			if (node.r_child != null)
			{
				return _searchTree(ID, node.r_child);
			}
		}
		return node;
	}

	public Node PrintTree(Node node) 
	{
		//This prints the data.
		if (node != null)
		{
			PrintTree(node.l_child);
			Console.Write(node.ID + " ");
			PrintTree(node.r_child);
		}
		return null;
	}

}


