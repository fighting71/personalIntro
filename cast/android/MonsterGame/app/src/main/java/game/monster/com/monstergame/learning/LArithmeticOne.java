package game.monster.com.monstergame.learning;

import android.util.Log;

import java.util.Arrays;

import game.monster.com.monstergame.learning.domain.ArithmeticOne;

/**
 * @author yj
 * @remark
 * @since 2018/8/30
 */

public class LArithmeticOne {

    private static final String tag = "net.learning.arithmetic.one";
    private static final String line = "》》》---------------------------------cool line----------------------------------《《《";

    public void test() {

        ArithmeticOne arithmeticOne = new ArithmeticOne();

        int[] arr = new int[100];

        for (int i = 0; i < arr.length; i++) {
            arr[i] = i + 1;
        }

        double sum = arithmeticOne.getSum(u -> {
            return (double) arr[u];
        }, 0, arr.length);

        Log.i(tag, "{f(0),f(1)...f(n)}求和的结果为：" + sum);

        double product = arithmeticOne.getMultiply(u -> {
            return (double) arr[u];
        }, 0, arr.length);

        Log.i(tag, "{f(0),f(1)...f(n)}求积的结果为：" + product);

        Log.i(tag, line);

        double expSum = arithmeticOne.getResult(u -> (double) arr[u], 0, arr.length, (num1, num2) -> {
            return num1 + num2;
        });

        Log.i(tag, "{f(0),f(1)...f(n)}求和的结果为：" + expSum);

        double expProduct = arithmeticOne.getResult(u -> (double) arr[u], 0, arr.length, (num1, num2) -> {
            return num1 * num2;
        });

        Log.i(tag, "{f(0),f(1)...f(n)}求积的结果为：" + expProduct);

        Log.i(tag, line);

        int realSum = Arrays.stream(arr).sum();
        Log.i(tag, "{f(0),f(1)...f(n)}求和的结果为：" + realSum);


        double realProduct = arr[0];
        for (int i = 1; i < arr.length; i++) {

            realProduct = realProduct * arr[i];

        }

        Log.i(tag, "{f(0),f(1)...f(n)}求积的结果为：" + realProduct);

        Log.i(tag, line);

        Log.i(tag, "{f(0),f(1)...f(n)}求乘积的结果为：" + arithmeticOne.getProduct(100));
        //计算成功 success

    }

}
