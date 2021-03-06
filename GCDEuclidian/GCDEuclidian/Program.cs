﻿using System;

namespace GCDEuclidian {
  public class GCD {
    static void Main() {
      int num1 = int.Parse(Console.ReadLine());
      int num2 = int.Parse(Console.ReadLine());
      while (num1 != 0 && num2 != 0) {
        if (num1 > num2) {
          num1 -= num2;
        }
        else {
          num2 -= num1;
        }
      }
      Console.WriteLine(Math.Max(num1, num2));

      Console.ReadKey();
    }
  }
}