// Author: Dana Kleber
// File Name: main.cs
// Project Name: Drawing Shapes
// Creation Date: Oct. 25, 2020
// Modified Date: Nov. 1, 2020
// Description: This program is built to allow a user to add, view, delete, and modify shapes 

using System;
using System.Collections.Generic;
using System.Linq;

class MainClass 
{
  // Store user choices
  static int choice;
  static int choice2;
  static int choice3;
  static int choice4;
  static int choice5;
  static int choice6;
  static int choice7;

  // store user modifications
  static int indexNum;
  static string confirmation;
  static bool confirmationReply;
  static int modifyChoice;
  static double userTransX;
  static double userTransY;
  static double userScaleFactor;
  static double userCollX;
  static double userCollY;
  static double userCollZ;

  static bool wasMenuChosen = false;
  public static void Main (string[] args) 
  {
    // Create and store a canvas
    Canvas newCanvas = new Canvas();

   // Store basic shape info
    bool mainMenu = true;
    string [] points = new string [1];
    string colour = "";

    // Store rectangle info 
    double [] xPointsRec = new double [1];
    double [] yPointsRec = new double [1];
    double recLength = 0;
    double recWidth = 0;
    double [] xPointsFullRec = new double [4];
    double [] yPointsFullRec = new double [4];

   // Store triangle info
    string [] pointsTri = new string [3];
    double [] xPointsTri = new double [3];
    double [] yPointsTri = new double [3];

    // Store circle info
    double [] xPointsCirc = new double [1];
    double [] yPointsCirc = new double [1];
    double radius = 0;

    // Store line info
    double [] xPointsLine = new double [2];
    double [] yPointsLine = new double [2];

    // Store 3d shape info
    double recDepth;
    double sphereDepth;
    double [] lineDepths = new double [2];
  
   // Display main menu
    MenuMsg();

    // Allow for user interaction
    while (mainMenu == true)
    {
      // Ask and store menu option
      choice = AskUserOperationChoice();
      switch (choice)
      {
        case 1:
        // Ask for 2D or 3D shape
        WhichShapeMsg();
        choice3 = AskUserShapeD();
        switch (choice3)
        {
        case 11:
        // Ask for and store which shape to add
        AddShapeMsg();
        choice2 = AskUserShapeChoice();
          switch (choice2)
          {
            case 5:
            // Ask for and store rec info
            colour = AskUserColour(colour);
            RecPoints();
            points = AskCoordinates(points, xPointsRec);
            xPointsRec = PlaceXCoordinates(points, xPointsRec);    
            yPointsRec = PlaceYCoordinates(points, yPointsRec);
            
            // Calculate length and width
            recLength = AskUserLength(recLength);
            recWidth = AskUserWidth(recWidth);

            // Add and display rectangle
            newCanvas.AddRec(colour, xPointsRec, yPointsRec, recLength, recWidth);
            newCanvas.DisplayAllShapesData();
            break;
            case 6: 
            // Ask for and store triangle info
            colour = AskUserColour(colour);
            TrianglePoints();
            pointsTri = AskCoordinates(pointsTri, xPointsTri);
            xPointsTri = PlaceXCoordinates(pointsTri, xPointsTri);
            yPointsTri = PlaceYCoordinates(pointsTri, yPointsTri);

            // Add and display triangle
            newCanvas.AddTri(colour,xPointsTri, yPointsTri);
            newCanvas.DisplayAllShapesData();
            break;
            case 7:
            // Ask for and store circle info
            colour = AskUserColour(colour);
            RecPoints();
            points = AskCoordinates(points, xPointsCirc);
            xPointsCirc = PlaceXCoordinates(points, xPointsCirc);    
            yPointsCirc = PlaceYCoordinates(points, yPointsCirc);
            radius = AskUserRadius(radius);

            // Add and display circle
            newCanvas.AddCircle(colour, xPointsCirc, yPointsCirc, radius);
            newCanvas.DisplayAllShapesData();
            break;

            case 8:
            // Ask for and store line info
            colour = AskUserColour(colour);
            LinePoints();
            points = AskCoordinates(points, xPointsLine);
            xPointsLine = PlaceXCoordinates(points, xPointsLine);    
            yPointsLine = PlaceYCoordinates(points, yPointsLine);

            // Add and display line 
            newCanvas.AddLine(colour, xPointsLine, yPointsLine);
            newCanvas.DisplayAllShapesData();
            break;
          }
      break;
      case 12:
       Add3DShapeMsg();
        choice4 = AskUser3DShapeChoice();
          switch (choice4)
          {
            case 15:
            // Ask for and store rectangular prisim
            colour = AskUserColour(colour);
            RecPoints();
            points = AskCoordinates(points, xPointsRec);
            xPointsRec = PlaceXCoordinates(points, xPointsRec);    
            yPointsRec = PlaceYCoordinates(points, yPointsRec);
            recDepth = AskDepth();

            // Calculate length and width
            recLength = AskUserLength(recLength);
            recWidth = AskUserWidth(recWidth);

            // Add and display rectangular prisim
            newCanvas.AddRecPrisim(colour, xPointsRec, yPointsRec, recLength, recWidth, recDepth);
            newCanvas.DisplayAllShapesData();
            break;
            case 16:
            // Ask for and store sphere info
            colour = AskUserColour(colour);
            RecPoints();
            points = AskCoordinates(points, xPointsCirc);
            xPointsCirc = PlaceXCoordinates(points, xPointsCirc);    
            yPointsCirc = PlaceYCoordinates(points, yPointsCirc);
            radius = AskUserRadius(radius);
            sphereDepth = AskDepth();

            // Add and display sphere
            newCanvas.AddSphere(colour, xPointsCirc, yPointsCirc, radius, sphereDepth);
            newCanvas.DisplayAllShapesData();
            break;

            case 17:
            // Ask for and store 3D line info
            colour = AskUserColour(colour);
            LinePoints();
            points = AskCoordinates(points, xPointsLine);
            xPointsLine = PlaceXCoordinates(points, xPointsLine);    
            yPointsLine = PlaceYCoordinates(points, yPointsLine);
            lineDepths[0] = AskDepth();
            lineDepths[1] = AskDepth();

            // Add and display line 
            newCanvas.Add3DLine(colour, xPointsLine, yPointsLine, lineDepths);
            newCanvas.DisplayAllShapesData();
            break;
          }
      break;
      } 
      break;
      case 2:
      // Ask to view 3D or 2D shape
      WhichShapeMsg();
      choice5 = AskUserShapeView();
      switch(choice5)
      {
        case 11:
        // Ask which shape to view and display
        indexNum = AskViewShapeNum(indexNum);newCanvas.DisplayTheExtraData(indexNum-1);break;
        case 12:
        // Ask which shape to view and display
        indexNum = AskViewShapeNum(indexNum);newCanvas.DisplayTheExtraData3D(indexNum -1);
        break;
      }
      break;
      case 3:
      // Ask whether 2D or 3D shape
      WhichShapeMsg();
      choice6 = AskUserShapeDelete();
      switch(choice6)
      {
        case 11:
        // Ask which shape to delete and confirmation
        indexNum = AskDelShapeNum(indexNum);confirmationReply = AskConfirmation(confirmation, confirmationReply);
        // If the user confirms, delete the shape
        if (confirmationReply == true)
        {
        newCanvas.DelShape(indexNum-1);
        Console.WriteLine("deleted!");
        }
        newCanvas.DisplayAllShapesData();
        break;
        case 12:
        // Ask which shape to delete and confirmation
        indexNum = AskDelShapeNum(indexNum);confirmationReply = AskConfirmation(confirmation, confirmationReply);
        // If the user confirms, delete the shape
        if (confirmationReply == true)
        {
        newCanvas.DelShape3D(indexNum-1);
        Console.WriteLine("deleted!");
        }
        newCanvas.DisplayAllShapesData();
        break;
        }
      break;
      case 4: 
      // Ask wether 2D shape or 3D shape
      WhichShapeMsg();
      choice7 = AskUserShapeModify();
      switch (choice7)
      {
        case 11:
        // Ask which modification
        modifyChoice = AskModify(modifyChoice);indexNum = AskModifyShapeNum(indexNum);switch (modifyChoice)
        {
        case 15:
        // Copy shape information
        xPointsFullRec = newCanvas.AssignExtraPointsXShape(indexNum-1, xPointsRec);
        yPointsFullRec = newCanvas.AssignExtraPointsYShape(indexNum-1, yPointsRec);
        double [] copyPointsX = newCanvas.CopyX(indexNum-1);
        double [] copyPointsY = newCanvas.CopyY(indexNum-1);
       
       // Ask user for desired translation 
        userTransX = AskUserTransX(userTransX);
        userTransY = AskUserTransY(userTransY);
       
       // Translate shape and display
        newCanvas.TranslateShapeX(indexNum-1, copyPointsX, userTransX);
        newCanvas.TranslateShapeY(indexNum-1, copyPointsY, userTransY);
        newCanvas.DisplayAllShapesData();
        break;
        case 16:
        // Copy shape info
        xPointsFullRec = newCanvas.AssignExtraPointsXShape(indexNum-1, xPointsRec);
        yPointsFullRec = newCanvas.AssignExtraPointsYShape(indexNum-1, yPointsRec);
        copyPointsX = newCanvas.CopyX(indexNum-1);
        copyPointsY = newCanvas.CopyY(indexNum-1);
       
        // Ask user for desired scale
        userScaleFactor = AskUserScale(userScaleFactor);
        
        // Scale shape and display
        newCanvas.ScaleShape(indexNum - 1, copyPointsX, copyPointsY, userScaleFactor);
        newCanvas.DisplayAllShapesData();
        break;
        case 17:
        // Copy shape info
        xPointsFullRec = newCanvas.AssignExtraPointsXShape(indexNum-1, xPointsRec);
        yPointsFullRec = newCanvas.AssignExtraPointsYShape(indexNum-1, yPointsRec);
        copyPointsX = newCanvas.CopyX(indexNum-1);
        copyPointsY = newCanvas.CopyY(indexNum-1);

        // Ask user for collision points
        userCollX = AskUserCollX(userCollX);
        userCollY = AskUserCollY(userCollY);

        // Perform collision and display
        newCanvas.CollDetection(indexNum - 1, userCollX, userCollY);
        newCanvas.DisplayAllShapesData();
        break; 
      }
      break;
      case 12:
      // Ask which shape to modify
      modifyChoice = AskModify(modifyChoice);
      indexNum = AskModifyShapeNum(indexNum);
      switch(modifyChoice)
      {
        case 15:
        // Copy shape information
        xPointsFullRec = newCanvas.AssignExtraPointsXShape(indexNum-1, xPointsRec);
        yPointsFullRec = newCanvas.AssignExtraPointsYShape(indexNum-1, yPointsRec);
        double [] copyPointsX = newCanvas.CopyX(indexNum-1);
        double [] copyPointsY = newCanvas.CopyY(indexNum-1);
      
        // Ask user for desired translation 
        userTransX = AskUserTransX(userTransX);
        userTransY = AskUserTransY(userTransY);
        
        // Translate shape and display
        newCanvas.TranslateShapeX3D(indexNum-1, copyPointsX, userTransX);
        newCanvas.TranslateShapeY3D(indexNum-1, copyPointsY, userTransY);
        newCanvas.DisplayAllShapesData();
        break;
        case 16: 
        // Copy shape info
        xPointsFullRec = newCanvas.AssignExtraPointsXShape(indexNum-1, xPointsRec);
        yPointsFullRec = newCanvas.AssignExtraPointsYShape(indexNum-1, yPointsRec);
        copyPointsX = newCanvas.CopyX(indexNum-1);
        copyPointsY = newCanvas.CopyY(indexNum-1);
      
        // Ask user for desired scale
        userScaleFactor = AskUserScale(userScaleFactor);

        // Scale shape and display
        newCanvas.ScaleShape3D(indexNum - 1, copyPointsX, copyPointsY, userScaleFactor);
        break;
        case 17:
        // Copy shape info
        xPointsFullRec = newCanvas.AssignExtraPointsXShape(indexNum-1, xPointsRec);
        yPointsFullRec = newCanvas.AssignExtraPointsYShape(indexNum-1, yPointsRec);
        copyPointsX = newCanvas.CopyX(indexNum-1);
        copyPointsY = newCanvas.CopyY(indexNum-1);

        // Ask user for collision points
        userCollX = AskUserCollX(userCollX);
        userCollY = AskUserCollY(userCollY);
        userCollZ = AskUserCollZ(userCollZ);

        // Perform collision and display
        newCanvas.CollDetection3D(indexNum - 1, userCollX, userCollY, userCollZ);
        break;
      }
      break;
        }
      break;
      case 5:
      newCanvas.ClearCanvas();
      break;
      }
    }
  }

