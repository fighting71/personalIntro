package game.monster.com.monstergame.learning.domain;

import game.monster.com.monstergame.cusInterface.IExpressionFunction;
import game.monster.com.monstergame.cusInterface.IExpressionFunction2;

/**
 * @author yj
 * @remark 简单的计算
 * @source
 * @since 2018/8/30 9:46
 */
public class ArithmeticOne {

    /**
     * 求和
     *
     * @param expression f(n)
     * @param minIndex   f(n_0)
     * @param maxIndex   f(n_max)
     * @return
     */
    @Deprecated
    public double getSum(IExpressionFunction<Integer, Double> expression, int minIndex, int maxIndex) {

        double sum = 0;

        for (int i = minIndex; i < maxIndex; i++) {

            sum = sum + expression.run(i);

        }

        return sum;
    }

    /**
     * 求和
     *
     * @param expression f(n)
     * @param minIndex   f(n_0)
     * @param maxIndex   f(n_max)
     * @return
     */
    @Deprecated
    public double getMultiply(IExpressionFunction<Integer, Double> expression, int minIndex, int maxIndex) {

        double sum = 1;

        for (int i = minIndex; i < maxIndex; i++) {

            sum = sum * expression.run(i);

        }

        return sum;

    }

    /**
     * 获取结果
     *
     * @param expression          f(n)
     * @param minIndex            f(n_0)
     * @param maxIndex            f(n_max)
     * @param getResultExpression sum(f(n))
     * @return
     */
    public double getResult(IExpressionFunction<Integer, Double> expression, int minIndex, int maxIndex, IExpressionFunction2<Double, Double, Double> getResultExpression) {

        double sum = expression.run(minIndex);//避免0影响计算

        for (int i = minIndex + 1; i < maxIndex; i++) {

            sum = getResultExpression.run(sum, expression.run(i));

        }

        return sum;

    }

    /**
     * 计算乘积
     *
     * @param num
     * @return
     */
    public double getProduct(int num) {

        return getResult(u -> (double) (num - u), 0, num, (aDouble, aDouble2) -> aDouble * aDouble2);

    }

}
