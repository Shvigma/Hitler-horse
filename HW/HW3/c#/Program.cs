using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Text.RegularExpressions;
using System;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Text;
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
                        else{z+=coefs[i];}
                        break;
                    case 1:                    
                        if (coefs[i-1]!=0){
                            if (coefs[i] <0 ){    
                                if(i!=coefs.Length && coefs[i+1]<0){z+= Math.Abs(coefs[i]) + "x"+" - ";}
                                else{z+=Math.Abs(coefs[i]) +"x";}
                                }
                            else{
                                if(i!=coefs.Length && coefs[i+1]<0){z+=" + " + coefs[i] + "x"+" - ";}
                                else{z+=" + " + coefs[i] +"x";}
                                }
                        }
                        else{
                            if (coefs[i] <0 ){    
                                if(i!=coefs.Length && coefs[i+1]<0){z+=" - "+ Math.Abs(coefs[i]) + "x"+" - ";}
                                else{z+=" - "+ Math.Abs(coefs[i]) +"x";}
                                }
                            else{
                                if(i!=coefs.Length && coefs[i+1]<0){z+=" + " + coefs[i] + "x"+" - ";}
                                else{z+=" + " + coefs[i] +"x";}
                                }
                        }
                        break;
                    default:
                        if (coefs[i-1]!=0){      
                            if(coefs[i]<0){           
                                if(i!=coefs.Length-1 && coefs[i+1]<0){z+=Math.Abs(coefs[i]) +"x^"+ i + " - ";}
                                else{z+= Math.Abs(coefs[i]) +"x^"+ i;}
                            }
                            else
                            {
                                if(i!=coefs.Length-1 && coefs[i+1]<0){z+=" + " + coefs[i] +"x^"+ i + " - ";}
                                else{z+= " + " + coefs[i] +"x^"+ i;}
                            }
                        }
                        else
                        {
                            if (coefs[i] < 0)
                            {
                                if(i!=coefs.Length-1 && coefs[i+1]<0){z+=" - "+ Math.Abs(coefs[i]) +"x^"+ i + " - ";}
                                else{z+=" - "+ Math.Abs(coefs[i]) +"x^"+ i;}
                            }


                            else
                            {
                                if(i!=coefs.Length-1 && coefs[i+1]<0){z+=" + " + coefs[i] +"x^"+ i + " - ";}
                                else{z+= " + " + coefs[i] +"x^"+ i;}
                            }
                        }
                        break;
                }
            }
        }
        return z;
    }
    public static Polynomia operator+(Polynomia obj1, Polynomia obj2){
        int k =  obj1.coefs.Length > obj2.coefs.Length ?  obj1.coefs.Length : obj2.coefs.Length;
        double[] coefs= new double[3];
        Array.Resize(ref coefs, k);
        for(int i =0; i<k; i++){
            if (obj1.coefs.Length>i){
                if (obj2.coefs.Length>i){
                    coefs[i]= obj2.coefs[i]+obj1.coefs[i];


                }
                else{
                    coefs[i]=obj1.coefs[i];
                }
            }
            else if(obj2.coefs.Length>i){
                coefs[i]=obj2.coefs[i];
            }
        }


        return new Polynomia(coefs);
    }
    public static Polynomia operator * (Polynomia obj, double k)
    {   
        int g = obj.coefs.Length;
        double[] coefs= new double[3];
        Array.Resize(ref coefs, g);
        for(int i = 0 ; i<g; i++)
        {
            coefs[i]=obj.coefs[i]*k;
        }
        return new Polynomia(coefs);
    }
} 
class Programm
{
    static void Main(string[] args)
    {   
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        double[] coeffs = new double[] {1.0, 0.0, 2.0 };
        Polynomia p = new Polynomia(coeffs);
        Console.WriteLine("При дефолтных значениях [1.0, 0.0, 2.0]");
        Console.WriteLine(p);

        double[] coffs = new double[] {};
        Console.WriteLine("Введите сколько будет коэффицентов");
        int q= int.Parse(Console.ReadLine());
        if (q >0){
        for (int i=0; i!=q; i++)
        {
            Console.WriteLine("Введите элемент №" + (i+1));
            Array.Resize(ref coffs, coffs.Length + 1);
            coffs[coffs.Length - 1] = Convert.ToDouble(Console.ReadLine());


        }
        Polynomia z = new Polynomia(coffs);
        Console.WriteLine("При значениях введеных вами:");
        Console.WriteLine(z);
        
        Polynomia l = p + z;
        Console.WriteLine("Если сложить 2 полученных многочлена, то получится");
        Console.WriteLine(l);
        Console.WriteLine("Введите элементы какого многочлена вы хотите умножить: 1 - Дефолтный многочлен, 2 - Многочлен заданый вами");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите коэффицент для умножения");
        if (n == 1)
        {
            Polynomia v = p * Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("После умножения на ваш коэффицент получился такой многочлен");
        Console.WriteLine(v);
        }
        else if (n == 2)
        {
            Polynomia v = z * Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("После умножения на ваш коэффицент получился такой многочлен");
            Console.WriteLine(v);
        }
        else
        {
            Console.WriteLine("Вы ввели не правильное n");
        }
        
        }
        else 
        {
            Console.WriteLine("Вы ввели " + q +" при таком колличестве коефицентов программа выводит пустоту, пожалуйста вводите числа > 0");
        }

        
        Console.WriteLine("Введите коэффицент для умножения");
        Polynomia f = p * Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("После умножения на ваш коэффицент получился такой многочлен");
        Console.WriteLine(f);

    }
}



