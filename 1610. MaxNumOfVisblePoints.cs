using System;
using System.Collections.Generic;

public class MaxNumOfVisiblePoints {
    const int D360 = 360;
    int origin;
    int maxVisible;

    public int VisiblePoints(IList<IList<int>> points, int angle, IList<int> location) {
        origin = 0;
        maxVisible = 0;
        List<double> angles = new List<double>();
        getAngles(angles, points, location);
        int pointer2 = 0;
        int anglesCount = angles.Count;
        for(var pointer1 = 0; pointer1 < anglesCount; pointer1++) {
            while (pointer2 < anglesCount && angles[pointer2] - angles[pointer1] <= angle)
                pointer2++;
            maxVisible = Math.Max(maxVisible, pointer2 - pointer1);
        }
        return maxVisible + origin;
    }

    private void getAngles(List<double> angles, IList<IList<int>> points, IList<int> location) {
        foreach(var point in points) {
            int xDist = point[0] - location[0];
            int yDist = point[1] - location[1];
            if (yDist == 0 && xDist == 0) {
                origin++;
            } else {
                double angleRadian = Math.Atan2(yDist, xDist);
                double angleDegree = angleRadian * 180 / Math.PI;
                if (angleDegree < 0) {
                    angleDegree = D360 + angleDegree;
                }
                angles.Add(angleDegree);
            } 
        }
        angles.Sort();

        // I want to have same values with a 360 degrees more, this will help 
        // when evaluating ranges in the 360 edge, because I won't have to convert
        // bigger angles than 360 to the first cuadrant.
        int count = angles.Count;
        for(var i = 0; i < count; i++) 
            angles.Add(angles[i] + D360);
    }
}

/*
  Time Complexity: O(N * log N)  The Sort is the most expesive operation.
  Space Complexity: O(N)

  Approach:
  1- Find every single angle from every point to the origin location. 
     (Asin won't work because you can't tell a difference between angles in 1st and 2nd cuadrant)
     (Use Atan2, explanation https://www.euclideanspace.com/maths/geometry/trig/inverse/index.htm)

  2- With all angles, you want to sort them and add duplicate the list by adding 360 degrees,
     in order to be able to handle 360 edges and not worrying about converting to first cuadrant.
     Doing this we can use two pointers to get the intervals.

  3- Use sliding window to get the maximum points that fit in the given angle.

  4- Points on the origin are special cases, they get added at the end.
*/

