using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Maze_DFS_BFS.Models
{
    /// <summary>
    /// Klasa generujaca labirynt wykorzustajac algorytm Prima
    /// </summary>
    public class MazeGenerator
    {
        private readonly Random _rnd;
        private readonly bool[,] _cells; // true oznacza ze ma byc sciezka
        private int rows, columns;

        public MazeGenerator(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            _rnd = new Random();
            _cells = new bool[rows, columns];
        }

        public bool[,] GenerateMaze()
        {
            var posRnd = new Point(1, 1);

            _cells[posRnd.X, posRnd.Y] = true; // Dodaj pierwsza wartosc do sciezki

            var candidateCells = new HashSet<Point>();
            candidateCells.UnionWith(FindFrontiers(posRnd, false)); // Pobierz kandydatow dla sciany

            while (candidateCells.Count > 0)
            {
                // 1. Wez randomowego kandydata
                var thisCell = candidateCells.ElementAt(_rnd.Next(0, candidateCells.Count));

                // 2. Pobierz kandydatow dla komorki
                var pathCandidates = FindFrontiers(thisCell, true);

                // 3. Jezeli istnieja nieotwarte kandydaty na droge
                if (pathCandidates.Count > 0)
                {
                    // 4. Otworz droge
                    LinkCell(pathCandidates[_rnd.Next(0, pathCandidates.Count)], thisCell);
                }

                // 5. Dodaj kandydatow na sciany do procesowania
                candidateCells.UnionWith(FindFrontiers(thisCell, false));

                // 6. Usun przeprocesowana komorke
                candidateCells.Remove(thisCell);
            }

            return _cells;
        }

        private void LinkCell(Point cellA, Point cellB)
        {
            var x = (cellA.X + cellB.X) / 2;
            var y = (cellA.Y + cellB.Y) / 2;
            _cells[cellB.X, cellB.Y] = true;
            _cells[x, y] = true;
        }

        private bool IsValidPosition(Point cell) => cell.X >= 0 && cell.X < rows &&
                                                    cell.Y >= 0 && cell.Y < columns;

        // Szukamy gdzie mozemy pojsc z danej komorki
        private IList<Point> FindFrontiers(Point position, bool onlyPath)
        {
            var candidatePathCells = new List<Point>();
            var candidateWallCells = new List<Point>();

            var northCandidate = new Point(position.X, position.Y - 2);
            var eastCandidate = new Point(position.X + 2, position.Y );
            var southCandidate = new Point(position.X, position.Y + 2 );
            var westCandidate = new Point(position.X - 2, position.Y );

            if (IsValidPosition(northCandidate))
            {
                if (_cells[northCandidate.X, northCandidate.Y]) { candidatePathCells.Add(northCandidate); }
                else { candidateWallCells.Add(northCandidate); }
            }
            if (IsValidPosition(eastCandidate))
            {
                if (_cells[eastCandidate.X, eastCandidate.Y]) { candidatePathCells.Add(eastCandidate); }
                else { candidateWallCells.Add(eastCandidate); }
            }
            if (IsValidPosition(southCandidate))
            {
                if (_cells[southCandidate.X, southCandidate.Y]) { candidatePathCells.Add(southCandidate); }
                else { candidateWallCells.Add(southCandidate); }
            }
            if (IsValidPosition(westCandidate))
            {
                if (_cells[westCandidate.X, westCandidate.Y]) { candidatePathCells.Add(westCandidate); }
                else { candidateWallCells.Add(westCandidate); }
            }

            return onlyPath ? candidatePathCells : candidateWallCells;
        }

    }
}
