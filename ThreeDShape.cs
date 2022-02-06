// Author: Dana Kleber
// File Name: ThreeDShape.cs
// Project Name: pass2
// Creation Date: Oct. 25, 2020
// Modified Date: Nov. 1, 2020
// Description: This program is built to make a 3d shape class

using System;

class ThreeDShape
{
  // store shape information
  protected string colour;
  protected double anchorPointX;
  protected double anchorPointY;

  // store shape calculations
  protected double surfaceArea;
  protected double volume;

  public ThreeDShape(string colour)
  {
    this.colour = colour;
  }

  //Pre: None 
  //Post: colour as a string
  //Desc: Retrieve colour
  public string GetColour()
  {
    return colour;
  }

  //Pre: None 
  //Post: x anchor point of shape as a double
  //Desc: Retrieve x anchor point of the shape
  public double GetAnchorPointX()
  {
    return anchorPointX;
  }

  //Pre: None 
  //Post: y anchor point of shape as a double
  //Desc: Retrieve y anchor point of the shape
  public double GetAnchorPointY()
  {
    return anchorPointY;
  }

  //Pre: None 
  //Post: surface area of shape as a double
  //Desc: Retrieve surface area of the shape
  public double GetSurfaceArea()
  {
    return surfaceArea;
  }

  //Pre: None 
  //Post: volume of shape as a double
  //Desc: Retrieve volume of the shape
  public double GetVolume()
  {
    return volume;
  }

  //Pre: colour of shape as a string
  //Post: None
  //Desc: modify the shapes length
  public void SetColour(string colour)
  {
    this.colour = colour;
  }

  //Pre: ap of shape as a double
  //Post: None
  //Desc: modify the shapes ap
  public void SetAnchorPointX(double anchorPointX)
  {
    this.anchorPointX = anchorPointX;
  }

  //Pre: ap of shape as a double
  //Post: None
  //Desc: modify the shapes ap
  public void SetAnchorPointY(double anchorPointY)
  {
    this.anchorPointY = anchorPointY;
  }

  // Pre: length1 as a double and length 2 as a double. 
  // Post: None
  // Description: calculate diagonal
  public double CalcDiagonal(double a, double b)
  {
    double c;

    c = Math.Sqrt(Math.Pow(a,2) + Math.Pow(b,2));

    return c;
  }

  // Pre: length1 as a double and length 2 as a double, length3 as a double and length 4 as a double, 
  // Post: None
  // Description: calculate length
  public double CalcLength(double x1, double x2, double y1, double y2)
  {
    double length;

    length = CalcDiagonal((Math.Abs(x2 - x1)),(Math.Abs(y2 - y1)));

    return length;
  }
 
  // Pre: none
  // Post: ap as a double
  // Description: assign anchor point 
  public virtual double AssignAnchorPointX()
  {
    return anchorPointX;
  }

  // Pre: none
  // Post: ap as a double
  // Description: assign anchor point 
  public virtual double AssignAnchorPointY()
  {
    return anchorPointY;
  }

  // Pre: none
  // Post: None
  // Description: display shapes
  public virtual void DisplayData()
  {
    Console.WriteLine("Shape Type: ");
  }

  // Pre: none
  // Post: None
  // Description: display extra shape data
  public virtual void DisplayExtraData()
  {

  }

  // Pre: none
  // Post: double array for x points
  // Description: copy x
  public virtual double [] PlaceShapeX()
  {
    double [] points = {1};
    return points;
  }

  // Pre: none
  // Post: double array for y points
  // Description: copy y
  public virtual double [] PlaceShapeY()
  {
    double [] points = {1};
    return points;
  }

  // Pre: x points as a double array and user translation for x as a double
  // Post: None
  // Description: translate shape by x
  public virtual void TranslateX(double [] xPoints, double userTransX)
  {
    for (int i = 0; i < xPoints.Length; i++)
    { 
      xPoints[i] = xPoints[i] + userTransX;
    }  
    anchorPointX = AssignAnchorPointX();
    anchorPointY = AssignAnchorPointY();
  }

  // Pre: y points as a double array and user translation for y as a double
  // Post: None
  // Description: translate shape by y
  public virtual void TranslateY(double [] yPoints, double userTransY)
  {
    for (int i = 0; i < yPoints.Length; i++)
    { 
      yPoints[i] = yPoints[i] + userTransY;
    }  
    anchorPointX = AssignAnchorPointX();
    anchorPointY = AssignAnchorPointY();
  }
 
  // Pre: x points as a double array and user points for y as a double, and scale factor as a double
  // Post: None
  // Description: scale shape
  public virtual void Scale(double [] xPoints, double [] yPoints, double scaleFactor)
  {
    for (int i = 0; i < xPoints.Length; i++)
    {
      xPoints[i] = xPoints[i] - anchorPointX;
      xPoints[i] = xPoints[i] * scaleFactor;
      xPoints[i] = xPoints[i] + anchorPointX;
    }
    for (int i = 0; i < yPoints.Length; i++)
    {
      yPoints[i] = yPoints[i] - anchorPointY;
      yPoints[i] = yPoints[i] * scaleFactor;
      yPoints[i] = yPoints[i] + anchorPointY;
    }
  }

  // Pre: user point for x as a double and user point for y and z as a double
  // Post: None
  // Description: find collision
  public virtual void CollDetection(double userPointX, double userPointY, double userPointZ)
  {

  }

  // Pre: none
  // Post: surface area as a double
  // Description: calc surface area
  public virtual double CalcSurfaceArea()
  {
    return surfaceArea;
  }
  
  // Pre: none
  // Post: volume as a double
  // Description: calc volume
  public virtual double CalcVolume()
  {
    return volume;
  }
  
  //Pre: x points as a double array
  // Post: x points as a double array
  // Description: assign extra points to rec
  public virtual double [] AssignExtraPointsShapeX(double [] xPoints)
  {
    return xPoints;
  }

  //Pre: y points as a double array
  // Post: y points as a double array
  // Description: assign extra points to rec
  public virtual double [] AssignExtraPointsShapeY(double [] yPoints)
  {
    return yPoints;
  }
  

  

}


  