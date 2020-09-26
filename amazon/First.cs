using System;
using System.Collections.Generic;

class First{
    // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
	public Tuple<int, int> IDsOfmovies(int flightDuration, int numMovies, List<int> movieDuration)
	{
		int target = flightDuration - 30;
        Dictionary<int, int> mov = new Dictionary<int, int>();
        Tuple<int, int> sol = null;
        int max = 0;

        for(int i = 0; i < movieDuration.Count; i++) {
            int movie1 = movieDuration[i];
            int movie2 = target - movie1;
            if (mov.ContainsKey(movie2)) {
                int currentMax = Math.Max(movie1, movie2);
                if (currentMax > max) {
                    sol = new Tuple<int, int>(i, mov[movie2]);
                    max = currentMax;
                }
            }
            mov[movie1] = i;
        }

        return sol;
	}
	// METHOD SIGNATURE ENDS
}