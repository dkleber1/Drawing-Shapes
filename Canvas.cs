// Author: Dana Kleber
// File Name: Canvas.CS
// Project Name: pass2
// Creation Date: Oct. 25, 2020
// Modified Date: Nov. 1, 2020
// Description: This program is built to create a canvas to add, view, delete, and modify shapes 

using System;
using System.Collections.Generic;

class Canvas
{
  // Store shapes
  private List<Shape> allShapes = new List<Shape>();
  private List <ThreeDShape> allShapesThreeD = new List <ThreeDShape>();

  // Store extra shape info
  private const int MAX_SHAPES = 6;
  private int numShapes = 0;

  // Pre: None
  // Post: None
  // Description: create canvas
  public Canvas()
  {
    
  }

  // Pre: colour as a string, x points and y points as double arrays, and length and width as doubles
  // Post: None
  // Description: add a rectangle
  public void AddRec(string colour, double [] xPoints, double [] yPoints, double recLength, double recWidth)
  {
    if (numShapes < MAX_SHAPES)
    {
      allShapes.Add(new Rec(colour, xPoints, yPoints, recLength, recWidth));

      numShapes++;
    }
  }

  // Pre: colour as a string, x points and y points as double arrays, and radius as a double
  // Post: None
  // Description: add a circle
  public void AddCircle(string colour, double [] xPoints, double [] yPoints, double radius)
  {
    if (numShapes < MAX_SHAPES)
    {
      allShapes.Add(new Circle(colour, xPoints, yPoints, radius));

      numShapes++;
    }
  }

  // Pre: colour as a string, x points and y points as double arrays
  // Post: None
  // Description: add a triangle
  public void AddTri(string colour, double [] xPoints, double [] yPoints)
  {
    if (numShapes < MAX_SHAPES)
    {
      allShapes.Add(new Triangle(colour, xPoints, yPoints));

      numShapes++;
    }
  }
  
  // Pre: colour as a string, x points and y points as double arrays
  // Post: None
  // Description: add a line
  public void AddLine(string colour, double [] xPoints, double [] yPoints)
  {
    if (numShapes < MAX_SHAPES)
    {
      allShapes.Add(new Line(colour, xPoints, yPoints));

      numShapes++;
    }
  }

  // Pre: colour as a string, x points and y points as double arrays, and length and width as doubles, and a depth
  // Post: None
  // Description: add a rectanglular prisim
  public void AddRecPrisim(string colour, double [] xPoints, double [] yPoints, double recLength, double recWidth, double depth)
  {
    if (numShapes < MAX_SHAPES)
    {
      allShapesThreeD.Add(new RectangularPrisim(colour, xPoints, yPoints, recLength, recWidth, depth));

      numShapes++;
    }
  }


  // Pre: colour as a string, x points and y points as double arrays, and radius as a double, and a depth
  // Post: None
  // Description: add a sphere
  public void AddSphere(string colour, double [] xPoints, double [] yPoints, double radius, double depth)
  {
    if (numShapes < MAX_SHAPES)
    {
      allShapesThreeD.Add(new Sphere(colour, xPoints, yPoints, radius, depth));

      numShapes++;
    }
  }
 
  // Pre: colour as a string, x points and y points as double arrays, and a depth
  // Post: None
  // Description: add a 3d line
  public void Add3DLine(string colour, double [] xPoints, double [] yPoints, double [] depths)
  {
    if (numShapes < MAX_SHAPES)
    {
      allShapesThreeD.Add(new ThreeDLine(colour, xPoints, yPoints, depths));

      numShapes++;
    }
  }

  // Pre: integer index
  // Post: None
  // Description: delete shape
  public void DelShape(int index)
  {
    allShapes.RemoveAt(index);
  }

  // Pre: integer index
  // Post: None
  // Description: delete 3d shape
  public void DelShape3D(int index)
  {
    allShapesThreeD.RemoveAt(index);
  }
   
  // Pre: none
  // Post: None
  // Description: display shapes
  public void DisplayAllShapesData()
  {
    for (int i = 0; i < allShapes.Count; i++)
    {
      allShapes[i].DisplayData();
    }
    for (int i = 0; i < allShapesThreeD.Count; i++)
    {
      allShapesThreeD[i].DisplayData();
    }
  }
 
  // Pre: integer index
  // Post: None
  // Description: display extra data
  public void DisplayTheExtraData(int index)
  {
    allShapes[index].DisplayExtraData();
  }

  // Pre: integer index
  // Post: None
  // Description: display extra data for 3d shape
  public void DisplayTheExtraData3D(int index)
  {
    allShapesThreeD[index].DisplayExtraData();
  }
  
