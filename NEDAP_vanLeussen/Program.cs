using System;
using System.Collections.Generic;

// ..........
// Made By Jeffrey van Leussen, 27-06-2022

// Question : Determine if a 9 x 9 Sudoku board is valid. 

// Rules:
//      Each row must contain the digits 1-9 without repetition.
//      Each column must contain the digits 1-9 without repetition.
//      Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.

// ..........

// Description : What is asked?           Boolean (&&)
//      1.  Boolean         Precheck conditions : Matrix of 9 x 9?: ___ inRange
//      2.  Boolean         Each row and each column must contain the digits 1-9 without repetition: ___ checkRows ___ checkColumns
//      3.  Boolean         Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition: ___checkBoxes

// ..........

namespace SudokuSolver
{
    class Program
    {
        //Main Boolean to apply all rules stated in the description (rule # 1 to 3)
        static bool isValidSudoku(char[,] sudoku)
        {
            return inRange(sudoku) && checkRows(sudoku) && checkColumns(sudoku) && checkBoxes(sudoku);
        }

        //Rule 1. Boolean | Check if the Sudoku is the size of 9 x 9
        static bool inRange(char[,] sudoku)
        {
            if (sudoku.GetLength(0) != 9 || sudoku.GetLength(1) != 9) return false;
            return true;
        }

        //Rule 2. Boolean | Each row and each column must contain the digits 1-9 without repetition.
        static bool checkRows(char[,] sudoku)
        {
            for (int r = 0; r < 9; r++)
            {
                // Every traverse of each row, nine in total, will create a new empty HashSet at the start
                HashSet<char> cRows = new HashSet<char>();
                for (int i = 0; i < 9; i++)
                {
                    // Check if the char exists
                    if (cRows.Contains(sudoku[r, i])) return false;
                    // If it does not exist, and is not empty, we add it to the HashSet
                    if (sudoku[r, i] != '.') cRows.Add(sudoku[r, i]);
                }
            }
            return true;
        }

        static bool checkColumns(char[,] sudoku)
        {
            for (int r = 0; r < 9; r++)
            {
                // Every traverse of each column, nine in total, will create a new empty HashSet at the start
                HashSet<char> cColumns = new HashSet<char>();
                for (int i = 0; i < 9; i++)
                {
                    // Check if the char exists
                    if (cColumns.Contains(sudoku[i, r])) return false;
                    // If it does not exist, and is not empty, we add it to the HashSet
                    if (sudoku[i, r] != '.') cColumns.Add(sudoku[i, r]);
                }
            }
            return true;
        }

        //Rule 3. Boolean | Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
        public static bool checkBoxes(char[,] sudoku)
        {
            //First we create a Row- and Colum-offset of 0 to 2 (multiplied by 3), which will generate an offset of 0, 3, 6 by 0, 3, 6 (BOXES)
            for (int startRow = 0; startRow < 3; startRow++) 
            {
                for (int startColumn = 0; startColumn < 3; startColumn++)
                {
                    // Every traverse of each Box, nine in total, will create a new empty HashSet at the start
                    HashSet<char> st = new HashSet<char>();
                    for (int row = 0; row < 3; row++)
                    {
                        for (int col = 0; col < 3; col++)
                        {
                            char curr = sudoku[row + startRow * 3, col + startColumn * 3];
                            // Check if the char exists
                            if (st.Contains(curr)) return false;
                            // If it does not exist, and is not empty, we add it to the HashSet
                            if (curr != '.') st.Add(curr);
                        }
                    }
                }
            }
            return true;
        }

        public static void Main(string[] args)
        {
            char[,] sudoku1 = new char[,] { { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                                            { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                                            { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                                            { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                                            { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                                            { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                                            { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                                            { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                                            { '.', '.', '.', '.', '8', '.', '.', '7', '9' }};

            char[,] sudoku2 = new char[,] { { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
                                            { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                                            { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                                            { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                                            { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                                            { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                                            { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                                            { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                                            { '.', '.', '.', '.', '8', '.', '.', '7', '9' }};

            Console.WriteLine("Sudoku Solution 1: \n");
            PrintSudoku(sudoku1);
            Console.WriteLine("Sudoku Solution 2: \n");
            PrintSudoku(sudoku2);
            Console.WriteLine((isValidSudoku(sudoku1) ? "The Sudoku Solution 1 is valid" : "The Sudoku Solution 1 is not valid"));
            Console.WriteLine((isValidSudoku(sudoku2) ? "The Sudoku Solution 2 is valid" : "The Sudoku Solution 2 is not valid"));
            Console.ReadKey();
        }

        public static void PrintSudoku(char[,] sudoku)
        {
            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                Console.Write("|{0}", sudoku[i, j]);
                Console.WriteLine("|");
            }
            Console.WriteLine("");
        }
    }
}