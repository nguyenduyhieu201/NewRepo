using System;
using System.Collections.Generic;

class Program
{
    static List<int> mang_vet = new List<int>();
    static List<Tuple<int, int[,]>> mang_vet_tuple = new List<Tuple<int, int[,]>>();
    static List<int[,]> mang_vet_mang = new List<int[,]>();
    static Tuple<int, int[,]> DemSoVetDauLoang(int[,] matran)
    {
        int so_vet_dau_loang = 0;
        bool da_tham = false;

        for (int j = 0; j < 5; j++)
        {
            int so_vet_dau_loang_cot = 0;
            for (int i = 0; i < 5; i++)
            {
                if (matran[i, j] == 1 && !da_tham)
                {
                    so_vet_dau_loang_cot++;
                    da_tham = true;
                }
                else if (matran[i, j] == 0)
                {
                    da_tham = false;
                }
            }
            da_tham = false;
            so_vet_dau_loang += so_vet_dau_loang_cot;
        }
        if (so_vet_dau_loang == 5)
        {
            DisplayMatrix(matran);
            //Console.WriteLine(matran);
        }
        return new Tuple <int, int[,]>(so_vet_dau_loang, matran);
    }

    static void LietKeHoanViHang(int[,] matran, int vi_tri = 0)
    {
        if (vi_tri == matran.GetLength(0) - 1)
        {
            //Console.WriteLine(DemSoVetDauLoang(matran));
            var mang = DemSoVetDauLoang(matran);
            mang_vet.Add(mang.Item1);
            mang_vet_tuple.Add(mang);
            mang_vet_mang.Add(mang.Item2);
            Console.WriteLine(mang_vet_mang);
        }
        else
        {
            for (int i = vi_tri; i < matran.GetLength(0); i++)
            {
                SwapHang(matran, vi_tri, i);
                LietKeHoanViHang(matran, vi_tri + 1);
                SwapHang(matran, vi_tri, i);
            }
        }
    }

    static void SwapHang(int[,] matran, int hang1, int hang2)
    {
        for (int j = 0; j < matran.GetLength(1); j++)
        {
            int temp = matran[hang1, j];
            matran[hang1, j] = matran[hang2, j];
            matran[hang2, j] = temp;
        }
    }

    static void DisplayMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.WriteLine("hello world");
        int[,] ma_tran_5x5 = {
            {1, 1, 1, 0, 0},
            {1, 0, 1, 0, 0},
            {1, 0, 0, 1, 1},
            {0, 0, 0, 1, 1},
            {1, 1, 1, 0, 0}
        };

        LietKeHoanViHang(ma_tran_5x5);
        //Console.WriteLine(string.Join(", ", mang_vet));

        var minValuePosition = mang_vet.IndexOf(mang_vet.Min());
        //DisplayMatrix(mang_vet_tuple[30].Item2);
        var item23 = mang_vet_tuple[23].Item2;
        Console.WriteLine("hello world \n");
        Console.WriteLine(mang_vet_mang);
        DisplayMatrix(mang_vet_mang[23]);
    }
}
