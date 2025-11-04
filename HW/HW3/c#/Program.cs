using System;
using System.Linq.Expressions;
using System.Security.Permissions;
class Polynomia{
    private double[] coefs;
    private int degree;
    private double[] Coefs{
        get => (double[]) this.coefs.Clone();
    }
    public int Degree{
        get=> this.degree;
    }
    public Polynomia(){
        this.coefs = new double[]{0};
        this.degree= 1;
    }
    public Polynomia(double[] new_coefs){
        this.degree=new_coefs.Length -1;
        this.coefs= (double[])new_coefs.Clone();
    }
    public override string ToString()
    {
        string z= "";
        int l=this.Coefs.Length;
        for(int i=0; i<this.Coefs.Length; i++ ){
            if (coefs[i] != 0)
            {
                switch (i)
                {
                    case 0:

                        if(i!=coefs.Length && coefs[i+1]<0){z+= coefs[i] + " - ";}
                        else{z+=coefs[i] + " + ";}
                        break;
                    case 1:                        
                        if(i!=coefs.Length && coefs[i+1]<0){z+= coefs[i] + "x"+" - ";}
                        else{z+=coefs[i] +"x" + " + ";}
                        break;
                    default:                   
                        if(i!=coefs.Length-1){if(i!=coefs.Length-1 && coefs[i+1]<0){z+= coefs[i] +"x^"+ i + " - ";}
                        else{z+= coefs[i] +"x^"+ i + " + ";}}
                        else{z+= coefs[i] +"x^"+ i;}
                        break;
                }
            }
        }
        return z;
    }
} 
class Programm
{
    static void Main(string[] args)
    {   
        double[] coeffs;
        coeffs =  [1.0, 0.0, 2.0 ];
        Polynomia p = new Polynomia(coeffs);
        Console.WriteLine("При дефолтных значениях [1.0, 0.0, 2.0]");
        Console.WriteLine(p);

        coeffs = [];
        Console.WriteLine("Введите сколько будет коэффицентов");
        int q= int.Parse(Console.ReadLine());

        for (int i=0; i!=q; i++)
        {
            Console.WriteLine("Введите элемент №" + i);
            Array.Resize(ref coeffs, coeffs.Length + 1);
            coeffs[coeffs.Length - 1] = Convert.ToDouble(Console.ReadLine());
        }
        Polynomia z = new Polynomia(coeffs);

        Console.WriteLine("При значениях введеных вами:");
        Console.WriteLine(z);
    }
}