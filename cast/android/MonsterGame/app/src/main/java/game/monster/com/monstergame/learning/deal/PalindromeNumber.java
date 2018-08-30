package game.monster.com.monstergame.learning.deal;


import java.util.ArrayList;
import java.util.List;

/**
 * @author yj
 * @remark 是否为回文数
 * @source https://leetcode.com/problems/palindrome-number/description/
 * @question Determine whether an integer is a palindrome. An integer is a palindrome when it reads the same backward as forward.
 * @since 2018/8/30 16:52
 */

public class PalindromeNumber {

    public boolean isPalindrome(int x) {

        List<Integer> list = new ArrayList<>();

        for (int i = 1; i < x; i = i * 10) {

            int num = (x / i) % 10;// 13456465   5 6 4 6 5 4 3 1

            // x /  (x - 10)

            list.add(num);

        }

        for (int i = 0; i < list.size() / 2; i++) {

            if (!list.get(i).equals(list.get(list.size() - i))) {
                return false;
            }

        }

        return true;

    }

}
