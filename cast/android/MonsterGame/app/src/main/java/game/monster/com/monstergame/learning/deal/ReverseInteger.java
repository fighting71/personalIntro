package game.monster.com.monstergame.learning.deal;

/**
 * @author yj
 * @remark 数字倒置 + 溢出检查
 * @source https://leetcode.com/problems/reverse-integer/description/
 * @question Given a 32-bit signed integer, reverse digits of an integer.
 * @since 2018/8/30 15:10
 */
public class ReverseInteger {

/**
 * Example :
 * Input: 123
 * Output: 321
 */

    // 1. 溢出 C#中有语法糖 check 进行检查，此处我便不进行更改

    /**
     * @param inputNum
     * @return
     * @remark 暴力破解 直接转string 再反转
     */
    public int reverse(int inputNum) {

//       int num = 12345;

        // 1 = num /10000
        // 2 = num /1000 % 10

        //幂 Math.abs(num1,num2);

        int chat = inputNum > 0 ? 1 : -1;
        inputNum = chat * inputNum;

        //开根 Math.sqrt(num1,num2);
        String num = inputNum + "";

        String newNum = "";

        for (int i = num.length(); i > 0; i--) {

            newNum = newNum + num.substring(i - 1, i);

        }

        return new Integer(newNum) * chat;

    }

    /**
     * @param inputNum
     * @return
     * @remark 优化算法 时间复杂度 logn
     */
    public int newReverse(int inputNum) {

        String newNum = "";

        int chat = inputNum > 0 ? 1 : -1;
        inputNum = chat * inputNum;

        for (int i = 1; i < inputNum; i = i * 10) {
            newNum = newNum + (inputNum / i) % 10;
        }

        Integer reverse = new Integer(newNum);

        if (reverse > Integer.MAX_VALUE) {
            try {
                throw new Exception("sorry,input number too big");
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

        return reverse * chat;

    }

    /**
     * 答案
     *
     * @param x
     * @return
     */
    public int otherReverse(int x) {
        int rev = 0;
        while (x != 0) {
            int pop = x % 10;
            x /= 10;
            if (rev > Integer.MAX_VALUE / 10 || (rev == Integer.MAX_VALUE / 10 && pop > 7))
                return 0;
            if (rev < Integer.MIN_VALUE / 10 || (rev == Integer.MIN_VALUE / 10 && pop < -8))
                return 0;
            rev = rev * 10 + pop;
        }
        return rev;
    }
}
