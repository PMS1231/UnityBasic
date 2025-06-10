using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Star : MonoBehaviour
{
    void Start()
    {
        Phase1();
        Phase2();
        Phase3();
        Phase4();
        Phase5();
    }
    void Phase1()
    {
        string star;
        star = string.Empty;

        for (int i = 0; i <= 4; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                star += "¡Ú";
            }

            star += "\n";
        }

        Debug.Log(star);
    }

    void Phase2()
    {
        string star;
        star = string.Empty;

        for (int i = 5; i >= 1; i--)
        {
            for (int j = 0; j < 5 - i; j++)
            {
                star += "¡¡  ";
            }

            for (int k = 0; k < i; k++)
            {
                star += "¡Ú";
            }

            star += "\n";
        }

        Debug.Log(star);
    }

    void Phase3()
    {
        string star;
        star = string.Empty;

        for (int i = 0; i <= 8; i++)
        {
            if (i <=4)
            {
                for (int j = 0; j <= i; j++)
                {
                    star += "¡Ú";
                }
            }
            else
            {
                for (int k = 8; k >= i; k--)
                {
                    star += "¡Ú";
                }
            }
            star += "\n";
        }

        Debug.Log(star);
    }

    void Phase4()
    {
        string star;
        star = string.Empty;

        for (int i = 0; i <= 8; i++)
        {
            if (i <= 4)
            {
                for (int k = 0; k < 4 - i; k++)
                {
                    star += "¡¡  ";
                }

                for (int j = 0; j <= i; j++)
                {
                    star += "¡Ú";
                }
            }
            else
            {
                for (int k = 0; k < i - 4; k++)
                {
                    star += "¡¡  ";
                }

                for (int j = 8; j >= i; j--)
                {
                    star += "¡Ú";
                }
            }

            star += "\n";
        }

        Debug.Log(star);
    }

    void Phase5()
    {
        string star;
        star = string.Empty;

        for (int i = 0; i <= 8; i++)
        {
            if (i <= 4)
            {
                for (int k = 0; k < 4 - i; k++)
                {
                    star += "¡¡  ";
                }

                for (int j = 0; j < i * 2 + 1; j++)
                {
                    star += "¡Ú";
                }
            }
            else
            {
                for (int k = 0; k < i - 4; k++)
                {
                    star += "¡¡  ";
                }

                for (int j = 0; j < (8 - i) * 2 + 1; j++)
                {
                    star += "¡Ú";
                }
            }

            star += "\n";
        }

        Debug.Log(star);
    }

}