  // Pre: integer index, x points as a double array and user translation for x as a double
  // Post: None
  // Description: translate shape by x
  public void TranslateShapeX(int index, double [] xPoints, double userTransX)
  {
    allShapes[index].TranslateX(xPoints, userTransX);
  }

  // Pre: integer index, y points as a double array and user translation for y as a double
  // Post: None
  // Description: translate shape by y
  public void TranslateShapeY(int index, double [] yPoints, double userTransY)
  {
    allShapes[index].TranslateY(yPoints, userTransY);
  }

  // Pre: integer index, x points as a double array and user translation for x as a double
  // Post: None
  // Description: translate 3d shape by x
  public void TranslateShapeX3D(int index, double [] xPoints, double userTransX)
  {
    allShapesThreeD[index].TranslateX(xPoints, userTransX);
  }

  // Pre: integer index, y points as a double array and user translation for y as a double
  // Post: None
  // Description: translate 3d shape by y
  public void TranslateShapeY3D(int index, double [] yPoints, double userTransY)
  {
    allShapesThreeD[index].TranslateY(yPoints, userTransY);
  }

  // Pre: integer index, y points as a double array and user translation for y as a double, and scale factor as a double
  // Post: None
  // Description: scale shape
  public void ScaleShape(int index, double [] xPoints, double [] yPoints, double scaleFactor)
  {
    allShapes[index].Scale(xPoints, yPoints, scaleFactor);
  }

  // Pre: integer index, y points as a double array and user translation for y as a double, and scale factor as a double
  // Post: None
  // Description: scale 3d shape
  public void ScaleShape3D(int index, double [] xPoints, double [] yPoints, double scaleFactor)
  {
    allShapesThreeD[index].Scale(xPoints, yPoints, scaleFactor);
  }

  // Pre: integer index
  // Post: None
  // Description: assign anchor point 
  public void AssignAnchorPointForShapeX(int index)
  {
    allShapes[index].AssignAnchorPointX();
  }

  // Pre: integer index, length1 as a double and length 2 as a double
  // Post: None
  // Description: calculate diagonal
  public void CalcDiagonalShape(int index, double a, double b)
  {
    allShapes[index].CalcDiagonal(a,b);
  }

  // Pre: integer index, length1 as a double and length 2 as a double, length3 as a double and length 4 as a double, 
  // Post: None
  // Description: calculate length
  public void CalcLengthShape(int index, double x1, double x2, double y1, double y2)
  {
    allShapes[index].CalcLength(x1,x2,y1,y2);
  }

  // Pre: index as an integer
  // Post: None
  // Description: calc area
  public double CalcAreaShape(int index)
  {
   double area;
   area = allShapes[index].CalcArea();
   return area;
  }

  // Pre: index as an integer
  // Post: None
  // Description: calc perimeter
  public double CalcPerimeterShape(int index)
  {
    double perimeter;
    perimeter = allShapes[index].CalcPerimeter();
    return perimeter;
  }

  // Pre: index as an integer, user point for x as a double and user point for y as a double
  // Post: None
  // Description: find collision
  public void CollDetection(int index, double userPointX, double userPointY)
  {
    allShapes[index].CollDetection(userPointX, userPointY);
  }

  // Pre: index as an integer, user point for x as a double and user point for y as a double and userpoint for z as a double
  // Post: None
  // Description: find collision
  public void CollDetection3D(int index, double userPointX, double userPointY, double userPointZ)
  {
    allShapesThreeD[index].CollDetection(userPointX, userPointY, userPointZ);
  }

  // Pre: none
  // Post: None
  // Description: clear canvas
  public void ClearCanvas()
  {
    Console.Clear();
    allShapes.Clear();
    allShapesThreeD.Clear();
  }

  // Pre: index as an integer
  // Post: None
  // Description: get anchor
  public void GetAnchor(int index)
  {
   allShapes[index].GetAnchorPointX();
  }
 
  // Pre: index as an integer
  // Post: double array for x points
  // Description: copy x
  public double [] CopyX (int index)
  {
    double [] x =  allShapes[index].PlaceShapeX();
    return x;
  }

  // Pre: index as an integer
  // Post: double array for y points
  // Description: copy y
  public double [] CopyY (int index)
  {
    double [] y =  allShapes[index].PlaceShapeY();
    return y;
  }

  // Pre: index as an integer, x points as a double array
  // Post: x points as a double array
  // Description: assign extra points to rec
  public double [] AssignExtraPointsXShape(int index, double [] xPoints)
  {
    double [] values = allShapes[index].AssignExtraPointsShapeX(xPoints);
    return values;
  }

  // Pre: index as an integer, y points as a double array
  // Post: y points as a double array
  // Description: assign extra points to rec
  public double [] AssignExtraPointsYShape(int index, double [] yPoints)
  {
    double [] values = allShapes[index].AssignExtraPointsShapeY(yPoints);
    return values;
  }

  

















}