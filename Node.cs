using System;

public class Node
{
	
	public int ID;
	public int Data;
	public Node r_child;
	public Node l_child;
	public string[] employee;


	public Node(int ID,string[] employee)
	{
		this.ID = ID;
		this.employee = employee;
	}
	public Node(int ID)
	{
		this.ID = ID;
	}
}