  // Pre: None
  // Post: None
  // Description: Display invalid option
  public static void InvalidOptionMsg()
  {
    Console.WriteLine("Invalid option. Enter the value again.");
  }

  // Pre: None
  // Post: None
  // Description: Display 2D shape adding options
  public static void AddShapeMsg()
  {
    Console.WriteLine("Press 5 to add a rectangle");
    Console.WriteLine("Press 6 to add a triangle");
    Console.WriteLine("Press 7 to add a circle");
    Console.WriteLine("Press 8 to add a line");
  }

  // Pre: None
  // Post: None
  // Description: Display 3D shape adding options
  public static void Add3DShapeMsg()
  {
    Console.WriteLine("Press 15 to add a rectangular prisim");
    Console.WriteLine("Press 16 to add a sphere");
    Console.WriteLine("Press 17 to add a 3D line");
  }

  // Pre: None
  // Post: None
  // Description: Display main menu
  public static void MenuMsg()
  {
    Console.WriteLine("Welcome to Drawing Shapes.");
    Console.WriteLine("Press 1 to add a shape, you can add up to 6 shapes.");
    Console.WriteLine("Press 2 to view a specific shapes information.");
    Console.WriteLine("Press 3 to delete a shape.");
    Console.WriteLine("Press 4 to modify a shape.");
    Console.WriteLine("Press 5 to clear the canvas and exit the game.");
  }

