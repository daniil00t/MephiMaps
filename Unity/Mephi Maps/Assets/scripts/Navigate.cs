using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Navigate : Structions
{
    // Start is called before the first frame update
    public const int SIZE = 4;
    public float[,] matrix = new float[SIZE, SIZE]; // матрица связей
    public float[] a = new float[SIZE]; // посещенные вершины
    public float[] d = new float[SIZE]; // минимальное расстояние
    public float save;//временное хранение различных величин
    public int begin_index = 0;//задаем индекс начальной вершины, от которой будем искать путь
    public float min;
    public int minindex;


    void alg_Dejksra(float[,] Matrix)
    {

        for (int i = 0; i < SIZE; i++)
        {
            d[i] = 10000;
            a[i] = 1;//отмечает все вершины как необработанные.
        }
        d[begin_index] = 0;
        // Шаг алгоритма
        do
        {
            minindex = 10000;//индекс вершины с минимальным весом
            min = Single.MaxValue;// мин вес
            for (int i = 0; i < SIZE; i++)
            { // Если вершину ещё не обошли и вес меньше min
                if ((a[i] == 1) && (d[i] < min))
                { // Переприсваиваем значения
                    min = d[i];
                    minindex = i;
                }
            }
            // Добавляем найденный минимальный вес
            // к текущему весу вершины
            // и сравниваем с текущим минимальным весом вершины
            if (minindex != 10000)
            {
                for (int i = 0; i < SIZE; i++)
                {
                    if (Matrix[minindex, i] > 0)
                    {
                        save = min + Matrix[minindex, i];
                        if (save < d[i])
                        {
                            d[i] = save;
                        }
                    }
                }
                a[minindex] = 0;
            }
        } while (minindex < 10000);

    }

    void v_p(float[,] Matrix)
    {
        int[] ver = new int[SIZE]; // массив посещенных вершин
        int end = 5; // индекс конечной вершины = SIZE - 1
        ver[0] = end + 1; // начальный элемент - конечная вершина
        int k = 1; // индекс предыдущей вершины
        float weight = d[end]; // вес конечной вершины

        while (end != begin_index) // пока не дошли до начальной вершины
        {
            for (int i = 0; i < SIZE; i++) // просматриваем все вершины
                if (Matrix[end, i] != 0)   // если связь есть
                {
                    float temp = weight - Matrix[end, i]; // определяем вес пути из предыдущей вершины
                    if (temp == d[i]) // если вес совпал с рассчитанным
                    {                 // значит из этой вершины и был переход
                        weight = temp; // сохраняем новый вес
                        end = i;       // сохраняем предыдущую вершину
                        ver[k] = i + 1; // и записываем ее в массив
                        k++;
                    }
                }
        }
        // Вывод кратчайших расстояний до вершин
        print("\nkratchayshee rasstoyanie do vershin \n");
        for (int i = 0; i < SIZE; i++)
            print(d[i]);
        // Вывод пути (начальная вершина оказалась в конце массива из k элементов)
        print("\nVyvod kratchayshego pyti\n");
        for (int i = k - 1; i >= 0; i--)
            print(ver[i]);
    }


    void Start()
    {
        print("Start navigate module");
        float INF = Single.MaxValue;
        matrix = new float[SIZE, SIZE]{ 
                    { 0f, 13f, INF, 3f }, 
                    { 13f, 0, 2, 14 }, 
                    { INF, 2, 0, 1 },
                    { 3, 14, 1, 0 } };
        alg_Dejksra(matrix);
        v_p(matrix);    

    }

    
}
