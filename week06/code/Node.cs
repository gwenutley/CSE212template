using System.ComponentModel.Design.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        //check for duplicates
        if (value == Data)
        {
            // Do nothing, we do not want duplicates in our tree
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        //check the value at the current node
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            // Search to the left
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else
        {
            // Search to the right
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        if (Left is null && Right is null)
        {
            return 1; 
        }
        //check if the left is null then add one to the height of the right tree
        else if (Left is null)
        {
            return 1 + Right!.GetHeight(); 
        }
        //check if the right is null then add one to the height of the left tree
        else if (Right is null)
        {
            return 1 + Left!.GetHeight(); 
        }
        else
        // check the height of the left and right and add 1
        {   
            return 1 + Math.Max(Left.GetHeight(), Right.GetHeight()); 
        }
    }
}