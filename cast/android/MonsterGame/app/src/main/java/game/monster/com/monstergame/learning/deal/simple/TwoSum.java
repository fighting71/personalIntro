package game.monster.com.monstergame.learning.deal.simple;


import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

/**
 * @author yj
 * @remark 简单的算法解决
 * @source https://leetcode.com/problems/two-sum/description/
 * @question Given an array of integers, return indices of the two numbers such that they add up to a specific target.
 * <p>
 * You may assume that each input would have exactly one solution, and you may not use the same element twice.
 * @since 2018/8/30 14:37
 */
public class TwoSum {

    /**
     * Example :
     * Given nums = [2, 7, 11, 15], target = 9,
     * Because nums[0] + nums[1] = 2 + 7 = 9,
     * return [0, 1].
     */

    /**
     * @param nums
     * @param target
     * @return
     * @intro 普通破解 low.....
     */
    public int[] twoSum(int[] nums, int target) {

        int[] result = new int[2];

        for (int i = 0; i < nums.length; i++) {

            if (nums[i] >= target) {
                continue;
            }

            for (int j = 0; j < nums.length && i != j; j++) {

                if (nums[j] >= target) {
                    continue;
                }

                if (nums[i] + nums[j] == target) {
                    result[0] = i;
                    result[1] = j;
                    return result;
                }

            }

        }

        return null;

    }

    /**
     * 他人的处理方式 [ =- 一看就明白了差距
     * @param nums
     * @param target
     * @return
     * @source https://leetcode.com/problems/two-sum/discuss/164852/C-code-using-extra-space-to-get-optimal-time-complexity-O(N)
     */
    public int[] otherTwoSum(int[] nums, int target) {

        Map<Integer, Integer> visited = new HashMap<>();

        for (int i = 0; i < nums.length; i++) {
            int current = nums[i];
            int search = target - current;

            if (visited.containsKey(search)) {
                return new int[]{visited.get(search), i};
            } else {
                if (!visited.containsKey(current)) {
                    visited.put(current, i);
                }
            }
        }

        return new int[0];
    }

}
