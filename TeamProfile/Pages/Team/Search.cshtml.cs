using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Licenses;
using NuGet.Versioning;
using TeamProfile.Data;
using TeamProfile.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TeamProfile.Pages.Team.check
{
    public class CheckModel : PageModel
    {
        private readonly TeamProfile.Data.TeamProfileContext _context;

        public CheckModel(TeamProfile.Data.TeamProfileContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string seaecrvalue { get; set; }
        public IList<teams> teams { get; set; } = default!;

        public IList<teams> newteams = new List<teams>();

        public async Task OnGetAsync()
        {
            if (_context.teams != null)
            {
                teams = await _context.teams.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostSearchb()
        {
            Searchmethod();
            OnGetAsync();
            return Page();
        }

        public teams mem1 { get; set; }

        //checking string similarity
        List<double> keys = new List<double>();
        IDictionary<double, string> numberNames = new Dictionary<double, string>();

        public async Task Searchmethod()
        {

            if (_context.teams != null)
            {
                teams = await _context.teams.ToListAsync();

                mem1 = teams[0];

                for (int i = 0; i < teams.Count; i++)
                {
                    double similarity = findSimilarity(teams[i].Name, seaecrvalue);
                    double simnum = Math.Round(similarity, 2);

                    if (keys.Contains(simnum))
                    {
                        double num = GetRandomNumbere(0.0001, 0.0005);
                        simnum += num;
                        keys.Add(simnum);
                        numberNames.Add(simnum, teams[i].Name);
                    }
                    else
                    {
                        keys.Add(simnum);
                        numberNames.Add(simnum, teams[i].Name);
                    }
                }
                keys.Sort();
                for (int i = keys.Count-1; i >=0; i--)
                {
                    //Debug.WriteLine(numberNames[keys[i]]);

                    foreach (var team in teams)
                    {
                        if (team.Name == numberNames[keys[i]])
                        {
                            newteams.Add(team);
                        }
                    }
                }

                teams = newteams;
                foreach(var t in teams)
                {
                    Debug.WriteLine(t.Name);
                }
            }
        }

        private double GetRandomNumbere(double v1, double v2)
        {
            Random random = new Random();
            return random.NextDouble() * (v2 - v1) + v1;
            throw new NotImplementedException();
        }

        public static int getEditDistance(string X, string Y)
        {
            int m = X.Length;
            int n = Y.Length;

            int[][] T = new int[m + 1][];
            for (int i = 0; i < m + 1; ++i)
            {
                T[i] = new int[n + 1];
            }

            for (int i = 1; i <= m; i++)
            {
                T[i][0] = i;
            }
            for (int j = 1; j <= n; j++)
            {
                T[0][j] = j;
            }

            int cost;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    cost = X[i - 1] == Y[j - 1] ? 0 : 1;
                    T[i][j] = Math.Min(Math.Min(T[i - 1][j] + 1, T[i][j - 1] + 1),
                            T[i - 1][j - 1] + cost);
                }
            }

            return T[m][n];
        }

        public static double findSimilarity(string x, string y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentException("Strings must not be null");
            }

            double maxLength = Math.Max(x.Length, y.Length);
            if (maxLength > 0)
            {
                // optionally ignore case if needed
                return (maxLength - getEditDistance(x, y)) / maxLength;
            }
            return 1.0;
        }

    }
}