  // Pre: None
  // Post: None
  // Description: Ask whether user wants 2D or 3D
  public static void WhichShapeMsg()
  {
    Console.WriteLine("Do you want to work with a 2D Shape or 3D Shape?");
    Console.WriteLine("Press 11 for a 2D shape, and press 12 for a 3D Shape");
  }

  // Pre: None
  // Post: return choice of what to do as an int
  // Description: Ask user for which menu choice they want to do
  public static int AskUserOperationChoice()
  {
    try
    {
      choice = Convert.ToInt32(Console.ReadLine());
      wasMenuChosen = true;
      while (choice != 1 && choice != 2 && choice != 3 && choice!= 4 && choice!= 5)
    {
     InvalidOptionMsg();
     choice = Convert.ToInt32(Console.ReadLine());
    }
    }
    catch (FormatException fe)
   {
    InvalidOptionMsg();
    Console.WriteLine("");
    }
    return choice;
  }

  // Pre: None
  // Post: return choice of which 2D shape as an int
  // Description: Ask user for which shape in 2D they want to add
  public static int AskUserShapeChoice()
  {
    try
    {
      choice2 = Convert.ToInt32(Console.ReadLine());
      while (choice2 != 5 && choice2 != 6 && choice2 != 7 && choice2 != 8)
    {
     InvalidOptionMsg();
     choice2 = Convert.ToInt32(Console.ReadLine());
    }
    }
    catch (FormatException fe)
   {
    InvalidOptionMsg();
   }
    return choice2;
  }

