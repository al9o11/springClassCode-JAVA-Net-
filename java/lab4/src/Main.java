import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter two numbers:");
        double num1 = scanner.nextDouble();
        double num2 = scanner.nextDouble();
        System.out.println("Enter The operation:");
        String op = scanner.next();

        switch (op){
            case "+":
                System.out.println(new Addition<>(num1,num2).calculate());
                break;
            case "-":
                System.out.println(new Subtraction<>(num1,num2).calculate());
                break;
            case "*":
                System.out.println(new Multiplication<>(num1,num2).calculate());
                break;
            case "/":
                System.out.println(new Division<>(num1,num2).calculate());
                break;
        }
        //Operations<Integer,Float> addition = new Addition<>(10,15.10f)
        //System.out.println(addition.calculate());


    }
}