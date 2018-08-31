package game.monster.com.monstergame.learning.deal.simple;

import android.text.TextUtils;

import java.util.Hashtable;
import java.util.Map;

/**
 * @author yj
 * @remark Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
 * @source https://leetcode.com/problems/roman-to-integer/description/
 * @since 2018/8/31 9:29
 * @intro Roman numerals are usually written largest to smallest from left to right. However
 */
public class RomantoInteger {


    /**
     * intro :
     * <p>
     * Symbol       Value
     * I             1
     * V             5
     * X             10
     * L             50
     * C             100
     * D             500
     * M             1000
     */


    public int romanToInt(String s) {

        int sum = 0;

        if (TextUtils.isEmpty(s)) {
            return sum;
        }

        for (int i = 0; i < s.length(); i++) {

            switch (s.charAt(i)) {
                case 'I':
                    sum = sum + 1;
                    break;
                case 'V':
                    sum = sum + 5;
                    break;
                case 'X':
                    sum = sum + 10;
                    break;
                case 'L':
                    sum = sum + 50;
                    break;
                case 'C':
                    sum = sum + 100;
                    break;
                case 'D':
                    sum = sum + 500;
                    break;
                case 'M':
                    sum = sum + 1000;
                    break;
            }

        }

        return sum;

    }

    public int optmizeRomanToInt(String s) {

        int sum = 0;

        if (TextUtils.isEmpty(s)) {
            return sum;
        }

        Map<Character, Integer> map = new Hashtable<>();
        map.put('I', 1);
        map.put('V', 5);
        map.put('X', 10);
        map.put('L', 50);
        map.put('C', 100);
        map.put('D', 500);
        map.put('M', 1000);

        Integer firstValue = null;

        char[] chars = s.toCharArray();

        for (int i = 0; i < chars.length; i++) {

            char c = chars[i];

            if (map.containsKey(c)) {

                int value = map.get(c);

                if (firstValue != null && value > firstValue && value <= firstValue * 10) {//error >>>> 1.仅限隔两位可触发 × -> √  2.可重复触发 √

                    sum = sum - firstValue - firstValue;

                }

                sum = sum + map.get(c);
                firstValue = value;

            } else {
                firstValue = null;
            }

        }
        return sum;

    }

    public int otherRomanToInt(String s) {
        int sum = 0;
        if (s.indexOf("IV") != -1) {
            sum -= 2;
        }
        if (s.indexOf("IX") != -1) {
            sum -= 2;
        }
        if (s.indexOf("XL") != -1) {
            sum -= 20;
        }
        if (s.indexOf("XC") != -1) {
            sum -= 20;
        }
        if (s.indexOf("CD") != -1) {
            sum -= 200;
        }
        if (s.indexOf("CM") != -1) {
            sum -= 200;
        }

        char c[] = s.toCharArray();
        int count = 0;

        for (; count <= s.length() - 1; count++) {
            if (c[count] == 'M') sum += 1000;
            if (c[count] == 'D') sum += 500;
            if (c[count] == 'C') sum += 100;
            if (c[count] == 'L') sum += 50;
            if (c[count] == 'X') sum += 10;
            if (c[count] == 'V') sum += 5;
            if (c[count] == 'I') sum += 1;

        }

        return sum;
    }

}