  // Pre: None
  // Post: return choice of which 3D shape as an int
  // Description: Ask user for which shape in 3D they want to add
  public static int AskUser3DShapeChoice()
  {
    try
    {
      choice4 = Convert.ToInt32(Console.ReadLine());
      while (choice4 != 15 && choice4 != 16 && choice4 != 17)
    {
     InvalidOptionMsg();
     choice4 = Convert.ToInt32(Console.ReadLine());
    }
    }
    catch (FormatException fe)
   {
    InvalidOptionMsg();
   }
    return choice4;
  }

  // Pre: None
  // Post: return choice of which shape (2D or 3D) as an int
  // Description: Ask user for which shape they want to delete
  public static int AskUserShapeD()
  {
    //int choice2 = 0; 
    try
    {
      choice3 = Convert.ToInt32(Console.ReadLine());
      while (choice3 != 12 && choice3 != 11)
    {
     InvalidOptionMsg();
     choice3 = Convert.ToInt32(Console.ReadLine());
    }
    }
    catch (FormatException fe)
   {
    InvalidOptionMsg();
    Console.WriteLine("");
   }
    return choice3;
  }


  // Pre: None
  // Post: return choice of which shape (2D or 3D) as an int
  // Description: Ask user for which shape they want to view
  public static int AskUserShapeView()
  {
    try
    {
      choice5 = Convert.ToInt32(Console.ReadLine());
      while (choice5 != 12 && choice5 != 11)
    {
     InvalidOptionMsg();
     choice5 = Convert.ToInt32(Console.ReadLine());
    }
    }
    catch (FormatException fe)
   {
    InvalidOptionMsg();
   }
    return choice5;
  }

