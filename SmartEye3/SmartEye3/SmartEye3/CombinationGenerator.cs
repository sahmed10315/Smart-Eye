using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIEnginePhase
{ 
public class CombinationGenerator {

  private int[] a;
  private int n;
  private int r;
  private BigInteger numLeft;
  private BigInteger total;
 
  public CombinationGenerator (int n, int r) {
    if (r > n) {
      throw new Exception ();
    }
    if (n < 1) {
      throw new Exception ();
    }
    this.n = n;
    this.r = r;
    a = new int[r];
    BigInteger nFact = getFactorial (n);
    BigInteger rFact = getFactorial (r);
    BigInteger nminusrFact = getFactorial (n - r);
    total = nFact /(rFact *  (nminusrFact));
    reset ();
  }
 
  public void reset () {
    for (int i = 0; i < a.Length; i++) {
      a[i] = i;
    }
    numLeft = new BigInteger (total);
  }
 
  public BigInteger getNumLeft () {
    return numLeft;
  }
 
  public bool hasMore () {
    return (numLeft== new BigInteger(0)) == false;
  }
  

  public BigInteger getTotal () {
    return total;
  } 
  private static BigInteger getFactorial (int n) {
    BigInteger fact = 1;
    for (int i = n; i > 1; i--) {
      fact = fact * (new BigInteger ((i)));
    }
    return fact;
  }
 

  public int[] getNext () {

    if (numLeft.Equals((total))) {
      numLeft = numLeft - new BigInteger(1);
      return a;
    }

    int i = r - 1;
    while (a[i] == n - r + i) {
      i--;
    }
    a[i] = a[i] + 1;
    for (int j = i + 1; j < r; j++) {
      a[j] = a[i] + j - i;
    }

    numLeft = numLeft - new BigInteger(1);
    return a;

  }

    }
}
