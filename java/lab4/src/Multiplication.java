public class Multiplication<T extends Number,V extends Number> implements Operations<T,V>{
    T num1;
    T num2;

    public Multiplication(T num1,T num2){
        this.num1=num1;
        this.num2=num2;
    }

    public double calculate() {
        return num1.doubleValue()*num2.doubleValue();
    }
}