  // Pre: None
  // Post: return choice of the shape number as an int
  // Description: Ask user for which shape in the list they want to delete
  public static int AskUserShapeDelete()
  {
    try
    {
      choice6 = Convert.ToInt32(Console.ReadLine());
      while (choice6 != 12 && choice6 != 11)
    {
     InvalidOptionMsg();
     choice6 = Convert.ToInt32(Console.ReadLine());
    }
    }
    catch (FormatException fe)
   {
    InvalidOptionMsg();
   }
    return choice6;
  }
  

  // Pre: points as an array of strings and x coordinates as an array of doubles
  // Post: return array of strings as the points
  // Description: Ask user for the coordinates
  public static string [] AskCoordinates(string [] points, double [] xPoints)
  {
    points = Console.ReadLine().Split(',');
    return points;
  }

  // Pre: None
  // Post: None
  // Description: Explain how to enter points
  public static void RecPoints()
  {
    Console.WriteLine("Enter coordinates in this format: x1,y1");
  }

  // Pre: None
  // Post: None
  // Description: Explain how to enter points
  public static void LinePoints()
  {
    Console.WriteLine("Enter coordinates in this format: x1,y1,x2,y2");
  }

  // Pre: None
  // Post: None
  // Description: Explain how to enter points
  public static void TrianglePoints()
  {
    Console.WriteLine("Enter coordinates in this format: x1,y1,x2,y2,x3,y3");
  }


  // Pre: None
  // Post: the depth of the shape as a double 
  // Description: Ask user for the depth of the shape
  public static double AskDepth()
  {
    double depth = 9;
    Console.WriteLine("Enter the depth: ");
    try
    {
     depth = Convert.ToDouble(Console.ReadLine());
    }
    catch (FormatException fe)
   {
    InvalidOptionMsg();
    Console.WriteLine("");
   }
    return depth;
  }

  // Pre: none
  // Post: the shape they chose as an int
  // Description: Ask user for which shape to work with
  public static int AskUserShapeModify()
  {
    try
    {
      choice7 = Convert.ToInt32(Console.ReadLine());
      while (choice7 != 12 && choice7 != 11)
    {
     InvalidOptionMsg();
     choice7 = Convert.ToInt32(Console.ReadLine());
    }
    }
    catch (FormatException fe)
   {
    InvalidOptionMsg();
    Console.WriteLine("");
   }
    return choice7;
  }

