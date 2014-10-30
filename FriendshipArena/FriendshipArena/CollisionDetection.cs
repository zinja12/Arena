using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class CollisionDetection
    {
        public static bool LineIntersection(Vector2 a, Vector2 b, Vector2 c, Vector2 d) 
        {
            float denominator = ((b.X - a.X) * (d.Y - c.Y)) - ((b.Y - a.Y) * (d.X - c.X));
            float numerator1 = ((a.Y - c.Y) * (d.X - c.X)) - ((a.X - c.X) * (d.Y - c.Y));
            float numerator2 = ((a.Y - c.Y) * (b.X - a.X)) - ((a.X - c.X) * (b.Y - a.Y));

            //Detect coincident lines is not working correctly
            if (denominator == 0)
                return numerator1 == 0 && numerator2 == 0;

            float r = numerator1 / denominator;
            float s = numerator2 / denominator;

            return (r >= 0 && r <= 1) && (s >= 0 && s <= 1);
        }

        public static float DistanceLineSegmentToPoint(Vector2 A, Vector2 B, Vector2 p)
        {
            //get the normalized line segment vector
            Vector2 v = B - A;
            v.Normalize();

            //determine the point on the line segment nearest to the point p
            float distanceAlongLine = Vector2.Dot(p, v) - Vector2.Dot(A, v);
            Vector2 nearestPoint;
            if (distanceAlongLine < 0)
            {
                //closest point is A
                nearestPoint = A;
            }
            else if (distanceAlongLine > Vector2.Distance(A, B))
            {
                //closest point is B
                nearestPoint = B;
            }
            else
            {
                //closest point is between A and B... A + d  * ( ||B-A|| )
                nearestPoint = A + distanceAlongLine * v;
            }

            //Calculate the distance between the two points
            float actualDistance = Vector2.Distance(nearestPoint, p);
            return actualDistance;
        }
        public static bool LineIntersectPoint(Vector2 A, Vector2 B, Vector2 p, float dist)
        {
            float actualDistance = DistanceLineSegmentToPoint(A, B, p);
            if (actualDistance <= dist)
                return true;
            else
                return false;
        }

         public static bool SegmentIntersectRectangle(double a_rectangleMinX, double a_rectangleMinY, double a_rectangleMaxX, double a_rectangleMaxY, double a_p1x, double a_p1y, double a_p2x, double a_p2y)
        {
            // Find min and max X for the segment

            double minX = a_p1x;
            double maxX = a_p2x;

            if(a_p1x > a_p2x)
            {
                minX = a_p2x;
                maxX = a_p1x;
            }

            // Find the intersection of the segment's and rectangle's x-projections

            if(maxX > a_rectangleMaxX)
            {
                maxX = a_rectangleMaxX;
            }

            if(minX < a_rectangleMinX)
            {
                minX = a_rectangleMinX;
            }

            if(minX > maxX) // If their projections do not intersect return false
            {
                return false;
            }

            // Find corresponding min and max Y for min and max X we found before

            double minY = a_p1y;
            double maxY = a_p2y;
            
            double dx = a_p2x - a_p1x;

            if(Math.Abs(dx) > 0.0000001)
            {
                double a = (a_p2y - a_p1y) / dx;
                double b = a_p1y - a * a_p1x;
                minY = a * minX + b;
                maxY = a * maxX + b;
            }

            if(minY > maxY)
            {
                double tmp = maxY;
                maxY = minY;
                minY = tmp;
            }

            // Find the intersection of the segment's and rectangle's y-projections

            if(maxY > a_rectangleMaxY)
            {
                maxY = a_rectangleMaxY;
            }

            if(minY < a_rectangleMinY)
            {
                minY = a_rectangleMinY;
            }

            if(minY > maxY) // If Y-projections do not intersect return false
            {
                return false;
            }

            return true;
        }

         public static bool checkLines(Vector2 a, Vector2 b, Rectangle rect) 
         {
             Point topLeft = new Point(rect.X, rect.Y);
             Point topRight = new Point(rect.X + rect.Width, rect.Y);
             Point bottomLeft = new Point(rect.X, rect.Y + rect.Height);
             Point bottomRight = new Point(rect.X + rect.Width, rect.Y + rect.Height);

             float degrees = (float)Math.Cos((a.X - b.X) / Vector2.Distance(a, b));

             rect.X -= (int)a.X;
             rect.Y -= (int)a.Y;

             topLeft.X = (int)((double)topLeft.X * Math.Cos(-degrees) - topLeft.Y * Math.Sin(-degrees));
             topLeft.Y = (int)((double)topLeft.X * Math.Cos(-degrees) + topLeft.Y * Math.Sin(-degrees));

             topRight.X = (int)((double)topRight.X * Math.Cos(-degrees) - topRight.Y * Math.Sin(-degrees));
             topRight.Y = (int)((double)topRight.X * Math.Cos(-degrees) + topRight.Y * Math.Sin(-degrees));

             bottomLeft.X = (int)((double)bottomLeft.X * Math.Cos(-degrees) - bottomLeft.Y * Math.Sin(-degrees));
             bottomLeft.Y = (int)((double)bottomLeft.X * Math.Cos(-degrees) + bottomLeft.Y * Math.Sin(-degrees));

             bottomRight.X = (int)((double)bottomRight.X * Math.Cos(-degrees) - bottomRight.Y * Math.Sin(-degrees));
             bottomRight.Y = (int)((double)bottomRight.X * Math.Cos(-degrees) + bottomRight.Y * Math.Sin(-degrees));
             

             if (topLeft.X < 0 && topLeft.Y < 0 && topRight.X < 0 && topRight.Y < 0 && bottomLeft.X < 0 && bottomLeft.Y < 0 && bottomRight.X < 0 && bottomRight.Y < 0)
             {
                 return false;
             }
             
             if (topLeft.X > 0 && topLeft.Y > 0 && topRight.X > 0 && topRight.Y > 0 && bottomLeft.X > 0 && bottomLeft.Y > 0 && bottomRight.X > 0 && bottomRight.Y > 0)
             {
                 return false;
             }
             else 
             {
                 return true;
             }
         }

         public static bool lineRectangleIntersect(float x1, float y1, float x2, float y2,
                                float rx, float ry, float rw, float rh)
         {

             float topIntersection;
             float bottomIntersection;
             float topPoint;
             float bottomPoint;

             // Calculate m and c for the equation for the line (y = mx+c)
             float m = (y2 - y1) / (x2 - x1);
             float c = y1 - (m * x1);

             // If the line is going up from right to left then the top intersect point is on the left
             if (m > 0)
             {
                 topIntersection = (m * rx + c);
                 bottomIntersection = (m * (rx + rw) + c);
             }
             // Otherwise it's on the right
             else
             {
                 topIntersection = (m * (rx + rw) + c);
                 bottomIntersection = (m * rx + c);
             }

             // Work out the top and bottom extents for the triangle
             if (y1 < y2)
             {
                 topPoint = y1;
                 bottomPoint = y2;
             }
             else
             {
                 topPoint = y2;
                 bottomPoint = y1;
             }

             float topOverlap;
             float botOverlap;

             // Calculate the overlap between those two bounds
             topOverlap = topIntersection > topPoint ? topIntersection : topPoint;
             botOverlap = bottomIntersection < bottomPoint ? bottomIntersection : bottomPoint;

             return (topOverlap < botOverlap) && (!((botOverlap < ry) || (topOverlap > ry + rh)));

         }
    }
}