  // Pre: x coordinate as a double
  // Post: return x point as a double
  // Description: Ask user for the x coordinate of the collision point
  public static double AskUserCollX(double userCollX)
  {
    Console.WriteLine("Enter the x point you are checking for intersection with: ");
    try
    {
    userCollX = Convert.ToDouble(Console.ReadLine());
    }
    catch (FormatException fe)
   {
    InvalidOptionMsg();
    Console.WriteLine("");
   }
    return userCollX;
  }

  // Pre: y coordinate as a double
  // Post: return y point as a double
  // Description: Ask user for the y coordinate of the collision point
  public static double AskUserCollY(double userCollY)
  {
    Console.WriteLine("Enter the y point you are checking for intersection with: ");
    try
    {
    userCollY = Convert.ToDouble(Console.ReadLine());
    }
    catch (FormatException fe)
   {
    InvalidOptionMsg();
    Console.WriteLine("");
   }
    return userCollY;
  }

  // Pre: z coordinate as a double
  // Post: return z point as a double
  // Description: Ask user for the z coordinate of the collision point
  public static double AskUserCollZ(double userCollY)
  {
    Console.WriteLine("Enter the z point you are checking for intersection with: ");
    try
    {
    userCollZ = Convert.ToDouble(Console.ReadLine());
    }
    catch (FormatException fe)
   {
    InvalidOptionMsg();
    Console.WriteLine("");
   }
    return userCollZ;
  }

  // Pre: points as an array of strings and x coordinates as an array of doubles
  // Post: return array of double as the x points
  // Description: Place x coordinates in shape
  public static double [] PlaceXCoordinates(string [] points, double [] xPoints)
  {
    try
    {
      for (int i = 0; i < xPoints.Length; i++)
    {
      xPoints[i] = Convert.ToDouble(points[i * 2]);
    }
    }
    catch (FormatException fe)
    {
      InvalidOptionMsg();
    }
    catch (IndexOutOfRangeException ie)
    {
      Console.WriteLine(ie.Message);
    }
    return xPoints;
  }

  // Pre: points as an array of strings and y coordinates as an array of doubles
  // Post: return array of double as the y points
  // Description: Place y coordinates in shape
  public static double [] PlaceYCoordinates(string [] points, double [] yPoints)
  {
    for (int i = 0; i < yPoints.Length; i++)
    {
      yPoints[i] = Convert.ToDouble(points[(i*2)+1]);
    }
    return yPoints;
  }

  // Pre: colour as a string
  // Post: return user colour
  // Description: Ask for and store user's shape colour
  public static string AskUserColour(string colour)
  {
    Console.WriteLine("Enter the shape's colour: ");
    try
    {
      colour = Console.ReadLine();
    }
    catch (FormatException fe)
    {
      InvalidOptionMsg();
    }
    return colour;
  }

  // Pre: length as a double
  // Post: return user length 
  // Description: Ask for and store user's length
  public static double AskUserLength(double length)
  { 
    Console.WriteLine("Enter the rectangle's length: ");
    try
    {
      length = Convert.ToDouble(Console.ReadLine());
    }
    catch (FormatException fe)
    {
      InvalidOptionMsg();
    }
    return length;
  }

  // Pre: width as a double
  // Post: return user width
  // Description: Ask for and store user's width
  public static double AskUserWidth(double width)
  { 
    Console.WriteLine("Enter the rectangle's width: ");
    try
    {
      width = Convert.ToDouble(Console.ReadLine());
    }
    catch (FormatException fe)
    {
      InvalidOptionMsg();
    }
    return width;
  }

  // Pre: radius as a double
  // Post: return user radius
  // Description: Ask for and store user's radius
  public static double AskUserRadius(double radius)
  { 
    Console.WriteLine("Enter the circle's radius: ");
    try
    {
      radius = Convert.ToDouble(Console.ReadLine());
    }
    catch (FormatException fe)
    {
      InvalidOptionMsg();
    }
    return radius;
  }

  // Pre: shape number as an integer
  // Post: return user shape number to view
  // Description: Ask for and store shape number
  public static int AskViewShapeNum(int num)
  {
    try
    {
      Console.WriteLine("Enter the shape you want to view. Pick from shape #1-6 (it is in order)");
      num = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException fe)
    {
      InvalidOptionMsg();
    }
    return num;
  }

  // Pre: shape number as an integer
  // Post: return user shape number to modify
  // Description: Ask for and store shape number
  public static int AskModifyShapeNum(int num)
  {
    try
    {
      Console.WriteLine("Enter the shape you want to modify. Pick from shape #1-6 (it is in order)");
      num = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException fe)
    {
      InvalidOptionMsg();
    }
    return num;
  }

  // Pre: shape number as an integer
  // Post: return user shape number to delete
  // Description: Ask for and store shape number
  public static int AskDelShapeNum(int num)
  {
    try
    {
      Console.WriteLine("Enter the shape you want to delete. Pick from shape #1-6 (it is in order)");
      num = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException fe)
    {
      InvalidOptionMsg();
    }
    return num;
  }

  // Pre: confirmation as a string and the result as a bool
  // Post: the result as a bool
  // Description: Ask for and store the users confirmation to delete a shape
  public static bool AskConfirmation(string confirmation, bool answer)
  {
      Console.WriteLine("Are you sure you want to delete a shape? Type YES if you wish to proceed. If you don't want to delete a shape, type NO");
      confirmation = Console.ReadLine();
      
      if (confirmation == "yes")
      {
        answer = true;
      }
      else if (confirmation == "no")
      {
        answer = false;
      }
      while (confirmation != "yes" && confirmation != "no")
      {
        InvalidOptionMsg();
        confirmation = Console.ReadLine();

        if (confirmation == "yes")
      {
        answer = true;
      }
      else if (confirmation == "no")
      {
        answer = false;
      }
      }  
    return answer;
  }

  // Pre: choice as an integer
  // Post: return user choice
  // Description: Ask for and store user choice to modify a shape
  public static int AskModify(int choice)
  {
      Console.WriteLine("To translate a shape, type 15. To scale a shape, type 16. To test for intersection with a point, type 17");
      choice = Convert.ToInt32(Console.ReadLine());
      
      while (choice != 15 && choice != 16 && choice != 17)
      {
        InvalidOptionMsg();
        choice = Convert.ToInt32(Console.ReadLine());
      }

    return choice;
  }

  // Pre: translation for x as a double
  // Post: return user translation for x
  // Description: Ask for and store user translation for x
  public static double AskUserTransX(double translation)
  {
    try
    {
      Console.WriteLine("How many units do you want to translate the shape horizontally? (to move the shape left or right)");
      translation = Convert.ToDouble(Console.ReadLine());
    }
    catch (FormatException fe)
    {
      InvalidOptionMsg();
    }
    return translation;
  }

  // Pre: translation for y as a double
  // Post: return user translation for y
  // Description: Ask for and store user translation for y
  public static double AskUserTransY(double translation)
  {
    try
    {
      Console.WriteLine("How many units do you want to translate the shape vertically? (to move the shape up or down)");
      translation = Convert.ToDouble(Console.ReadLine());
    }
    catch (FormatException fe)
    {
      InvalidOptionMsg();
    }
    return translation;
  }

  // Pre: scale factor as a double
  // Post: return user factor
  // Description: Ask for and store user scale factor
  public static double AskUserScale(double scaleFactor)
  {
    try
    {
      scaleFactor = Convert.ToDouble(Console.ReadLine());
    }
    catch (FormatException fe)
   {
     InvalidOptionMsg();
     Console.WriteLine("");
   }
    return scaleFactor;
  }
  
  
  




}




